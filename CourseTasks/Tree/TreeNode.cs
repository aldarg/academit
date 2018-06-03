using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set;
        }

        internal TreeNode(T data)
        {
            Data = data;
        }
    }
}
