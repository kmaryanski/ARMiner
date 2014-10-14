using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class Transaction
    {
        public List<string> items=new List<string>();
        public int tid = 0;

        public Transaction()
        {
            this.items = new List<string>();
            this.tid = 0;
        }

        public Transaction(int tid, string[] elements)
        {
            foreach(string e in elements)
            {
                this.items.Add(e);
                this.tid = tid;
            }
        }
    }
}
