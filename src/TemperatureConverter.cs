using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class TemperatureConverter
    {
        private bool dot = false;
        private Dictionary<string, Func<double, double>> toC = new Dictionary<string, Func<double, double>>()
        {
            { "°C", temp => temp },
            { "°F", temp => (temp - 32) * 5 / 9 },
            { "K", temp => temp - 273.15 },
        };

        private Dictionary<string, Func<double, double>> fromC = new Dictionary<string, Func<double, double>>()
        {
            { "°C", temp => temp },
            { "°F", temp => temp * 9 / 5 + 32 },
            { "K", temp => temp + 273.15 },
        };

        public void ConvertTemperature(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseTemperature, ComboBox CBTrgtTemperature)
        {
            string[] Baseparts = CBBaseTemperature.SelectedItem.ToString().Split(" - ");
            string[] Trgtparts = CBTrgtTemperature.SelectedItem.ToString().Split(" - ");
            if (Baseparts[1] != Trgtparts[1])
            {
                lblOutput.Content = lblOutput.Content.ToString().Replace("−", "-");
                if (double.TryParse(lblOutput.Content.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                {
                    double tempC = toC[Baseparts[1]](num);
                    lblOutputTrgt.Content = fromC[Trgtparts[1]](tempC);
                    Logging.logger.Information("Punkt wird als Dezimaltrennzeichen verwendet für die Umrechnung; Temperaturrechner");
                    Logging.logger.Information("Temperatur umgerechnet von " + Baseparts[1] + " zu " + Trgtparts[1]);
                }
            }
            else
            {
                lblOutputTrgt.Content = lblOutput.Content;
                Logging.logger.Information("Temperatur ist gleich");
            }
        }

        public void AddString(string entry, Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseTemperature, ComboBox CBTrgtTemperature)
        {
            Logging.logger.Information("Eintrag wird hinzugefügt; Temperaturrechner");
            if (CBBaseTemperature.SelectedItem != null && CBTrgtTemperature.SelectedItem != null)
            {
                if (entry == ".")
                {
                    if (dot == false)
                    {
                        dot = true;
                        lblOutput.Content += ".";
                    }
                }
                else if (lblOutput.Content.ToString() == "0" && entry != "")
                {
                    lblOutput.Content = entry;
                }
                else if ((lblOutput.Content.ToString() == "0" || entry != "") && lblOutput.Content.ToString() == "-0")
                {
                    lblOutput.Content = lblOutput.Content.ToString().Replace("0", entry);
                }
                else
                {
                    lblOutput.Content += entry;
                }
                if (CBBaseTemperature.SelectedItem != null && CBTrgtTemperature.SelectedItem != null)
                {
                    ConvertTemperature(lblOutput, lblOutputTrgt, CBBaseTemperature, CBTrgtTemperature);
                }
            }
        }

        public async void RemoveString(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseTemperature, ComboBox CBTrgtTemperature)
        {
            Logging.logger.Information("Letzter Eintrag wird gelöscht; Temperaturrechner");
            if (lblOutput.Content.ToString().Length > 0)
            {
                if (lblOutput.Content.ToString() == "")
                {
                    lblOutput.Content = "0";
                    lblOutputTrgt.Content = "0";
                }
                if (lblOutput.Content.ToString() != "")
                {
                    if (lblOutput.Content.ToString().Last().ToString() == ".")
                    {
                        dot = false;
                    }
                    lblOutput.Content = lblOutput.Content.ToString().Remove(lblOutput.Content.ToString().Length - 1);
                    if (lblOutput.Content.ToString() == "-")
                    {
                        lblOutputTrgt.Content = 0;
                    }
                    if (lblOutput.Content.ToString() == "")
                    {
                        lblOutput.Content = "0";
                        lblOutputTrgt.Content = "0";
                        ConvertTemperature(lblOutput, lblOutputTrgt, CBBaseTemperature, CBTrgtTemperature);
                    }
                    else
                    {
                        if (CBBaseTemperature.SelectedItem != null && CBTrgtTemperature.SelectedItem != null)
                        {
                            ConvertTemperature(lblOutput, lblOutputTrgt, CBBaseTemperature, CBTrgtTemperature);
                        }
                    }
                }
            }
        }

        public void Clear(Label lblInput, Label lblOutput, ComboBox CBBaseTemperature, ComboBox CBTrgtTemperature)
        {
            Logging.logger.Information("Eingabe und Ausgabe wird gelöscht; Temperaturrechner");
            lblInput.Content = "0";
            lblOutput.Content = "0";
            dot = false;
            ConvertTemperature(lblOutput, lblOutput, CBBaseTemperature, CBTrgtTemperature);
        }
    }
}
