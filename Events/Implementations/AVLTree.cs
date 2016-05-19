using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Events.Interfaces;

namespace Events.Implementations
{
    public class AVLTree<T> : BinaryTree<T>
    {
        public override bool Add(T value)
        {
            var added = base.Add(value);



            return added;
        }

        private BinaryTreeNode<T> RotateRight(BinaryTreeNode<T> p)
        {
            var q = p.left;
            p.left = q.right;
            q.right = p;
            p.UpdateHeight();
            q.UpdateHeight();
            return q;
        }

        private BinaryTreeNode<T> RotateLeft(BinaryTreeNode<T> q)
        {
            var p = q.right;
            q.right = p.left;
            q.left = q;
            q.UpdateHeight();
            p.UpdateHeight();
            return p;
        }

        private BinaryTreeNode<T> Balance(BinaryTreeNode<T> p)
        {
            p.UpdateHeight();
            switch (p.GetBalanceFactor())
            {
                case 2:
                    if (p.right.GetBalanceFactor() < 0)
                        p.right = RotateRight(p.right);
                    return RotateLeft(p);
                case -2:
                    if (p.left.GetBalanceFactor() > 0)
                        p.left = RotateLeft(p.left);
                    return RotateRight(p);
                default:
                    return p;
            }
        }
    }
}
