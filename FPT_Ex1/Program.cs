using System.Runtime.CompilerServices;

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
                                string name = "", address = "", gender = "";
                                uint age = 0;
                                Gender _gender = Gender.Other;
                                bool rightName = false, rightAddress = false, rightGender = false, rightAge = false;
                                while (inLoop)
                                {
                                    while(!(rightGender && rightName&&rightGender&&rightAge))
                                    {
                                        Console.Clear();
                                        try
                                        {
                                            if (!rightName)
                                            {
                                                Console.WriteLine("Enter name");
                                                name = Console.ReadLine();
                                                rightName = !string.IsNullOrEmpty(name);
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Name: {name}");
                                            }
                                            if (!rightAge)
                                            {
                                                Console.WriteLine("Enter age");
                                                age = uint.Parse(Console.ReadLine());
                                                rightAge = age > 0;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Age:{age}");
                                            }
                                            if (!rightAddress)
                                            {
                                                Console.WriteLine("Enter address");
                                                address = Console.ReadLine();
                                                rightAddress = !string.IsNullOrEmpty(address);
                                            }
                                            else
                                            { Console.WriteLine($"Address: {address}"); }
                                            if (!rightGender)
                                            {
                                                Console.WriteLine("Enter gender");
                                                gender = Console.ReadLine();
                                                rightGender = Enum.TryParse(gender,out _gender);                                               
                                            }
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine("Wrong format");
                                        }
                                    }
                                    
                                    Console.WriteLine("Please fill choose employee's type");
                                    Console.WriteLine("""
                                    0: Worker
                                    1: Officer
                                    2: Engineer                                   
                                    """);
                                    rightType = int.TryParse(Console.ReadLine(), out j);
                                    if (rightType && 0 <= j && j <= 2)
                                    {
                                        switch (j)
                                        {
                                            case 0:
                                                {
                                                    Console.WriteLine("Input Worker's Level");
                                                    if (int.TryParse(Console.ReadLine(), out int lvl))
                                                    {
                                                        if (0 <= lvl && lvl <= 10)
                                                        {
                                                            EmployeeManager.Add(new Worker(name, age, address, _gender, lvl));
                                                            inLoop = false;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Invalid number");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid number");
                                                    }
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    Console.WriteLine("Input Officer's job");
                                                    string job = Console.ReadLine();
                                                    EmployeeManager.Add(new Officer(name, age, address, _gender, job));
                                                    inLoop = false;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    Console.WriteLine("Input Engineer's major");
                                                    string major = Console.ReadLine();
                                                    EmployeeManager.Add(new Engineer(name, age, address, _gender, major));
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