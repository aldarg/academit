using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    internal class CelsiusScale : ITemperatureScale
    {
        public string Name
        {
            get
            {
                return "Celsius";
            }
        }

        public Dictionary<Tuple<string, string>, Func<double, double>> ConvertingRules
        {
            get;
        }

        public CelsiusScale()
        {
            var convertingRules = new Dictionary<Tuple<string, string>, Func<double, double>>();
            convertingRules.Add(new Tuple<string, string> ("Kelvin", "Celsius"), x => x - 273.15);

            ConvertingRules = convertingRules;
        }
    }
}
