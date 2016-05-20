using System;
using Events.Interfaces;

namespace Events.Implementations
{
    public class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; }
        public int Size { get; private set; }
        public int Height { get; private set; }
        
        internal BinaryTreeNode<T> left;
        internal BinaryTreeNode<T> right;

        public IBinaryTreeNode<T> Left
        {
            get { return left; }
            set { left = (BinaryTreeNode<T>) value; }
        }

        public IBinaryTreeNode<T> Right
        {
            get { return right; }
            set { right = (BinaryTreeNode<T>) value; }
        }

        public BinaryTreeNode(T value)
        {
            Value = value;
            Size = Height = 1;
        }

        public void UpdateSize()
        {
            Size = 1 + Left.GetSize() + Right.GetSize();
        }

        public void UpdateHeight()
        {
            Height = Math.Max(Left.GetHeight(), Right.GetHeight()) + 1;
        }

        public BinaryTreeNode<T> Update()
        {
            UpdateSize();
            UpdateHeight();
            return this;
        }
    }
}
