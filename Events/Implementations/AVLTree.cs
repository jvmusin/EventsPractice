using System;
using System.Collections.Generic;
using Events.Interfaces;

namespace Events.Implementations
{
    // ReSharper disable once InconsistentNaming
    public class AVLTree<T> : BinaryTree<T>
    {
        private AVLTreeNode<T> root;

        public override IBinaryTreeNode<T> Root
        {
            get { return root; }
            set { root = (AVLTreeNode<T>) value; }
        }

        public AVLTree(IComparer<T> comparer) : base(comparer)
        {
        }

        public AVLTree() : this(Comparer<T>.Default) { }

        public override bool Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            bool added;
            Root = Add((AVLTreeNode<T>) Root, value, out added);
            return added;
        }

        private AVLTreeNode<T> Add(AVLTreeNode<T> current, T value, out bool added)
        {
            if (current == null)
            {
                added = true;
                return new AVLTreeNode<T>(value);
            }

            var cmp = Comparer.Compare(value, current.Value);
            if      (cmp < 0) current.Left  = Add((AVLTreeNode<T>) current.Left,  value, out added);
            else if (cmp > 0) current.Right = Add((AVLTreeNode<T>) current.Right, value, out added);
            else added = false;

            return Balance(current);
        }

        private static AVLTreeNode<T> RotateRight(AVLTreeNode<T> p)
        {
            var q = (AVLTreeNode<T>) p.Left;
            p.Left = q.Right;
            q.Right = p;
            p.Update();
            q.Update();
            return q;
        }

        private static AVLTreeNode<T> RotateLeft(AVLTreeNode<T> q)
        {
            var p = (AVLTreeNode<T>) q.Right;
            q.Right = p.Left;
            p.Left = q;
            q.Update();
            p.Update();
            return p;
        }

        private static AVLTreeNode<T> Balance(AVLTreeNode<T> p)
        {
            p.Update();
            switch (GetBalanceFactor(p))
            {
                case 2:
                    if (GetBalanceFactor(p.Right) < 0)
                        p.Right = RotateRight((AVLTreeNode<T>) p.Right);
                    return RotateLeft(p);
                case -2:
                    if (GetBalanceFactor(p.Left) > 0)
                        p.Left = RotateLeft((AVLTreeNode<T>) p.Left);
                    return RotateRight(p);
                default:
                    return p.Update();
            }
        }

        private static int GetBalanceFactor(IBinaryTreeNode<T> node)
        {
            var leftHeight = ((AVLTreeNode<T>) node.Left).GetHeightSafe();
            var rightHeight = ((AVLTreeNode<T>) node.Right).GetHeightSafe();
            return rightHeight - leftHeight;
        }
    }
}
