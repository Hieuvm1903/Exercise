namespace FPT_Ex15
{
    internal class Program
    {
        static List<Faculty> faculties = new List<Faculty>();
        static void Main(string[] args)
        {
            Init();
            while (true)
            {
                Console.WriteLine("""
                    0: Enter a Faculty name
                    1: Access to a Faculty
                    2: Exit
                    """);
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    if (0 <= value && value <= 2)
                    {
                        switch (value)
                        {
                            case 0:
                                {
                                    Console.WriteLine("0: Enter Faculty's name: ");
                                    faculties.Add(new(Console.ReadLine()));
                                    break;
                                }
                            case 1:
                                {
                                    Console.WriteLine("1: Enter Faculty's name: ");
                                    string s = Console.ReadLine();
                                    Faculty faculty = faculties.Find(x => x.Name == s);
                                    if (faculty == null)
                                    {
                                        Console.WriteLine("Name not found");
                                    }
                                    else
                                    {
                                        bool inloop = true;
                                        while (inloop)
                                        {
                                            Console.WriteLine("""
                                            Choose Action:
                                            0: Add new student
                                            1: Total number of regular student
                                            2: Highest entrance score student
                                            3: Find students by city
                                            4: Students have latest semester's GPA > 8.0
                                            5: Highest GPA student
                                            6: Sort student by year: 1:ascending, 0: descending
                                            7: Students by year
                                            8: Find student by id
                                            9: Back
                                            """);
                                            string read = Console.ReadLine();
                                            if (int.TryParse(read, out int i))
                                            {
                                                if (0 <= i && i <= 9)
                                                {
                                                    switch (i)
                                                    {
                                                        case 0:
                                                            {
                                                                Console.WriteLine("Enter student's info");
                                                                faculty.AddStudent(Input());
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                Console.WriteLine($"Total number of regular student: {faculty.TotalNumberOfRegularStudents}");
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                Console.WriteLine($"Highest entrance score student: {faculty.HighestInGradeStudent}");
                                                                Output(faculty.HighestInGradeStudent);
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                Console.WriteLine("Enter city's name");
                                                                List<Student> students = faculty.FindStudentByCity(Console.ReadLine());
                                                                if (students.Count > 0)
                                                                {
                                                                    foreach (Student student in students)
                                                                    {
                                                                        Console.WriteLine(student);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No city name found");
                                                                }


                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                Console.WriteLine("Students have latest semester's GPA > 8.0");
                                                                List<Student> students = faculty.FindOver8Student();
                                                                if (students.Count > 0)
                                                                {
                                                                    foreach (Student student in students)
                                                                    {
                                                                        Console.WriteLine(student);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No student found");
                                                                }
                                                                break;
                                                            }
                                                        case 5:
                                                            {
                                                                Console.WriteLine($"Highest GPA student: {faculty.MaxGPAStudent}");
                                                                Output(faculty.MaxGPAStudent);
                                                                break;
                                                            }
                                                        case 6:
                                                            {
                                                                Console.WriteLine("Enter order");
                                                                string order = Console.ReadLine();
                                                                if (order == "0" || order == "1")
                                                                {
                                                                    faculty.Sort(s);

                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Invalid Input");
                                                                    break;
                                                                }
                                                            }
                                                            break;

                                                        case 7:
                                                            {
                                                                faculty.TotalStudentByYear();
                                                                break;
                                                            }
                                                        case 8:
                                                            {
                                                                Console.WriteLine("Enter an id:");
                                                                string id = Console.ReadLine();
                                                                Student student = faculty.Students.Find(x=>x.Id == id);
                                                                if(student!=null)
                                                                {
                                                                    Console.WriteLine(student);
                                                                    Output(student);
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No id found");
                                                                }

                                                                break;
                                                            }
                                                        case 9:
                                                            {
                                                                inloop = false;
                                                                goto _continue;
                                                            }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid number 1");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Invalid number 2");
                                            }
                                            Console.ReadKey();

                                        }


                                    }
                                    
                                    break;
                                }
                            case 2:
                                {
                                    Environment.Exit(0);
                                    break;
                                }
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid number 3");

                    }

                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
                Console.ReadKey();
            _continue:

                Console.Clear();





            }
        }
        static Student Input()
        {
            try
            {
                Console.WriteLine("Enter student's info: id, name, date of birth (mm/dd/yy), year, entrance score");
                string[] s = Console.ReadLine().Split(',');
                string id = s[0].Trim();
                string name = s[1];
                DateTime dob = DateTime.Parse(s[2].Trim());
                int year = int.Parse(s[3].Trim());
                float score = float.Parse(s[4].Trim());
                Console.WriteLine("Choose student type: 0: regular, 1: in-service");
                string type = Console.ReadLine();
                if (type == "0")
                {
                    RegularStudent student = new RegularStudent(id,name,dob,year,score);
                    return student;
                }
                else
                if (type == "1")
                {
                    Console.WriteLine("Enter city's name");
                    string city = Console.ReadLine();
                    InServiceStudent student = new InServiceStudent(id, name, dob, year, score,city);
                    return student;

                }
                else
                {
                    Console.WriteLine("Wrong type");
                }
            }
            catch (FormatException fe)
            {
                Console.WriteLine("Wrong number format");
            }
            catch { Console.WriteLine("Wrong format"); }


            return null;
        }
        static void Output(Student student)
        {
            if (student == null) return;
            Console.WriteLine("""
                0: Is student regular
                1: GPA base on semester
                2: Add new Semester
                3: Back
                """);
            string s = Console.ReadLine();
            if(s == "0")
            {
                Console.WriteLine(student.IsRegular);
            }
            else if (s=="1")
            {
                Console.WriteLine("Enter semester");
                string name = Console.ReadLine();
                LearningOutcome lo = student.LearningOutcomes?.Find(x => x.SemesterName == name);
                if(lo != null)
                {
                    Console.WriteLine($"Semester {lo.SemesterName} GPA:{lo.GPA}");
                }
                else
                {
                    Console.WriteLine("Not found");
                }
            }
            else if(s=="2")
            {
                try
                {
                    Console.WriteLine("Enter semester's info: name, gpa");
                    string[] semester = Console.ReadLine().Split(',');
                    student.LearningOutcomes.Add(new(semester[0], float.Parse(semester[1])));
                }
                catch
                {
                    Console.WriteLine("Wrong semester format");
                }
            }
                                   
            if(s=="3")
            {
                return;
            }
            else
            {
                Console.WriteLine("Wrong format");
            }
        }
        static void Init()
        {
            faculties.Add(new("Sami"));
            faculties.Add(new("Sep"));
            faculties.Add(new("Sef"));
            faculties.Add(new("Soict"));
        }
    }
}