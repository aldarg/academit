using System;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    internal class TemperatureConverter
    {
        private List<ITemperatureScale> scales = new List<ITemperatureScale>();

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
            ITemperatureScale kelvinScale = new Kelvin();
            ITemperatureScale farenheitScale = new Farenheit();
            ITemperatureScale celsiusScale = new Celsius();

            scales.Add(kelvinScale);
            scales.Add(farenheitScale);
            scales.Add(celsiusScale);

            /*
             * Add your scale classes here like this:
             * 
             * ITemperatureScale scaleName = new ClassName();
             * scales.Add(scaleName);
             */

            ITemperatureScale rankineScale = new Rankine();
            scales.Add(rankineScale);
        }

        public double GetResult(double inputValue, string inputScale, string outputScale)
        {
            ITemperatureScale input = null;
            ITemperatureScale output = null;

            foreach (ITemperatureScale scale in scales)
            {
                if (scale.Name == inputScale)
                {
                    input = scale;
                }

                if (scale.Name == outputScale)
                {
                    output = scale;
                }
            }

            if (input == null || output == null)
            {
                throw new Exception("Ошибка поиска шкалы температур.");
            }

            return input.ConvertTo(inputValue, output);
        }
    }
}
