namespace Academits.DargeevAleksandr
{
    interface ITemperatureScale
    {
        string Name
        {
            get;
        }

        double ConvertToCelsius(double input);
        double ConvertFromCelsius(double input);
    }
}
