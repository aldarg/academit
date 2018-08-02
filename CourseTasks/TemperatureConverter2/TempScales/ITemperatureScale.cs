namespace Academits.DargeevAleksandr
{
    interface ITemperatureScale
    {
        string Name
        {
            get;
        }

        double ConvertTo(double input, ITemperatureScale toScale);
        double ConvertFrom(double input, ITemperatureScale fromScale);
    }
}
