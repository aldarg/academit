using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    class PerimeterComparer : IComparer<Shapes>
    {
        public int Compare(Shapes shape1, Shapes shape2)
        {
            if (shape1.GetPerimeter() > shape2.GetPerimeter())
            {
                return -1;
            }
            else if (shape1.GetPerimeter() < shape2.GetPerimeter())
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
