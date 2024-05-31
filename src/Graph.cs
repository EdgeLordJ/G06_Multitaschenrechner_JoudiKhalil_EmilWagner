using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using NCalc.Domain;
using NCalc;

namespace Multitaschenrechner
{
    public class Graph
    {

        private int _scale = 20;

        private Func<double, double> _function;

        private Brush _color = new SolidColorBrush(Colors.White);
        

        
        public Brush Color { get; set; }

        public Func<double, double> Function
        { get
            {
                return this._function;
            }
            set
            {
                this._function = value;
            }
        }

        public Graph(string function) 
        { 
            
            this._function = this.ConvertStringToFunc(function);
            
        }
        public void Edit(string function)
        {
            this._function = this.ConvertStringToFunc(function);
        }
        public Func<double, double> ConvertStringToFunc(string functionExpression)
        {
            string string1 = "";
            string string2 = "";
            string number1 = "";
            string number2 = "";

            for (int i = 0; i < functionExpression.Length; i++)
            {
                string1 = "";
                string2 = "";
                number1 = "";
                number2 = "";

                if (functionExpression[i] == '^')
                {
                    string1 = functionExpression.Split('^')[0];
                    string2 = functionExpression.Split('^')[1];

                    int lastSpaceIndex = string1.LastIndexOf(' ');

                    if (lastSpaceIndex != -1)
                    {
                        number1 = string1.Substring(lastSpaceIndex + 1);
                    }
                    else
                    {
                        number1 = string1;
                    }

                    number2 = string2.Split(' ')[0];

                    string replacement = $"Math.Pow({number1},{number2})";
                    functionExpression = functionExpression.Replace($"{number1}^{number2}", replacement).Trim(' ');
                }
            }

            Func<double, double> function = x =>
            {
                var expression = new NCalc.Expression(functionExpression);
                expression.Parameters["x"] = x;
                return Convert.ToDouble(expression.Evaluate());
            };

            return function;
        }


        public void DrawGraph(Canvas canvas)
        {

            double coordinateWidth = canvas.ActualWidth;
            double coordinateHeight = canvas.ActualHeight;
            double centerX = coordinateWidth / 2;
            double centerY = coordinateHeight / 2;

            Polyline graph = new Polyline();
            graph.Stroke = Color;
            graph.StrokeThickness = 2;

            for (double x = -centerX; x <= centerX; x++)
            {
                double y = centerY - this._function(x / _scale) * _scale;
                if (!double.IsNaN(y))
                {
                    graph.Points.Add(new Point(centerX + x, y));
                }
            }

            canvas.Children.Add(graph);
        }

        

    }
}
