using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private NormalCalc calc = new NormalCalc();

        public UserControl1()
        {
            InitializeComponent();

            // Zum Testen
            //NCalc.Expression expr = new NCalc.Expression("Pow(2,2)");
            //Debug.WriteLine(Convert.ToDouble(expr.Evaluate())); // Für alle Funktionalitäten Paket "NCalc" installieren
        }

        private void Btn0_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("0", lblOutput);
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("1", lblOutput);
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("2", lblOutput);
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("3", lblOutput);
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("4", lblOutput);
        }

        private void Btn5_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("5", lblOutput);
        }

        private void Btn6_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("6", lblOutput);
        }

        private void Btn7_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("7", lblOutput);
        }

        private void Btn8_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("8", lblOutput);
        }

        private void Btn9_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("9", lblOutput);
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("+", lblOutput);
        }

        private void BtnMinus_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("-", lblOutput);
        }

        private void BtnMal_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("*", lblOutput);
        }

        private void BtnDivision_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("/", lblOutput);
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            calc.RemoveString(lblOutput);
        }

        private void BtnEquals_Click(object sender, RoutedEventArgs e)
        {
            double result = calc.Berechnen(lblOutput.Content.ToString());
            lblOutput.Content = result;
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            calc.Clear(lblOutput);
        }

        private void BtnPoint_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(".", lblOutput);
        }

        private void BtnPowerTwo_Click(object sender, RoutedEventArgs e)
        {
            calc.Squared(lblOutput);
        }

        private void BtnOverOne_Click(object sender, RoutedEventArgs e)
        {
            calc.OneDividedBy(lblOutput);
        }

        private void BtnSqrt_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("Sqrt(", lblOutput);
        }

        private void BtnBracketOpen_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString("(", lblOutput);
        }

        private void BtnBracketClose_Click(object sender, RoutedEventArgs e)
        {
            calc.AddString(")", lblOutput);
        }

        private void BtnNegativ_Click(object sender, RoutedEventArgs e)
        {
            calc.Negate(lblOutput);
        }

        private void BtnProzent_Click(object sender, RoutedEventArgs e)
        {
            calc.Percent(lblOutput);
        }
    }
}
