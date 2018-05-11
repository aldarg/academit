using System;

namespace Vector
{
    class Vector
    {
        public double[] Components
        {
            get;
            set;
        }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            Components = new double[n];
        }

        public Vector(Vector original)
        {
            Components = new double[original.GetSize()];

            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] = original.Components[i];
            }
        }

        public Vector(double[] a)
        {
            Components = new double[a.Length];

            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] = a[i];
            }
        }

        public Vector(int n, double[] a)
        {
            if (n <= 0)
            {
                throw new ArgumentException();
            }

            Components = new double[n];

            for (int i = 0; i < n; i++)
            {
                Components[i] = (i < a.Length) ? a[i] : 0;
            }
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            string result = "{";

            int n = GetSize();

            for (int i = 0; i < n; i++)
            {
                result += (i < n - 1) ? String.Format(" {0},", Components[i]) : String.Format(" {0}{1}", Components[i], "}");
            }

            return result;
        }

        public void Add(Vector vector)
        {
            int n1 = GetSize();
            int n2 = vector.GetSize();

            for (int i = 0; i < n1; i++)
            {
                Components[i] += (i < n2) ? vector.Components[i] : 0;
            }
        }

        public void Subtract(Vector vector)
        {
            int n1 = GetSize();
            int n2 = vector.GetSize();

            for (int i = 0; i < n1; i++)
            {
                Components[i] -= (i < n2) ? vector.Components[i] : 0;
            }
        }

        public void Multiply(double scalar)
        {
            for (int i = 0; i < GetSize(); i++)
            {
                Components[i] *= scalar;
            }
        }

        public void Reverse()
        {
            Multiply(-1);
        }

        public double GetLength()
        {
            double result = 0;

            for (int i = 0; i < GetSize(); i++)
            {
                result += Math.Pow(Components[i], 2);
            }

            return Math.Sqrt(result);
        }

        public void SetByIndex(int index, double x)
        {
            if (index < 0 || index >= GetSize())
            {
                throw new ArgumentOutOfRangeException();
            }

            Components[index] = x;
        }

        public double GetByIndex(int index)
        {
            if (index < 0 || index >= GetSize())
            {
                throw new ArgumentOutOfRangeException();
            }

            return Components[index];
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (GetSize() != vector.GetSize())
            {
                return false;
            }

            for (int i = 0; i < GetSize(); i++)
            {
                if (Components[i] != vector.Components[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;

            foreach (double x in Components)
            {
                hashCode += x.GetHashCode();
            }

            return hashCode;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            int n1 = vector1.GetSize();
            int n2 = vector2.GetSize();

            int n = Math.Max(n1, n2);
            Vector result = new Vector(n);

            for (int i = 0; i < n; i++)
            {
                result.Components[i] += (i < n1) ? vector1.Components[i] : 0;
                result.Components[i] += (i < n2) ? vector2.Components[i] : 0;
            }

            return result;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector temp = new Vector(vector2);
            temp.Reverse();

            return GetSum(vector1, temp);
        }

        public static double GetScalarProduct(Vector vector1, Vector vector2)
        {
            int n1 = vector1.GetSize();
            int n2 = vector2.GetSize();

            double result = 0;
            int n = Math.Max(n1, n2);

            for (int i = 0; i < n; i++)
            {
                result += ((i < n1) ? vector1.Components[i] : 0) * ((i < n2) ? vector2.Components[i] : 0);
            }

            return result;
        }
    }
}
