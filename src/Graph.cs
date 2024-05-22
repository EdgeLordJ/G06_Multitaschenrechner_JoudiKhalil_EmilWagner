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

namespace Multitaschenrechner
{
    public class Graph
    {

        private int _scale = 20;

        private Func<double, double> _function;

        private Brush _color = new SolidColorBrush(Colors.White);
        private string _content = "";

        public string Content
        {
            get
            {
                return _content;
            }
            set
            {

            }
        }
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

        public Graph(Func<double, double> function) 
        { 
            this._function = function;
            
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

        public void DrawButtonLabel(Grid grid, int i)
        {
            Button b = new Button()
            {
                Content = Convert.ToString(i+1),
                Background = Color,
                
                
            };
            Grid.SetRow(b, i);

            Rectangle r = new Rectangle()
            {
                Fill = Brushes.Gray,
                
            };
            Grid.SetColumn(r, 1);
            Grid.SetRow(r, i);

            Label l = new Label()
            {
               Name = $"LabelGraph{i}",
               Content = Content,
            };
            Grid.SetColumn(l, 1);
            Grid.SetRow(l, i);

            grid.Children.Add(b);
            grid.Children.Add(r);
            grid.Children.Add(l);

            
        }

    }
}
