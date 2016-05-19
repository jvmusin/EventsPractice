namespace Events.Interfaces
{
    public interface IBinaryTreeNode<out T>
    {
        T Value { get; }
        IBinaryTreeNode<T> LeftNode { get; }
        IBinaryTreeNode<T> RightNode { get; } 
    }
}
