using System;

namespace DoublyLinkedList
{
    class Program
    {
        static void Main()
        {
            ILinkedList list = new DoublyLinkedList();
            Console.WriteLine($"count: {list.GetCount()}");
            list.AddNode(1);
            list.AddNode(2);
            list.AddNode(3);
            Console.WriteLine($"count: {list.GetCount()}");
            list.RemoveNode(0);
            list.RemoveNode(1);
            list.RemoveNode(1);
            Console.WriteLine($"count: {list.GetCount()}");
        }
    }
}