using System;
using System.Linq;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class Length
    {
        public double Converting { get; set; }
        public string LengthName { get; set; }

        private bool dot = false;

        public Length() { }

        public Length(double converting, string lengthName)
        {
            Converting = converting;
            LengthName = lengthName;
        }

        public void AddString(string entry, Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseLength, ComboBox CBTrgtLength)
        {
            if (CBBaseLength.SelectedItem != null && CBTrgtLength.SelectedItem != null)
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

                // Update the output after adding a string
                UpdateOutput(lblOutput, lblOutputTrgt, CBBaseLength, CBTrgtLength);
            }
        }

        public void RemoveString(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseLength, ComboBox CBTrgtLength)
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

                // Update the output after removing a string
                UpdateOutput(lblOutput, lblOutputTrgt, CBBaseLength, CBTrgtLength);
            }
        }

        public void Clear(Label lblInput, Label lblOutput)
        {
            lblInput.Content = "0";
            lblOutput.Content = "0";
            dot = false;
        }

        public void UpdateOutput(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseLength, ComboBox CBTrgtLength)
        {
            if (CBBaseLength.SelectedItem != null && CBTrgtLength.SelectedItem != null)
            {
                string fromUnit = CBBaseLength.SelectedItem.ToString().Split(' ')[1];
                string toUnit = CBTrgtLength.SelectedItem.ToString().Split(' ')[1];

                if (double.TryParse(lblOutput.Content.ToString().Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
                {
                    double result = LengthDic.Convert(value, fromUnit, toUnit);
                    lblOutputTrgt.Content = result.ToString(System.Globalization.CultureInfo.InvariantCulture);
                }
            }
        }
    }


}
