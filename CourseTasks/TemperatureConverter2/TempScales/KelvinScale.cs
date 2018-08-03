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

        public double ConvertToCelsius(double input)
        {
            return input - 273.15;
        }

        public double ConvertFromCelsius(double input)
        {
            return input + 273.15;
        }
    }
}
