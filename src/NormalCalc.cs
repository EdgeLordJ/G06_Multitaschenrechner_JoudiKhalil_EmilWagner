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
        private string lastNums = "0";

        public string LastEntry { get { return lastEntry; } set { lastEntry = value; } }
        public string Rechnung { get; set; }
        public string Ergebnis { get; set; }
        public string LastNums { get { return lastNums; } set { lastNums = value; } }

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
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{nums * nums}";
                LastNums = $"{nums * nums}";
                Logging.logger.Information("Zahl wurde quadriert:", nums);
            }
        }

        public void OneDividedBy(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{1 / nums}";
                LastNums = $"{1 / nums}";
                Logging.logger.Information("1 wurde durch Zahl geteilt:", nums);
            }
        }

        public void Negate(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{-nums}";
                LastNums = $"{-nums}";
                Logging.logger.Information("Zahl wurde negiert:", nums);
            }
        }

        public void Percent(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0 && LastNums.Length <= lblOutput.Content.ToString().Length && Double.TryParse(LastNums, out double nums))
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove((lblOutput.Content.ToString().Length) - LastNums.Length, LastNums.Length);
                lblOutput.Content += $"{nums / 100}";
                LastNums = $"{nums / 100}";
                Logging.logger.Information("Prozentwert wurde berechnet:", nums);
            }
        }

        public void AddString(string entry, Label lblOutput)
        {
            Logging.logger.Information("Eintrag wird hinzugefügt; Normaler Taschenrechner");
            if (entry == ",")
            {
                if (dot == false)
                {
                    LastNums += entry;
                    dot = true;
                    lblOutput.Content += entry;
                    LastEntry = entry;
                }
            }
            else if (entry == "(" || entry == ")")
            {
                LastEntry = entry;
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
            else if (LastEntry != "+" && LastEntry != "-" && LastEntry != "*" && LastEntry != "÷")
            {
                LastNums += entry;
                if (lblOutput.Content.ToString() == "0")
                {
                    lblOutput.Content = entry;
                    LastEntry = entry;
                    LastNums = entry;
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
                dot = false;
                LastEntry = entry;
                if (LastEntry != "+" && LastEntry != "-" && LastEntry != "*" && LastEntry != "÷")
                {
                    LastNums += entry;
                    if (lblOutput.Content.ToString() == "0")
                    {
                        lblOutput.Content = entry;
                        LastEntry = entry;
                        LastNums = entry;
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
            Logging.logger.Information("Letzter Eintrag wird gelöscht; Normaler Taschenrechner");
            if (lblOutput.Content.ToString().Length > 0)
            {
                lblOutput.Content = lblOutput.Content.ToString().Remove(lblOutput.Content.ToString().Length - 1);
                if (LastNums.Length > 0)
                {
                    LastNums = LastNums.Remove(LastNums.Length - 1);
                }   
                if (lblOutput.Content.ToString() == "")
                {
                    lblOutput.Content = "0";
                }
                if (lblOutput.Content.ToString() != "")
                {
                    LastEntry = lblOutput.Content.ToString().Last().ToString();
                    int dotcount = 0;
                    if (dot == true)
                    {
                        for (int i = lblOutput.Content.ToString().Length - 1; i >= 0; i--)
                        {
                            if (lblOutput.Content.ToString()[i] == '+' || lblOutput.Content.ToString()[i] == '-' || lblOutput.Content.ToString()[i] == '*' || lblOutput.Content.ToString()[i] == '/')
                            {
                                break;
                            }
                            if (lblOutput.Content.ToString()[i] == ',')
                            {
                                dotcount++;
                            }
                        }
                        if (dotcount == 0)
                        {
                            dot = false;
                        }
                    }
                }
                else
                {
                    LastEntry = "+";
                }
            }
        }

        public void UpdateVariables(string result)
        {
            Logging.logger.Information("Variablen werden aktualisiert; Normaler Taschenrechner");
            LastEntry = result.Last().ToString();
            for (int i = result.Length - 1; i >= 0; i--)
            {
                if (result[i] == ',')
                {
                    dot = true;
                }
            }
            LastNums = result;
        }

        public void Clear(Label lblOutput)
        {
            Logging.logger.Information("Rechner wird zurückgesetzt; Normaler Taschenrechner");
            lblOutput.Content = "0";
            LastEntry = "+";
            dot = false;
            LastNums = "0";
        }

        public string SerializeToCsv()
        {
            Logging.logger.Information("Zeile wird serialisiert:", $"{Rechnung};{Ergebnis}");
            return $"{Rechnung};{Ergebnis}";
        }

        public static NormalCalc DeSerializeToCsv(string serialized)
        {
            string[] parts = serialized.Split(';');

            if (parts.Length == 2)
            {
                Logging.logger.Information("Zeile wurde deserialisiert:", serialized);
                string rechnung = parts[0];
                string ergebnis = parts[1];

                NormalCalc calc = new NormalCalc(rechnung, ergebnis);

                return calc;
            }
            else
            {
                Logging.logger.Error("Anzahl der deserialisierten Werte stimmen nicht überein:", serialized);
                throw new ArgumentException("Anzahl der deserialisierten Werte stimmt nicht überein.");
            }
        }

        public string Berechnen(string rechnung)
        {
            Logging.logger.Information("Rechnung wird berechnet:", rechnung);
            rechnung = rechnung.Replace("√", "Sqrt");
            rechnung = rechnung.Replace("÷", "/");
            rechnung = rechnung.Replace(",", ".");
            NCalc.Expression expr = new NCalc.Expression(rechnung);
            try
            {
                return expr.Evaluate().ToString();
            }
            catch (Exception e)
            {
                Logging.logger.Error(e, "Fehler beim Berechnen der Rechnung:", rechnung);
                return "undefined";
            }
        }
    }
}
