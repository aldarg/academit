using System;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    class Tree<T>
    {
        private TreeNode<T> root;
        private IComparer<T> comparer;

        public int Count
        {
            get;
            private set;
        }

        public Tree()
        {
        }

        public Tree(IComparer<T> comparer)
        {
            this.comparer = comparer;
        }

        public Tree(T root)
        {
            this.root = new TreeNode<T>(root);
            Count = 1;
        }

        public Tree(T root, IComparer<T> comparer)
        {
            this.root = new TreeNode<T>(root);
            this.comparer = comparer;
            Count = 1;
        }

        private int Compare(T data1, T data2)
        {
            if (data1 == null && data2 != null)
            {
                return -1;
            }
            else if (data1 != null && data2 == null)
            {
                return 1;
            }
            else if (data1 == null && data2 == null)
            {
                return 0;
            }

            int check;

            if (comparer == null)
            {
                var data1Comparable = data1 as IComparable<T>;

                if (data1Comparable == null)
                {
                    throw new TypeLoadException("Ошибка приведения к Comparable.");
                }

                check = data1Comparable.CompareTo(data2);
            }
            else
            {
                check = comparer.Compare(data1, data2);
            }

            return check;
        }

        public void Add(T newData)
        {
            if (root == null)
            {
                root = new TreeNode<T>(newData);
                ++Count;

                return;
            }

            TreeNode<T> current = root;

            while (current != null)
            {
                if (Compare(newData, current.Data) < 0)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current.Left = new TreeNode<T>(newData);
                        ++Count;

                        break;
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        current.Right = new TreeNode<T>(newData);
                        ++Count;

                        break;
                    }
                }
            }
        }

        public TreeNode<T> Find(T data)
        {
            if (root == null)
            {
                return null;
            }

            TreeNode<T> current = root;

            while (current != null)
            {
                int check = Compare(data, current.Data);

                if (check == 0)
                {
                    break;
                }
                else if (check < 0)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = null;

                        break;
                    }
                }
                else
                {
                    if (current.Right != null)
                    {
                        current = current.Right;
                    }
                    else
                    {
                        current = null;

                        break;
                    }
                }
            }

            return current;
        }

        private TreeNode<T> GetParent(TreeNode<T> child)
        {
            if (child == null)
            {
                throw new NullReferenceException("Ошибка: в качестве аргумента <children> передан null.");
            }

            if (root == null)
            {
                throw new NullReferenceException("Ошибка: пустое дерево.");
            }

            TreeNode<T> current = root;

            while (current != null)
            {
                if (current == child)
                {
                    return null;
                }

                int check = Compare(child.Data, current.Data);

                if (check < 0)
                {
                    if (current.Left == child)
                    {
                        break;
                    }
                    else if (current.Left == null)
                    {
                        return null;
                    }
                    else
                    {
                        current = current.Left;
                    }
                }
                else
                {
                    if (current.Right == child)
                    {
                        break;
                    }
                    else if (current.Right == null)
                    {
                        return null;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }

            return current;
        }

        private void ChangeAtParent(TreeNode<T> node, TreeNode<T> newNode)
        {
            TreeNode<T> parent = GetParent(node);

            if (parent == null)
            {
                if (node == root)
                {
                    root = newNode;

                    return;
                }
                else
                {
                    throw new NullReferenceException("Ошибка поиска родителя.");
                }
            }

            if (parent.Left == node)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }
        }

        public bool Remove(T data)
        {
            TreeNode<T> node = Find(data);

            if (node == null)
            {
                return false;
            }

            bool noLeft = (node.Left == null);
            bool noRight = (node.Right == null);

            if (noLeft && noRight)
            {
                ChangeAtParent(node, null);
            }
            else if (noLeft && !noRight)
            {
                ChangeAtParent(node, node.Right);
            }
            else if (!noLeft && noRight)
            {
                ChangeAtParent(node, node.Left);
            }
            else
            {
                TreeNode<T> minNode = node.Right;

                while (minNode.Left != null)
                {
                    minNode = minNode.Left;
                }

                ChangeAtParent(minNode, minNode.Right);

                ChangeAtParent(node, minNode);
                minNode.Left = node.Left;
                minNode.Right = node.Right;
            }

            --Count;

            return true;
        }

        private static void Visit(TreeNode<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Data);

            if (node.Left != null)
            {
                Visit(node.Left, action);
            }
            if (node.Right != null)
            {
                Visit(node.Right, action);
            }
        }

        public void RecursiveDepthTraversal(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Не задан делегат Action<T>");
            }

            if (root == null)
            {
                return;
            }

            Visit(root, action);
        }

        public void NonRecursiveDepthTraversal(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Не задан делегат Action<T>");
            }

            if (root == null)
            {
                return;
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

                action(node.Data);

                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }

        public void BreadthTraversal(Action<T> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException("Не задан делегат Action<T>");
            }

            if (root == null)
            {
                return;
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode<T> current = queue.Dequeue();

                action(current.Data);

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }
                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }
    }
}
