using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex6
{
    internal class School
    {
        private string name;
        List<Class> classes = new();
        public School(string name)
        {
            this.name = name;
        }
        public void AddStudent(Student student,string className) 
        {
            Class c = classes.Find(x => x.Name == className);
            if (c == null)
            {
                c = new Class(className);
                classes.Add(c);
            }
            c.Add(student);
        }
        public void Show()
        {
            Console.WriteLine($"School: {name}");
            foreach (Class c in classes)
            {
                c.ShowStudentInfo();
            }
        }
        public void Show20YearsOldStudent()
        {
            List<Student> students = new List<Student>();
            foreach(var c in classes)
            {
                students.AddRange(c.Students.FindAll(x => x.Age == 20));
            }
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }
        public int DaNangStudent()
        {
            int i = 0;
            string home = "DaNang";
            foreach (var c in classes)
            {
                i += c.Students.FindAll(x => x.Age == 23 && x.Home == home).Count;
            }
            return i;
        }


    }
}
