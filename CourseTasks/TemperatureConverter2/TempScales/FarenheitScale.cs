namespace Academits.DargeevAleksandr
{
    internal class FarenheitScale : ITemperatureScale
    {
        public string Name
        {
            get
            {
                return "Farenheit";
            }
        }

        public double ConvertToCelsius(double input)
        {
            return (input - 32) * 5 / 9;
        }

        public double ConvertFromCelsius(double input)
        {
            return input * 9 / 5 + 32;
        }
    }
}
