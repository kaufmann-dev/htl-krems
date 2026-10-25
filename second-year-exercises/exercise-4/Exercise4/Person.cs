using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    public class Person
    {
        private int age;
        public string LastName { get; /*set;*/ }
        public string FirstName { get; /*set;*/ }
        public Person( string lastName, string firstName)
        {
            LastName = lastName;
            FirstName = firstName;
            //Console.WriteLine("Person is being created...");
        }
        public int Age
        {
            get => age;
            set
            {
                if (value < 0 || value > 130)
                {
                    throw new Exception("Age value not valid!");
                }
                age = value;
            }
        }
        public string Info()
        {
            return $"firstName: {FirstName} lastName: {LastName} age:{Age}";
        }
    }
}
