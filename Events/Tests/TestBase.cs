using System;
using System.Collections.Generic;
using Events.Interfaces;

namespace Events.Tests
{
    public abstract class TestBase
    {
        protected readonly Random Rnd = new Random();

        protected static void BuildTree<T>(IBinaryTree<T> tree, IEnumerable<T> values)
        {
            foreach (var value in values)
                tree.Add(value);
        }

        protected static void BuildSampleTree(IBinaryTree<int> tree)
        {
            BuildTree(tree, SampleTreeValues);
        }

        protected static readonly IEnumerable<int> SampleTreeValues = new[]
        {
            8,
            4, 12,
            2, 6, 10, 14,
            1, 3, 5, 7, 9, 11, 13, 15
        };
    }
}
