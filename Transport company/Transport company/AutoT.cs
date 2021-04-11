using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    class AutoT<T>
    {// Поля
        private T[] _auto;
        private T[] _Gnom;
        private T[] _name;
        private Trace<string>[] Traces;
        private int _head;
        private int _tail;

        // Методы
        /// <summary>
        /// Создаём очередь. Ёмкость по умолнчанию - 0;
        /// </summary>
        public AutoT()
        {
            _auto = new T[0];
            _Gnom = new T[0];
            _name = new T[0];
            Traces = new Trace<string>[0];
        }

        /// <summary>
        /// Создаём очередь на основе коллекции.
        /// </summary>
        /// <param name="collection">Исходная коллекция.</param>
        public AutoT(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException();
            _auto = new T[4];
            Count = 0;
            foreach (T variable in collection)
                Enqueue(variable);
        }

        /// <summary>
        /// Создаём очередь с заданной начальной ёмкостью. 
        /// Если количество добавленных элементов превысит заданную ёмкость, то она будет автоматически увеличена.
        /// </summary>
        /// <param name="capacity">Начальная ёмкость.</param>
        public AutoT(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException();
            _auto = new T[capacity];
            _Gnom = new T[capacity];
            _name = new T[capacity];
            Traces = new Trace<string>[capacity];
            _head = 0;
            _tail = 0;
            Count = 0;
        }

        /// <summary>
        /// Количество элементов в очереди.
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Очистка очереди.
        /// </summary>
        public void Clear()
        {
            if (_head < _tail)
            {
                Array.Clear(_auto, _head, Count);
                Array.Clear(_Gnom , _head, Count);
                Array.Clear(_name , _head, Count);
                Array.Clear(Traces, _head, Count);
            }
            else
            {
                Array.Clear(_auto, _head, _auto.Length - _head);
                Array.Clear(_auto, 0, _tail);
                Array.Clear(_Gnom, _head, _auto.Length - _head);
                Array.Clear(_Gnom, 0, _tail);
                Array.Clear(_name, _head, _auto.Length - _head);
                Array.Clear(_name, 0, _tail);
                Array.Clear(Traces, _head, _auto.Length - _head);
                Array.Clear(Traces, 0, _tail);
            }
            _head = 0;
            _tail = 0;
            Count = 0;
        }

        /// <summary>
        /// Проверка на нахождении элемента в очереди.
        /// </summary>
        /// <param name="item">Элемент.</param>
        /// <returns>true, если элемент содержится в очереди.</returns>
        public bool Contains(T item)
        {
            int index = _head;
            int num2 = Count;
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;
            while (num2-- > 0)
            {
                if (item == null)
                {
                    if (_auto[index] == null)
                        return true;
                }
                else if ((_auto[index] != null) && comparer.Equals(_auto[index], item))
                    return true;
                index = (index + 1) % _auto.Length;
            }
            return false;
        }

        /// <summary>
        /// Извлечение элемента из очереди.
        /// </summary>
        /// <returns>Извлечённый элемент.</returns>
        public T Dequeue()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            T local = _auto[_head];
            _auto[_head] = default(T);
            _head = (_head + 1) % _auto.Length;
            Count--;
            return local;
        }

        /// <summary>
        /// Добавление элемента в очередь.
        /// </summary>
        /// <param name="item">Добавляемый элемент.</param>
        public void Enqueue(T item)
        {
            if (Count == _auto.Length)
            {
                var capacity = (int)((_auto.Length * 200L) / 100L);
                if (capacity < (_auto.Length + 4))
                    capacity = _auto.Length + 4;
                SetCapacity(capacity);
            }
            _auto[_tail] = item;
            _tail = (_tail + 1) % _auto.Length;
            Count++;
        }

        /// <summary>
        /// Просмотр элемента на вершине очереди.
        /// </summary>
        /// <returns>Верхний элемент.</returns>
        public T Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException();
            return _auto[_head];
        }

        // Изменение ёмкости очереди.
        private void SetCapacity(int capacity)
        {
            var destinationArray = new T[capacity];
            if (Count > 0)
            {
                if (_head < _tail)
                    Array.Copy(_auto, _head, destinationArray, 0, Count);
                else
                {
                    Array.Copy(_auto, _head, destinationArray, 0, _auto.Length - _head);
                    Array.Copy(_auto, 0, destinationArray, _auto.Length - _head, _tail);
                }
            }
            _auto = destinationArray;
            _head = 0;
            _tail = (Count == capacity) ? 0 : Count;
        }

        /// <summary>
        /// Преобразование очереди в массив.
        /// </summary>
        /// <returns>Массив с элементами из очереди.</returns>
        public T[] ToArray()
        {
            var destinationArray = new T[Count];
            if (Count != 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_auto, _head, destinationArray, 0, Count);
                    return destinationArray;
                }
                Array.Copy(_auto, _head, destinationArray, 0, _auto.Length - _head);
                Array.Copy(_auto, 0, destinationArray, _auto.Length - _head, _tail);
            }
            return destinationArray;
        }
    }
}
