namespace Events.Implementations
{
    public class AVLTree<T> : BinaryTree<T>
    {
        internal override BinaryTreeNode<T> Add(BinaryTreeNode<T> current, T value, out bool added)
        {
            if (current == null)
            {
                added = true;
                return new BinaryTreeNode<T>(value);
            }

            var cmp = Comparer.Compare(value, current.Value);
            if (cmp < 0) current.left = Add(current.left, value, out added);
            else if (cmp > 0) current.right = Add(current.right, value, out added);
            else added = false;

            return Balance(current);
        }

        private static BinaryTreeNode<T> RotateRight(BinaryTreeNode<T> p)
        {
            var q = p.left;
            p.left = q.right;
            q.right = p;
            p.Update();
            q.Update();
            return q;
        }

        private static BinaryTreeNode<T> RotateLeft(BinaryTreeNode<T> q)
        {
            var p = q.right;
            q.right = p.left;
            p.left = q;
            q.Update();
            p.Update();
            return p;
        }

        private static BinaryTreeNode<T> Balance(BinaryTreeNode<T> p)
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
                    return p.Update();
            }
        }
    }
}
