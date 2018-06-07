using System;

namespace Academits.DargeevAleksandr
{
    public class GraphHome
    {
        static void Main(string[] args)
        {
            int[,] edges =
            {
                {0, 1, 0, 0, 0, 0, 0},
                {1, 0, 1, 0, 1, 1, 0},
                {0, 1, 0, 0, 0, 0, 1},
                {0, 1, 0, 0, 0, 0, 0},
                {0, 1, 0, 0, 0, 1, 0},
                {0, 1, 0, 0, 1, 0, 1},
                {0, 0, 1, 0, 0, 1, 0}
            };

            Graph test = new Graph(edges);
            Action<int> action = Console.WriteLine;

            test.BreadthTraversal(action);

            Console.WriteLine();

            test.DepthTraversal(action);
        }
    }
}
