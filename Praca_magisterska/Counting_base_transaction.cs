using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class Counting_base_transaction
    {
        public int TiD=new int();
        public List<Itemset> itemsets = new List<Itemset>();
        public Counting_base_transaction(Transaction transaction)
        {
            this.TiD = transaction.tid;
            foreach(string item in transaction.items)
            {
                Itemset new_set = new Itemset();
                new_set.items.Add(item);
                this.itemsets.Add(new_set);
            }
        }
        public Counting_base_transaction(int tid, Itemset itemset)
        {
            this.itemsets.Add(itemset);
            this.TiD = tid;
        }
    }
}
