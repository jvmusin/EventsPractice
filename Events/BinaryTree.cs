using System;
using System.Collections;
using System.Collections.Generic;

namespace Events
{
    public class BinaryTree<T> : ITree<T>
    {
        private Node root;
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

        public bool Contains(T value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            return Contains(root, value);
        }

        private bool Add(Node parent, ref Node current, T value)
        {
            if (current == null)
            {
                current = new Node(parent, value);
                return true;
            }

            var cmp = Comparer.Compare(value, current.Value);
            if (cmp < 0) return Add(current, ref current.Left, value);
            if (cmp > 0) return Add(current, ref current.Right, value);
            return false;
        }

        private bool Contains(Node current, T value)
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
//            return EnumerateTree(root).GetEnumerator();
            return new TreeEnumerator(this);
        }

        private IEnumerable<T> EnumerateTree(Node current)
        {
            while (true)
            {
                if (current == null)
                    yield break;

                foreach (var value in EnumerateTree(current.Left))
                    yield return value;
                yield return current.Value;
                current = current.Right;
            }
        }

        private class Node
        {
            public T Value { get; }
            public Node Parent;
            public Node Left;
            public Node Right;

            public Node(Node parent, T value)
            {
                Parent = parent;
                Value = value;
            }
        }

        private class TreeEnumerator : IEnumerator<T>
        {
            private readonly BinaryTree<T> tree;
            private Node lastNode;
            private bool finished;
            private readonly ISet<Node> visited;

            public TreeEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;
                visited = new HashSet<Node>();
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (finished)
                    return false;

                if (lastNode == null)
                {
                    lastNode = tree.root;
                    return GoToMinNodeAndSaveIt();
                }

                if (lastNode.Right != null && !visited.Contains(lastNode.Right))
                {
                    lastNode = lastNode.Right;
                    return GoToMinNodeAndSaveIt();
                }

                GoToFirstUnusedParent();
                if (lastNode == null)
                {
                    finished = true;
                    return false;
                }
                return SaveCurrentNode();
            }

            private bool SaveCurrentNode()
            {
                visited.Add(lastNode);
                Current = lastNode.Value;
                return true;
            }

            private void GoToMinNode()
            {
                while (lastNode.Left != null)
                    lastNode = lastNode.Left;
            }

            private void GoToFirstUnusedParent()
            {
                while (lastNode != null && visited.Contains(lastNode))
                    lastNode = lastNode.Parent;
            }

            private bool GoToMinNodeAndSaveIt()
            {
                GoToMinNode();
                return SaveCurrentNode();
            }

            public void Reset()
            {
                lastNode = null;
                finished = false;
                visited.Clear();
            }

            object IEnumerator.Current => Current;

            public T Current { get; private set; }
        }
    }
}
