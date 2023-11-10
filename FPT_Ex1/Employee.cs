using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex1
{
    internal abstract class Employee
    {
        private uint age;
        public uint Age {  get { return age; } set {  age = value; } }
        private string name;
        public string Name { get { return name; } set { name = value; } }
        private string address;
        public string Address { get { return address; } set { address = value; } }
        private Gender gender;
        public Gender m_Gender { get { return gender; } set { gender = value; } }
        protected EmployeeType type;
        public Employee(string name,uint age, string address,Gender gt)
        {
            this.name = name;
            this.address = address;
            this.gender = gt;
            this.age = age;
        }
        public override string ToString()
        {
            return $"Name: {name}, Age: {age}, Gender: {gender}, Address: {address}";
        }


    }
    public enum EmployeeType
    {
        Worker,
        Officer,
        Engineer

    }


    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
