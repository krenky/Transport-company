using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    class TransportComp
    {
        int First, End = -1;
        static int Count = 5;
        AutoT<string>[] Company = new AutoT<string>[Count];
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
        private void OnlyAdd(string Auto, string GosNamber, string Rider)
        {
            End++;
            Company[End].Automobile1 = Auto;
            Company[End].GosNamber1 = GosNamber;
            Company[End].Name1 = Rider;
            Company[End].Traces = new Trace<string>();
        }
        public void SearchAndAddTrace(string input, string Start, string Finish, int mass)
        {
            if (Search(input) != -1)
            {
                Company[Search(input)].Traces.Add(Start, Finish, mass);
            }
        }
        public int Search(string Input)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Comparison(Input, i))
                {
                    return i;
                }
            }
            return -1;
        }
        private bool Comparison(string Input, int Index)
        {
            if (Company[Index].Automobile1 == Input)
            {
                return true;
            }
            else if (Company[End].GosNamber1 == Input)
            {
                return true;
            }
            else if (Company[End].Name1 == Input)
            {
                return true;
            }
            else return false;
        }
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
        public string Print(int Index)
        {
            if (Index != -1)
            {
                string Info = "Auto: " + Company[Index].Automobile1 + "\n" + "Nomber: " + Company[Index].GosNamber1 + "\n" + "Rider: " + Company[Index].Name1 + "\n" + Company[Index].Traces.PrintAll();
                return Info;
            }
            else
            {
                return "Not found";
            }
        }
    }
}
