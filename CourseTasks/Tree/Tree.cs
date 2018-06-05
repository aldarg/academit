using System;
using System.Collections.Generic;

namespace Academits.DargeevAleksandr
{
    class Tree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public int Count
        {
            get;
            private set;
        }

        public Tree()
        {
        }

        public Tree(T root)
        {
            this.root = new TreeNode<T>(root);
            Count = 1;
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
                if (newData.CompareTo(current.Data) < 0)
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
                throw new NullReferenceException("Ошибка: пустое дерево.");
            }

            TreeNode<T> current = root;

            while (current != null)
            {
                int check = data.CompareTo(current.Data);

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

        private TreeNode<T> GetParent(TreeNode<T> children)
        {
            if (children == null)
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
                if (current == children)
                {
                    return null;
                }

                int check = children.Data.CompareTo(current.Data);

                if (check < 0)
                {
                    if (current.Left == children)
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
                    if (current.Right == children)
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

        private void Visit(TreeNode<T> node)
        {
            if (node == null )
            {
                return;
            }

            Console.WriteLine(node.Data);

            if (node.Left != null)
            {
                Visit(node.Left);
            }
            if (node.Right != null)
            {
                Visit(node.Right);
            }
        }

        public void RecursiveDepthTraversal()
        {
            if (root == null)
            {
                throw new NullReferenceException("Ошибка: пустое дерево.");
            }

            Visit(root);
        }

        public void NonRecursiveDepthTraversal()
        {
            if (root == null)
            {
                throw new NullReferenceException("Ошибка: пустое дерево.");
            }

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();

            stack.Push(root);

            while (stack.Count != 0)
            {
                TreeNode<T> node = stack.Pop();

                Console.WriteLine(node.Data);

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

        public void BreadthTraversal()
        {
            if (root == null)
            {
                throw new NullReferenceException("Ошибка: пустое дерево.");
            }

            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                TreeNode<T> current = queue.Dequeue();

                Console.WriteLine(current.Data);

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
