using System;

namespace Academits.DargeevAleksandr
{
    public class Square : Shapes
    {
        double Side
        {
            get;
            set;
        }

        public Square(double side)
        {
            Side = side;
        }

        public override double GetWidth()
        {
            return Side;
        }

        public override double GetHeight()
        {
            return Side;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return 4 * Side;
        }

        public override string ToString()
        {
            return String.Format($"Квадрат со стороной {Side}.");
        }

        public override int GetHashCode()
        {
            return Side.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Square square = (Square)obj;

            if (square.Side != Side)
            {
                return false;
            }

            return true;
        }
    }
}
