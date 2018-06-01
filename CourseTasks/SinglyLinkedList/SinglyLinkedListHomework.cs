using System;

namespace Academits.DargeevAleksandr
{
    class ListHomework
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> test = new SinglyLinkedList<int>();

            test.AddFirst(1);
            test.AddFirst(2);
            test.AddFirst(3);
            test.AddFirst(4);
            test.AddFirst(5);

            test.SetOther(0, 3);
            test.SetOther(3, 3);
            test.SetOther(1, 4);
            test.SetOther(4, 2);

            for (int i = 0; i < test.Count; ++i)
            {
                Console.WriteLine(test.GetData(i));
            }

            Console.WriteLine();

            Console.WriteLine(test.GetData(0));
            Console.WriteLine(test.GetOtherData(0));
            Console.WriteLine(test.GetData(3));
            Console.WriteLine(test.GetOtherData(3));

            Console.WriteLine();

            SinglyLinkedList<int> testCopy = test.CopyOptional();

            test.RemoveFirst();
            test.RemoveFirst();
            test.RemoveFirst();
            test.RemoveFirst();
            test.RemoveFirst();

            try
            {
                Console.WriteLine(test.GetFirstData());
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
            }

            for (int i = 0; i < testCopy.Count; ++i)
            {
                Console.WriteLine(testCopy.GetData(i));
            }
            Console.WriteLine();

            Console.WriteLine(testCopy.GetData(0));
            Console.WriteLine(testCopy.GetOtherData(0));
            Console.WriteLine(testCopy.GetData(3));
            Console.WriteLine(testCopy.GetOtherData(3));
        }
    }
}
