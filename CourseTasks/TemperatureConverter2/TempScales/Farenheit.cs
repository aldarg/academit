using System;

namespace Academits.DargeevAleksandr
{
    internal class Farenheit : ITemperatureScale
    {
        public string Name
        {
            get
            {
                return "Farenheit";
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
                case "Celsius":
                    return (input - 32) * 5 / 9;
                case "Kelvin":
                    return (input + 459.67) * 5 / 9;
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
