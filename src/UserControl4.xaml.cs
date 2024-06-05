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
    /// Interaktionslogik für UserControl4.xaml
    /// </summary>
    public partial class UserControl4 : UserControl
    {
        CurrenciesCollection currencies = new CurrenciesCollection();
        CurrencyComparison comparison = new CurrencyComparison();
        public UserControl4()
        {
            InitializeComponent();

            currencies.GetCurrencies(CBSrcCurrency);
        }

        private void CBSrcCurrency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] parts = CBSrcCurrency.SelectedItem.ToString().Split(" - ");

            comparison.DrawRects(CanvasDraw, parts[1]);
        }
    }
}
