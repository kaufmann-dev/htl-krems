using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Benzinrechner
            int getankteLiter = 0;
            int gefahreneKM = 0;

            double verbrauch = 0;
            string eingabeText;

            Console.WriteLine("Benzinverbrauch V1.0");
            Console.WriteLine("=================================================");
            Console.Write("getankteLiter Liter");

            //ZIEL = QUELLE;
            eingabeText = Console.ReadLine();

            //Console.WriteLine("Ihre Eingabe: " + eingabeText);
            getankteLiter = Convert.ToInt32(eingabeText);
            Console.WriteLine("Liter: "+getankteLiter);

            Console.WriteLine("Geafhrene Kilometer: ");
            eingabeText = Console.ReadLine();
            gefahreneKM = Convert.ToInt32(eingabeText);

            //Verbrauch in Litern pro 100 KM

            verbrauch = (double)getankteLiter / gefahreneKM * 100;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Verbrauch: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(verbrauch);

            Console.ReadLine();
        }
    }
}
