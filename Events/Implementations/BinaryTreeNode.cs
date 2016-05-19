using Events.Interfaces;

namespace Events.Implementations
{
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; }
        public int Size { get; private set; }

        public BinaryTreeNode<T> Parent;
        public BinaryTreeNode<T> Left;
        public BinaryTreeNode<T> Right;

        public IBinaryTreeNode<T> LeftNode => Left;
        public IBinaryTreeNode<T> RightNode => Right;

        public BinaryTreeNode(BinaryTreeNode<T> parent, T value)
        {
            Parent = parent;
            Value = value;
            Size = 1;
        }

        public void UpdateSize()
        {
            Size = 1;
            if (Left != null) Size += Left.Size;
            if (Right != null) Size += Right.Size;
        }
    }
}
