using System;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    public class Graph
    {
        public int[,] Edges
        {
            get;
            set;
        }

        public Graph(int[,] edges)
        {
            if (edges.GetLength(0) != edges.GetLength(1))
            {
                throw new ArgumentException("Матрица графов должна быть квадратной N x N.");
            }

            Edges = edges;
        }

        public void BreadthTraversal(Action<int> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Не задан делегат Action");
            }

            int verticesCount = Edges.GetLength(0);
            bool[] visited = new bool[verticesCount];

            Queue<int> traversal = new Queue<int>();

            for (int i = 0; i < verticesCount; ++i)
            {
                if (visited[i])
                {
                    continue;
                }

                traversal.Enqueue(i);

                while (traversal.Count != 0)
                {
                    int vertice = traversal.Dequeue();

                    if (visited[vertice])
                    {
                        continue;
                    }

                    action(vertice);
                    visited[vertice] = true;

                    for (int j = 0; j < verticesCount; ++j)
                    {
                        if (j == vertice || visited[j] || Edges[vertice, j] == 0)
                        {
                            continue;
                        }

                        traversal.Enqueue(j);
                    }
                }
            }
        }

        public void DepthTraversal(Action<int> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Не задан делегат Action");
            }

            int verticesCount = Edges.GetLength(0);
            bool[] visited = new bool[verticesCount];

            Stack<int> traversal = new Stack<int>();

            for (int i = 0; i < verticesCount; ++i)
            {
                if (visited[i])
                {
                    continue;
                }

                traversal.Push(i);

                while (traversal.Count != 0)
                {
                    int vertice = traversal.Pop();

                    if (visited[vertice])
                    {
                        continue;
                    }

                    action(vertice);
                    visited[vertice] = true;

                    for (int j = verticesCount - 1; j >= 0; --j)
                    {
                        if (j == vertice || visited[j] || Edges[vertice, j] == 0)
                        {
                            continue;
                        }

                        traversal.Push(j);
                    }
                }
            }
        }

        private void Visit(int vertice, bool[] visited, Action<int> action)
        {
            if (visited[vertice])
            {
                return;
            }

            action(vertice);
            visited[vertice] = true;

            for (int i = 0; i < Edges.GetLength(0); ++i)
            {
                if (Edges[vertice, i] != 0 && i != vertice)
                {
                    Visit(i, visited, action);
                }
            }
        }

        public void RecursiveDepthTraversal(Action<int> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Не задан делегат Action");
            }

            bool[] visited = new bool[Edges.GetLength(0)];

            for (int i = 0; i < Edges.GetLength(0); ++i)
            {
                if (!visited[i])
                {
                    Visit(i, visited, action);
                }
            }
        }
    }
}
