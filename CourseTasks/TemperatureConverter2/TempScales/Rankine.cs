using System;

namespace Academits.DargeevAleksandr
{
    internal class Rankine : ITemperatureScale
    {
        public string Name
        {
            get
            {
                return "Rankine";
            }
        }

        public double ConvertFrom(double input, ITemperatureScale fromScale)
        {
            string fromScaleName = fromScale.Name;

            if (Name == fromScaleName)
            {
                return input;
            }

            switch (fromScaleName)
            {
                case "Farenheit":
                    return input + 459.67;
                case "Kelvin":
                    return input * 9 / 5;
                case "Celsius":
                    return (input + 273.15) * 9 / 5;
                default:
                    throw new Exception("Отсутствует формула конвертации.");
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
                    return input - 459.67;
                case "Kelvin":
                    return input * 5 / 9;
                case "Celsius":
                    return (input - 491.67) * 5 / 9;
                default:
                    return toScale.ConvertFrom(input, this);
            }
        }
    }
}
