using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex1
{
    internal class Officer:Employee
    {
        private string job;
        public string Job {  get { return job; } set { job = value; } }
        public Officer(string name, uint age, string address, Gender gt,string job) : base(name, age, address, gt)
        {
            type = EmployeeType.Officer;
            this.job = job;
        }
        public override string ToString()
        {
            return "Officer "+base.ToString()+$"Job: {job}";
        }
    }
}
