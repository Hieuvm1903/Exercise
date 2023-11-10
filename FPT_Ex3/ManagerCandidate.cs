using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex3
{
    internal static class ManagerCandidate
    {
        static List<Candidate> candidates = new List<Candidate>();
        public static void Add(Candidate candidate)
        {
            if (FindByID(candidate.ID) != null)
            {
                Console.WriteLine("Duplicate ID");
                return;
            }
            candidates.Add(candidate);
            Console.WriteLine("Success");
        }
        public static Candidate FindByID(int id)
        {
            Candidate result = candidates.Find(x => x.ID == id);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public static void Show()
        {
            foreach (Candidate candidate in candidates)
            {
                Console.WriteLine(candidate);
            }
        }
    }
}
