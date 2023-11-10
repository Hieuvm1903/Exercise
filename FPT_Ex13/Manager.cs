using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex13
{
    internal static class Manager
    {
        static List<Employee> employees = new List<Employee>();
        public static List<Employee> Employees {  get { return employees; } }
        static Manager()
        {
            Init();
        }
        static void Init()
        {
            employees = new List<Employee>()
            {
                new Experience(1,"Hieu","123456798","HieuVm1903@gmail.com",new DateTime(2001,03,19),1,".Net"),
                new Fresher(2,"John","79815123","abc@gmail.com",new DateTime(2001,01,21),Rank.Excellent,"Hust",new DateTime(2023,9,15)),
                new Intern(3,"Dave","123549871","xyz@fpt.com",new DateTime(2001, 03, 13),"Maths","2023A","Hust")

            };
            employees[0].Certificates.AddRange(new[] {
                new Certificate("1", "AWS", "rank A", new DateTime(2023, 1, 1)),
                new Certificate("2", "AMZ", "rank B", new DateTime(2022, 12, 11)),
                new Certificate("3", "MUN", "Good", new DateTime(2021, 11, 11)) }
                );
            employees[1].Certificates.AddRange(new[] {
                new Certificate("11", "DAS", "rank A", new DateTime(2020, 2, 9)),
                new Certificate("21", "FHU", "globe", new DateTime(2021, 5, 21)),
                new Certificate("31", "AWS", "rank C", new DateTime(2021, 7, 11)) }
                );
            employees[2].Certificates.AddRange(new[] {
                new Certificate("41", "AWS", "Long", new DateTime(2021, 8, 30)),
                new Certificate("52", "AWE", "rank A", new DateTime(2021, 10, 12)),
                new Certificate("36", "EVO", "rank A", new DateTime(2021, 6, 1)) }
                );
        }
    }
}
