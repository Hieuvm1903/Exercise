using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex4
{
    internal class Street
    {
        private List<Home> homes = new List<Home>();
        public void ShowInfo()
        {
            foreach (Home home in homes)
            {
                home.ShowInfo();
            }
        }
        public void Add(Home home)
        {
            homes.Add(home);
        }
        public bool FindHomeByID(int id)
        {
            return homes.Find(x=>x.Number==id)!= null;
        }
    }
}
