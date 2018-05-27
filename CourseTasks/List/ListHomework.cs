using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    class ListHomework
    {
        static void Main(string[] args)
        {
            MyList<int> test1 = new MyList<int>();

            test1.Add(1);
            test1.Add(2);

            foreach (int num in test1)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(test1.Capacity);

            foreach (int num in test1)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine(test1.Capacity);
            Console.WriteLine(test1.Count);

            test1[1] = 3;
            Console.WriteLine(test1[1]);

            Console.WriteLine();
            MyList<int> test2 = new MyList<int>(20);
            Console.WriteLine(test2.Capacity);
            Console.WriteLine(test2.Count);

            for (int i = 0; i < 15; ++i)
            {
                test2.Add(i);
            }

            Console.WriteLine();

            foreach (int num in test2)
            {
                Console.WriteLine(num);
            }

            test2.EnsureCapacity(25);
            Console.WriteLine(test2.Capacity);
            Console.WriteLine(test2.Count);

            Console.WriteLine();

            test2.TrimToSize();
            Console.WriteLine(test2.Capacity);
            Console.WriteLine(test2.Count);

            test2.Add(1);
            Console.WriteLine(test2.Capacity);
            Console.WriteLine(test2.Count);

            //test2.Clear();
            //Console.WriteLine(test2.Capacity);
            //Console.WriteLine(test2.Count);

            Console.WriteLine(test2.Contains(4));
            Console.WriteLine(test2.Contains(100));
            Console.WriteLine(test2.Contains(-1));

            int[] array = new int[30];

            test2.CopyTo(array, 2);

            Console.WriteLine();

            foreach (int num in array)
            {
                Console.WriteLine(num);
            }

            Console.WriteLine();

            Console.WriteLine(test2.IndexOf(100));

            test2.RemoveAt(10);
            foreach (int num in test2)
            {
                Console.WriteLine(num);
            }

        }
    }
}
