using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    class TransportComp
    {
        int Head = -1; 
        int Tail = -1;
        public int Count;
        AutoT[] Company;

        public TransportComp(int IntCount)
        {
            Company = new AutoT[IntCount];
            Count = IntCount;
        }

        public AutoT[] Company1 { get => Company; set => Company = value; }
        public int End1 { get => Tail; set => Tail = value; }

        public bool isEmpty()
        {
            return Head == Tail;
        }
        public bool isFull()
        {
            if ((Head == Tail + 1) || (Head == 0 && Tail == Count - 1))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// вставляет элементы высчитавая индекс по формуле
        ///  ((индекс пос.элемента+1) % count) 
        /// </summary>
        /// <param name="Auto"></param>
        /// <param name="GosNamber"></param>
        /// <param name="Rider"></param>
        /// <returns></returns>
        public bool Push(string Auto, string GosNamber, string Rider)
        {
            AutoT auto = new AutoT(Auto, GosNamber, Rider);
            //if (!isFull())
            //{
                if (Head == -1) Head = 0;
                Tail = (Tail + 1) % Count;
                Company[Tail] = auto;
                return true;
            //}
            //return false;
        }
        /// <summary>
        /// вставляет элементы высчитавая индекс по формуле
        ///  ((индекс пос.элемента+1) % count)
        /// </summary>
        /// <param name="auto"></param>
        /// <returns></returns>
        public bool Push(AutoT auto)
        {
            if (!isFull())
            {
                if (Head == -1) Head = 0;
                Tail = (Tail + 1) % Count;
                Company[Tail] = auto;
                return true;
            }
            return false;
        }
        /// <summary>
        /// метод для добавления поездки
        /// </summary>
        /// <param name="input">данные для поиска</param>
        /// <param name="Start"></param>
        /// <param name="Finish"></param>
        /// <param name="mass"></param>
        public void SearchAndAddTrace(string input, string Start, string Finish, int mass)
        {
            if (Search(input) != -1)
            {
                Company[Search(input)].Traces1.Add(new DoublyNode(Start, Finish, mass));
            }
        }
        /// <summary>
        /// метод поиска
        /// </summary>
        /// <param name="Input">данные для поиска</param>
        /// <returns></returns>
        public int Search(string Input)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Company[i] != null && Comparison(Input, i))
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// метод сравнения используемый в методе  Search
        /// </summary>
        /// <param name="Input"></param>
        /// <param name="Index"></param>
        /// <returns>true если найдено совпадение</returns>
        private bool Comparison(string Input, int Index)
        {
            if (Company[Index].Automobile1 == Input)
            {
                return true;
            }
            else if (Company[Tail].GosNamber1 == Input)
            {
                return true;
            }
            else if (Company[Tail].Name1 == Input)
            {
                return true;
            }
            else return false;
        }
        /// <summary>
        /// метод вывода информации об искомой машине
        /// </summary>
        /// <param name="Input"></param>
        /// <returns>информация об автомобиле</returns>
        public string SearchAndPrint(string Input)
        {
            if (Search(Input) == -1)
            {
                return "Not found";
            }
            else
            {
                return Print(Search(Input));
            }
        }
        /// <summary>
        /// метод вывода информации об автомобиле
        /// </summary>
        /// <param name="Index"></param>
        /// <returns>информация об автомобиле</returns>
        public string Print(int Index)
        {
            if (Index != -1)
            {
                string Info = "Auto: " + Company[Index].Automobile1 + "\n" + "Nomber: " + Company[Index].GosNamber1 + "\n" + "Rider: " + Company[Index].Name1 + "\n" + Company[Index].Traces1.PrintAll();
                return Info;
            }
            else
            {
                return "Not found";
            }
        }
        /// <summary>
        /// метод вывода суммы всех грузов
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int sum = 0;
            foreach(AutoT i in Company)
            {
                sum = sum + i.Traces1.AllMass();
            }
            return sum;
        }
    }
}
