using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class Angle
    {
        public double Converting { get; set; }
        public string AngleName { get; set; }

        private bool dot = false;

        public Angle() { }

        public Angle(double converting, string angleName)
        {
            Converting = converting;
            AngleName = angleName;
        }

        public void AddString(string entry, Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseAngle, ComboBox CBTrgtAngle)
        {
            if (CBBaseAngle.SelectedItem != null && CBTrgtAngle.SelectedItem != null)
            {
                if (entry == ",")
                {
                    entry = ".";
                }
                if (entry == ".")
                {
                    if (!dot)
                    {
                        dot = true;
                        lblOutput.Content += ".";
                    }
                }
                else if (lblOutput.Content.ToString() == "0")
                {
                    lblOutput.Content = entry;
                }
                else
                {
                    lblOutput.Content += entry;
                }


                UpdateOutput(lblOutput, lblOutputTrgt, CBBaseAngle, CBTrgtAngle);
            }
        }

        public void RemoveString(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseAngle, ComboBox CBTrgtAngle)
        {
            if (lblOutput.Content.ToString().Length > 0)
            {
                if (lblOutput.Content.ToString() == "")
                {
                    lblOutput.Content = "0";
                    lblOutputTrgt.Content = "0";
                }
                if (lblOutput.Content.ToString() != "")
                {
                    if (dot)
                    {
                        if (lblOutput.Content.ToString().Last().ToString() == ".")
                        {
                            dot = false;
                        }
                    }
                    lblOutput.Content = lblOutput.Content.ToString().Remove(lblOutput.Content.ToString().Length - 1);
                    if (lblOutput.Content.ToString() == "")
                    {
                        lblOutput.Content = "0";
                        lblOutputTrgt.Content = "0";
                    }
                }


                UpdateOutput(lblOutput, lblOutputTrgt, CBBaseAngle, CBTrgtAngle);
            }
        }

        public void Clear(Label lblInput, Label lblOutput)
        {
            lblInput.Content = "0";
            lblOutput.Content = "0";
            dot = false;
        }

        public void UpdateOutput(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseAngle, ComboBox CBTrgtAngle)
        {
            if (CBBaseAngle.SelectedItem != null && CBTrgtAngle.SelectedItem != null)
            {
                string fromUnit = CBBaseAngle.SelectedItem.ToString().Split(' ')[1];
                string toUnit = CBTrgtAngle.SelectedItem.ToString().Split(' ')[1];

                if (double.TryParse(lblOutput.Content.ToString().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
                {
                    double result = AngleConverter.Convert(value, fromUnit, toUnit);
                    lblOutputTrgt.Content = Math.Round(result, 12).ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
            }
            else
            {
                Logging.logger.Information("Es wurde nichts ausgewählt zum umwandeln");
            }
        }
    }
}
