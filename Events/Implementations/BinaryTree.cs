using System;
using System.Collections;
using System.Collections.Generic;
using Events.Interfaces;

namespace Events.Implementations
{
    public class BinaryTree<T> : IBinaryTree<T>
    {
        protected BinaryTreeNode<T> root;

        public virtual IBinaryTreeNode<T> Root
        {
            get { return root; }
            set { root = (BinaryTreeNode<T>) value; }
        }

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
            Root = Add((BinaryTreeNode<T>) Root, value, out added);
            return added;
        }

        public virtual bool Contains(T value) => Contains(root, value);

        protected BinaryTreeNode<T> Add(BinaryTreeNode<T> current, T value, out bool added)
        {
            if (current == null)
            {
                added = true;
                return new BinaryTreeNode<T>(value);
            }

            var cmp = Comparer.Compare(value, current.Value);
            if      (cmp < 0) current.Left  = Add((BinaryTreeNode<T>) current.Left,  value, out added);
            else if (cmp > 0) current.Right = Add((BinaryTreeNode<T>) current.Right, value, out added);
            else added = false;
            
            return current.Update();
        }

        protected bool Contains(IBinaryTreeNode<T> current, T value)
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

        public T this[int index] => GetElementAt(index);

        public T GetElementAt(int index)
        {
            var nodesCount = ((BinaryTreeNode<T>) Root).Size;
            if (index < 0 || index >= nodesCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            var current = Root;
            while (true)
            {
                var leftNode = (BinaryTreeNode<T>) current.Left;
                var currentIndex = leftNode?.Size ?? 0;
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
