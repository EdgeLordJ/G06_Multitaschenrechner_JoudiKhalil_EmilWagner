using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Multitaschenrechner
{
    public partial class UserControl2 : UserControl
    {
        private CoordinateSystem _coordinateSystem = new CoordinateSystem(20, 5);

        public UserControl2()
        {
            InitializeComponent();
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

       
    }
}
