namespace FPT_Ex3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OnInit();
            int i ;
            bool rightFormat;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("""
                    0: Add new candidate;
                    1: Show candidate's infomation
                    2: Find candidate by id
                    3: Exit
                    """);
                rightFormat = int.TryParse(Console.ReadLine(), out i);
                if (rightFormat)
                {
                    switch (i)
                    {
                        case 0:
                            {
                                bool inLoop = true;
                                while (inLoop)
                                {




                                    Console.WriteLine("""
                                    a: Block A candidate
                                    b: Block B candidate
                                    c: Block C candidate
                                    exit: Exit
                                    """);
                                    string block = Console.ReadLine();
                                    switch (block)
                                    {
                                        case "a":
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter block A candidate's info: id, name, address, level");
                                                    string info = Console.ReadLine();
                                                    string[] details = info.Split(",");
                                                    var can = new ACandidate(int.Parse(details[0]), details[1], details[2], int.Parse(details[3]));
                                                    ManagerCandidate.Add(can);

                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Wrong format, try again");
                                                }
                                                break;
                                            }
                                        case "b":
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter block B candidate's info: id, name, address, level");
                                                    string info = Console.ReadLine();
                                                    string[] details = info.Split(",");
                                                    var can = new BCandidate(int.Parse(details[0]), details[1], details[2], int.Parse(details[3]));
                                                    ManagerCandidate.Add(can);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Wrong format, try again");
                                                }

                                                break;
                                            }
                                        case "c":
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter block C candidate's info: id, name, address, level");
                                                    string info = Console.ReadLine();
                                                    string[] details = info.Split(",");
                                                    var can = new CCandidate(int.Parse(details[0]), details[1], details[2], int.Parse(details[3]));
                                                    ManagerCandidate.Add(can);
                                                }
                                                catch
                                                {
                                                    Console.WriteLine("Wrong format, try again");
                                                }

                                                break;
                                            }
                                        case "exit":
                                            {
                                                inLoop = false;
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("Wrong input, try again");
                                                break;
                                            }
                                    }
                                }
                                break;
                            }
                        case 1:
                            {
                                ManagerCandidate.Show();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Enter ID:");
                                bool rightID = int.TryParse(Console.ReadLine(),out int id);
                                if(rightID)
                                {
                                   Candidate c = ManagerCandidate.FindByID(id);
                                    if(c!=null)
                                    {
                                        Console.WriteLine(c);
                                    }
                                    else
                                    {
                                        Console.WriteLine("No match found");
                                    }
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Wrong format");
                                }
                                
                                break;
                            }
                        case 3:
                            {
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Number must be from 0 to 3");
                                break;

                            }
                    }
                }
                else
                {
                    Console.WriteLine("Wrong format");
                }
                Console.ReadKey();



            }
        }
        static void OnInit()
        {
            var c1 = new ACandidate(1, "Hieu", "Hai Phong", 1);
            var c2 = new BCandidate(2, "Minh", "Ha Noi", 2);
            var c3 = new ACandidate(3, "Nghia", "Thanh Hoa", 3);
            var c4 = new CCandidate(5, "Thanh", "Vinh Phuc", 1);
            var c5 = new ACandidate(7, "Duc", "Lang Son", 2);
            var c6 = new CCandidate(9, "Long", "Da Nang", 3);
            var c7 = new BCandidate(12, "Duong", "Ha Noi", 1);
            ManagerCandidate.Add(c1);
            ManagerCandidate.Add(c2);
            ManagerCandidate.Add(c3);
            ManagerCandidate.Add(c4);
            ManagerCandidate.Add(c5);
            ManagerCandidate.Add(c6);
            ManagerCandidate.Add(c7);

        }
    }
}