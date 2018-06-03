using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academits.DargeevAleksandr
{
    class Tree<T> where T: IComparable
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

        public void Add(T item)
        {
            if (root == null)
            {
                root = new TreeNode<T>(item);
                ++Count;

                return;
            }

            TreeNode<T> current = root;

            while (current != null)
            {
                if (item.CompareTo(current.Data) < 0)
                {
                    if (current.Left != null)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current.Left = new TreeNode<T>(item);
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
                        current.Right = new TreeNode<T>(item);
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
    }
}
