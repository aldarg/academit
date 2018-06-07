using System;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    public class MyClassComparer : IComparer<MyClass>
    {
        public int Compare(MyClass x, MyClass y)
        {
            if (x == null && y != null)
            {
                return -1;
            }
            else if (x != null && y == null)
            {
                return 1;
            }
            else if (x == null & y == null)
            {
                return 0;
            }
            else
            {
                if (x.Age > y.Age)
                {
                    return 1;
                }
                else if (x.Age < y.Age)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

        }
    }

    public class MyClass
    {
        public int Age
        {
            get;
            set;
        }

        public MyClass(int age)
        {
            Age = age;
        }

        public override string ToString()
        {
            return Age.ToString();
        }
    }

    class TreeHomework
    {
        static void Main(string[] args)
        {
            Tree<MyClass> test = new Tree<MyClass>(new MyClassComparer());

            test.Add(new MyClass(8));
            test.Add(new MyClass(3));
            test.Add(new MyClass(10));
            test.Add(new MyClass(1));
            test.Add(new MyClass(6));
            test.Add(new MyClass(14));
            test.Add(new MyClass(4));
            test.Add(new MyClass(7));
            test.Add(new MyClass(13));

            Action<MyClass> operation = Console.WriteLine;

            test.BreadthTraversal(operation);

            Console.WriteLine();

            test.NonRecursiveDepthTraversal(operation);

            /*Tree<int> test1 = new Tree<int>();

            TreeNode<int> test2 = new TreeNode<int>(2);

            test1.Add(8);
            test1.Add(3);
            test1.Add(10);
            test1.Add(1);
            test1.Add(6);
            test1.Add(14);
            test1.Add(4);
            test1.Add(7);
            test1.Add(13);

            Tree<string> test1 = new Tree<string>();

            test1.Add("ac");
            test1.Add("bc");
            test1.Add("cd");
            test1.Add("dde");
            test1.Add("ddb");
            test1.Add("ab");
            test1.Add(null);
            test1.Add("abd");

            test1.BreadthTraversal();

            Console.WriteLine();

            test1.RecursiveDepthTraversal();

            Console.WriteLine();

            test1.NonRecursiveDepthTraversal();

            Console.WriteLine();

            Console.WriteLine(test1.Find("dde"));

            Console.WriteLine(test1.Remove("cd"));
            Console.WriteLine(test1.Remove(null));

            Console.WriteLine();

            test1.BreadthTraversal();*/
        }
    }
}
