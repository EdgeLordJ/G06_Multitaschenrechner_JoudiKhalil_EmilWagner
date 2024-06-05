using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Multitaschenrechner
{
    public class CurrencyComparison
    {
        private HttpClient client = new HttpClient();
        private CurrenciesCollection currencies = new CurrenciesCollection();
        private Dictionary<string, double> CurrencyRates;

        public CurrencyComparison()
        {

        }

        public async void GetData(string currency)
        {
            CurrencyRates.Clear();

            string apiUrl = $"https://api.frankfurter.app/latest?from={currency}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);

            foreach (var item in json)
            {
                CurrencyRates.Add(json[item.Key].ToString(), (double)json[item.Value]);
            }
        }

        public void DrawRects(Canvas canvas, string currency)
        {
            int distance = 10;
            GetData(currency);

            double maxRate = CurrencyRates.Values.Max();

            foreach (var item in CurrencyRates)
            {
                Label label = new Label()
                {
                    Content = item.Key
                };

                Rectangle rect = new Rectangle()
                {
                    Width = 10,
                    Height = ((canvas.ActualHeight-label.Height) / maxRate) * item.Value,
                    Fill = Brushes.Blue,
                };

                Canvas.SetTop(label, 10);
                Canvas.SetLeft(label, distance);

                Canvas.SetTop(rect, canvas.ActualHeight-rect.Height);
                Canvas.SetLeft(rect, distance);
                
                canvas.Children.Add(label);
                canvas.Children.Add(rect);
                distance += 50;
            }
        }
    }
}
