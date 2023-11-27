using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex15
{
    internal class Faculty
    {
        string name;
        public string Name { get { return name; } set { name = value; } }
        List<Student> students = new List<Student>();
        public List<Student> Students { get {  return students; } }
        public Faculty() { }
        public Faculty(string name)
        {
               this.name = name;
        }
        public int TotalNumberOfRegularStudents=>students.FindAll(x=>x.IsRegular).Count();
        public Student HighestInGradeStudent => students.Count>0?students?.MaxBy(x => x.Grade):null;
        public List<Student> FindStudentByCity(string city)
        {
            List<Student> list = new List<Student>();
            foreach (var student in students)
            {
                if (student is InServiceStudent)
                {
                    InServiceStudent iss = (InServiceStudent)student;
                    if (iss.City == city)
                    {
                        list.Add(iss);
                    }
                }
            }
            return list;
        }
        public List<Student> FindOver8Student()
        {
            if(students.Count == 0) { return null; }
            List<Student> list = new List<Student>();
            foreach (var student in students)
            {
                if (8 < student.LearningOutcomes?[student.LearningOutcomes.Count-1].GPA)
                {
                    list.Add(student);
                }
            }
            return list;
        }
        public Student MaxGPAStudent => students?.MaxBy(x => x.MaxGPA);
        public void Sort(string s)
        {
            if(s =="1")
            {
                students?.Sort((x,y)=>x.CompareTo(y));
            }
            else if(s=="0")
            {
                students?.Sort((x,y)=>y.CompareTo(x));
            }
        }
        public void TotalStudentByYear()
        {
            
            var yearStudent = students.GroupBy(x => x.Year).Select(x => new { Year = x.Key,Total = x.Count() }) ;

            
            foreach(var pair in yearStudent)
            {
                Console.WriteLine($"{pair.Year}: {pair.Total}");
            }

        }
        public void AddStudent(Student student)
        {
             students?.Add(student);
        }



    }
}
