using Events.Interfaces;

namespace Events.Implementations
{
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; }
        public int Size { get; set; }

        public BinaryTreeNode<T> left;
        public BinaryTreeNode<T> right;

        public virtual IBinaryTreeNode<T> Left
        {
            get { return left; }
            set { left = (BinaryTreeNode<T>) value; }
        }

        public virtual IBinaryTreeNode<T> Right
        {
            get { return right; }
            set { left = (BinaryTreeNode<T>) value; }
        }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Size = 1;
        }

        private void UpdateSize()
        {
            Size = left.GetSize() + right.GetSize() + 1;
        }

        public virtual BinaryTreeNode<T> Update()
        {
            UpdateSize();
            return this;
        }
    }
}
