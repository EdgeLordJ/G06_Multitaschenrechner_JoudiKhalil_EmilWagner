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
    /// Interaktionslogik für UserControl3.xaml
    /// </summary>
    public partial class UserControl3 : UserControl
    {
        private CurrenciesCollection currencies = new CurrenciesCollection();
        private Currency currency = new Currency();

        public UserControl3()
        {
            InitializeComponent();

            currencies.SetComboBox(ComboBoxSrcCurrency);
            currencies.SetComboBox(ComboBoxTrgtCurrency);
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            currency.Clear(lblSrcNum, lblTrgtNum);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            currency.RemoveString(lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("7", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("8", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("9", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("4", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("5", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("6", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("1", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("2", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("3", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString("0", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            currency.AddString(".", lblSrcNum, lblTrgtNum, ComboBoxSrcCurrency, ComboBoxTrgtCurrency);
        }

        private void ComboBoxSrcCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = ComboBoxSrcCurrency.SelectedItem.ToString().Split(" - ");
            lblSrcCurrency.Content = parts[1];
        }

        private void ComboBoxTrgtCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = ComboBoxTrgtCurrency.SelectedItem.ToString().Split(" - ");
            lblTrgtCurrency.Content = parts[1];
        }
    }
}
