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

        public string LastBracket { get; set; } = " ";

        public bool Dot { get; set; } = false;

        public NormalCalc()
        {
            
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
            else if (entry == "()")
            {
                if (LastBracket == " ")
                {
                    lblOutput.Content += "(";
                    LastBracket = "(";
                }
                else if (LastBracket == "(")
                {
                    lblOutput.Content += ")";
                    LastBracket = " ";
                }
            }
            else if (LastEntry != "+" && LastEntry != "-" && LastEntry != "*" && LastEntry != "/")
            {
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
                Dot = false;
                LastEntry = entry;
                if (LastEntry != "+" && LastEntry != "-" && LastEntry != "*" && LastEntry != "/")
                {
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
                    if (lblOutput.Content.ToString().IndexOf("(") == -1)
                    {
                        LastBracket = "("; // Crazy Feature (Klammern in Klammern jetzt möglich)
                    }
                }
                else
                {
                    LastEntry = "0";
                }
            }
        }

        public void Clear(Label lblOutput)
        {
            lblOutput.Content = "0";
            LastEntry = "0";
            LastBracket = " ";
            Dot = false;
        }

        public double Berechnen(string rechnung)
        {
            rechnung = rechnung.Replace("^", "");
            NCalc.Expression expr = new NCalc.Expression(rechnung);
            return (Convert.ToDouble(expr.Evaluate())); // Fehler bei 2 mal "=" drücken wenn z.B. 3.2 drin steht
        }
    }
}
