using System;
using System.IO;
using Transport_company;
using System.Xml.Serialization;

namespace TestAuto
{
    class Program
    {
        static void Main(string[] args)
        {
            auto Basa = new auto(); XmlSerializer formatter = new XmlSerializer(typeof(auto));
            string Auto, Number, Rider, Sr = "";
            Console.WriteLine("ВВедите поочередно название авто, номер авто и имя водителя");
            Auto = Console.ReadLine();
            Number = Console.ReadLine();
            Rider = Console.ReadLine();
            Basa.Add(Auto, Number, Rider);
            Console.WriteLine("Введите о чем хотите вывести информацию");
            Sr = Console.ReadLine();
            Console.WriteLine(Basa.SearchAndPrint(Sr));

        }
    }
}
