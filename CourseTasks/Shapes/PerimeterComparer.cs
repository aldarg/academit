using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    class PerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            double epsilon = 1.0e-10;

            if (shape1.GetPerimeter() - shape2.GetPerimeter() > epsilon)
            {
                return -1;
            }
            else if (shape1.GetPerimeter() - shape2.GetPerimeter() < -epsilon)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
