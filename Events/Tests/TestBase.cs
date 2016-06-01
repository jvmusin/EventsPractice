using System;
using System.Collections.Generic;
using System.Linq;
using Events.Implementations;
using Events.Interfaces;
using Events.Utilities;
using Ninject;
using Ninject.Planning.Bindings;

namespace Events.Tests
{
    public abstract class TestBase
    {
        public static readonly Random rnd = new Random();

        public static void BuildTree<T>(IBinaryTree<T> tree, IEnumerable<T> values)
        {
            foreach (var value in values)
                tree.Add(value);
        }

        public static void BuildSampleTree(IBinaryTree<int> tree)
        {
            BuildTree(tree, SampleTreeValues);
        }

        public static readonly IEnumerable<int> SampleTreeValues = new[]
        {
            8,
            4, 12,
            2, 6, 10, 14,
            1, 3, 5, 7, 9, 11, 13, 15
        };
        
        public IEnumerable<int> GetRandomDistinctInts(int count)
        {
            return rnd.Ints().Distinct().Take(count);
        }

        public IEnumerable<IBinaryTree<T>> GetTrees<T>()
        {
            var kernel = new StandardKernel();
            //TODO Register interafaces
            var bindings = kernel.GetBindings(typeof (IBinaryTree<>));
            var trees = bindings.Select(b => kernel.Get(b.Service)); 
            return (IEnumerable<IBinaryTree<T>>) trees;
        }
    }
}
