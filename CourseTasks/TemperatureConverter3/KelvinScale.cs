using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    internal class KelvinScale : ITemperatureScale
    {
        public string Name
        {
            get
            {
                return "Kelvin";
            }
        }

        public Dictionary<Tuple<string, string>, Func<double, double>> ConvertingRules
        {
            get;
        }

        public KelvinScale()
        {
            var convertingRules = new Dictionary<Tuple<string, string>, Func<double, double>>();
            convertingRules.Add(new Tuple<string, string> ("Celsius", "Kelvin"), x => x + 273.15);

            ConvertingRules = convertingRules;
        }
    }
}
