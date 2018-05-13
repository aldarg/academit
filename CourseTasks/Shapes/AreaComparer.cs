using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    class AreaComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            double epsilon = 1.0e-10;

            if (shape1.GetArea() - shape2.GetArea() > epsilon)
            {
                return -1;
            }
            else if (shape1.GetArea() - shape2.GetArea() < -epsilon)
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
