using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_magisterska
{
    class Rules_generator
    {
        public List<Rule> rules = new List<Rule>();
        public List<Itemset> itemsets = new List<Itemset>();
        public double min_sup = new double();
        public double min_conf = new double();

        public Rules_generator(double min_sup, double min_conf, List<Itemset> itemsets)
        {
            this.min_sup=min_sup;
            this.min_conf=min_conf;
            this.itemsets = itemsets;
        }

        private double get_confidence(Itemset itemset, Rule rule, List<Itemset> itemsets)//calculate confidence
        {
            double prev_support=0;
            double itemset_support=itemset.support;
            foreach(Itemset L_itemset in itemsets)// find support for prev part of rule
            {
                var diff = new List<String>();
                diff = L_itemset.items.Except(rule.prev).ToList<String>();
                if(diff.Count == 0)
                {
                    prev_support = L_itemset.support;
                    break;
                }
            }
            double confidence = itemset_support / prev_support;
            return confidence;
        }

        public void generate_rules()//generate association rules
        {
            foreach(Itemset itemset in itemsets)
            {
                //MessageBox.Show("itemset support=" + itemset.support);
                List<Rule> candidate_rules = new List<Rule>();
                candidate_rules = generate_candidate_rules(itemset);//generate potential rules
                foreach(Rule r in candidate_rules)//check conf of rules
                {
                    if(r.confidence>=min_conf)
                    {
                        rules.Add(r);
                    }
                }
            }
        }

        private List<Rule> generate_candidate_rules(Itemset itemset)//generate candidate rules
        {
            //MessageBox.Show("itemset support=" + itemset.support);
            List<Rule> candidate_rules = new List<Rule>();
            List<Set> allSubsets = new List<Set>();
            List<Set> alldiffs = new List<Set>();//

            int subsetCount = (int)Math.Pow(2, itemset.items.Count);
            for (int i = 0; i < subsetCount; i++)
            {
                Set subset = new Set();
                Set diff = new Set();//
                for (int bitIndex = 0; bitIndex < itemset.items.Count; bitIndex++)
                {
                    if (GetBit(i, bitIndex) == 1)
                    {
                        subset.items.Add(itemset.items[bitIndex]);                        
                    }
                    //diff.items = itemset.items.Except(subset.items).ToList<string>();//
                    //alldiffs.Add(diff);//
                }
                allSubsets.Add(subset);
            }
            //MessageBox.Show("subsets: " + allSubsets.Count.ToString() + " diffs: " + alldiffs.Count.ToString());
            //List<Set> alldiffs = new List<Set>();
            foreach (Set s in allSubsets)
            {
                Set diff = new Set();
                diff.items = itemset.items.Except(s.items).ToList<string>();
                alldiffs.Add(diff);
            }

            //creating rules
            for (int i=0 ; i<allSubsets.Count; i++)
            {
                Rule r = new Rule(allSubsets[i].items, alldiffs[i].items, itemset.support);
                r.confidence = get_confidence(itemset, r, itemsets);
                if (r.prev.Count > 0 && r.next.Count > 0)
                {
                    candidate_rules.Add(r);
                }
            }

            //LOG
            //Log window = new Log();
            //window.Show();
            //window.richTextBox1.Text += "Candidate rules:\n";
            //foreach (Rule r in candidate_rules)
            //{
            //    String prv = "";
            //    foreach (string s in r.prev)
            //    {
            //        prv += " " + s;
            //    }
            //    String next = "";
            //    foreach (string s in r.next)
            //    {
            //        next += " " + s;
            //    }
            //    window.richTextBox1.Text += prv + " => " + next + " " + r.support + "\n";
            //}
            //LOG part 2
            //window.richTextBox1.Text += "\nitemset ";
            //foreach(string s in itemset.items)
            //{
            //    window.richTextBox1.Text += s + ", ";
            //}
            //window.richTextBox1.Text += "subsets: \n";

            //for (int i = 0; i < allSubsets.Count; i++ )
            //{
            //    for(int j=0; j<allSubsets[i].items.Count; j++)
            //    {
            //        window.richTextBox1.Text += allSubsets[i].items[j] + ", ";
            //    }
            //    window.richTextBox1.Text += "<-->";
            //    for (int j = 0; j < alldiffs[i].items.Count; j++)
            //    {
            //        window.richTextBox1.Text += alldiffs[i].items[j] + ", ";
            //    }
            //    window.richTextBox1.Text += "\n";
            //}
            //LOG

            return candidate_rules;            
        }

        public int GetBit(int value, int position)
        {
            int bit = value & (int)Math.Pow(2, position);
            return (bit > 0 ? 1 : 0);
        }
    }
}
