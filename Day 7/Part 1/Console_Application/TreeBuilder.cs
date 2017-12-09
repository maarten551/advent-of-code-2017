using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Application
{
    public class TreeBuilder
    {
        private readonly Dictionary<string, TreeNode> nameToTreeNodeCache = new Dictionary<string, TreeNode>();
        private readonly Dictionary<string, TreeNode> nodesWithoutParents = new Dictionary<string, TreeNode>();

        public void AddTreeData(string treeName, int value, IEnumerable<string> childNames)
        {
            TreeNode parentTree = GetOrCreateTreeNode(treeName);
            parentTree.Value = value;

            foreach (string childName in childNames)
            {
                TreeNode childNode = GetOrCreateTreeNode(childName);
                SetTreeNodeParent(childNode, parentTree);
            }
        }
        
        public (TreeNode, int)? FindInbalancedNode(TreeNode treeNode)
        {
            foreach (TreeNode childNode in treeNode.Children)
            {
                if (!childNode.IsInBalance())
                {
                    return FindInbalancedNode(childNode);
                }
            }

            // If there is no parent at this point, the tree is balanced
            if (treeNode.Parent == null)
                return null;
            
            // Now we are at this point, this means this node is the problem
            TreeNode weirdTreeNode = treeNode.FindChildWithDifferentValue();
            int wantedValue = weirdTreeNode.Parent.Children.First(node => node != weirdTreeNode).CalculateWeightSum();
            if (weirdTreeNode.Children.Count > 0)
                wantedValue -= weirdTreeNode.Children.Sum(node => node.CalculateWeightSum());
                
            return (weirdTreeNode, wantedValue);
        }

        public TreeNode GetFirstTreeNode()
        {
            if (nodesWithoutParents.Count == 1)
                return nodesWithoutParents.Values.First();

            throw new Exception("There is no first node!");
        }

        private void SetTreeNodeParent(TreeNode child, TreeNode parent)
        {
            child.Parent = parent;
            parent.Children.Add(child);

            if (nodesWithoutParents.ContainsKey(child.Name))
                nodesWithoutParents.Remove(child.Name);
        }

        private TreeNode GetOrCreateTreeNode(string treeName)
        {
            TreeNode treeNode;

            if (!nameToTreeNodeCache.ContainsKey(treeName))
            {
                treeNode = new TreeNode(treeName);
                nameToTreeNodeCache.Add(treeName, treeNode);
                nodesWithoutParents.Add(treeName, treeNode);
            }
            else
                treeNode = nameToTreeNodeCache[treeName];


            return treeNode;
        }

        public TreeNode GetTreeNodeByName(string name)
        {
            if (nameToTreeNodeCache.ContainsKey(name))
                return nameToTreeNodeCache[name];

            return null;
        }
    }
}