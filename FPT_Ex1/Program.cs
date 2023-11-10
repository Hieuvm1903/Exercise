namespace FPT_Ex1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OnInit();
            int i;
            int j;
            bool rightType;
            bool rightFormat;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Input a number from 0 to 3:");
                Console.WriteLine("""
                    0: Add new employee.
                    1: Find employee by name
                    2: Show employees's info
                    3: Exit
                    """);
                rightFormat = Int32.TryParse(Console.ReadLine(), out i);
                if (rightFormat)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                bool inLoop = true;
                                while (inLoop)
                                {
                                    Console.WriteLine("Please fill in employee's info");
                                    Console.WriteLine("""
                                    0: Worker
                                    1: Officer
                                    2: Engineer
                                    3: Back
                                    """);
                                    rightType = int.TryParse(Console.ReadLine(), out j);
                                    if (rightType && 0 <= j && j <= 3)
                                    {
                                        switch (j)
                                        {
                                            case 0:
                                                {
                                                    Console.WriteLine("Input Worker's info");
                                                    Console.WriteLine("name, age, address, gender(Male, Female, Other), level ");

                                                    try
                                                    {
                                                        string info = Console.ReadLine();
                                                        string[] infos = info.Split(",");
                                                        Gender gender = (Gender)Enum.Parse(typeof(Gender), infos[3]);
                                                        Employee worker = new Worker(infos[0], uint.Parse(infos[1]), infos[2], gender, int.Parse(infos[4]));
                                                        EmployeeManager.Add(worker);
                                                        Console.WriteLine("Success");
                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Wrong format");
                                                    }

                                                    break;
                                                }
                                            case 1:
                                                {
                                                    Console.WriteLine("Input Officer's info");
                                                    Console.WriteLine("name, age, address, gender(Male, Female, Other), job ");

                                                    try
                                                    {
                                                        string info = Console.ReadLine();
                                                        string[] infos = info.Split(",");
                                                        Gender gender = (Gender)Enum.Parse(typeof(Gender), infos[3]);
                                                        Employee officer = new Officer(infos[0], uint.Parse(infos[1]), infos[2], gender, infos[4]);
                                                        EmployeeManager.Add(officer);
                                                        Console.WriteLine("Success");

                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Wrong format");

                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.WriteLine("Input Engineer's info");
                                                    Console.WriteLine("name, age, address, gender(Male, Female, Other), major ");
                                                    try
                                                    {
                                                        string info = Console.ReadLine();
                                                        string[] infos = info.Split(",");
                                                        Gender gender = (Gender)Enum.Parse(typeof(Gender), infos[3]);
                                                        Employee engineer = new Engineer(infos[0], uint.Parse(infos[1]), infos[2], gender, infos[4]);
                                                        EmployeeManager.Add(engineer);
                                                        Console.WriteLine("Success");

                                                    }
                                                    catch
                                                    {
                                                        Console.WriteLine("Wrong format");

                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    inLoop = false;

                                                    break;
                                                }
                                            default:
                                                {
                                                    
                                                    break;
                                                }

                                        }
                                    }
                                    else
                                    {
                                        inLoop = false;
                                        Console.WriteLine("Please try again");
                                    }
                                }
                                break;
                            }
                        case 1:
                            {
                                string s = Console.ReadLine();
                                EmployeeManager.Find(s);
                                break;
                            }
                        case 2:
                            {
                                EmployeeManager.Show();
                                break;
                            }
                        case 3:
                            {
                                EmployeeManager.Exit();
                                break;
                            }
                        default:
                            {
                                Retry();
                                break;
                            }


                    }
                    Console.ReadKey();

                }
                else
                {
                    Retry();
                }
            }


        }
        static void Retry()
        {
            Console.WriteLine("Please input a valid number");
            Console.ReadKey();
        }
        static void OnInit()
        {
            Employee e1 = new Worker("John", 25, "NewYork", Gender.Male, 1);
            Employee e2 = new Worker("Karen", 32, "Washinton DC", Gender.Female, 3);
            Employee e3 = new Worker("Ben", 20, "Vancouver", Gender.Male, 5);

            Employee e4 = new Officer("Jessica", 22, "London", Gender.Female, "Accountancy");
            Employee e5 = new Officer("Bob", 40, "Manchester", Gender.Male, "Manager");
            Employee e6 = new Officer("Natasha", 25, "Moscow", Gender.Female, "Accountancy");

            Employee e7 = new Engineer("Arthur", 30, "Hanoi", Gender.Male, "Electric");
            Employee e8 = new Engineer("Henry", 28, "HCM city", Gender.Male, "IT");
            EmployeeManager.Add(e1);
            EmployeeManager.Add(e2);
            EmployeeManager.Add(e3);
            EmployeeManager.Add(e4);
            EmployeeManager.Add(e5);
            EmployeeManager.Add(e6);
            EmployeeManager.Add(e7);
            EmployeeManager.Add(e8);



        }
    }
}