using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitaschenrechner
{
    public class TemperatureConverter
    {
        private Dictionary<string, double> ToFromC = new Dictionary<string, double>()
        {
            { "Celsius", 1 },
            { "FToC", 1.8 + 32 },
            { "K", 273.15 },
            { "CToF", 32 }
        };
    }
}
