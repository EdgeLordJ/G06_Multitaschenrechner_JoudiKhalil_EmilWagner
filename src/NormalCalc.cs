using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace Multitaschenrechner
{
    public class NormalCalc
    {
        private string lastEntry = "+";
        private bool dot = false;
        private string lastNums = "";

        public string LastEntry { get { return lastEntry; } set { lastEntry = value; } }
        public string Rechnung { get; set; }
        public string Ergebnis { get; set; }

        public NormalCalc()
        {
            Rechnung = "0";
            Ergebnis = "0";
        }

        public NormalCalc(string rechnung, string ergebnis)
        {
            Rechnung = rechnung;
            Ergebnis = ergebnis;
        }

        public void Squared(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && lastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(lastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - lastNums.Length, lastNums.Length);
                lblOutput.Content += $"{nums * nums}";
                lastNums = $"{nums * nums}";
            }
        }

        public void OneDividedBy(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && lastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(lastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - lastNums.Length, lastNums.Length);
                lblOutput.Content += $"{1 / nums}";
                lastNums = $"{1 / nums}";
            }
        }

        public void Negate(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && lastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(lastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - lastNums.Length, lastNums.Length);
                lblOutput.Content += $"{-nums}";
                lastNums = $"{-nums}";
            }
        }

        public void Percent(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && lastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(lastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - lastNums.Length, lastNums.Length);
                lblOutput.Content += $"{nums / 100}";
                lastNums = $"{nums / 100}";
            }
        }

        public void AddString(string entry, Label lblOutput)
        {
            if (entry == ".")
            {
                if (dot == false)
                {
                    dot = true;
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
            else if (lastEntry != "+" && lastEntry != "-" && lastEntry != "*" && lastEntry != "/")
            {
                lastNums += entry;
                if (lblOutput.Content.ToString() == "0")
                {
                    lblOutput.Content = entry;
                    lastEntry = entry;
                }
                else
                {
                    lblOutput.Content += entry;
                    lastEntry = entry;
                }
            }
            else
            {
                lastNums = "";
                dot = false;
                lastEntry = entry;
                if (lastEntry != "+" && lastEntry != "-" && lastEntry != "*" && lastEntry != "/")
                {
                    lastNums += entry;
                    if (lblOutput.Content.ToString() == "0")
                    {
                        lblOutput.Content = entry;
                        lastEntry = entry;
                    }
                    else
                    {
                        lblOutput.Content += entry;
                        lastEntry = entry;
                    }
                }
            }
        }

        public void RemoveString(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0)
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove(lblOutput.Content.ToString().Length - 1);
                if (lblOutput.Content.ToString() == "")
                {
                    lblOutput.Content = "0";
                }
                if (lblOutput.Content.ToString() != "")
                {
                    lastEntry = lblOutput.Content.ToString().Last().ToString();
                    if (dot == true)
                    {
                        for (int i = lblOutput.Content.ToString().Length - 1; i >= 0; i--)
                        {
                            if ((lblOutput.Content.ToString()[i] == '+' || lblOutput.Content.ToString()[i] == '-' || lblOutput.Content.ToString()[i] == '*' || lblOutput.Content.ToString()[i] == '/') && lblOutput.Content.ToString().Last().ToString() == ".")
                            {
                                dot = false;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    lastEntry = "+";
                }
            }
        }

        public void Clear(Label lblOutput)
        {
            lblOutput.Content = "0";
            lastEntry = "+";
            dot = false;
        }

        public string SerializeToCsv()
        {
            return $"{Rechnung};{Ergebnis}";
        }

        public static NormalCalc DeSerializeToCsv(string serialized)
        {
            string[] parts = serialized.Split(';');

            if (parts.Length == 2)
            {
                string rechnung = parts[0];
                string ergebnis = parts[1];

                NormalCalc calc = new NormalCalc(rechnung, ergebnis);

                return calc;
            }
            else
            {
                throw new ArgumentException("Anzahl der deserialisierten Werte stimmt nicht überein.");
            }
        }

        public string Berechnen(string rechnung)
        {
            rechnung = rechnung.Replace(",", ".");
            rechnung = rechnung.Replace("√", "Sqrt");
            NCalc.Expression expr = new NCalc.Expression(rechnung);
            try
            {
                return expr.Evaluate().ToString(); // Fehler bei 2 mal "=" drücken wenn z.B. 3.2 drin steht
            }
            catch (Exception e)
            {
                return "undefined";
            }
        }
    }
}
