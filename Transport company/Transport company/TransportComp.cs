using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Text.Json;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Microsoft.Win32;
using System.Windows;


namespace Transport_company
{
    [Serializable]
    class TransportComp
    {
        //public delegate void Hendler();
        //public event Hendler AddAutoevent;
        //public event Hendler AddTraceEvent;

        int Head = -1; 
        int Tail = -1;
        public int Count;
        AutoT[] Company;

        public TransportComp(int IntCount)
        {
            Company = new AutoT[IntCount];
            Count = IntCount;
        }
        public TransportComp()
        {

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
                //AddAutoevent?.Invoke();
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
                //AddAutoevent?.Invoke();
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
                //AddTraceEvent?.Invoke();
            }
        }
        public void SearchAndAddTrace(string input, string Start, string Finish, int mass, DateTime time)
        {
            if (Search(input) != -1)
            {
                Company[Search(input)].Traces1.SearchAndPast(new DoublyNode(Start, Finish, mass, time));
                //AddTraceEvent?.Invoke();
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
                if(i != null)
                sum = sum + i.Traces1.AllMass();
            }
            return sum;
        }
        
    }
    public static class Serializator
    {
        private static BinaryFormatter _bin = new BinaryFormatter();

        public static void Serialize(string pathOrFileName, object objToSerialise)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.Create))
                {
                    try
                    {
                        _bin.Serialize(stream, objToSerialise);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                        throw;
                    }
                }
            }
            else
            {
                using (Stream stream = File.Open(pathOrFileName, FileMode.Create))
                {
                    try
                    {
                        _bin.Serialize(stream, objToSerialise);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                        throw;
                    }
                }
            }
        }

        public static T Deserialize<T>(string pathOrFileName)
        {
            T items;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == true)
            {
                using (Stream stream = File.Open(openFileDialog.FileName, FileMode.Open))
                {
                    try
                    {
                        items = (T)_bin.Deserialize(stream);
                    }
                    catch (SerializationException e)
                    {
                        Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                        throw;
                    }
                }

                return items;
            }
            using (Stream stream = File.Open(pathOrFileName, FileMode.Open))
            {
                try
                {
                    items = (T)_bin.Deserialize(stream);
                }
                catch (SerializationException e)
                {
                    Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                    throw;
                }
            }

            return items;
        }
    }
}
namespace System.Runtime.Serialization
{
}
