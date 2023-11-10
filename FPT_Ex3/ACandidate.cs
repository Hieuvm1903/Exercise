using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex3
{
    internal class ACandidate : Candidate
    {
        public ACandidate(int id, string name, string address, int level) : base(id, name, address, level)
        {
            block = Block.A;
            subjects = " Math, Physics, Chemistry";
        }

    }
}
