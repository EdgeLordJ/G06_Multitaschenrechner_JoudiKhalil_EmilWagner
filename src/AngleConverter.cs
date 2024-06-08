using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multitaschenrechner
{
    public class AngleConverter
    {
        public static double Convert(double value, string fromUnit, string toUnit)
        {
            if (fromUnit == "Winkelgrad" && toUnit == "Bogenmaß")
                return value * Math.PI / 180;
            if (fromUnit == "Winkelgrad" && toUnit == "Gon")
                return value * 10 / 9;
            if (fromUnit == "Bogenmaß" && toUnit == "Grad")
                return value * 180 / Math.PI;
            if (fromUnit == "Bogenmaß" && toUnit == "Gon")
                return value * 200 / Math.PI;
            if (fromUnit == "Gon" && toUnit == "Winkelgrad")
                return value * 9 / 10;
            if (fromUnit == "Gon" && toUnit == "Bogenmaß")
                return value * Math.PI / 200;
            return value; 
        }
     }
    
}
