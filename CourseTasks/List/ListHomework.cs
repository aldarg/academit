using System;

namespace Academits.DargeevAleksandr
{
    class ListHomework
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> test = new SinglyLinkedList<int>();

            test.AddFirst(5);

            Console.WriteLine(test.Length);
            Console.WriteLine(test.GetData(0));

            test.RemoveByValue(5);

            Console.WriteLine(test.Length);

            test.AddFirst(5);
            test.AddFirst(4);
            test.AddFirst(3);
            test.AddFirst(5);

            Console.WriteLine(test.Length);
            Console.WriteLine(test.GetData(1));

            test.RemoveByValue(5);

            Console.WriteLine(test.Length);
            Console.WriteLine(test.GetData(1));

            test.AddFirst(1);
            test.AddFirst(2);
            test.AddFirst(3);

            Console.WriteLine();

            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test.GetData(i));
            }

            test.Mirror();
            Console.WriteLine();

            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test.GetData(i));
            }

            Console.WriteLine();

            SinglyLinkedList<int> test2 = new SinglyLinkedList<int>();
            test2 = test.Copy();

            for (int i = 0; i < test2.Length; i++)
            {
                Console.WriteLine(test2.GetData(i));
            }

            Console.WriteLine();


        }
    }
}
