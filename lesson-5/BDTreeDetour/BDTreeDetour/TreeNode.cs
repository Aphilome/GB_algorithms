namespace BDTreeDetour
{
    public class TreeNode<T>
    {
        public T Value { get; set; }
        
        public TreeNode<T>[] Children {get; set; }
    }
}
