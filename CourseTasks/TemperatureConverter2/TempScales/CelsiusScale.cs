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

        public double ConvertToCelsius(double input)
        {
            return input;
        }

        public double ConvertFromCelsius(double input)
        {
            return input;
        }
    }
}
