using System;

namespace Academits.DargeevAleksandr
{
    public class Square : IShape
    {
        public double Side
        {
            get;
            set;
        }

        public Square(double side)
        {
            double epsilon = 1.0e-10;

            if (side <= epsilon)
            {
                throw new ArgumentException("Сторона квадрата должна быть больше нуля.");
            }

            Side = side;
        }

        public double GetWidth()
        {
            return Side;
        }

        public double GetHeight()
        {
            return Side;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public double GetPerimeter()
        {
            return 4 * Side;
        }

        public override string ToString()
        {
            return ($"Квадрат со стороной {Side}.");
        }

        public override int GetHashCode()
        {
            return Side.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Square square = (Square)obj;

            return square.Side == Side;
        }
    }
}
