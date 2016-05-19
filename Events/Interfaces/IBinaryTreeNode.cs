namespace Events.Interfaces
{
    public interface IBinaryTreeNode<out T>
    {
        T Value { get; }
        IBinaryTreeNode<T> Parent { get; }
        IBinaryTreeNode<T> Left { get; }
        IBinaryTreeNode<T> Right { get; } 
    }
}
