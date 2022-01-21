using System;
using System.Collections;
using System.Collections.Generic;


namespace CustomStackProject
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public Node(T data) => Data = data;
        }

        private class StackEnumerator : IEnumerator<T>
        {
            private CustomStack<T> _stack;
            public Node Cur { get; private set; }
            public object Current => Cur;
            T IEnumerator<T>.Current => Cur.Data;

            public StackEnumerator(CustomStack<T> stack)
            {
                _stack = stack;
                Cur = new Node(default(T));
                Cur.Left = _stack._head;
            }

            public bool MoveNext()
            {
                if (Cur.Left == null)
                    return false;
                Cur = Cur.Left;
                return true;
            }

            public void Reset()
            {}

            public void Dispose()
            {}
        }
        public int Capacity { get; private set; }
        public int Count { get; private set; }

        private Node _head;
        private Node _tail;
       
        public CustomStack(int capacity) => Capacity = capacity;
        
        public T Take()
        {
            if(Count == 0)
                throw new NullReferenceException("Error. Stack is empty!");
            var pointer = _head;
            _head = _head.Left;
            Count--;
            pointer.Left = null;
            _head.Right = null;
            return pointer.Data;
        }
        public void Put(T data)
        {
            if(Count == 0) 
            {
                _head = new Node(data);
                _tail = _head;
                Count++;
                return;
            }

            var pointer = new Node(data);
            pointer.Left = _head;
            _head.Right = pointer;

            Count++;
            _head = pointer;

            if (Count > Capacity)
            {
                pointer = _tail;
                Count--;
                _tail = _tail.Right;
                _tail.Left = null;
                pointer.Right = null;
            }
                
        }

        public T Peek()
        {
            if (Count == 0)
                throw new NullReferenceException("Error! Stack is empty");
            return _head.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}
