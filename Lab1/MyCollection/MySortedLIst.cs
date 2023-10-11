using System.Collections;

namespace Lab1;

public class MySortedList<T> : ICollection<T> where T : IComparable
{
    public delegate void EventHandler(MySortedList<T> sender);
    public event EventHandler? CountIncrease;
    public event EventHandler? CountDecrease;
    private Node<T>? _head;
    public int Count { get; set; }
    public bool IsReadOnly => false;

    public T[] GetValuesArray()
    {
        if (Count is 0) throw new Exception("SortedList is empty!");
        T[] array = new T[Count];
        Node<T>? current = _head;
        for (int i = 0; i < Count; i++)
        {
            array[i] = current!.Data;
            current = current.Next;
        }

        return array;
    }
    public List<T> GetValuesList()
    {
        if (Count is 0) throw new Exception("SortedList is empty!");
        List<T> list = new List<T>();
        Node<T> current = _head!;
        for (int i = 0; i < Count; i++)
        {
            list.Add(current.Data);
            current = current.Next!;
        }

        return list;
    }
    public T GetByIndex(int index)
    {
        if (Count is 0) throw new Exception("SortedList is empty!");
        if (index < 0) throw new IndexOutOfRangeException("Index must not be less than 0!");
        if (index >= Count) throw new IndexOutOfRangeException("Index must not be greater than SortedList Count!");
        if (index is 0) return _head!.Data;
        Node<T> current = _head!;
        for (int i = 0; i < index; i++)
        {
            current = current.Next!;
        }

        return current.Data;
    }
    public int GetIndexOf(T item)
    {
        if (Contains(item))
        {
            Node<T>? current = _head;
            for (int i = 0; i < Count; i++)
            {
                if (current!.Data.Equals(item)) return i;
                current = current.Next;
            }
        }
        throw new Exception("There is no element in the SortedList equal to your value!");
    }
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
            node.Next = _head;
            _head = node;
            
        }
        CountIncrease?.Invoke(this);
    }
    private Node<T>? FindPlace(Node<T> node)
    {
        if (Count is 0) return null;
        Node<T>? previous = null;
        Node<T>? current = _head;
        for (int i = 0; i < Count; i++)
        {
            if (node.Data.CompareTo(current!.Data) < 0)
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
        if (Count is 0) return;
        Node<T>? current = _head;
        for (int i = 0; i < Count; i++)
        {
            array[i + arrayIndex] = current!.Data;
            current = current.Next;
        }
    }
    public void Clear()
    {
        _head = null;
        Count = 0;
    }
    public bool Contains(T item)
    {
        if (Count > 0)
        {
            Node<T>? current = _head;
            for (int i = 0; i < Count; i++)
            {
                if (current!.Data.Equals(item)) return true;
                current = current.Next;
            }
        } 

        return false;
    }
    public bool Remove(T item)
    {
        if (!Contains(item)) return false;
        Node<T>? previous = null;
        Node<T>? current = _head;
        for (int i = 0; i < Count; i++)
                
        {
            if (current!.Data.Equals(item))
            {
                RemoveNode(current, previous);
                CountDecrease?.Invoke(this);
                return true;
            }
            previous = current;
            current = current.Next;
        }

        return false;
    }
    public bool RemoveAll(T item)
    {
        if (!Contains(item)) return false;
        while (Contains(item)) Remove(item);
        return false;
    }
    public bool RemoveByIndex(int index)
    {
        if (Count is 0) throw new Exception("SortedList is empty!");
        if (index < 0) throw new IndexOutOfRangeException("Index must not be less than 0!");
        if (index >= Count) throw new IndexOutOfRangeException("Index must not be greater than SortedList Count!");
        if (index is 0)
        {
            _head = _head!.Next;
            return true;
        }

        Node<T>? previous = null;
        Node<T>? current = _head;
        for (int i = 0; i < index; i++)
        {
            previous = current;
            current = current!.Next;
        }
        RemoveNode(current!, previous);
        CountDecrease?.Invoke(this);
        return true;
    }
    private void RemoveNode(Node<T> current, Node<T>? previous)
    {
        if (previous is not null)
        {
            previous.Next = current.Next;
        }
        else
        {
            _head = current.Next;
        }
    }
    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator(this);
    }
    private class MyEnumerator : IEnumerator<T>
    {
        public T Current => _current!.Data;
        object IEnumerator.Current => _current!.Data;
        
        private static Node<T>? _current;
        private readonly MySortedList<T> _list;
        private int _counter;
        
        public MyEnumerator(MySortedList<T> list)
        {
            _list = list;
            if (_list._head != null) _current = _list._head;
            _counter = 0;
        }
        
        public bool MoveNext()
        {
            if (_counter >= _list.Count - 1)
            {
                return false;
            }

            _current = _current!.Next;
            _counter++;
            return true;
        }

        public void Reset()
        {
            _current = _list._head;
        }


        public void Dispose() { }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}