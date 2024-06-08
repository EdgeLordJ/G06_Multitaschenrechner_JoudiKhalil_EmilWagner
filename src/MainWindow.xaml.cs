using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Multitaschenrechner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CC.Content = new UserControl1();
        }

        private void rbtnCalculator_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl1();
        }

        private void rbtnGraph_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl2();
        }

        private void rbtnCurrency_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl3();
        }

        private void rbtnCurrencyComparison_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControl4();
        }

        private void rbtnLength_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControlLengthCalculator();
        }

        private void rbtnSettings_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControlSettings();
        }

        private void rbtnTemperature_Checked(object sender, RoutedEventArgs e)
        {
            CC.Content = new UserControlTemperatureConverter();
        }
    }
}
