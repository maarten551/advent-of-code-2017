using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Application
{
    public class TreeNode
    {
        private int value;
        private readonly string name;
        private readonly List<TreeNode> children = new List<TreeNode>();
        private TreeNode parent;

        public int CalculateWeightSum()
        {
            return RecursionWeightSumCalculation(0);
        }

        public bool IsInBalance()
        {
            int? firstValue = null;
            
            foreach (TreeNode child in children)
            {
                if (!firstValue.HasValue)
                {
                    firstValue = child.CalculateWeightSum();
                    continue;
                }

                if (firstValue != child.CalculateWeightSum())
                    return false;
            }

            return true;
        }

        public TreeNode FindChildWithDifferentValue()
        {
            Dictionary<int, (int, TreeNode)> tuples = new Dictionary<int, (int, TreeNode)>();
            
            children.ForEach(node =>
            {
                int nodeValue = node.CalculateWeightSum();
                if (!tuples.ContainsKey(nodeValue))
                    tuples.Add(nodeValue, (1, node));
                else
                    tuples[nodeValue] = (tuples[nodeValue].Item1 + 1, tuples[nodeValue].Item2);
            });

            return tuples.First(tuple => tuple.Value.Item1 == 1).Value.Item2;
        }

        private int RecursionWeightSumCalculation(int currentSum)
        {
            currentSum += value;

            foreach (TreeNode child in children)
            {
                currentSum = child.RecursionWeightSumCalculation(currentSum);
            }

            return currentSum;
        }

        public TreeNode(string name)
        {
            this.name = name;
        }

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public TreeNode Parent
        {
            get => parent;
            set => parent = value;
        }

        public string Name => name;

        public List<TreeNode> Children => children;
    }
}