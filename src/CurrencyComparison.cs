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
        private Dictionary<string, double> CurrencyRates = new Dictionary<string, double>();

        public CurrencyComparison()
        {

        }

        public async Task<Dictionary<string, double>> GetData(string currency)
        {
            CurrencyRates.Clear();

            string apiUrl = $"https://api.frankfurter.app/latest?from={currency}";
            HttpResponseMessage response = await client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            JObject json = JObject.Parse(responseBody);
            var rates = json["rates"] as JObject;

            foreach (var item in rates)
            {
                CurrencyRates.Add(item.Key, (double)item.Value);
            }

            return CurrencyRates;
        }

        public async void DrawRects(Canvas canvas, string currency)
        {
            canvas.Children.Clear();
            int distance = 7;
            CurrencyRates = await GetData(currency);

            double maxRate = CurrencyRates.Values.Max();

            foreach (var item in CurrencyRates)
            {
                Label label = new Label()
                {
                    Content = item.Key,
                    Background = Brushes.White,
                    Height = 30,
                    Width = 35
                };

                Rectangle rect = new Rectangle()
                {
                    Width = 10,
                    Height = 200, //((canvas.ActualHeight-label.Height) / maxRate) * item.Value,
                    Fill = Brushes.Blue,
                };

                Canvas.SetTop(label, canvas.ActualHeight-35);
                Canvas.SetLeft(label, distance);

                Canvas.SetTop(rect, canvas.ActualHeight-(rect.Height+50)); // canvas.ActualHeight-rect.Height
                Canvas.SetLeft(rect, distance + (label.Width / 4)+2);
                
                canvas.Children.Add(label);
                canvas.Children.Add(rect);
                distance += 50;
            }
        }
    }
}
