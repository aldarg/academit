using System;
using System.Collections.Generic;
using System.Linq;

namespace Academits.DargeevAleksandr
{
    class Lambda2
    {
        public static IEnumerable<double> GetSquareRoots()
        {
            int i = 0;

            while (true)
            {
                yield return Math.Sqrt(i);
                ++i;
            }
        }

        public static void First()
        {
            var squares = GetSquareRoots();

            Console.Write("Вывести квадратных корней: ");
            int squaresCount = Convert.ToInt32(Console.ReadLine());

            var someSquares = squares
                .Take(squaresCount);

            foreach (double x in someSquares)
            {
                Console.WriteLine(x);
            }
        }

        public static IEnumerable<int> GetFibonacci()
        {
            int x0 = 0;
            int x1 = 1;

            yield return x0;
            yield return x1;

            while (true)
            {
                int xN = x0 + x1;
                yield return xN;

                x0 = x1;
                x1 = xN;
            }
        }

        public static void Second()
        {
            var fibonacciNumbers = GetFibonacci();

            Console.Write("Вывести чисел Фибоначчи: ");
            int fibonacciCount = Convert.ToInt32(Console.ReadLine());

            var someFibonacci = fibonacciNumbers
                .Take(fibonacciCount);

            foreach (int f in someFibonacci)
            {
                Console.WriteLine(f);
            }
        }

        static void Main(string[] args)
        {
            // First();
            Second();            
        }
    }
}
