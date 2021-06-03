using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Transport_company
{
    [Serializable]
    public class AutoT
    {
        String Automobile;
        string GosNamber;
        string Name;
        Trace Traces;

        //public AutoT()
        //{
        //    Automobile = "";
        //    GosNamber = "";
        //    Name = "";
        //}

        public AutoT()
        {
            Automobile1 = "";
            GosNamber1 = "";
            Name1 = "";
        }

        public AutoT(string automobile1, string gosNamber1, string name1)
        {
            Automobile1 = automobile1;
            GosNamber1 = gosNamber1;
            Name1 = name1;
            SetTraces1(new Trace());
        }
        
        public string Automobile1 { get => Automobile; set => Automobile = value; }
        public string GosNamber1 { get => GosNamber; set => GosNamber = value; }
        public string Name1 { get => Name; set => Name = value; }
        public Trace Traces1 { get => Traces; set => Traces = value; }

        public Trace GetTraces1()
        {
            return Traces1;
        }

        public void SetTraces1(Trace value)
        {
            Traces1 = value;
        }
    }
}
