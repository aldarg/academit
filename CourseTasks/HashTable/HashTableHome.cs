using System;

namespace Academits.DargeevAleksandr
{
    class HashTableHome
    {
        static void Main(string[] args)
        {
            HashTable<Object> test1 = new HashTable<Object>(10);

            test1.Add(null);

            foreach(Object a in test1)
            {
                Console.WriteLine(a);
            }

            test1.Remove(null);

            foreach (Object a in test1)
            {
                Console.WriteLine(a);
            }

            /*test1.Add(1);
            test1.Add(2);
            test1.Add(3);
            test1.Add(4);
            test1.Add(2);

            Console.WriteLine(test1.Capacity);

            foreach (int a in test1)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();

            int[] array = new int[10];

            test1.CopyTo(array, 3);

            foreach (int a in array)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine();

            test1.Capacity = 3;
            Console.WriteLine(test1.Capacity);

            test1.Add(5);
            test1.Add(10);
            test1.Add(25);
            test1.Add(35);

            foreach (int a in test1)
            {
                Console.WriteLine(a);
            }*/
        }
    }
}
