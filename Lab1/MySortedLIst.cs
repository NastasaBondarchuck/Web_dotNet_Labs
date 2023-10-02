using System.Collections;
using System.Net;

namespace Lab1;

public class MySortedList<T> : IEnumerable<T>, ICollection<T> where T : IComparable 
{
    public Node<T>? Head;
    public int Count { get; private set; }
    
    public bool IsReadOnly => false;

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
        if (Count is 0)
        {
            return null;
        }
        Node<T>? previous = null;
        Node<T>? current = Head;
        for (int i = 0; i < Count; i++)
        {
            if (node.Data.CompareTo(current!.Data) >= 0)
            {
                return previous;
            }

            previous = current;
            current = current.Next;
        }

        return previous;
    }
    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array.Length - arrayIndex < Count) throw new IndexOutOfRangeException("SortedList contains more elements than Array might contain!");
        if (arrayIndex < 0) throw new IndexOutOfRangeException("ArrayIndex must not be less than 0!");
        if (array.Rank != 1) throw new ArgumentException("Array must be one-dimensional!");

        Node<T>? current = Head;
        for (int i = 0; i < Count; i++)
        {
            array[i + arrayIndex] = current!.Data;
            current = current.Next;
        }
    }
    public void Clear()
    {
        Head = null;
        Count = 0;
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

    public bool Remove(T item)
    {
        if (Contains(item))
        {
            Node<T>? previous = null;
            Node<T>? current = Head;
            for (int i = 0; i < Count; i++)
            {
                if (current!.Data.Equals(item))
                {
                    RemoveNode(current, previous);
                    Count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
        }

        return false;
    }

    private void RemoveNode(Node<T> current, Node<T>? previous)
    {
        if (previous is not null)
        {
            previous.Next = current.Next;
        }
        else
        {
            Head = current.Next;
        }
    }
    
    
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator(this);
    }
    
    private class MyEnumerator : IEnumerator<T>
    {
        public T Current { get; } = default!;
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