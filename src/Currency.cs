using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class Currency
    {
        public string Shortcut { get; set; }
        public string Name { get; set; }
        private bool dot = false;
        private int lastTwo = 0;
        private static readonly HttpClient client = new HttpClient();

        public Currency()
        {
            Shortcut = "";
            Name = "";
        }

        public Currency(string shortcut, string name)
        {
            Shortcut = shortcut;
            Name = name;
        }

        public async Task<double> ConvertCurrency(string baseCurrency, string targetCurrency, double amount)
        {
            Logging.logger.Information($"Währung {baseCurrency} wird in {targetCurrency} umgerechnet");
            string apiUrl = $"https://api.frankfurter.app/latest?from={baseCurrency};to={targetCurrency}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);
            double exchangeRate = (double)json["rates"][targetCurrency];

            return Math.Round(amount * exchangeRate, 2);
        }

        public async void AddString(string entry, Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseCurrency, ComboBox CBTrgtCurrency)
        {
            Logging.logger.Information("Eintrag wird hinzugefügt; Währungsrechner");
            if (CBBaseCurrency.SelectedItem != null && CBTrgtCurrency.SelectedItem != null)
            {
                if (lastTwo < 2)
                {
                    if (dot == true && entry != ".")
                    {
                        lastTwo += 1;
                    }
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
                    else
                    {
                        lblOutput.Content += entry;
                    }
                }
                if (CBBaseCurrency.SelectedItem != null && CBTrgtCurrency.SelectedItem != null)
                {
                    string[] Baseparts = CBBaseCurrency.SelectedItem.ToString().Split(" - ");
                    string[] Trgtparts = CBTrgtCurrency.SelectedItem.ToString().Split(" - ");
                    if (Baseparts[1] != Trgtparts[1])
                    {
                        // CultureInfo.InvariantCulture sagt dem code es soll den Punkt als Dezimaltrennzeichen verwenden vorher hat es das Punkt ignoriert
                        lblOutputTrgt.Content = await ConvertCurrency(Baseparts[1], Trgtparts[1], Convert.ToDouble(lblOutput.Content, CultureInfo.InvariantCulture));
                        Logging.logger.Information("Punkt wird als Dezimaltrennzeichen verwendet für die Umrechnung");
                        Logging.logger.Information("Währung umgerechnet von " + Baseparts[1] + " zu " + Trgtparts[1]);
                    }
                    else
                    {
                        lblOutputTrgt.Content = lblOutput.Content;
                        Logging.logger.Information("Währung ist gleich");
                    }
                }
            }
        }

        public async void RemoveString(Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseCurrency, ComboBox CBTrgtCurrency)
        {
            Logging.logger.Information("Letzter Eintrag wird gelöscht; Währungsrechner");
            if (lblOutput.Content.ToString().Length > 0)
            {
                if (lblOutput.Content.ToString() == "")
                {
                    lblOutput.Content = "0";
                    lblOutputTrgt.Content = "0";
                }
                if (lblOutput.Content.ToString() != "")
                {
                    if (dot == true)
                    {
                        if (lastTwo > 0)
                        {
                            lastTwo -= 1;
                        }
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
                    else
                    {
                        if (CBBaseCurrency.SelectedItem != null && CBTrgtCurrency.SelectedItem != null)
                        {
                            string[] Baseparts = CBBaseCurrency.SelectedItem.ToString().Split(" - ");
                            string[] Trgtparts = CBTrgtCurrency.SelectedItem.ToString().Split(" - ");
                            if (Baseparts[1] != Trgtparts[1])
                            {
                                // CultureInfo.InvariantCulture sagt dem code es soll den Punkt als Dezimaltrennzeichen verwenden vorher hat es das Punkt ignoriert
                                lblOutputTrgt.Content = await ConvertCurrency(Baseparts[1], Trgtparts[1], Convert.ToDouble(lblOutput.Content, CultureInfo.InvariantCulture));
                                Logging.logger.Information("Punkt wird als Dezimaltrennzeichen verwendet für die Umrechnung");
                                Logging.logger.Information("Währung umgerechnet von " + Baseparts[1] + " zu " + Trgtparts[1]);
                            }
                            else
                            {
                                lblOutputTrgt.Content = lblOutput.Content;
                                Logging.logger.Information("Währung ist gleich");
                            }
                        }
                    }
                }
            }
        }

        public void Clear(Label lblInput, Label lblOutput)
        {
            Logging.logger.Information("Eingabe und Ausgabe wird gelöscht; Währungsrechner");
            lblInput.Content = "0";
            lblOutput.Content = "0";
            dot = false;
            lastTwo = 0;
        }
    }
}
