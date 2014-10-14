using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praca_magisterska
{
    class Vertical_transaction
    {
        public List<string> itemset = new List<string>();
        public List<int> tids = new List<int>();
        public double support = new double();

        public Vertical_transaction (List<string> set, List<int> ids, double sup)
        {
            this.itemset = set;
            this.tids = ids;
            this.support = sup;
        }
    }
}
