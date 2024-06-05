using System;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using NCalc;

namespace Multitaschenrechner
{
    public class Graph
    {
        private int _scale;
        private Func<double, double> _function;
        private Brush _color = new SolidColorBrush(Colors.White);

        public Brush Color { get; set; }

        public Func<double, double> Function
        {
            get { return this._function; }
            set { this._function = value; }
        }

        public Graph(string function)
        {
            this._function = this.ConvertStringToFunc(function);
        }

        public void Edit(string function)
        {
            this._function = this.ConvertStringToFunc(function);
        }

        private Func<double, double> ConvertStringToFunc(string functionExpression)
        {
            try
            {
                functionExpression = ConvertRootExpressions(functionExpression);
                functionExpression = ConvertPowerExpressions(functionExpression);

                Func<double, double> function = x =>
                {
                    var expression = new NCalc.Expression(functionExpression);
                    expression.Parameters["x"] = x; // Definieren der Variablen x
                    expression.Parameters["e"] = Math.E;
                    var result = expression.Evaluate();
                    return Convert.ToDouble(result);
                };

                return function;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting function string to Func<double, double>: " + ex.Message);
            }
        }


        private string ConvertRootExpressions(string functionExpression)
        {
            try
            {
                string pattern = @"(\d*(\.\d+)?)√\(([^)]+)\)";
                Regex regex = new Regex(pattern);

                return regex.Replace(functionExpression, match =>
                {
                    string baseNumber = match.Groups[1].Value;
                    string radicand = match.Groups[3].Value;

                    if (string.IsNullOrEmpty(baseNumber))
                    {
                        baseNumber = "2"; // Default to square root if no base is provided
                    }

                    return $"Pow({radicand}, 1.0/{baseNumber})";
                });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting root expressions: " + ex.Message);
            }
        }

        private string ConvertPowerExpressions(string functionExpression)
        {
            try
            {
                string pattern = @"(\b\w+|\([^\)]+\)|e)\^(\(.+?\)|\b\w+|\d+(\.\d+)?|e)"; //angepasster Regex
                Regex regex = new Regex(pattern);

                return regex.Replace(functionExpression, match =>
                {
                    string baseExpression = match.Groups[1].Value;
                    string exponentExpression = match.Groups[2].Value;

                    // Handle complex expressions by preserving parentheses if necessary
                    return $"Pow({baseExpression}, {exponentExpression})";
                });
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error converting power expressions: " + ex.Message);
            }
        }





        public void DrawGraph(Canvas canvas, int scale)
        {
            try
            {
                double coordinateWidth = canvas.ActualWidth;
                double coordinateHeight = canvas.ActualHeight;
                double centerX = coordinateWidth / 2;
                double centerY = coordinateHeight / 2;

                Polyline graph = new Polyline
                {
                    Stroke = Color,
                    StrokeThickness = 2
                };

                for (double x = -centerX; x <= centerX; x += 0.1) // Adjust the step for smoother graph
                {
                    double y;
                    try
                    {
                        y = this._function(x / scale);
                    }
                    catch
                    {
                        continue; // Skip if function evaluation throws an error
                    }

                    double canvasY = centerY - y * scale;
                    if (canvasY >= 0 && canvasY <= coordinateHeight)
                    {
                        graph.Points.Add(new System.Windows.Point(centerX + x, canvasY));
                    }
                }

                canvas.Children.Add(graph);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error drawing graph: " + ex.Message);
            }
        }
    }
}
