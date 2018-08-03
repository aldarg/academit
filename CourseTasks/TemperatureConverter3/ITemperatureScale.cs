using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    interface ITemperatureScale
    {
        string Name
        {
            get;
        }

        Dictionary<Tuple<string, string>, Func<double, double>> ConvertingRules
        {
            get;
        }
    }
}
