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
    /// Interaktionslogik für UserControlTemperatureConverter.xaml
    /// </summary>
    public partial class UserControlTemperatureConverter : UserControl
    {
        private NormalCalc calc = new NormalCalc();
        private TemperatureConverter temperatureConverter = new TemperatureConverter();

        public UserControlTemperatureConverter()
        {
            InitializeComponent();
        }

        private void ComboBoxTrgtTemperature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = ComboBoxTrgtTemperature.SelectedItem.ToString().Split(" - ");
            lblTrgtTemperature.Content = parts[1];
            temperatureConverter.AddString("", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
            Logging.logger.Information("Zieltemperatur wurde geändert");
        }

        private void ComboBoxSrcTemperature_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = ComboBoxSrcTemperature.SelectedItem.ToString().Split(" - ");
            lblSrcTemperature.Content = parts[1];
            temperatureConverter.AddString("", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
            Logging.logger.Information("Basistemperatur wurde geändert");
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("7", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("8", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("9", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("4", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("5", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("6", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("1", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("2", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("3", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString("0", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.AddString(".", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.RemoveString(lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            temperatureConverter.Clear(lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
        }

        private void BtnNegativ_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxSrcTemperature.SelectedItem != null && ComboBoxTrgtTemperature.SelectedItem != null)
            {
                calc.LastNums = lblSrcNum.Content.ToString();
                calc.Negate(lblSrcNum);
                temperatureConverter.AddString("", lblSrcNum, lblTrgtNum, ComboBoxSrcTemperature, ComboBoxTrgtTemperature);
            }
            Logging.logger.Information("Eingabe wurde negiert");
        }
    }
}
