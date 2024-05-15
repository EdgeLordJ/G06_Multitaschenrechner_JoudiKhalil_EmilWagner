using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Multitaschenrechner
{
    public partial class UserControl2 : UserControl
    {
        private CoordinateSystem _coordinateSystem = new CoordinateSystem(20, 5);
        private GraphList _graphList = new GraphList();

        private Func<double, double> test1 = x=> 2*x;
        private Func<double, double> test2 = x=> Math.Pow(x, 2);

        private Graph graph1;
        private Graph graph2;

        public UserControl2()
        {
            InitializeComponent();

            graph1 = new Graph(test1);
            graph2 = new Graph(test2);

        }

        private void KoordinatenCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this._coordinateSystem.DrawCoordinateSystem(CanvasCoordinateSystem);

            

        }

        private void ZoomIn_Click(object sender, RoutedEventArgs e)
        {
            this._coordinateSystem.ZoomIn(CanvasCoordinateSystem);

            
        }

        private void ZoomOut_Click(object sender, RoutedEventArgs e)
        {
            this._coordinateSystem.ZoomOut(CanvasCoordinateSystem);

            
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            this._graphList.Add(graph1);
            this._graphList.Add(graph2);

            this._graphList.DrawGraphene(CanvasCoordinateSystem);

        }
    }
}
