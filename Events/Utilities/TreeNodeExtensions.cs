using Events.Implementations;

namespace Events.Utilities
{
    public static class TreeNodeExtensions
    {
        public static int GetSizeSafe<T>(this BinaryTreeNode<T> node) => node?.Size ?? 0;

        public static int GetHeightSafe<T>(this AVLTreeNode<T> node) => node?.Height ?? 0;
    }
}
