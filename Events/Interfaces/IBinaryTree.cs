using System.Collections.Generic;

namespace Events.Interfaces
{
    public interface IBinaryTree<T> : IEnumerable<T>
    {
        bool Add(T value);
        bool Contains(T value);
        bool Remove(T value);
        IBinaryTreeNode<T> Root { get; }
        int Size { get; }
        T this[int index] { get; }
    }
}
