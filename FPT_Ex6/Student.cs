using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex6
{
    internal class Student
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int age;
        public int Age { get { return age; } set { age = value; } }
        private string home;
        public string Home { get { return home; } set { home = value; } }
        public Student(string name, int age, string home) 
        { 
            this.name = name;
            this.age = age;
            this.home = home;

        }
        public override string ToString()
        {
            return $"Name: {name}, Age: {age}, Home: {home}";
        }
    }
}
