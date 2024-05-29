using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public async Task<decimal> ConvertCurrency(string baseCurrency, string targetCurrency, decimal amount)
        {
            string apiUrl = $"https://api.frankfurter.app/latest?from={baseCurrency};to={targetCurrency}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);
            decimal exchangeRate = (decimal)json["rates"][targetCurrency];

            return Math.Round(amount * exchangeRate, 2);
        }

        public async void AddString(string entry, Label lblOutput, Label lblOutputTrgt, ComboBox CBBaseCurrency, ComboBox CBTrgtCurrency)
        {
            if (lastTwo < 2)
            {
                if (dot == true)
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
                else if (lblOutput.Content.ToString() == "0")
                {
                    lblOutput.Content = entry;
                }
                else
                {
                    lblOutput.Content += entry;
                }
            }
            string[] Baseparts = CBBaseCurrency.SelectedItem.ToString().Split(" - ");
            string[] Trgtparts = CBTrgtCurrency.SelectedItem.ToString().Split(" - ");
            lblOutputTrgt.Content = await ConvertCurrency(Baseparts[1], Trgtparts[1], Convert.ToDecimal(lblOutput.Content));
        }

        public void RemoveString(Label lblOutput)
        {
            if (lblOutput.Content.ToString().Length > 0)
            {
                if (lblOutput.Content.ToString() == "")
                {
                    lblOutput.Content = "0";
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
                }
                lblOutput.Content = lblOutput.Content.ToString().Remove(lblOutput.Content.ToString().Length - 1);
            }
        }

        public void Clear(Label lblOutput)
        {
            lblOutput.Content = "0";
            dot = false;
            lastTwo = 0;
        }
    }
}
