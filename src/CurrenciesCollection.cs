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
        private HttpClient client = new HttpClient();
        public List<Currency> currencies = new List<Currency>();

        public CurrenciesCollection()
        {

        }

        public void Add(Currency currency)
        {
            currencies.Add(currency);
        }

        public async void GetCurrencies(ComboBox CB)
        {
            currencies.Clear();
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
                CB.Items.Add($"{currency.Name} - {currency.Shortcut}");
            }
        }
    }
}
