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
        [Range(0,10,ErrorMessage = "Level must be between 0 and 10")]
        private int level;
        public int Level { get { return level; }
            set {
                level = value; 
            } }
        public Worker(string name, uint age, string address, Gender gt, int lvl ):base(name, age, address, gt)
        {
            type  = EmployeeType.Worker;
            level = lvl;
            level = 15;
            
        }
        public override string ToString()
        {
            return "Worker "+ base.ToString()+$" Level: {level}";
        }
    }
}
