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
        string[,] Automobile = new string[3,Count];//1 строчка авто, 2 строчка номер, 3 строчка имя

        public void Add(string Auto, string GosNamber, string Rider)
        {
            if(End == -1 | End < First)
            {
                First++;
                OnlyAdd(Auto, GosNamber, Rider);
            }
            else
            {
                if(End == Count - 1)
                {
                    End = -1;
                    Add(Auto, GosNamber, Rider);
                }
            }
        }
        private void OnlyAdd(string Auto, string GosNamber, string Rider)
        {
            End++;
            Automobile[0, End] = Auto;
            Automobile[1, End] = GosNamber;
            Automobile[2, End] = Rider;
        }
        public string Print(int Index)
        {
            string Info = "Auto: " + Automobile[0, Index] + "\n" + "Nomber: " + Automobile[1, Index] + "\n" + "Rider: " + Automobile[2, Index];
            return Info;
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
    }
}
