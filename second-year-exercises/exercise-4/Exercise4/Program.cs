using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Person donald = new Person("Donald", "Truck"); //Konstruktor
            donald.Age = 112;

            Console.WriteLine(donald.Info());

            /*Person putin = new Person();
            putin.FirstName = "Putin";
            putin.LastName = "Okto";
            putin.Age = 20;*/

            Person putin = new Person("Putin", "Okto");
            putin.Age = 20;

            Console.WriteLine(putin.Info());

            //Console.WriteLine("lastName : {0} firstName: {1}", donald.LastName, donald.FirstName);
            //Console.WriteLine("lastName : {0}{1}firstName: {2}", donald.LastName, "\n", donald.FirstName);

            Console.ReadKey();
        }
    }
}
