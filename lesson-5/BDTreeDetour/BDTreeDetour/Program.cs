using System;

namespace BDTreeDetour
{
    class Program
    {
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
            
            
        }
    }
}