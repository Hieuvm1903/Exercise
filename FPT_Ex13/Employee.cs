using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex13
{
    internal abstract class Employee
    {
        private int id;
        private string name;
        private string phone;
        private string email;
        private DateTime dob;
        protected EmployeeType type;
        protected List<Certificate> certificates = new List<Certificate>();


        public int ID { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Phone { get { return phone; } set { phone = value; } }
        public string Email { get { return email; } set { email = value; } }
        public DateTime DateOfBirth { get { return dob; } set { dob = value; } }
        public EmployeeType Type { get { return type; } set { type = value; } }
        public List<Certificate> Certificates { get { return certificates; }  }
        public static int EmployeeCount=>Manager.Employees.Count;
        public Employee(int id, string name, string phone, string email,DateTime dob) 
        { 
            this.id = id;
            this.name = name;
            this.phone = phone;
            this.email = email;
            this.dob = dob;
        
        }
        public abstract string ShowInfo();
        public override string ToString()
        {
            return $"{ID},{Name},{Phone},{Email}";
        }




    }
    public enum EmployeeType
    {
        Experience,
        Fresher,
        Intern
    }
}
