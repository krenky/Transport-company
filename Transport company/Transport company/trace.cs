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
    /// <typeparam name="T"></typeparam>
    public class Trace<T> 
    {
        DoublyNode<T> Head;
        DoublyNode<T> Tail;
        int Count;

        /// <summary>
        /// Добавление нового маршрута
        /// с грузом
        /// </summary>
        /// <param name="Start">Начало маршрута</param>
        /// <param name="Finish">конец маршрута</param>
        /// <param name="mass">Масса груза</param>
        public void Add(T Start, T Finish, int mass)
        {
            DoublyNode<T> node = new DoublyNode<T>(Start, Finish, mass);

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
        public void Add(T Start, T Finish)
        {
            DoublyNode<T> node = new DoublyNode<T>(Start, Finish);

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
            DoublyNode<T> current = Head;

            DoublyNode<T> removedItem = null;
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
                DoublyNode<T> current = Head;
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
    }
    /// <summary>
    /// Класс DoublyNode является основой для замкнутого
    /// двунаправленного списка
    /// </summary>
    /// <typeparam name="T">Тип данных заголовков</typeparam>
    public class DoublyNode<T>
    {
        /// <summary>
        /// конструктор DoublyNode
        /// </summary>
        /// <param name="start">Начало маршрута</param>
        /// <param name="finish">конец маршрута</param>
        /// <param name="mass">Масса груза</param>
        public DoublyNode(T start, T finish, int mass)
        {
            Start1 = start;
            Finish1 = finish;
            Time1 = DateTime.Now;
            Mass1 = mass;
        }
        public DoublyNode(T start, T finish)
        {
            Start1 = start;
            Finish1 = finish;
        }

        private T Start;
        private T Finish;
        private DateTime Time;
        private int Mass;
        private DoublyNode<T> Previous;
        private DoublyNode<T> Next;
        public T Start1 { get => Start; set => Start = value; }
        public T Finish1 { get => Finish; set => Finish = value; }
        public DateTime Time1 { get => Time; set => Time = value; }
        public int Mass1 { get => Mass; set => Mass = value; }
        public DoublyNode<T> Previous1 { get => Previous; set => Previous = value; }
        public DoublyNode<T> Next1 { get => Next; set => Next = value; }
    }
}
