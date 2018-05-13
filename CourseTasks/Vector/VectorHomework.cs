using System;

namespace Vector
{
    class VectorHomework
    {
        static void Main(string[] args)
        {
            Vector test1 = new Vector(4);
            Vector test2 = new Vector(new double[] { 1, 2, 3, 4 });
            Vector test3 = new Vector(test2);
            Vector test4 = new Vector(6, new double[] { 7, 8, 5, 4 });
            Vector test5 = new Vector(new double[] { 1, 2, 3, 4, 5, 6, 7 });

            Console.WriteLine(test2);
            test2.Add(test5);
            Console.WriteLine(test2);
            Console.WriteLine(test5);

            return;

            Console.WriteLine("Проверяем конструкторы и метод ToString()");
            Console.WriteLine($"Вектор1 = {test1}");
            Console.WriteLine($"Вектор2 = {test2}");
            Console.WriteLine($"Вектор3 = {test3}");
            Console.WriteLine($"Вектор4 = {test4}");

            Console.WriteLine();

            Console.WriteLine($"Размерность test4 = {test4.Size}");

            Console.WriteLine();

            Console.WriteLine("метод Add");
            Console.WriteLine(test3);
            test3.Add(test2);
            Console.WriteLine(test3);
            Console.WriteLine(test2);

            Console.WriteLine("метод Subtract");
            Console.WriteLine(test3);
            test3.Subtract(test2);
            Console.WriteLine(test3);
            Console.WriteLine(test2);

            Console.WriteLine("метод Multiply");
            Console.WriteLine(test3);
            test3.Multiply(3);
            Console.WriteLine(test3);

            Console.WriteLine("метод Reverse");
            Console.WriteLine(test3);
            test3.Reverse();
            Console.WriteLine(test3);

            Console.WriteLine("метод Length");
            Console.WriteLine(test2);
            Console.WriteLine(test2.GetLength());

            Console.WriteLine("метод SetByIndex");
            Console.WriteLine(test4);
            test4.SetByIndex(2, 3.5);
            Console.WriteLine(test4);

            Console.WriteLine("метод GetByIndex");
            Console.WriteLine(test4);
            Console.WriteLine(test4.GetByIndex(2));

            Console.WriteLine("метод SetByIndex");
            Vector copy = new Vector(test4);
            Console.WriteLine(test4.Equals(copy));
            test1.SetByIndex(0, 1);
            test1.SetByIndex(1, 2);
            test1.SetByIndex(2, 3);
            test1.SetByIndex(3, 4);
            Console.WriteLine(test1);
            Console.WriteLine(test2);
            Console.WriteLine(test1.Equals(test2));

            Console.WriteLine("метод GetHashCode");
            Console.WriteLine(test4.GetHashCode());

            Console.WriteLine("метод GetSum");
            Vector sum = Vector.GetSum(test1, test4);
            Console.WriteLine(test1);
            Console.WriteLine(test4);
            Console.WriteLine(sum);

            Console.WriteLine("метод GetDifference");
            Vector difference = Vector.GetDifference(test2, test4);
            Console.WriteLine(test2);
            Console.WriteLine(test4);
            Console.WriteLine(difference);

            Console.WriteLine("скалярное произведение");
            Console.WriteLine(test1);
            Console.WriteLine(test2);
            Console.WriteLine(Vector.GetScalarProduct(test1, test2));
        }
    }
}
