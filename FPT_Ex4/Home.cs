using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex4
{
    internal class Home
    {
        private List<Person> persons = new();
        public int Members => persons.Count;
        private int number;
        public int Number { get { return number; } set { number = value; } }
        public Home(int number)
        {
            this.number = number;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"House {number}:");
            foreach (Person person in persons)
            {
                Console.WriteLine(person);
            }
        }
        public void Add(Person person)
        { persons.Add(person);}
    }
}
