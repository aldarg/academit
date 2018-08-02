using System;

namespace Academits.DargeevAleksandr
{
    internal class Celsius : ITemperatureScale
    {
        public string Name
        {
            get
            {
                return "Celsius";
            }
        }

        public double ConvertTo(double input, ITemperatureScale toScale)
        {
            string toScaleName = toScale.Name;

            if (Name == toScaleName)
            {
                return input;
            }

            switch (toScaleName)
            {
                case "Farenheit":
                    return input * 9 / 5 + 32;
                case "Kelvin":
                    return input + 273.15;
                default:
                    return toScale.ConvertFrom(input, this);
            }
        }

        public double ConvertFrom(double input, ITemperatureScale fromScale)
        {
            string fromScaleName = fromScale.Name;

            switch (fromScaleName)
            {
                default:
                    throw new Exception("Отсутствует формула конвертации.");
            }
        }
    }
}
