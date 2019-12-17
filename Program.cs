using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace powto1
{
    class Program
    {
        static void Main(string[] args)
        { 

            Konto k1 = new Konto("adolf");
            Konto k2 = new Konto("benito");
            k1._stanKonta = 100.00;
            Console.WriteLine("konto2:");
            Console.WriteLine(k2.ToString());
            KontoSkarbonka k3 = new KontoSkarbonka("mamed");
            k3._stanKonta = 200;
            k3.Wyplac(50);
            Console.WriteLine(k3.ToString());
            Bank bank1 = new Bank("banko1");
            bank1.UtworzKonto(k1);
            bank1.UtworzKonto(k2);
            Console.WriteLine(bank1);
            Console.ReadKey();
            // Bank.zapiszplik("elo.xml");
            // DataSerializer 
        }
    }
}
