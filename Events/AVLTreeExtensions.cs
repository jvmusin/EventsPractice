using Events.Implementations;

namespace Events
{
    internal static class AVLTreeExtensions
    {
        public static int GetHeight<T>(this AVLTreeNode<T> node) => node?.Height ?? 0;

        public static int GetSize<T>(this BinaryTreeNode<T> node) => node?.Size ?? 0;

        public static int GetBalanceFactor<T>(this AVLTreeNode<T> node)
            => node.right.GetHeight() - node.left.GetHeight();
    }
}
