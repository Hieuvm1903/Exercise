using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex15
{
    internal class InServiceStudent:Student
    {
        string city;
        public string City { get { return city; } set { city = value; } }
        public InServiceStudent() { }
        public InServiceStudent(string id, string name, DateTime dob, int year, float inGrade,string city):base(id,name,dob, year,inGrade)
        { 
            this.city = city;
        }
        public InServiceStudent(InServiceStudent student):base(student) 
        { 
            this.city = student.City;
        }

    }
}
