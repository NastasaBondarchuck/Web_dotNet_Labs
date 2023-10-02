namespace Lab1;

public class Node<T> where T : IComparable
{
    public Node(T data)
    {
        Data = data;
    }
    public T Data { get; set;  }
    public Node<T>? Next { get; set; }
}