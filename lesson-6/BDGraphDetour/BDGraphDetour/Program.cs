using System;
using System.Collections.Generic;
using System.Linq;

namespace BDGraphDetour
{
    class Program
    {
        static void Bfs<T>(Node<T> root)
        {
            Console.Write("BFS: ");
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);
            root.IsVisited = true;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (queue.Count == 0 && node.Neighbours.All(i => i.IsVisited))
                    Console.Write($"{node.Value}. ");
                else
                    Console.Write($"{node.Value}, ");
                if (node.Neighbours is {})
                    foreach (var neighbor in node.Neighbours.Where(i => i.IsVisited == false))
                    {
                        queue.Enqueue(neighbor);
                        neighbor.IsVisited = true;
                    }
            }
        }

        static void Dfs<T>(Node<T> root)
        {
            Console.Write("DFS: ");
            var stack = new Stack<Node<T>>();
            stack.Push(root);
            root.IsVisited = true;
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (stack.Count == 0 && node.Neighbours.All(i => i.IsVisited))
                    Console.Write($"{node.Value}. ");
                else
                    Console.Write($"{node.Value}, ");
                if (node.Neighbours is {})
                    foreach (var neighbor in node.Neighbours.Where(i => i.IsVisited == false))
                    {
                        stack.Push(neighbor);
                        neighbor.IsVisited = true;
                    }
            }
        }
        
        static void Main()
        {
            #region initialization
            
            var n1 = new Node<int>
            {
                Value = 1
            };
            var n2 = new Node<int>
            {
                Value = 2
            };
            var n3 = new Node<int>
            {
                Value = 3
            };
            var n4 = new Node<int>
            {
                Value = 4 
            };
            var n5 = new Node<int>
            {
                Value = 5
            };
            n1.Neighbours = new[] {n2, n4};
            n2.Neighbours = new[] {n1, n3, n4};
            n3.Neighbours = new[] {n2, n5};
            n4.Neighbours = new[] {n1, n2};
            n5.Neighbours = new[] {n3};
            
            #endregion
            Bfs(n1);
            n1.IsVisited = false;
            n2.IsVisited = false;
            n3.IsVisited = false;
            n4.IsVisited = false;
            n5.IsVisited = false;
            Console.WriteLine();
            Dfs(n1);
        }
    }
}
