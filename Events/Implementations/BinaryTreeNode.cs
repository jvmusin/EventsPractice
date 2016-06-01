using Events.Interfaces;
using Events.Utilities;

namespace Events.Implementations
{
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; }
        public int Size { get; set; }

        private BinaryTreeNode<T> left;
        private BinaryTreeNode<T> right;

        public virtual IBinaryTreeNode<T> Left
        {
            get { return left; }
            set { left = (BinaryTreeNode<T>) value; }
        }

        public virtual IBinaryTreeNode<T> Right
        {
            get { return right; }
            set { right = (BinaryTreeNode<T>) value; }
        }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Size = 1;
        }

        private int CalculateSubtreeSize()
        {
            var leftSubtreeSize  = ((BinaryTreeNode<T>) Left ).GetSizeSafe();
            var rightSubtreeSize = ((BinaryTreeNode<T>) Right).GetSizeSafe();
            return leftSubtreeSize + rightSubtreeSize + 1;
        }

        public virtual BinaryTreeNode<T> Update()
        {
            Size = CalculateSubtreeSize();
            return this;
        }
    }
}
