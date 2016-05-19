using Events.Interfaces;

namespace Events
{
    public static class AVLTreeExtensions
    {
        public static int GetHeight<T>(this IBinaryTreeNode<T> node) => node?.Height ?? 0;

        public static int GetSize<T>(this IBinaryTreeNode<T> node) => node?.Size ?? 0;

        public static int GetBalanceFactor<T>(this IBinaryTreeNode<T> node)
            => node.Right.GetHeight() - node.Left.GetHeight();
    }
}
