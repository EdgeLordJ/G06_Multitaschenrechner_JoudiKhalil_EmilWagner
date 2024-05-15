using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

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
            for (int i = (int)centerX; i < coordinateWidth; i += this._scale)
            {
                if (this._scale <= 10 && (i - centerX) % (this._scale * 5) != 0) // Zeige nur jede 10. Spalte
                    continue;

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
            }

            for (int i = (int)centerX; i > 0; i -= this._scale)
            {
                if (this._scale <= 10 && (centerX - i) % (this._scale * 5) != 0) // Zeige nur jede 10. Spalte
                    continue;

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
            }

            for (int i = (int)centerY; i < coordinateHeight; i += this._scale)
            {
                if (this._scale <= 10 && (i - centerY) % (this._scale * 5) != 0) // Zeige nur jede 10. Reihe
                    continue;

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
            }

            for (int i = (int)centerY; i > 0; i -= this._scale)
            {
                if (this._scale <= 10 && (centerY - i) % (this._scale * 5) != 0) // Zeige nur jede 10. Reihe
                    continue;

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
            if (newScale >= 1) // Sicherstellen, dass der Maßstab nicht kleiner als 1 wird
            {
                this._scale = newScale;
                this.DrawCoordinateSystem(canvas);
            }
        }

    }
}
