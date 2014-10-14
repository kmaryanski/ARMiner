using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class Itemset
    {
        public List<String> items=new List<string>();
        public double support=new double();        

        public Itemset()
        {
            items=new List<string>();
            support=new double();        
        }

        public Itemset(List<String> elements, double sup)
        {
            this.items = elements;
            this.support = sup;
        }

        public String ToString()
        {
            string s="";
            foreach(string item in items)
            {
                s+=item+" ";
            }
            s+="\t"+support.ToString();
            return s;
        }
    }
}
