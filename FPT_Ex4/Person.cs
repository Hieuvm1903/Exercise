using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex4
{
    internal class Person
    {
        private string identityCard;
        public string IdentityCard { 
            get { return identityCard; } 
            set {
                identityCard = value;
            } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private int age;
        public int Age { get { return age; } set { age = value; } }
        private string job;
        public string Job { get { return job; } set { job = value; } }
        public override string ToString()
        {
            return $"ID: {identityCard}, Name: {name}, Age: {age}, Job: {job}";
        }
        public Person(string id, string name, int age, string job)
        {
            IdentityCard = id;
            this.name = name;
            this.age = age;
            this.job = job;
        }



    }
}
