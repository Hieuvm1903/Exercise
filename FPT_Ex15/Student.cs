using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex15
{
    internal abstract class Student:IComparable<Student>
    {
        string id;
        public string Id { get { return id; } set { id = value; } }
        string name;
        public string Name { get { return name; } set { name = value; } }
        DateTime dob;
        public DateTime Dob { get { return dob; }set { dob = value; } }
        int year;
        public int Year { get { return year; } set { year = value; } }
        float inGrade;
        public float Grade { get {  return inGrade; } set {  inGrade = value; } }
        List<LearningOutcome> outcomes = new List<LearningOutcome>();
        public List<LearningOutcome> LearningOutcomes { get { return outcomes; } }
        public Student() { }
        public Student(string id,string name,DateTime dob,int year,float inGrade)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.year = year;
            this.inGrade = inGrade;

        }
        public Student(Student student)
        {
            this.id = student.id;
            this.name = student.name;
            this.dob = student.dob;
            this.year = student.year;
            this.inGrade = student.inGrade;
        }
        public bool IsRegular => this is RegularStudent;
        public bool SemesterGPA(string semester,out float GPA)
        {
            LearningOutcome lo = outcomes.Find(x => x.SemesterName == semester);
            if (lo !=null)
            {
                GPA = lo.GPA;
                return true;
            }

            Console.WriteLine("Invalid semester name");
            GPA = 0;
            return false;
        }
        public int CompareTo(Student? other)
        {
            if(other == null) return 1;
            return year.CompareTo(other.year);
        }
        public float MaxGPA => LearningOutcomes.Max(x => x.GPA);
        public override string ToString()
        {
            return $"Id: {id}, Name: {name}, DateOfBirth: {dob}, Year: {year}, Entrance score: {inGrade}";
        }



    }
}
