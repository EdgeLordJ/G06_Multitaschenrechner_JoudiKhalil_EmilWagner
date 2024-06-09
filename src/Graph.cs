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
                    expression.Parameters["x"] = x; 
                    expression.Parameters["e"] = Math.E;
                    var result = expression.Evaluate();
                    return Convert.ToDouble(result);
                };

                Logging.logger.Information("Funktion wurde erfolgreich berechnet/umgewandelt");
                return function;
            }
            catch
            {
                Logging.logger.Error("Eine Funktion konnte nicht umgewandelt werden.");
                throw new InvalidOperationException("Funktion konnte nicht umgewandelt werden" );
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
                        baseNumber = "2"; 
                    }

                    return $"Pow({radicand}, 1.0/{baseNumber})";
                });
            }
            catch (Exception ex)
            {
                Logging.logger.Error("Eine Wurzel konnte nicht aufgelöst werden");
                throw new InvalidOperationException("Wurzel konnte nicht aufgelöst werden" + ex.Message);
            }
        }

        private string ConvertPowerExpressions(string functionExpression)
        {
            try
            {
                string pattern = @"(\b\w+|\([^\)]+\)|e)\^(\(.+?\)|\b\w+|\d+(\.\d+)?|e)"; 
                Regex regex = new Regex(pattern);

                return regex.Replace(functionExpression, match =>
                {
                    string baseExpression = match.Groups[1].Value;
                    string exponentExpression = match.Groups[2].Value;

                    
                    return $"Pow({baseExpression}, {exponentExpression})";
                });
            }
            catch (Exception ex)
            {
                Logging.logger.Error("Eine Hochzahl konnte nicht aufgelöst werden");
                throw new InvalidOperationException("Hochzahl konnte nicht verarbeitet werden " + ex.Message);
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

                for (double x = -centerX; x <= centerX; x += 0.2)
                {
                    double y;
                    try
                    {
                        y = this._function(x / scale);
                    }
                    catch
                    {
                        continue; 
                    }

                    double canvasY = centerY - y * scale;
                    if (canvasY >= 0 && canvasY <= coordinateHeight)
                    {
                        graph.Points.Add(new System.Windows.Point(centerX + x, canvasY));
                    }
                }

                canvas.Children.Add(graph);
                Logging.logger.Information("Graph gezeichnet");
            }
            catch (Exception ex)
            {
                Logging.logger.Error("Graph konnte nicht gezeichnet werden");
                throw new InvalidOperationException("Graph kann nicht gezeichnet werden" + ex.Message);
            }
        }
    }
}
