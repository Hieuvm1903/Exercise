using System;
namespace FPT_Ex13
{
    internal class Certificate
    {
        private string id;
        private string name;
        private string rank;
        private DateTime date;
        public string ID { get { return id; } set { id = value; } }
        public string Name { get { return name; }set { name = value; } }
        public string Rank { get { return rank; } set { rank = value; } }
        public DateTime Date { get { return date; }set { date = value; }  }
        public Certificate(string id, string name, string rank,DateTime dateTime)
        {
            this.id = id;
            this.name = name;
            this.rank = rank;
            this.date = dateTime;
        }



    }
}
