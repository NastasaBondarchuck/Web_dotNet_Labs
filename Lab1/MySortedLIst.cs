using System.Collections;
using System.Net;

namespace Lab1;

public class MySortedList<T> : IEnumerable<T>, ICollection<T> where T : IComparable 
{
    public Node<T>? Head;
    public int Count { get; set; }
    public bool IsReadOnly { get; }
    
    public void Add(T item)
    {
        Node<T> node = new Node<T>(item);
        Node<T>? previous = FindPlace(node);
        if (previous is not null)
        {
            Node<T>? next = previous.Next;
            previous.Next = node;
            node.Next = next;
        }
        else
        {
            Head = node;
        }
        Count++;
    }

    private Node<T>? FindPlace(Node<T> node)
    {
        return;
    }

    public void Clear()
    {
        
    }

    public bool Contains(T item)
    {
        Node<T>? current = Head;
        for (int i = 0; i < Count; i++)
        {
            if (current!.Data.Equals(item))
            {
                return true;
            }

            current = current.Next;
        }

        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    
    
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator(this);
    }
    
    private class MyEnumerator : IEnumerator<T>
    {
        public T? Current { get; }
        object? IEnumerator.Current => _current;
        
        private readonly MySortedList<T> _list;
        private Node<T>? _current; 
        
        public MyEnumerator(MySortedList<T> list)
        {
            _list = list;
            if (_list.Head != null) _current = _list.Head;
        }
        
        public bool MoveNext()
        {
            if (_current?.Next is null)
            {
                return false;
            }

            _current = _current.Next;
            return true;
        }

        public void Reset()
        {
            _current = _list.Head;
        }


        public void Dispose() { }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}