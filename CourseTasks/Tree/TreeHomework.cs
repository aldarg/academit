using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    class TreeHomework
    {
        static void Main(string[] args)
        {
            Tree<int> test1 = new Tree<int>();

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

            test1.BreadthTraversal();

            Console.WriteLine();

            test1.RecursiveDepthTraversal();

            Console.WriteLine();

            test1.NonRecursiveDepthTraversal();

            Console.WriteLine();

            Console.WriteLine(test1.Find(3));

            Console.WriteLine(test1.Remove(6));

            Console.WriteLine();

            test1.BreadthTraversal();
        }
    }
}
