using System;

namespace Events.Implementations
{
    public class AVLTree<T> : BinaryTree<T>
    {
        protected new AVLTreeNode<T> root; 

        public override bool Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            bool added;
            root = Add(root, value, out added);
            return added;
        }

        public override bool Contains(T value) => Contains(root, value);

        private AVLTreeNode<T> Add(AVLTreeNode<T> current, T value, out bool added)
        {
            if (current == null)
            {
                added = true;
                return new AVLTreeNode<T>(value);
            }

            var cmp = Comparer.Compare(value, current.Value);
            if (cmp < 0) current.left = Add(current.left, value, out added);
            else if (cmp > 0) current.right = Add(current.right, value, out added);
            else added = false;

            return Balance(current);
        }

        private static AVLTreeNode<T> RotateRight(AVLTreeNode<T> p)
        {
            var q = p.left;
            p.left = q.right;
            q.right = p;
            p.Update();
            q.Update();
            return q;
        }

        private static AVLTreeNode<T> RotateLeft(AVLTreeNode<T> q)
        {
            var p = q.right;
            q.right = p.left;
            p.left = q;
            q.Update();
            p.Update();
            return p;
        }

        private static AVLTreeNode<T> Balance(AVLTreeNode<T> p)
        {
            p.Update();
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
                    return p.Update();
            }
        }
    }
}
