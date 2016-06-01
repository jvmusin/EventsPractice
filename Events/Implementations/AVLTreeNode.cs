using System;
using Events.Interfaces;
using Events.Utilities;

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

        private int CalculateSubtreeHeight()
        {
            var leftSubtreeHeight  = ((AVLTreeNode<T>) Left ).GetHeightSafe();
            var rightSubtreeHeight = ((AVLTreeNode<T>) Right).GetHeightSafe();
            return Math.Max(leftSubtreeHeight, rightSubtreeHeight) + 1;
        }

        public new AVLTreeNode<T> Update()
        {
            base.Update();
            Height = CalculateSubtreeHeight();
            return this;
        }
    }
}
