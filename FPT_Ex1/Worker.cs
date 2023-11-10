using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FPT_Ex1
{
    internal class Worker:Employee
    {
        private int level;
        [Range(0, 10, ErrorMessage = "Level must be between 0 and 10")]

        public int Level { get { return level; }
            set {
                level = value; 
            } }
        public Worker(string name, uint age, string address, Gender gt, int lvl ):base(name, age, address, gt)
        {
            type  = EmployeeType.Worker;
            Level = lvl;            
        }
        public override string ToString()
        {
            return "Worker "+ base.ToString()+$" Level: {level}";
        }
    }
}
