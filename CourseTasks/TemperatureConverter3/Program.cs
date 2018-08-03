using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    class Program
    {
        static void Main(string[] args)
        {
            var converter = new TemperatureConverter();

            Console.WriteLine(converter.Convert(0, "Kelvin", "Celsius"));
        }
    }
}
