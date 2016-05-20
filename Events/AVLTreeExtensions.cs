using Events.Implementations;

namespace Events
{
    internal static class AVLTreeExtensions
    {
        public static int GetHeightSafe<T>(this AVLTreeNode<T> node) => node?.Height ?? 0;

        public static int GetSizeSafe<T>(this BinaryTreeNode<T> node) => node?.Size ?? 0;
    }
}
