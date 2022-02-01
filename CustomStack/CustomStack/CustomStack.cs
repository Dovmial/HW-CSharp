using System;
using System.Collections;
using System.Collections.Generic;


namespace CustomStackProject
{
    /// <summary>
    /// Пользовательская реализация стека
    /// </summary>
    /// <typeparam name="T">шаблонный тип содержимого стека</typeparam>
    public class CustomStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Узел стека
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Хранящиеся в узле данные
            /// </summary>
            public T Data { get; set; }
            /// <summary>
            /// ссылка на правый узел в стеке
            /// </summary>
            public Node Right { get; set; }
            /// <summary>
            /// ссылка на левый узел в стеке
            /// </summary>
            public Node Left { get; set; }

            /// <summary>
            /// Конструктор узла
            /// </summary>
            /// <param name="data">данные для хранения</param>
            public Node(T data) => Data = data;
        }

        /// <summary>
        /// перечислитель по стеку
        /// </summary>
        private class StackEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// ссылка на стек
            /// </summary>
            private CustomStack<T> _stack;

            /// <summary>
            /// текущее положение указателя на узел
            /// </summary>
            public Node Cur { get; private set; }
            /// <summary>
            /// упаковка узла
            /// </summary>
            public object Current => Cur;
            /// <summary>
            /// Данные в выбранном узле
            /// </summary>
            T IEnumerator<T>.Current => Cur.Data;

            /// <summary>
            /// Конструктор перечислителя
            /// </summary>
            /// <param name="stack">сслыка на пользовательский стек</param>
            public StackEnumerator(CustomStack<T> stack)
            {
                _stack = stack;
                Cur = new Node(default(T));
                Cur.Left = _stack._head;
            }

            /// <summary>
            /// Перемещение по стеку
            /// </summary>
            /// <returns>возврат возможности переместиться на следующий узел</returns>
            public bool MoveNext()
            {
                if (Cur.Left == null)
                    return false;
                Cur = Cur.Left;
                return true;
            }
            /// <summary>
            /// неиспользуемая, функция интерфейса 
            /// </summary>
            public void Reset()
            {}
            /// <summary>
            /// неиспользуемая, функция интерфейса 
            /// </summary>
            public void Dispose()
            {}
        }
        /// <summary>
        /// вместимость стека
        /// </summary>
        public int Capacity { get; private set; }
        /// <summary>
        /// количество элементов в стеке
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// ссылка на голову стека
        /// </summary>
        private Node _head;
        /// <summary>
        /// ссылкаа на хвост стека
        /// </summary>
        private Node _tail;
       
        /// <summary>
        /// конструктор стека
        /// </summary>
        /// <param name="capacity">базовая вместимость стека</param>
        public CustomStack(int capacity) => Capacity = capacity;
        
        /// <summary>
        /// изъятие элемента с вершины стека
        /// </summary>
        /// <returns>T - хранящиеся данные</returns>
        /// <exception cref="NullReferenceException"></exception>
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

        /// <summary>
        /// положить эелемент в стек
        /// </summary>
        /// <param name="data">складируемые данные</param>
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
        /// <summary>
        /// посмотреть данные в вершине сека, не удаляя их из стека
        /// </summary>
        /// <returns>T - данные в вершине стека</returns>
        /// <exception cref="NullReferenceException"></exception>
        public T Peek()
        {
            if (Count == 0)
                throw new NullReferenceException("Error! Stack is empty");
            return _head.Data;
        }

        /// <summary>
        /// получение перечислителя
        /// </summary>
        /// <returns>IEnumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new StackEnumerator(this);
        }

        /// <summary>
        /// перечислитель из интерфейса
        /// </summary>
        /// <returns>IEnumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
}
