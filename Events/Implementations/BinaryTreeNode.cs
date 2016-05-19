using Events.Interfaces;

namespace Events.Implementations
{
    internal class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; }
        public int Size { get; private set; }

        internal BinaryTreeNode<T> parent;
        internal BinaryTreeNode<T> left;
        internal BinaryTreeNode<T> right;

        public IBinaryTreeNode<T> Parent => parent; 
        public IBinaryTreeNode<T> Left => left;
        public IBinaryTreeNode<T> Right => right;

        public BinaryTreeNode(BinaryTreeNode<T> parent, T value)
        {
            this.parent = parent;
            Value = value;
            Size = 1;
        }

        public void UpdateSize()
        {
            Size = 1;
            if (left != null) Size += left.Size;
            if (right != null) Size += right.Size;
        }
    }
}
