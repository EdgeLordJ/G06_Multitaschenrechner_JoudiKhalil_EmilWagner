using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class NormalCalc
    {
        public string Rechnung { get; set; } // Für Verlauf/Speicher

        public string LastEntry { get; set; } = "+";

        public bool Dot { get; set; } = false;

        public string LastNums { get; set; } = "";

        public NormalCalc()
        {
            
        }

        public void Squared(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{nums * nums}";
                LastNums = "";
            }
        }

        public void OneDividedBy(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{1 / nums}";
                LastNums = "";
            }
        }

        public void Sqrt(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{Math.Sqrt(nums)}";
                LastNums = "";
            }
        }

        public void AddString(string entry, Label lblOutput)
        {
            if (entry == ".")
            {
                if (Dot == false)
                {
                    Dot = true;
                    lblOutput.Content += ".";
                }
            }
            else if (entry == "(" || entry == ")")
            {
                if (entry == "(")
                {
                    lblOutput.Content += "(";
                }
                else if (entry == ")")
                {
                    lblOutput.Content += ")";
                }
            }
            else if (LastEntry != "+" && LastEntry != "-" && LastEntry != "*" && LastEntry != "/")
            {
                LastNums += entry;
                if (lblOutput.Content.ToString() == "0")
                {
                    lblOutput.Content = entry;
                    LastEntry = entry;
                }
                else
                {
                    lblOutput.Content += entry;
                    LastEntry = entry;
                }
            }
            else
            {
                LastNums = "";
                Dot = false;
                LastEntry = entry;
                if (LastEntry != "+" && LastEntry != "-" && LastEntry != "*" && LastEntry != "/")
                {
                    LastNums += entry;
                    if (lblOutput.Content.ToString() == "0")
                    {
                        lblOutput.Content = entry;
                        LastEntry = entry;
                    }
                    else
                    {
                        lblOutput.Content += entry;
                        LastEntry = entry;
                    }
                }
            }
        }

        public void RemoveString(Label lblOutput) // "." richtig anpassen
        {
            if (lblOutput.Content.ToString().Length > 0)
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove(lblOutput.Content.ToString().Length - 1);
                if (lblOutput.Content.ToString() != "")
                {
                    LastEntry = lblOutput.Content.ToString().Last().ToString();
                }
                else
                {
                    LastEntry = "+";
                }
            }
        }

        public void Clear(Label lblOutput)
        {
            lblOutput.Content = "0";
            LastEntry = "+";
            LastBracket = " ";
            Dot = false;
        }

        public double Berechnen(string rechnung)
        {
            rechnung = rechnung.Replace("Pow(x)", "Pow(x, 2)");
            NCalc.Expression expr = new NCalc.Expression(rechnung);
            return (Convert.ToDouble(expr.Evaluate())); // Fehler bei 2 mal "=" drücken wenn z.B. 3.2 drin steht
        }
    }
}
