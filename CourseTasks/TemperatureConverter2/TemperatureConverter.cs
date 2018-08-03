using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.DargeevAleksandr
{
    internal class TemperatureConverter
    {
        private readonly List<ITemperatureScale> scales = new List<ITemperatureScale>();

        public List<string> ScalesList
        {
            get
            {
                return scales
                    .Select(x => x.Name)
                    .ToList();
            }
        }

        public TemperatureConverter()
        {
            var kelvinScale = new KelvinScale();
            var farenheitScale = new FarenheitScale();
            var celsiusScale = new CelsiusScale();

            scales.Add(kelvinScale);
            scales.Add(farenheitScale);
            scales.Add(celsiusScale);

            /*
             * Add your scale classes here like this:
             * 
             * var scaleName = new ClassName();
             * scales.Add(scaleName);
             */
        }

        public double Convert(double input, string inputScaleName, string outputScaleName)
        {
            var inputScale = scales
                .Where(x => x.Name == inputScaleName)
                .First();

            var outputScale = scales
                .Where(x => x.Name == outputScaleName)
                .First();

            if (inputScale == null || outputScale == null)
            {
                throw new Exception("Ошибка поиска шкалы температур.");
            }

            return outputScale.ConvertFromCelsius(inputScale.ConvertToCelsius(input));
        }
    }
}
