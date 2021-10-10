using System;

namespace BinaryTree
{
    public class Tree : ITree
    {
        private TreeNode Root { get; set; }
        public TreeNode GetRoot()
        {
            return Root;
        }

        public void AddItem(int value)
        {
            if (Root == null)
            {
                Root = new TreeNode()
                {
                    Value = value,
                    LeftChild = null,
                    RightChild = null
                };
                return;
            }
            TreeNode node = Root;
            while ((node?.LeftChild != null && value < node.Value) || 
                   (node?.RightChild != null && value >= node.Value))
            {
                if (value < node.Value)
                    node = node.LeftChild;
                else
                    node = node.RightChild;
            }
            if (value < node.Value)
                node.LeftChild = new TreeNode()
                {
                    Value = value,
                    LeftChild = null,
                    RightChild = null
                };
            else
                node.RightChild = new TreeNode()
                {
                    Value = value,
                    LeftChild = null,
                    RightChild = null
                };
        }

        public void RemoveItem(int value)
        {
            var res = FindWithParent(value);
            if (res.findNode == null)
                return;
            RemoveItem(res.findNode, res.parent);
        }

        public TreeNode GetNodeByValue(int value)
        {
            var res = FindWithParent(value);
            return res.findNode;
        }

        public void PrintTree()
        {
            if (Root == null)
                return;
            var mas = TreeHelper.GetTreeInLine(this);
            var currentDepth = -1;
            foreach (var i in mas)
            {
                if (currentDepth != i.Depth)
                {
                    Console.SetCursorPosition(0, i.Depth);
                    currentDepth = i.Depth;
                    Console.Write($"{i.Depth}: ");
                }
                if (i.Node == null)
                    Console.Write($"__\t");
                else
                    Console.Write($"{i.Node.Value}\t");
            }
        }
        
        private void RemoveItem(TreeNode node, TreeNode parent)
        {
            if (node.LeftChild == null && node.RightChild == null)
            {
                if (ReferenceEquals(parent.LeftChild, node))
                    parent.LeftChild = null;
                else
                    parent.RightChild = null;
                return;
            }
            if (node.LeftChild == null || node.RightChild == null)
            {
                if (ReferenceEquals(parent.LeftChild, node))
                    parent.LeftChild = node.LeftChild ?? node.RightChild;
                else
                    parent.RightChild = node.LeftChild ?? node.RightChild;
                return;
            }

            var maxNode = node.LeftChild;
            var p = node;
            while (maxNode.RightChild != null)
            {
                p = maxNode;
                maxNode = maxNode.RightChild;
            }
            RemoveItem(maxNode, p);
        }

        private (TreeNode findNode, TreeNode parent) FindWithParent(int value)
        {
            if (Root == null)
                return (null, null);
            if (Root.Value == value)
                return (Root, null);
            return FindRecoursiveWithParent(Root, value);
        }
        
        private (TreeNode findNode, TreeNode parent) FindRecoursiveWithParent(TreeNode parent, int value)
        {
            if (parent == null)
                return (null, null);
            if (parent.LeftChild?.Value == value)
                return (parent.LeftChild, parent);
            if (parent.RightChild?.Value == value)
                return (parent.RightChild, parent);
            var left = FindRecoursiveWithParent(parent.LeftChild, value);
            if (left.findNode != null)
                return left;
            return FindRecoursiveWithParent(parent.RightChild, value);
        }
    }
}