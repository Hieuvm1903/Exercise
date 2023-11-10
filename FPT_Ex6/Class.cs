using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex6
{
    internal class Class
    {
        string name;
        public string Name {  get { return name; } set {  name = value; } }
        List<Student> students = new List<Student>();
        public List<Student> Students { get { return students; } }

        public Class(string name)
        { this.name = name; }
        public void ShowStudentInfo()
        {
            Console.WriteLine($"Class {name}:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        public void Add(Student student)
        {
            students.Add(student);
        }
        

    }
}
