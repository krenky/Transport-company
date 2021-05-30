using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;

namespace Transport_company 
{
    /// <summary>
    /// Класс Trace для управления 
    /// списком
    /// </summary>
    /// <typeparam name="string"></typeparam>
    public class Trace : IEnumerable
    {
        DoublyNode Head;
        DoublyNode Tail;
        int Count;
        public delegate void ChangedList();
        public event ChangedList ChangeListEvent;
        /// <summary>
        /// Добавление нового маршрута
        /// с грузом
        /// </summary>
        /// <param name="Start">Начало маршрута</param>
        /// <param name="Finish">конец маршрута</param>
        /// <param name="mass">Масса груза</param>
        public void Add(DoublyNode node)
        {
            if (Head == null)
            {
                Head = node;
                Head.Next = node;
                Head.Previous = node;
            }
            else
            {
                node.Previous = Head.Previous;
                node.Next = Head;
                Head.Previous.Next = node;
                Head.Previous = node;
            }

            ChangeListEvent?.Invoke();
            Tail = node;
            Count++;
        }

        /// <summary>
        /// Добавление нового маршрута
        /// без груза
        /// </summary>
        /// <param name="Start">Начало маршрута</param>
        /// <param name="Finish">конец маршрута</param>
        public void Add(string Start, string Finish)
        {
            DoublyNode node = new DoublyNode(Start, Finish);

            if (Head == null)
            {
                Head = node;
                Head.Next = node;
                Head.Previous = node;
            }
            else
            {
                node.Previous = Head.Previous;
                node.Next = Head;
                Head.Previous.Next = node;
                Head.Previous = node;
            }
            ChangeListEvent?.Invoke();
            Tail = node;
            Count++;
        }

        /// <summary>
        /// Поиск и удаление маршрута
        /// </summary>
        /// <param name="start">Начало маршрута</param>
        /// <param name="finish">конец маршрута</param>
        /// <returns>True - Успешно, False - не найден</returns>
        public bool Remove(String start, string finish)
        {
            DoublyNode current = Head;

            DoublyNode removedItem = null;
            if (Count == 0) return false;
            // поиск удаляемого узла
            do
            {
                if (current.Старт.Equals(start) && current.Финиш.Equals(finish))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next;
            }
            while (current != Head);

            if (removedItem != null)
            {
                // если удаляется единственный элемент списка
                if (Count == 1)
                    Head = null;
                else
                {
                    // если удаляется первый элемент
                    if (removedItem == Head)
                    {
                        Head = Head.Next;
                    }
                    removedItem.Previous.Next = removedItem.Next;
                    removedItem.Next.Previous = removedItem.Previous;
                }
                Count--;
                ChangeListEvent?.Invoke();
                return true;
            }
            return false;
        }

        /// <summary>
        /// получение строки
        /// с информациеq о всех маршрутах
        /// </summary>
        /// <returns>String</returns>
        public String PrintAll()
        {
            if (Head != null)
            {
                string Sim = "";
                DoublyNode current = Head;
                do
                {
                    Sim = Sim + "Start: " + current.Старт + " " + "Finish: " + current.Финиш + " " + "Time: " + current.Время + " Масса груза: " + current.Масса + "\n";
                    if (current != null)
                    {
                        current = current.Next;
                    }
                }
                while (current != Head);
                return Sim;
            }
            else return "Поездок не было";
        }

        public int AllMass()
        {
            int sum = 0;
            DoublyNode Current = Head;
            do
            {
                if (Current != null)
                {
                    sum = sum + Current.Масса;
                }
            }
            while (Current != Head);
            return sum;
        }
        /// <summary>
        /// Добавление элемента AddingItem после
        /// элемента Item
        /// </summary>
        /// <param name="AddingItem"></param>
        /// <param name="Item"></param>
        /// <returns></returns>
        public DoublyNode AddBetween(DoublyNode AddingItem, DoublyNode Item)
        {
            AddingItem.Previous = Item;
            AddingItem.Next = Item.Next;
            Item.Next = AddingItem;
            Item.Next.Previous = AddingItem;
            Count++;
            return Item;
        }

        private void AddHead(DoublyNode node)
        {
            node.Previous = Tail;
            node.Next = Head;
            Head = node;
            Tail.Next = Head;
            Count++;
        }
        public void SearchAndPast(DoublyNode node)
        {
            if (Head != null)
            {
                if (node.Время > Head.Время && node.Время < Tail.Время)
                {
                    Head = SearchNode(node, Head);
                }
                else
                {
                    if (node.Время < Head.Время)
                    {
                        AddHead(node);
                    }
                    else Add(node);
                }
            }
            else
            {
                Add(node);
            }
            ChangeListEvent?.Invoke();
        }
        public DoublyNode SearchNode(DoublyNode node, DoublyNode SrchNode)
        {
            if(SrchNode.Next.Время > node.Время)
            {
                return SrchNode = AddBetween(node, SrchNode);
            }
            else
            {
                SrchNode.Next = SearchNode(node, SrchNode.Next);
                return SrchNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            DoublyNode current = Tail;
            do
            {
                if (current != null)
                {
                    current = current.Next;
                    yield return current;
                }
            }
            while (current != Tail);
        }
    }
    /// <summary>
    /// Класс DoublyNode является основой для замкнутого
    /// двунаправленного списка
    /// </summary>
    /// <typeparam name="string">Тип данных заголовков</typeparam>
    public class DoublyNode
    {
        /// <summary>
        /// конструктор DoublyNode
        /// </summary>
        /// <param name="start">Начало маршрута</param>
        /// <param name="finish">конец маршрута</param>
        /// <param name="mass">Масса груза</param>
        public DoublyNode(string start, string finish, int mass)
        {
            Старт = start;
            Финиш = finish;
            Время = DateTime.Now;
            Масса = mass;
        }
        public DoublyNode(string start, string finish, int mass, DateTime time)
        {
            Старт = start;
            Финиш = finish;
            Время = time;
            Масса = mass;
        }
        public DoublyNode(string start, string finish)
        {
            Старт = start;
            Финиш = finish;
        }

        private string Start;
        private string Finish;
        private DateTime Time;
        private int Mass;
        public DoublyNode Previous;
        public DoublyNode Next;
        public string Старт { get => Start; set => Start = value; }
        public string Финиш { get => Finish; set => Finish = value; }
        public DateTime Время { get => Time; set => Time = value; }
        public int Масса { get => Mass; set => Mass = value; }
        //public DoublyNode Previous1 { get => Previous; set => Previous = value; }
        //public DoublyNode Next1 { get => Next; set => Next = value; }
    }
}
