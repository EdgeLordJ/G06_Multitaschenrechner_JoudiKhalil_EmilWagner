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
                LastNums = $"{nums * nums}";
            }
        }

        public void OneDividedBy(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{1 / nums}";
                LastNums = $"{1 / nums}";
            }
        }

        public void Negate(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{-nums}";
                LastNums = $"{-nums}";
            }
        }

        public void Percent(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{nums / 100}";
                LastNums = $"{nums / 100}";
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
                if (lblOutput.Content.ToString() == "0")
                {
                    lblOutput.Content = entry;
                }
                else if (entry == "(")
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

        public void RemoveString(Label lblOutput)
        {
            string CurrentEntry = lblOutput.Content.ToString();
            if (CurrentEntry.Length > 0)
            {
                lblOutput.Content = CurrentEntry.Remove(CurrentEntry.Length - 1);
                if (CurrentEntry != "")
                {
                    LastEntry = CurrentEntry.Last().ToString();
                    if (Dot == true)
                    {
                        for (int i = CurrentEntry.Length - 1; i >= 0; i--)
                        {
                            if ((CurrentEntry[i] == '+' || CurrentEntry[i] == '-' || CurrentEntry[i] == '*' || CurrentEntry[i] == '/') && CurrentEntry.Last().ToString() == ".")
                            {
                                Dot = false;
                                break;
                            }
                        }
                    }
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
            Dot = false;
        }

        public double Berechnen(string rechnung)
        {
            NCalc.Expression expr = new NCalc.Expression(rechnung);
            return (Convert.ToDouble(expr.Evaluate())); // Fehler bei 2 mal "=" drücken wenn z.B. 3.2 drin steht
        }
    }
}
