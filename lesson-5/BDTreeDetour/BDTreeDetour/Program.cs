using System;
using System.Collections.Generic;
using System.Linq;

namespace BDTreeDetour
{
    class Program
    {
        static void Bfs<T>(TreeNode<T> root)
        {
            Console.Write("BFS: ");
            var queue = new Queue<TreeNode<T>>();
            // 1
            queue.Enqueue(root);
            // 2
            while (queue.Count > 0)
            {
                // 3
                var node = queue.Dequeue();
                // 4
                if (queue.Count == 0 && node.Children is null)
                    Console.Write($"{node.Value}. ");
                else
                    Console.Write($"{node.Value}, ");
                // 5
                if (node.Children is {})
                    foreach (var child in node.Children)
                        queue.Enqueue(child);
            }
        }

        static void Dfs<T>(TreeNode<T> root)
        {
            Console.Write("DFS: ");
            var stack = new Stack<TreeNode<T>>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                var node = stack.Pop();
                if (stack.Count == 0 && node.Children is null)
                    Console.Write($"{node.Value}. ");
                else
                    Console.Write($"{node.Value}, ");
                if (node.Children is {})
                    foreach (var child in node.Children.Reverse())
                        stack.Push(child);
            }
        }

        static void Main()
        {
            var root = new TreeNode<int>
            {
                Value = 1,
                Children = new []
                {
                    new TreeNode<int>
                    {
                        Value = 2,
                        Children = new []
                        {
                            new TreeNode<int>
                            {
                                Value = 3,
                                Children = null
                            }
                        }
                    },
                    new TreeNode<int>
                    {
                        Value = 4,
                        Children = new []
                        {
                            new TreeNode<int>
                            {
                                Value = 5,
                                Children = null
                            },
                            new TreeNode<int>
                            {
                                Value = 6,
                                Children = null
                            },
                            new TreeNode<int>
                            {
                                Value = 7,
                                Children = null
                            },
                            new TreeNode<int>
                            {
                                Value = 8,
                                Children = null
                            },
                            new TreeNode<int>
                            {
                                Value = 9,
                                Children = null
                            }
                        }
                    },
                    new TreeNode<int>
                    {
                        Value = 10,
                        Children = null
                    },
                    new TreeNode<int>
                    {
                        Value = 11,
                        Children = new []
                        {
                            new TreeNode<int>
                            {
                                Value = 12,
                                Children = null
                            },
                            new TreeNode<int>
                            {
                                Value = 13,
                                Children = null
                            },
                            new TreeNode<int>
                            {
                                Value = 14,
                                Children = new []
                                {
                                    new TreeNode<int>
                                    {
                                        Value = 15,
                                        Children = null
                                    },
                                    new TreeNode<int>
                                    {
                                        Value = 16,
                                        Children = null
                                    }
                                }
                            },
                        }
                    }
                }
            };
            
            Bfs(root);
            Console.WriteLine();
            Dfs(root);
        }
    }
}