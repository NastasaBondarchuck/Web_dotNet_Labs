using System.Collections;

namespace Lab1;

public class MySortedList<T> : IEnumerable<T> where T : IComparable 
{
    public Node<T>? Head;
    public int Count;
    
    
    
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