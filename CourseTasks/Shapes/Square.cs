using System;

namespace Academits.DargeevAleksandr
{
    public class Square : IShape
    {
        double Side
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

            double epsilon = 1.0e-10;

            if (Math.Abs(square.Side - Side) > epsilon)
            {
                return false;
            }

            return true;
        }
    }
}
