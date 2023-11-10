using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex13
{
    internal class Intern : Employee
    {
        private string majors;
        private string semester;
        private string university;

        public string Majors { get { return majors; }set { majors = value; } }
        public string Semester { get { return semester; } set { semester = value; } }
        public string University { get { return university; }set { university = value; } }
        public Intern(int id, string name, string phone, string email,DateTime dob, string majors, string semester,string uni)
            :base(id,name,phone,email, dob)
        {
            this.majors = majors;
            this.semester = semester;
            this.university = uni;
            type = EmployeeType.Intern;
        }
        public override string ShowInfo()
        {
            return $"{Majors},{Semester},{University}";
        }
    }
}
