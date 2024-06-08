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
    /// Interaktionslogik für UserControlAngleConverter.xaml
    /// </summary>
    public partial class UserControlAngleConverter : UserControl
    {
        public UserControlAngleConverter()
        {
            InitializeComponent();
        }
        private Angle _angle = new Angle();
        private AngleConverter _angleconverter = new AngleConverter();

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            this._angle.Clear(lblSrcNum, lblTrgtNum);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            this._angle.RemoveString(lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("7", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("8", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("9", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("4", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("5", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("6", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("1", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("2", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("3", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString("0", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            this._angle.AddString(".", lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._angle.UpdateOutput(lblSrcNum, lblTrgtNum, ComboBoxSrcAngle, ComboBoxTrgtAngle);
            Logging.logger.Information("Es wurde eine andere Winkeleinheit ausgewählt");
        }
    }
}
