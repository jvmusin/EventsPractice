namespace Events
{
    public interface IBinaryTreeNode<T>
    {
        T Value { get; }
        IBinaryTreeNode<T> LeftNode { get; }
        IBinaryTreeNode<T> RightNode { get; } 
    }
}
