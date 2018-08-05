using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.DargeevAleksandr
{
    internal class TemperatureConverter
    {
        private readonly List<ITemperatureScale> _scales = new List<ITemperatureScale>();

        public string[] ScalesList => _scales
            .Select(x => x.Name)
            .ToArray();

        public TemperatureConverter()
        {
            var kelvinScale = new KelvinScale();
            var farenheitScale = new FarenheitScale();
            var celsiusScale = new CelsiusScale();

            _scales.Add(kelvinScale);
            _scales.Add(farenheitScale);
            _scales.Add(celsiusScale);

            /*
             * Add your scale classes here like this:
             * 
             * var scaleName = new ClassName();
             * scales.Add(scaleName);
             */
        }

        public double Convert(double input, string inputScaleName, string outputScaleName)
        {
            var inputScale = _scales
                .First(x => x.Name == inputScaleName);

            var outputScale = _scales
                .First(x => x.Name == outputScaleName);

            if (inputScale == null || outputScale == null)
            {
                throw new Exception("Ошибка поиска шкалы температур.");
            }

            return outputScale.ConvertFromCelsius(inputScale.ConvertToCelsius(input));
        }
    }
}
