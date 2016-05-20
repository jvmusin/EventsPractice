using System;
using Events.Interfaces;

namespace Events.Implementations
{
    // ReSharper disable once InconsistentNaming
    public class AVLTreeNode<T> : BinaryTreeNode<T>
    {
        public int Height { get; set; }

        private AVLTreeNode<T> left;
        private AVLTreeNode<T> right;

        public override IBinaryTreeNode<T> Left
        {
            get { return left; }
            set { left = (AVLTreeNode<T>) value; }
        }

        public override IBinaryTreeNode<T> Right
        {
            get { return right; }
            set { right = (AVLTreeNode<T>) value; }
        }

        public AVLTreeNode(T value) : base(value)
        {
        }

        private void UpdateHeight()
        {
            Height = Math.Max(GetHeight(Left), GetHeight(Right)) + 1;
        }

        public new AVLTreeNode<T> Update()
        {
            base.Update();
            UpdateHeight();
            return this;
        }

        private static int GetHeight(IBinaryTreeNode<T> node)
        {
            var n = node as AVLTreeNode<T>;
            return n?.Height ?? 0;
        }
    }
}
