using System;
using System.Collections.Generic;

namespace DoublyLinkedList
{
    public class DoublyLinkedList : ILinkedList
    {
        private Node StartNode { get; set; }
        private Node EndNode { get; set; }
        
        public int GetCount()
        {
            int i = 0;
            var n = StartNode;
            while (n != null)
            {
                n = n.NextNode;
                i++;
            }
            return i;
        }

        public void AddNode(int value)
        {
            var node = new Node();
            node.Value = value;

            if (EndNode == null)
            {
                StartNode = node;
                EndNode = node;
            }
            else
            {
                EndNode.NextNode = node;
                node.PrevNode = EndNode;
                EndNode = node;
            }
        }

        public void AddNodeAfter(Node node, int value)
        {
            if (node == null)
                return ;
            if (node == EndNode)
                AddNode(value);
            else
            {
                var n = new Node();
                n.Value = value;
                n.NextNode = node.NextNode;
                n.PrevNode = node;
                node.NextNode = n;
                n.NextNode.PrevNode = n;
            }
        }

        public void RemoveNode(int index)
        {
            if (StartNode == null)
                return;
            var i = 0;
            var node = StartNode;
            while (i < index && node != null)
            {
                node = node.NextNode;
                i++;
            }
            RemoveNode(node);
        }

        public void RemoveNode(Node node)
        {
            if (node == null)
                return;
            if (node == StartNode)
            {
                StartNode = StartNode.NextNode;
                StartNode.PrevNode = null;
            }
            else if (node == EndNode)
            {
                EndNode = EndNode.PrevNode;
                EndNode.NextNode = null;
            }
            else
            {
                node.PrevNode.NextNode = node.NextNode;
                node.NextNode.PrevNode = node.PrevNode;
            }
        }

        public Node FindNode(int searchValue)
        {
            if (StartNode == null)
                return null;
            var n = StartNode;
            while (n != null)
            {
                if (n.Value == searchValue)
                    return n;
                n = n.NextNode;
            }
            return null;
        }

        // DELETE
        public void Check()
        {
            var list = new List<Node>();
            var m = StartNode;
            if (StartNode == null)
                return;
            while (m != EndNode)
            {
                list.Add(m);
                m = m.NextNode;
            }
            list.Add(m);
        }
        
    }
}