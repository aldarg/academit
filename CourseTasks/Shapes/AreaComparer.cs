using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    class AreaComparer : IComparer<Shapes>
    {
        public int Compare(Shapes shape1, Shapes shape2)
        {
            if (shape1.GetArea() > shape2.GetArea())
            {
                return -1;
            }
            else if (shape1.GetArea() < shape2.GetArea())
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
