using System.Collections.Generic;

namespace Events.Interfaces
{
    public interface IBinaryTree<T> : IEnumerable<T>
    {
        bool Add(T value);
        bool Contains(T value);
        IBinaryTreeNode<T> Root { get; }
        T this[int index] { get; }
    }
}
