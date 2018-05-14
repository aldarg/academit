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
            Console.WriteLine(test3);
            Console.WriteLine(test4);

            Console.WriteLine(test4.GetSize(0));
            Console.WriteLine(test4.GetSize(1));

            Console.WriteLine(test4.GetRow(2));
            test4.SetRow(vector1, 2);
            Console.WriteLine(test4);
            test4.SetRow(new double[] { 20, 30, 40, 50 }, 2);
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

            double[,] e = { { 1 } };

            Matrix test8 = new Matrix(e);
            Console.WriteLine(test8);
        }
    }
}
