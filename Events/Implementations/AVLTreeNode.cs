using System;
using Events.Interfaces;

namespace Events.Implementations
{
    // ReSharper disable once InconsistentNaming
    public class AVLTreeNode<T> : BinaryTreeNode<T>
    {
        public int Height { get; set; }

        public new AVLTreeNode<T> left;
        public new AVLTreeNode<T> right;

        public override IBinaryTreeNode<T> Left
        {
            get { return left; }
            set { base.left = left = (AVLTreeNode<T>) value; }
        }

        public override IBinaryTreeNode<T> Right
        {
            get { return right; }
            set { base.right = right = (AVLTreeNode<T>) value; }
        }

        public AVLTreeNode(T value) : base(value)
        {
        }

        private void UpdateHeight()
        {
            Height = Math.Max(left.GetHeight(), right.GetHeight()) + 1;
        }

        public new AVLTreeNode<T> Update()
        {
            base.Update();
            UpdateHeight();
            return this;
        }
    }
}
