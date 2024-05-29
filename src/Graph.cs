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
        public  Func<double, double> ConvertStringToFunc(string functionExpression)
        {
            string strings = "";
            string number1 = "";
            for (int i = 0; i < functionExpression.Length; i++)
            {
                if (functionExpression[i] == '^')
                {
                    strings = functionExpression.Split("^")[0];
                    for (int j = strings.Length; j < strings.Length; j--)
                    {
                        if (strings[j] == ' ')
                        {
                            number1 = strings.Split(' ')[0];
                        }
                    }
                }
            }
            return x =>
            {
                var expression = new NCalc.Expression(functionExpression);
                expression.Parameters["x"] = x;
                return Convert.ToDouble(expression.Evaluate());
            };
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
