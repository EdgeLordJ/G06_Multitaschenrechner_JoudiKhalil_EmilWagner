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
            Logging.logger.Information("Währungsraten von einer Währung werden von API geladen und in eine Dictionary hinzugefügt");
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
            Logging.logger.Information("Balkendiagramm wird erstellt");
            canvas.Children.Clear();
            int distance = 7;
            CurrencyRates = await GetData(currency);

            double maxRate = CurrencyRates.Values.Max();

            // Je größer der Balken, desto mehr Wert hat die ausgewählte Währung
            // Wegen Logarithmus wird das Diagramm besser dargestellt aber die Werte sind nicht genau

            foreach (var item in CurrencyRates)
            {
                Label label = new Label()
                {
                    Content = item.Key,
                    Background = Brushes.Transparent,
                    Foreground = Brushes.White,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
                    VerticalAlignment = System.Windows.VerticalAlignment.Center,
                    Height = 30,
                    Width = 35
                };

                // Für ScrollBar um nach rechts zu scrollen
                double totalWidth = 0;
                foreach (var item2 in CurrencyRates)
                {
                    totalWidth += label.Width + 15;
                }

                canvas.Width = totalWidth;
                double logRate = Math.Log10(item.Value);

                Rectangle rect = new Rectangle()
                {
                    Width = 10,
                    Height = Math.Min(Math.Abs(((canvas.ActualHeight-label.Height) / Math.Log10(maxRate) * logRate)), canvas.ActualHeight - label.Height - 30),
                    Fill = Brushes.LightBlue,
                };

                Canvas.SetTop(label, canvas.ActualHeight-35);
                Canvas.SetLeft(label, distance);

                Canvas.SetTop(rect, canvas.ActualHeight - (rect.Height + 50));
                Canvas.SetLeft(rect, distance + (label.Width / 4) + 2);
                
                canvas.Children.Add(label);
                canvas.Children.Add(rect);
                distance += 50;
            }
        }
    }
}
