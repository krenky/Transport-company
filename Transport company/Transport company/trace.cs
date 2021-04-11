using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    class Trace<T> 
    {
        DoublyNode<T> Head;
        DoublyNode<T> Tail;
        int Count;
        public void Add(T Start, T Finish, int mass)
        {
            DoublyNode<T> node = new DoublyNode<T>(Start, Finish, mass);

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
            Tail = node;
            Count++;
        }
        public void Add(T Start, T Finish)
        {
            DoublyNode<T> node = new DoublyNode<T>(Start, Finish);

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
            Tail = node;
            Count++;
        }
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
                return true;
            }
            return false;
        }
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
                        current = current.Next;
                    }
                }
                while (current != Head);
                return Sim;
            }
            else return "Поездок не было";
        }
    }
    public class DoublyNode<T>
    {
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
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
        public T Start1 { get => Start; set => Start = value; }
        public T Finish1 { get => Finish; set => Finish = value; }
        public DateTime Time1 { get => Time; set => Time = value; }
        public int Mass1 { get => Mass; set => Mass = value; }
    }
}
