using System;
using Events.Interfaces;

namespace Events.Implementations
{
    internal class BinaryTreeNode<T> : IBinaryTreeNode<T>
    {
        public T Value { get; }
        public int Size { get; private set; }
        public int Height { get; private set; }
        
        internal BinaryTreeNode<T> left;
        internal BinaryTreeNode<T> right;
        
        public IBinaryTreeNode<T> Left => left;
        public IBinaryTreeNode<T> Right => right;

        public BinaryTreeNode(T value)
        {
            Value = value;
            Size = Height = 1;
        }

        public void UpdateSize()
        {
            Size = 1 + left.GetSize() + right.GetSize();
        }

        public void UpdateHeight()
        {
            Height = Math.Max(left.GetHeight(), right.GetHeight()) + 1;
        }

        public BinaryTreeNode<T> Update()
        {
            UpdateSize();
            UpdateHeight();
            return this;
        }
    }
}
