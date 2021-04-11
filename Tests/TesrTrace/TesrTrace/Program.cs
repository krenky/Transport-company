using System;
using Transport_company;

namespace TesrTrace
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace<string> Test = new Trace<string>();
            Test.Add("Вологда", "Казань");
            Test.Add("Вологда12", "Казан2ь");
            Test.Add("Вологд23а", "Казан323ь");
            Console.WriteLine(Test.PrintAll());
        }
    }
}
