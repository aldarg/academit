using System;

namespace Academits.DargeevAleksandr
{
    class MatrixHomework
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(new double[] { 1, 2, 3, 4 });
            Vector vector2 = new Vector(new double[] { 7, 8, 5, 4, 5, 6 });
            double[,] a =
            {
                {1, 2, 3, 4 },
                {6, 7, 8, 9 },
                {4, 5, 10, 20 }
            };

            Vector[] vectors = new Vector[] { vector1, vector2 };

            Matrix test1 = new Matrix(vectors);
            Matrix test2 = new Matrix(test1);

            Matrix test3 = new Matrix(3, 5);
            Matrix test4 = new Matrix(a);


            Console.WriteLine(test1);
            Console.WriteLine(test2);

            test1.Add(test2);

            Console.WriteLine(test1);
            Console.WriteLine(test2);

            Console.WriteLine(test3);
            Console.WriteLine(test4);

            Console.WriteLine(test4.Height);
            Console.WriteLine(test4.Width);

            Console.WriteLine(test4.GetRow(2));
            test4.SetRow(2, vector1);
            Console.WriteLine(test4);

            Console.WriteLine(test4.GetColumn(2));

            Console.WriteLine(test4);
            test4.Transpose();
            Console.WriteLine(test4);

            test4.Multiply(3);
            Console.WriteLine(test4);

            double[,] b =
            {
                { 1, 2, 3, 6 },
                { 6, 7, 8, 6 },
                { 4, 5, 9, 6 },
                { 24, 25, 29, 26 }
            };

            Matrix test5 = new Matrix(b);
            Console.WriteLine(test5);
            double determinant = test5.GetDeterminant();
            Console.WriteLine(determinant);
            Console.WriteLine(test5);

            double[,] c =
            {
                {4, 5 },
                {6, 7 },
                {8, 9 }
            };

            double[,] d =
            {
                {1, 2, 3 },
                {4, 5, 6 }
            };

            Matrix test6 = new Matrix(c);
            Matrix test7 = new Matrix(d);

            Console.WriteLine(Matrix.MultiplyMatrixes(test6, test7));

            Vector v1 = new Vector(new double[] { 1, 2, 3 });

            Console.WriteLine(Matrix.MultiplyMatrixes(test6, test7).Multiply(v1));

            double[,] e = { { 1 } };

            Matrix test8 = new Matrix(e);
            Console.WriteLine(test8);

            double[,] f =
            {
                {3, 4, 2 },
                {4, 10, 2 }
            };

            Matrix test9 = new Matrix(f);
            test9.Subtract(test7);

            Console.WriteLine(test9);
        }
    }
}
