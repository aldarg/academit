using System;

namespace Academits.DargeevAleksandr
{
    internal class TreeNode<T>
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
    }
}
