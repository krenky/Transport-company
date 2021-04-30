using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    /// <summary>
    /// Класс Trace для управления 
    /// списком
    /// </summary>
    /// <typeparam name="string"></typeparam>
    public class Trace 
    {
        DoublyNode Head;
        DoublyNode Tail;
        int Count;

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
                Head.Next1 = node;
                Head.Previous1 = node;
            }
            else
            {
                node.Previous1 = Head.Previous1;
                node.Next1 = Head;
                Head.Previous1.Next1 = node;
                Head.Previous1 = node;
            }
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
                Head.Next1 = node;
                Head.Previous1 = node;
            }
            else
            {
                node.Previous1 = Head.Previous1;
                node.Next1 = Head;
                Head.Previous1.Next1 = node;
                Head.Previous1 = node;
            }
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
                if (current.Start1.Equals(start) && current.Finish1.Equals(finish))
                {
                    removedItem = current;
                    break;
                }
                current = current.Next1;
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
                        Head = Head.Next1;
                    }
                    removedItem.Previous1.Next1 = removedItem.Next1;
                    removedItem.Next1.Previous1 = removedItem.Previous1;
                }
                Count--;
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
                    Sim = Sim + "Start: " + current.Start1 + " " + "Finish: " + current.Finish1 + " " + "Time: " + current.Time1 + " Масса груза: " + current.Mass1 + "\n";
                    if (current != null)
                    {
                        current = current.Next1;
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
                    sum = sum + Current.Mass1;
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
            AddingItem.Previous1 = Item;
            AddingItem.Next1 = Item.Next1;
            Item.Next1 = AddingItem;
            Item.Next1.Previous1 = AddingItem;
            Count++;
            return Item;
        }

        private void AddHead(DoublyNode node)
        {
            node.Previous1 = Tail;
            node.Next1 = Head;
            Head = node;
            Count++;
        }
        public void SearchAndPast(DoublyNode node)
        {
            if(node.Time1 > Head.Time1 && node.Time1 < Tail.Time1)
            {
                Head = SearchNode(node, Head);
            }
            else
            {
                if (node.Time1 < Head.Time1)
                {
                    AddHead(node);
                }
                else Add(node);
            }
        }
        public DoublyNode SearchNode(DoublyNode node, DoublyNode SrchNode)
        {
            if(SrchNode.Next1.Time1 > node.Time1)
            {
                return SrchNode = AddBetween(node, SrchNode);
            }
            else
            {
                SrchNode.Next1 = SearchNode(node, SrchNode.Next1);
                return SrchNode;
            }
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
            Start1 = start;
            Finish1 = finish;
            Time1 = DateTime.Now;
            Mass1 = mass;
        }
        public DoublyNode(string start, string finish, int mass, DateTime time)
        {
            Start1 = start;
            Finish1 = finish;
            Time1 = time;
            Mass1 = mass;
        }
        public DoublyNode(string start, string finish)
        {
            Start1 = start;
            Finish1 = finish;
        }

        private string Start;
        private string Finish;
        private DateTime Time;
        private int Mass;
        private DoublyNode Previous;
        private DoublyNode Next;
        public string Start1 { get => Start; set => Start = value; }
        public string Finish1 { get => Finish; set => Finish = value; }
        public DateTime Time1 { get => Time; set => Time = value; }
        public int Mass1 { get => Mass; set => Mass = value; }
        public DoublyNode Previous1 { get => Previous; set => Previous = value; }
        public DoublyNode Next1 { get => Next; set => Next = value; }
    }
}
