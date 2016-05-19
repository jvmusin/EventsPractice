using System.Collections;
using System.Collections.Generic;
using Events.Interfaces;

namespace Events.Implementations
{
    public class BinaryTreeEnumerator<T> : IEnumerator<T>
    {
        private readonly IBinaryTree<T> tree; 
        private IBinaryTreeNode<T> lastNode;
        private bool finished;
        private readonly ISet<IBinaryTreeNode<T>> visited;
        private readonly Stack<IBinaryTreeNode<T>> path; 

        public BinaryTreeEnumerator(IBinaryTree<T> tree)
        {
            this.tree = tree;
            visited = new HashSet<IBinaryTreeNode<T>>();
            path = new Stack<IBinaryTreeNode<T>>();
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
                lastNode = tree.Root;
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
            path.Push(lastNode);
            while (lastNode.Left != null)
                path.Push(lastNode = lastNode.Left);
        }

        private void GoToFirstUnusedParent()
        {
//            while (lastNode != null && visited.Contains(lastNode))
//                lastNode = lastNode.Parent;
            while (visited.Contains(lastNode) && path.Count > 1)
            {
                path.Pop();
                lastNode = path.Peek();
            }
            if (visited.Contains(lastNode))
                lastNode = null;
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
