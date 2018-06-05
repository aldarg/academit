using System;

namespace Academits.DargeevAleksandr
{
    internal class TreeNode<T> where T : IComparable<T>
    {
        internal TreeNode<T> Left
        {
            get;
            set;
        }

        internal TreeNode<T> Right
        {
            get;
            set;
        }

        internal T Data
        {
            get;
        }

        internal TreeNode(T data)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }
    }
}
