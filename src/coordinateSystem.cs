using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;
using System.Linq;

namespace Multitaschenrechner
{
    public class CoordinateSystem
    {
        private int _scale;
        private int _scaleStep;

        public CoordinateSystem(int scale, int scaleStep)
        {
            this._scale = scale;
            this._scaleStep = scaleStep;
        }

        public void DrawCoordinateSystem(Canvas canvas)
        {
            canvas.Children.Clear();

            double coordinateWidth = canvas.ActualWidth;
            double coordinateHeight = canvas.ActualHeight;
            double centerX = coordinateWidth / 2;
            double centerY = coordinateHeight / 2;

            // X-Achse Zeichnen
            Line xAxis = new Line()
            {
                X1 = 0,
                Y1 = centerY,
                X2 = coordinateWidth,
                Y2 = centerY,
                Stroke = Brushes.Black,
                StrokeThickness = 1.5,
            };
            canvas.Children.Add(xAxis);


            // Y-Achse Zeichnen
            Line yAxis = new Line()
            {
                X1 = centerX,
                Y1 = 0,
                X2 = centerX,
                Y2 = coordinateHeight,
                Stroke = Brushes.Black,
                StrokeThickness = 1.5,
            };
            canvas.Children.Add(yAxis);

            // Beschriftung x-Achse
            Label xLabel = new Label
            {
                Content = "X",
                Foreground = Brushes.Black
            };
            Canvas.SetLeft(xLabel, coordinateWidth - 20);
            Canvas.SetTop(xLabel, centerY - 20);
            canvas.Children.Add(xLabel);

            // Beschriftung y-Achse
            Label yLabel = new Label
            {
                Content = "Y",
                Foreground = Brushes.Black
            };
            Canvas.SetLeft(yLabel, centerX - 20);
            Canvas.SetTop(yLabel, 0);
            canvas.Children.Add(yLabel);

            // Gitternetzlinien und Skalierung
            for (int i = (int)centerX, countX = 0; i < coordinateWidth; i += this._scale, countX++)
            {
                Line gridLine = new Line
                {
                    X1 = i,
                    Y1 = 0,
                    X2 = i,
                    Y2 = coordinateHeight,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                canvas.Children.Add(gridLine);

                if (countX % 10 == 0) 
                {
                    Label xGridLabel = new Label
                    {
                        Content = (countX).ToString(), 
                        Foreground = Brushes.Black
                    };
                    Canvas.SetLeft(xGridLabel, i - 15); 
                    Canvas.SetTop(xGridLabel, centerY + 2); 
                    canvas.Children.Add(xGridLabel);
                }
            }

            
            for (int i = (int)centerX, countX = -1; i > 0; i -= this._scale, countX--)
            {
                Line gridLine = new Line
                {
                    X1 = i,
                    Y1 = 0,
                    X2 = i,
                    Y2 = coordinateHeight,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                canvas.Children.Add(gridLine);

                if (countX % 10 == 0) 
                {
                    Label xGridLabel = new Label
                    {
                        Content = "-" + (countX * -1).ToString(), 
                        Foreground = Brushes.Black
                    };
                    Canvas.SetLeft(xGridLabel, i - 35); 
                    Canvas.SetTop(xGridLabel, centerY + 5); 
                    canvas.Children.Add(xGridLabel);
                }
            }

            // Beschriftung der positiven Y-Achse 
            for (int i = (int)centerY, countY = 0; i > 0; i -= this._scale, countY++)
            {
                Line gridLine = new Line
                {
                    X1 = 0,
                    Y1 = i,
                    X2 = coordinateWidth,
                    Y2 = i,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                canvas.Children.Add(gridLine);

                if (countY % 10 == 0) 
                {
                    Label yGridLabel = new Label
                    {
                        Content = (countY).ToString(), 
                        Foreground = Brushes.Black
                    };
                    Canvas.SetLeft(yGridLabel, centerX - 20); 
                    Canvas.SetTop(yGridLabel, i - 17); 
                    canvas.Children.Add(yGridLabel);
                }
            }

            // Beschriftung der negativen Y-Achse 
            for (int i = (int)centerY, countY = -1; i < coordinateHeight; i += this._scale, countY--)
            {
                Line gridLine = new Line
                {
                    X1 = 0,
                    Y1 = i,
                    X2 = coordinateWidth,
                    Y2 = i,
                    Stroke = Brushes.LightGray,
                    StrokeThickness = 0.5
                };
                canvas.Children.Add(gridLine);

                if (countY % 10 == 0) 
                {
                    Label yGridLabel = new Label
                    {
                        Content = (countY).ToString(), 
                        Foreground = Brushes.Black
                    };
                    Canvas.SetLeft(yGridLabel, centerX - 24); 
                    Canvas.SetTop(yGridLabel, i );
                    canvas.Children.Add(yGridLabel);
                }
            }



        }



        public void ZoomIn(Canvas canvas)
        {
            this._scale += this._scaleStep;
            this.DrawCoordinateSystem(canvas);
        }

        public void ZoomOut(Canvas canvas)
        {
            int newScale = this._scale - this._scaleStep;
            if (newScale >= 1) 
            {
                this._scale = newScale;
                this.DrawCoordinateSystem(canvas);
            }
        }

    }
}
