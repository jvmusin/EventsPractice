using System;
using System.Collections;
using System.Collections.Generic;
using Events.Interfaces;

namespace Events.Implementations
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        internal BinaryTreeNode<T> root;
        public IBinaryTreeNode<T> Root => root;

        public IComparer<T> Comparer { get; }

        public BinaryTree(IComparer<T> comparer)
        {
            Comparer = comparer;
        }

        public BinaryTree() : this(Comparer<T>.Default)
        {
        }

        public bool Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return Add(null, ref root, value);
        }

        public bool Contains(T value) => Contains(root, value);

        private bool Add(BinaryTreeNode<T> parent, ref BinaryTreeNode<T> current, T value)
        {
            if (current == null)
            {
                current = new BinaryTreeNode<T>(parent, value);
                return true;
            }

            var cmp = Comparer.Compare(value, current.Value);
            if (cmp == 0) return false;

            var added = false;
            if (cmp < 0) added = Add(current, ref current.Left, value);
            if (cmp > 0) added = Add(current, ref current.Right, value);
            current.UpdateSize();
            return added;
        }

        private bool Contains(BinaryTreeNode<T> current, T value)
        {
            while (current != null)
            {
                var cmp = Comparer.Compare(value, current.Value);
                if (cmp == 0) return true;
                if (cmp < 0) current = current.Left;
                if (cmp > 0) current = current.Right;
            }
            return false;
        }

        public T this[int index] {
            get
            {
                if (index < 0 || index >= root.Size)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return GetElementAt(index, root);
            }
        }

        private static T GetElementAt(int index, BinaryTreeNode<T> current)
        {
            while (true)
            {
                var currentIndex = current.Left?.Size ?? 0;
                if (currentIndex == index) return current.Value;

                if (index < currentIndex)
                {
                    current = current.Left;
                }
                else
                {
                    index -= currentIndex + 1;
                    current = current.Right;
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => new BinaryTreeEnumerator<T>(this);
    }
}
