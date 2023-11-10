using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex1
{
    internal class Engineer:Employee
    {
        private string major;
        public string Major { get { return major; } set { major = value; } }
        public Engineer(string name, uint age, string address, Gender gt,string major) : base(name, age, address, gt)
        {
            type = EmployeeType.Engineer;
            this.major = major;
        }
        public override string ToString()
        {
            return "Engineer " +base.ToString()+$" Major: {major}";
        }
    }
}
