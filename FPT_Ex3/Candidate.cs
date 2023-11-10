using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPT_Ex3
{
    internal abstract class Candidate
    {
        private int _id;
        private string _name;
        private string _address;
        private int _level;
        public int ID { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Address { get { return _address; } set { _address = value; } }
        public int Level { get { return _level; } set { _level = value; } }
        protected Block block;
        protected string subjects;
        public Candidate(int id, string name, string address, int level)
        {
            _id = id;
            _name = name;
            _address = address;
            _level = level;

        }
        public override string ToString()
        {
            return $"ID: {_id}, Name: {_name}, Address: {_address}, Level: {_level}, Block: {block}, Subject: {subjects}";
        }

        public Block GetBlock() { return block; }








    }
    public enum Block
    {
        A,
        B,
        C
    }
}
