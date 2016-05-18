using System.Collections.Generic;

namespace Events
{
    public interface ITree<T> : IEnumerable<T>
    {
        bool Add(T value);
        bool Contains(T value);
    }
}
