using System;
using System.Collections.Generic;
using System.Linq;
using Events.Tests;
using FluentAssertions;
using NUnit.Framework;

namespace Events
{
    [TestFixture]
    public class BinaryTree_Should : TestBase
    {
        private BinaryTree<int> tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinaryTree<int>();
        }

        [Test]
        public void AddOneItemCorrectly()
        {
            tree.Add(123).Should().BeTrue();
        }

        [Test]
        public void AddSomeItemsCorrectly()
        {
            tree.Add(123).Should().BeTrue();
            tree.Add(42).Should().BeTrue();
        }

        [Test]
        public void NotAddItemsTwiceOrMore()
        {
            tree.Add(42).Should().BeTrue();
            tree.Add(42).Should().BeFalse();
            tree.Add(42).Should().BeFalse();
        }

        [Test]
        public void ContainElements_AfterAdding()
        {
            var num1 = 123;
            var num2 = 45;

            tree.Add(num1);
            tree.Add(num2);

            tree.Contains(num1).Should().BeTrue();
            tree.Contains(num2).Should().BeTrue();
        }

        [Test]
        public void NotContainUnexistingElements()
        {
            tree.Contains(555).Should().BeFalse();
        }

        [Test]
        public void FailOnAddingElement_WhenElementIsNull()
        {
            var tree = new BinaryTree<object>();
            Action adding = () => tree.Add(null);
            adding.ShouldThrow<Exception>();
        }

        [Test]
        public void EnumerateValuesCorrectly()
        {
            var treeVales = new[]
            {
                8,
                4, 12,
                2, 6, 10, 14,
                1, 3, 5, 7, 9, 11, 13, 15
            };
            foreach (var value in treeVales)
                tree.Add(value);
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

        [Test, Timeout(6000), TestCaseSource(nameof(PerfrormanceTestCases))]
        public void WorkFast_WithManyRandomElements(IList<int> elements)
        {
            foreach (var element in elements)
                tree.Add(element);
            foreach (var element in elements)
                tree.Contains(element).Should().BeTrue();
        }

        private IEnumerable<int> GetRandomDistinctInts(int count)
        {
            return Rnd.Ints().Distinct().Take(count);
        }

        private IEnumerable<TestCaseData> PerfrormanceTestCases
        {
            get
            {
                yield return new TestCaseData(GetRandomDistinctInts((int)1e5).ToList());
                yield return new TestCaseData(GetRandomDistinctInts((int)2e5).ToList());
                yield return new TestCaseData(GetRandomDistinctInts((int)4e5).ToList());
            }
        }
    }
}
