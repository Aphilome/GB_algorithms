using System;

namespace BinaryTree
{
    class Program
    {
        static void Main()
        {
            var tree = new Tree();
            tree.AddItem(10);
            tree.AddItem(6);
            tree.AddItem(12);
            
            tree.AddItem(3);
            tree.AddItem(9);
            tree.AddItem(11);
            tree.AddItem(14);
            
            tree.RemoveItem(9);
            tree.PrintTree();
        }
    }
}