using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex13
{
    internal class Fresher : Employee
    {
        private DateTime graduationDate;
        public DateTime GraduationDate { get { return graduationDate; }set { graduationDate = value; } }
        private Rank graduationRank;
        public Rank GraduationRank { get { return graduationRank; }set { graduationRank = value; } }
        private string education;
        public string Education { get { return education; } set { education = value; } }

        public Fresher(int id, string name, string phone, string email,DateTime dob,Rank rank, string education,DateTime graduationDate) : base(id, name, phone, email,dob)
        {
            this.graduationDate = graduationDate;
            this.graduationRank = rank;
            this.education = education;
            type = EmployeeType.Fresher;
        }

        public override string ShowInfo()
        {
            return $"{GraduationDate},{GraduationRank},{Education}";
        }
        
    }
    public enum Rank
    {
        Excellent,
        VeryGood,
        Good

    }

}
