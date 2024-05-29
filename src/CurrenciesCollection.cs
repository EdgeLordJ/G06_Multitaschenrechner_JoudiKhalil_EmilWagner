using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Multitaschenrechner
{
    public class CurrenciesCollection
    {
        private static readonly HttpClient client = new HttpClient();
        public List<Currency> currencies = new List<Currency>();

        public void Add(Currency currency)
        {
            currencies.Add(currency);
        }

        public async void GetCurrencies(ComboBox CB1, ComboBox CB2)
        {
            string apiUrl = $"https://api.frankfurter.app/currencies";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);

            foreach (var currency in json)
            {
                currencies.Add(new Currency(currency.Key, currency.Value.ToString()));
            }

            foreach (Currency currency in currencies)
            {
                CB1.Items.Add($"{currency.Name} - {currency.Shortcut}");
                CB2.Items.Add($"{currency.Name} - {currency.Shortcut}");
            }
        }
    }
}
