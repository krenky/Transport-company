using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    /// <summary>
    /// класс auto управляет кольцевой очередью
    /// на основе массива
    /// <value>Automobile</value>
    /// <value>GosNamber</value>
    /// <value>Name</value>
    /// </summary>
    internal class auto
    {
        int First, End = -1;
        static int Count = 5;
        string[] Automobile = new string[Count];
        string[] GosNamber = new string[Count];
        string[] Name = new string[Count];
        Trace<string>[] Traces = new Trace<string>[Count];

        public static int Count1 { get => Count; set => Count = value; }
        public int End1 { get => End; set => End = value; }
        public string[] Automobile1 { get => Automobile; set => Automobile = value; }
        public string[] GosNamber1 { get => GosNamber; set => GosNamber = value; }
        public string[] Name1 { get => Name; set => Name = value; }

        /// <summary>
        /// Проверка условий и добавление данных в список.
        /// </summary>
        /// <param name="Auto">Модель авто</param>
        /// <param name="GosNamber">Государственный номер</param>
        /// <param name="Rider">Имя водителя</param>
        public void Add(string Auto, string GosNamber, string Rider)
        {
            //if(End == -1 | End < First)
            //{
            //    First++;
            //    OnlyAdd(Auto, GosNamber, Rider);
            //}
            if (First < End)
            {
                if (End != Count - 1)
                {
                    if (End == -1)
                    {
                        if (First == -1)
                        {
                            First++;
                            OnlyAdd(Auto, GosNamber, Rider);
                        }
                    }
                    else
                    {
                        if (End < Count - 1)
                        {
                            OnlyAdd(Auto, GosNamber, Rider);
                        }
                        else
                        {
                            First++;
                            End = -1;
                            OnlyAdd(Auto, GosNamber, Rider);
                        }
                    }
                }
                else
                {
                    First++;
                    End = -1;
                    OnlyAdd(Auto, GosNamber, Rider);
                }
            }
            else
            {
                if (First < Count)
                {
                    First++;
                    OnlyAdd(Auto, GosNamber, Rider);
                }
                else
                {
                    First = 0;
                    Add(Auto, GosNamber, Rider);
                }
            }
        }

        /// <summary>
        /// Поиск автомобиля с помощью
        /// входного параметра Input(имя водителя, модель авто или гос. номер)
        /// и добавление маршрута найденному
        /// автомобилю.
        /// </summary>
        /// <param name="Start">Начало маршрута</param>
        /// <param name="Finish">Конец маршрута</param>
        /// <param name="Input">имя водителя, модель авто или гос. номер</param>
        /// <param name="time">Время начало поездки</param>
        /// <param name="mass">Масса груза</param>
        public void SearchAndAddTrace(string Start, string Finish, string Input, DateTime time, int mass)
        {
            if(Search(Input) != -1)
            {
                Traces[Search(Input)].Add(Start, Finish, mass);
            }
        }

        /// <summary>
        /// Только добавление,
        /// использется в методе Add
        /// </summary>
        /// <param name="Auto">Модель авто</param>
        /// <param name="GosNamber">Государственный номер</param>
        /// <param name="Rider">Имя водителя</param>
        private void OnlyAdd(string Auto, string GosNamber, string Rider)
        {
            End++;
            Automobile[End] = Auto;
            GosNamber1[End] = GosNamber;
            Name1[End] = Rider;
            Traces[End] = new Trace<string>();
        }

        /// <summary>
        /// Поиск автомобиля с помощью
        /// входного параметра Input(имя водителя, модель авто или гос. номер)
        /// и добавление маршрута найденному
        /// автомобилю.
        /// Дата задается автоматически.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="Start"></param>
        /// <param name="Finish"></param>
        /// <param name="mass"></param>
        public void SearchAndAddTrace(string input, string Start, string Finish, int mass)
        {
            if (Search(input) != -1)
            {
                Traces[Search(input)].Add(Start, Finish, mass);
            }
        }
        public string Print(int Index)
        {
            if (Index != -1)
            {
                string Info = "Auto: " + Automobile[Index] + "\n" + "Nomber: " + GosNamber1[Index] + "\n" + "Rider: " + Name1[Index] + "\n" + Traces[Index].PrintAll();
                return Info;
            }
            else
            {
                return "Not found";
            }
        }
        public int Search(string Input)
        {
            for(int i = 0; i < Count; i++)
            {
                if(Comparison(Input, i))
                {
                    return i;
                }
            }
            return -1;
        }
        private bool Comparison(string Input, int Index)
        {
            if (Automobile[Index] == Input)
            {
                return true;
            }
            else if (GosNamber1[Index] == Input)
            {
                return true;
            }
            else if (Name1[Index] == Input)
            {
                return true;
            }
            else return false;
        }
        public string SearchAndPrint(string Input)
        {
            if(Search(Input) == -1)
            {
                return "Not found";
            }
            else
            {
                return Print(Search(Input));
            }
        }
        public void Clear()
        {
            First = -1;
            End = -1;
            Automobile = new string[Count];
            GosNamber = new string[Count];
            Name = new string[Count];
            Traces = new Trace<string>[Count];
        }
    }
}
