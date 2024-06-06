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
    /// Interaktionslogik für UserControlLengthCalculator.xaml
    /// </summary>
    public partial class UserControlLengthCalculator : UserControl
    {
        private Length _length = new Length();
        private LengthDic _lengthdic = new LengthDic();

        public UserControlLengthCalculator()
        {
            InitializeComponent();
            ComboBoxSrcLength.SelectionChanged += ComboBox_SelectionChanged;
            ComboBoxTrgtLength.SelectionChanged += ComboBox_SelectionChanged;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            this._length.Clear(lblSrcNum, lblTrgtNum);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            this._length.RemoveString(lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("7", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("8", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("9", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("4", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("5", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("6", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("1", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("2", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("3", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString("0", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            this._length.AddString(".", lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._length.UpdateOutput(lblSrcNum, lblTrgtNum, ComboBoxSrcLength, ComboBoxTrgtLength);
        }
    }
}
