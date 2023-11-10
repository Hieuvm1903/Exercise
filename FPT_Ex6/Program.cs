namespace FPT_Ex6
{
    internal class Program
    {

        static void Main(string[] args)
        {
            School school = new("Hust");
            school.AddStudent(new("Hieu", 20, "HaiPhong"), "A1");
            school.AddStudent(new("Duong", 23, "DaNang"), "A2");
            school.AddStudent(new("Minh", 20, "HaiPhong"), "A1");
            school.AddStudent(new("Long", 23, "DaNang"), "B2");
            school.AddStudent(new("Hoang", 20, "HaiPhong"), "A1");






            while (true)
            {
                Console.Clear();
                Console.WriteLine("""
                    0: Add new student
                    1: Show 20 years old students
                    2: Show 23 years old and come from DaNang students
                    3: Exit
                    """);
                if(int.TryParse(Console.ReadLine(), out int i))
                {
                    switch (i)
                    {
                        case 0:
                            {
                                while (true)
                                {
                                    Console.WriteLine("Enter student info: name, age, home, class ");
                                    Console.WriteLine("or enter exit to exit");
                                    string s = Console.ReadLine();
                                    if(s.Equals("exit"))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        try
                                        {
                                            string[] detail = s.Split(",");
                                            Student student = new(detail[0], int.Parse(detail[1]), detail[2]);
                                            school.AddStudent(student, detail[3]);
                                            Console.WriteLine("success");

                                        }
                                        catch
                                        {
                                            Console.WriteLine("Wrong format");
                                        }
                                    }


                                }
                                break;
                            }
                        case 1:
                            {
                                school.Show20YearsOldStudent();
                                break;
                            }
                            case 2:
                            {
                                Console.WriteLine($"There are {school.DaNangStudent()} 23 years old students come from DaNang");
                                break;
                            }
                            case 3:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Please input a valid number");

                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Please input a valid number");
                }
                Console.ReadKey();


            }
        }
    }
}