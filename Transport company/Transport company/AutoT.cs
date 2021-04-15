using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport_company
{
    public class AutoT<T>
    {
        String Automobile;
        string GosNamber;
        string Name;
        public Trace<string> Traces;

        //public AutoT()
        //{
        //    Automobile1 = "";
        //    GosNamber1 = "";
        //    Name1 = "";
        //}

        public string Automobile1 { get => Automobile; set => Automobile = value; }
        public string GosNamber1 { get => GosNamber; set => GosNamber = value; }
        public string Name1 { get => Name; set => Name = value; }
        
    }
}
