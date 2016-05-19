using System.Collections;
using System.Collections.Generic;
using Events.Implementations;

namespace Events
{
    public class BinaryTreeEnumerator<T> : IEnumerator<T>
    {
        private readonly BinaryTree<T> tree;
        private BinaryTreeNode<T> lastNode;
        private bool finished;
        private readonly ISet<BinaryTreeNode<T>> visited;

        public BinaryTreeEnumerator(BinaryTree<T> tree)
        {
            this.tree = tree;
            visited = new HashSet<BinaryTreeNode<T>>();
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

        private bool GoToMinNodeAndSaveIt()
        {
            GoToMinNode();
            return SaveCurrentNode();
        }

        private void GoToMinNode()
        {
            while (lastNode.LeftNode != null)
                lastNode = lastNode.Left;
        }

        private void GoToFirstUnusedParent()
        {
            while (lastNode != null && visited.Contains(lastNode))
                lastNode = lastNode.Parent;
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
