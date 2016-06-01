using System;
using System.Linq;
using Events.Implementations;
using Events.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Events.Tests
{
    [TestFixture]
    public class BinaryTreeEnumerator_Should : TestBase
    {
        private IBinaryTree<int> tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinaryTree<int>();
        }

        [Test]
        public void EnumerateValuesCorrectly()
        {
            BuildSampleTree(tree);
            Console.WriteLine(tree.ToList());
        }

        [Test]
        public void ReturnAllValues_OnEnumerating()
        {
            var elements = GetRandomDistinctInts(100).ToList();
            foreach (var element in elements)
                tree.Add(element);
            tree.ShouldBeEquivalentTo(elements);
        }

        [Test]
        public void EnumerateTree_InAscendingOrder()
        {
            var elements = GetRandomDistinctInts(100500).ToList();
            foreach (var element in elements)
                tree.Add(element);
            tree.Should().BeInAscendingOrder();
        }

        [Test]
        public void NotEnumerateEmptyTree()
        {
            tree.Should().BeEmpty();
        }
    }
}
