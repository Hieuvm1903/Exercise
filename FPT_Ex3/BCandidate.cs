using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex3
{
    internal class BCandidate : Candidate
    {
        public BCandidate(int id, string name, string address, int level) : base(id, name, address, level)
        {
            subjects = "Math, Chemistry, Biology";
            block = Block.B;
        }
    }
}
