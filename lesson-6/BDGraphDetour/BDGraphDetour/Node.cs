namespace BDGraphDetour
{
    public class Node<T>
    {
        public T Value { get; set; }
        
        public Node<T>[] Neighbours { get; set; }
        
        public bool IsVisited { get; set; }
    }
}