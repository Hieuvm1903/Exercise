using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex13
{
    internal class Experience : Employee
    {
        private int expInYear;
        private string proSkill;

        public int ExpInYear { get { return expInYear; }set { expInYear = value; } }
        public string ProSkill { get { return proSkill; }set { proSkill = value; } }
        public Experience(int id, string name, string phone, string email,DateTime dob,int expInYear,string proSkill) : base(id, name, phone, email, dob)
        {
            this.expInYear = expInYear;
            this.proSkill = proSkill;
            type = EmployeeType.Experience;
        }

        public override string ShowInfo()
        {
            return $"{expInYear},{proSkill}";
        }
    }
}
