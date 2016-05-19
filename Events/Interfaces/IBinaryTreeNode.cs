namespace Events.Interfaces
{
    public interface IBinaryTreeNode<out T>
    {
        T Value { get; }
        int Size { get; }
        int Height { get; }
        
        IBinaryTreeNode<T> Left { get; }
        IBinaryTreeNode<T> Right { get; }
    }
}
