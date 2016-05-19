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
            if (comparer == null)
                throw new ArgumentNullException(nameof(comparer));
            Comparer = comparer;
        }

        public BinaryTree() : this(Comparer<T>.Default)
        {
        }

        public virtual bool Add(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            bool added;
            root = Add(root, value, out added);
            return added;
        }

        public bool Contains(T value) => Contains(root, value);

        private BinaryTreeNode<T> Add(BinaryTreeNode<T> current, T value, out bool added)
        {
            if (current == null)
            {
                added = true;
                return new BinaryTreeNode<T>(value);
            }

            var cmp = Comparer.Compare(value, current.Value);
            if (cmp < 0) current.left = Add(current.left, value, out added);
            else if (cmp > 0) current.right = Add(current.right, value, out added);
            else added = false;

            current.Update();
            return current;
        }

        private bool Contains(BinaryTreeNode<T> current, T value)
        {
            while (current != null)
            {
                var cmp = Comparer.Compare(value, current.Value);
                if (cmp == 0) return true;
                if (cmp < 0) current = current.left;
                if (cmp > 0) current = current.right;
            }
            return false;
        }
        
        public T this[int index] {
            get
            {
                if (index < 0 || index >= root.Size)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return GetElementAt(index);
            }
        }

        private T GetElementAt(int index)
        {
            var current = root;
            while (true)
            {
                var currentIndex = current.left?.Size ?? 0;
                if (currentIndex == index) return current.Value;

                if (index < currentIndex)
                {
                    current = current.left;
                }
                else
                {
                    index -= currentIndex + 1;
                    current = current.right;
                }
            }
        }


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator() => new BinaryTreeEnumerator<T>(this);
    }
}
