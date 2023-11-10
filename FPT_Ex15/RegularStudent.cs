using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex15
{
    internal class RegularStudent:Student           
    {
        public RegularStudent() { }
        public RegularStudent(string id, string name, DateTime dob, int year, float inGrade) : base(id, name, dob, year, inGrade)
        {

        }
        public RegularStudent(RegularStudent student):base(student)
        {

        }
    }
}
