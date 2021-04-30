using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    class TransportComp: IEnumerable
    {
        int First = -1; 
        int End = -1;
        public int Count;
        AutoT[] Company;

        public TransportComp(int IntCount)
        {
            Company = new AutoT[IntCount];
            Count = IntCount;
        }

        public AutoT[] Company1 { get => Company; set => Company = value; }
        public int End1 { get => End; set => End = value; }

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
            Company[End] = new AutoT(Auto, GosNamber, Rider);
        }
        public void SearchAndAddTrace(string input, string Start, string Finish, int mass)
        {
            if (Search(input) != -1)
            {
                Company[Search(input)].GetTraces1().Add(new DoublyNode(Start, Finish, mass));
            }
        }
        public void SearchAndAddTrace(string input, string Start, string Finish, int mass, DateTime time)
        {
            if (Search(input) != -1)
            {
                Company[Search(input)].GetTraces1().Add(new DoublyNode(Start, Finish, mass, time));
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
                string Info = "Auto: " + Company[Index].Automobile1 + "\n" + "Nomber: " + Company[Index].GosNamber1 + "\n" + "Rider: " + Company[Index].Name1 + "\n" + Company[Index].GetTraces1().PrintAll();
                return Info;
            }
            else
            {
                return "Not found";
            }
        }
        public int Sum()
        {
            int sum = 0;
            foreach(AutoT i in Company)
            {
                sum = sum + i.GetTraces1().AllMass();
            }
            return sum;
        }

        public IEnumerator GetEnumerator()
        {
            return Company.GetEnumerator();
        }
    }
}
