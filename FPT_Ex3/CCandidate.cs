using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex3
{
    internal class CCandidate : Candidate
    {
        public CCandidate(int id, string name, string address, int level) : base(id, name, address, level)
        {
            block = Block.C;
            subjects = "Litrature, History, Geography ";
        }
    }
}
