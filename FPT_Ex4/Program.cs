namespace FPT_Ex4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exit = "Exit";
            Street street = new Street();
            Console.WriteLine("Enter a number");
            bool rightFormat = int.TryParse(Console.ReadLine(),out int n);
            if (rightFormat)
            {


                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter home number");
                    if (int.TryParse(Console.ReadLine(), out int number))
                    {
                        if (street.FindHomeByID(number))
                        {
                            Console.WriteLine("Duplicate number");
                            i--;
                        }
                        else
                        {
                            Home home = new(number);
                            while (true)
                            {
                                Console.WriteLine("""
                                Enter Person info: id, name, age, job
                                or 'Exit' to exit
                                """);
                                try
                                {
                                    string info = Console.ReadLine();
                                    if (info.Equals(exit))
                                    {
                                        break;
                                    }
                                    string[] detail = info.Split(",");
                                    if (detail[0].Any(char.IsLetter) || detail[0].Length != 6)
                                    {
                                        Console.WriteLine("Wrong format!");
                                        continue;
                                    }
                                    else
                                    {
                                        Person p = new Person(detail[0], detail[1], int.Parse(detail[2]), detail[3]);
                                        home.Add(p);
                                        Console.WriteLine("Success");

                                    }

                                }
                                catch
                                {
                                    Console.WriteLine("Wrong input");
                                }
                            }
                            street.Add(home);

                        }

                    }
                    else
                    {
                        Console.WriteLine("Wrong format");
                    }



                }
                Console.Clear();
                street.ShowInfo();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Wrong format");
            }




        }
    }
}