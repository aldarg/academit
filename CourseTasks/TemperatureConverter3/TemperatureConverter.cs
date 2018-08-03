using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    internal class TemperatureConverter
    {
        private List<ITemperatureScale> scales = new List<ITemperatureScale>();
        private Dictionary<Tuple<string, string>, Func<double, double>> convertingRules = new Dictionary<Tuple<string, string>, Func<double, double>>();

        public List<string> ScalesList
        {
            get
            {
                List<string> scalesList = new List<string>();

                foreach (ITemperatureScale scale in scales)
                {
                    scalesList.Add(scale.Name);
                }

                return scalesList;
            }
        }

        public TemperatureConverter()
        {
            var celsiusScale = new CelsiusScale();
            var kelvinScale = new KelvinScale();

            scales.Add(celsiusScale);
            scales.Add(kelvinScale);

            foreach (var scale in scales)
            {
                foreach (var rule in scale.ConvertingRules)
                {
                    if (!convertingRules.ContainsKey(rule.Key))
                    {
                        convertingRules.Add(rule.Key, rule.Value);
                    }
                }
            }
        }

        public double Convert(double input, string inputScale, string outputScale)
        {
            var key = new Tuple<string, string> (inputScale, outputScale);

            if (convertingRules.ContainsKey(key))
            {
                return convertingRules[new Tuple<string, string>("Kelvin", "Celsius")].Invoke(input);
            }
            else
            {
                throw new Exception("Не найдена формула преобразования.");
            }
        }
    }
}
