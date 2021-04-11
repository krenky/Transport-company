using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    class auto
    {
        int First, End = -1;
        static int Count = 5;
        string[,] Automobile = new string[3, Count];//1 строчка авто, 2 строчка номер, 3 строчка имя
        Trace<string>[] Traces = new Trace<string>[Count];

        public static int Count1 { get => Count; set => Count = value; }
        public int End1 { get => End; set => End = value; }
        public string[,] Automobile1 { get => Automobile; set => Automobile = value; }

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
        public void SearchAndAddTrace(string Start, string Finish, string Input, DateTime time, int mass)
        {
            if(Search(Input) != -1)
            {
                Traces[Search(Input)].Add(Start, Finish, mass);
            }
        }
        private void OnlyAdd(string Auto, string GosNamber, string Rider)//first и end выходят за пределы
        {
            End++;
            Automobile[0, End] = Auto;
            Automobile[1, End] = GosNamber;
            Automobile[2, End] = Rider;
            Traces[End] = new Trace<string>();
        }
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
                string Info = "Auto: " + Automobile[0, Index] + "\n" + "Nomber: " + Automobile[1, Index] + "\n" + "Rider: " + Automobile[2, Index] + "\n" + Traces[Index].PrintAll();
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
            if (Automobile[0, Index] == Input)
            {
                return true;
            }
            else if (Automobile[1, Index] == Input)
            {
                return true;
            }
            else if (Automobile[2, Index] == Input)
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
            Automobile = new string[3, Count];
            Traces = new Trace<string>[Count];
        }
    }
}
