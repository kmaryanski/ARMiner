using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_magisterska
{
    class Data_saver
    {
        string dir = "";
        List<Rule> rules = new List<Rule>();
        List<Itemset> itemsets = new List<Itemset>();
        string name = "";
        
        public Data_saver(string dir, string algorytm, List<Rule> rules, List<Itemset> itemsets)
        {
            this.dir = dir+"\\";
            this.rules = rules;
            this.name = algorytm;
            this.itemsets = itemsets;
        }

        public void save()
        {
            DateTime now = DateTime.Now;
            string day = now.Day.ToString();
            string month = now.Month.ToString();
            string year = now.Year.ToString();
            string time = now.Hour.ToString()+"_"+now.Minute.ToString()+"_"+now.Second.ToString();

            string filename_sets = name + "_itemsets_" + day + "_" + month + "_" + year + "_" + time + ".txt";
            string filename_rules = name + "_rules_" + day + "_" + month + "_" + year + "_" + time + ".txt";


            //reguly
            StringBuilder rules_to_save = new StringBuilder();
            int n=1;
            foreach(Rule r in rules)
            {
                string poprzednik = "{";
                foreach(string s in r.prev)
                {
                    poprzednik += s;
                    poprzednik += ", ";
                }
                //poprzednik += "}";
                poprzednik = poprzednik.Substring(0, poprzednik.Length - 2) + "}";
                string nastepnik = "{";
                foreach(string s in r.next)
                {
                    nastepnik += s;
                    nastepnik += ", ";
                }
                nastepnik = nastepnik.Substring(0, nastepnik.Length - 2) + "}";
                string line = n.ToString() + "\t" + poprzednik + "\t=>\t" + nastepnik + "\t" + r.support + "\t" + r.confidence;
                rules_to_save.AppendLine(line);
                n++;
            }

            //Zbiory
            StringBuilder itemsets_to_save = new StringBuilder();
            n = 1;
            foreach (Itemset i in itemsets)
            {
                string items="{";
                foreach(String s in i.items)
                {
                    items += s;
                    items +=", ";
                }
                //items+="}";
                items = items.Substring(0, items.Length - 2) + "}";
                string line = n.ToString() + "\t" + items + "\t" + i.support;
                itemsets_to_save.AppendLine(line);
                n++;
            }
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(dir+filename_sets);
                writer.Write(itemsets_to_save);
                writer.Close();
                writer = new StreamWriter(dir + filename_rules);
                writer.Write(rules_to_save);
                writer.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Wystąpił błąd przy zapisywaniu pliku."+e);
            }
            finally
            {
                if (writer != null) writer.Close();
            }
            //MessageBox.Show(dir+filename);
            //throw new NotImplementedException();
        }
    }
}
