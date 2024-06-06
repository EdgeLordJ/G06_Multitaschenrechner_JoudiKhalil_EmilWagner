using System;
using System.Collections.Generic;

namespace Multitaschenrechner
{
    public class LengthDic
    {
        private static readonly Dictionary<string, double> _lengthDic = new Dictionary<string, double>
        {
            {"Nanometer", 1e-9 },
            {"Mikrometer", 1e-6 },
            {"Millimeter", 1e-3 },
            {"Zentimeter", 1e-2 },
            {"Meter", 1 },
            {"Kilometer", 1e3 },
            {"Zoll", 0.0254 },
            {"Fuß", 0.3048 },
            {"Yard", 0.9144 },
            {"Meilen", 1609.344 },
            {"Seemeilen", 1852 }
        };

        public static double Convert(double value, string fromUnit, string toUnit)
        {
            if (_lengthDic.ContainsKey(fromUnit) && _lengthDic.ContainsKey(toUnit))
            {
                double fromFactor = _lengthDic[fromUnit];
                double toFactor = _lengthDic[toUnit];
                return value * fromFactor / toFactor;
            }
            throw new ArgumentException("Invalid units.");
        }
    }
}
