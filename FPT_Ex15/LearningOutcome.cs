using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex15
{
    internal class LearningOutcome
    {
        string semesterName;
        public string SemesterName {  get { return semesterName; } set { semesterName = value; } }
        float gpa;
        public float GPA { get { return gpa; } set { gpa = value; } }
        public LearningOutcome(string semesterName, float gpa)
        {
            this.semesterName = semesterName;
            this.gpa = gpa;
        }
    }
}
