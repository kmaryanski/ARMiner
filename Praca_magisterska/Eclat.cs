using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class Eclat
    {
        public List<Transaction> data = new List<Transaction>();
        public List<Itemset> L_itemsets = new List<Itemset>();
        public double min_sup;
        int nr_of_transactions = new int();
        ////Log window = new Log();

        public Eclat() { }

        public Eclat(List<Transaction> data, double min_sup)
        {
            this.data = data;
            this.min_sup = min_sup;
        }

        public void start_eclat()
        {
            ////window.Show();
            ////window.richTextBox1.Text += "starting eclat with data of "+data.Count+" transactions \n";
            //count transactions 
            nr_of_transactions = data.Count;
            //find all unique items
            List<string> one_itemsets = get_1_itemsets(data);
            //convert database and get support for 1-itemsets
            List<Vertical_transaction> vertical_data = convert_to_vertical(one_itemsets ,data);
            //remove infrequent support checked in generation step
            //vertical_data = remove_infrequent(min_sup, vertical_data);
            //add frequent 1-itemsets to L_itemsets
            ////window.richTextBox1.Text += "vertical data: "+vertical_data.Count+" rows \n";
            foreach(Vertical_transaction t in vertical_data)
            {
                L_itemsets.Add(new Itemset(t.itemset, t.support));
                //window.richTextBox1.Text += "adding l_itemset \n";
            }
            //loop
            //window.richTextBox1.Text += "vertical data count" +vertical_data.Count + " \n";
            while (vertical_data.Count > 1)
            //for (int iterator = 0; iterator < 4;iterator++)
            {
                ////window.richTextBox1.Text += "vertical data count" + vertical_data.Count + " \n";
                //generate candidates
                vertical_data = generate_candidates(vertical_data);
                ////window.richTextBox1.Text += "vertical data candidate count " + vertical_data.Count + " \n";
                //remove infrequent - checked in generation step
                //add to L_itemsets
                foreach (Vertical_transaction t in vertical_data)
                {
                    L_itemsets.Add(new Itemset(t.itemset, t.support));
                    //window.richTextBox1.Text += "adding l_itemset \n";
                }
            }
            ////window.richTextBox1.Text += "the end \n";
        }

        private List<Vertical_transaction> generate_candidates(List<Vertical_transaction> vertical_data)// generate candidate itemset
        {
            List<Vertical_transaction> new_data = new List<Vertical_transaction>();
            if(vertical_data.Count==0)
            {
                ////window.richTextBox1.Text += "generate entry 0 \n";
                return new_data;
            }
            //zbiory 1-elementowe
            if(vertical_data[0].itemset.Count==1)
            {
                ////window.richTextBox1.Text += "generate entry 1 \n";
                foreach(Vertical_transaction t1 in vertical_data)
                {
                    foreach(Vertical_transaction t2 in vertical_data)
                    {
                        if(t1.itemset[0]!=t2.itemset[0])
                        {
                            List<string> items_list = new List<string>();
                            items_list.Add(t1.itemset[0]);
                            items_list.Add(t2.itemset[0]);
                            //deal with duplicates
                            items_list.Sort();
                            List<int> tids = new List<int>();
                            tids=t1.tids.Intersect(t2.tids).ToList<int>();
                            double support= get_support(tids);
                            
                            Vertical_transaction new_transaction = new Vertical_transaction(items_list, tids, support);
                            if(is_new(new_transaction, new_data) && support>=min_sup)
                            {
                                ////window.richTextBox1.Text += "support: " + support + " \n";
                                new_data.Add(new_transaction);
                                string log = "";
                                foreach (string itemset in new_transaction.itemset)
                                {
                                    log += itemset.ToString() + ", ";
                                }
                                ////window.richTextBox1.Text+=log+" \n";
                            }
                        }
                    }
                }
                ////window.richTextBox1.Text += "generate exit 1:" + new_data.Count + " rows \n";
                return new_data;
            }
            //pozostałe przypadki
            
            else
            {
                ////window.richTextBox1.Text += "generate entry 2 \n";
                string log = "";
                foreach (Vertical_transaction v in vertical_data)
                {
                    foreach (string s in v.itemset) { log += s + ", "; }
                    log += "\n";
                }
                ////window.richTextBox1.Text+=log+" \n";

                int k_count = vertical_data[0].itemset.Count;
                foreach (Vertical_transaction t1 in vertical_data)
                {
                    t1.itemset.Sort();
                    foreach (Vertical_transaction t2 in vertical_data)
                    {
                        t2.itemset.Sort();
                        //
                        bool merge = true;
                        List<string> new_set = new  List<string>();
                        for (int iterator = 0; iterator < k_count; iterator++)
                        {
                            if (t1.itemset[iterator].Equals(t2.itemset[iterator]) && iterator < k_count - 1)//i.items[iterator]==i2.items[iterator])
                            {
                                new_set.Add(t1.itemset[iterator]);
                            }
                            else if (!t1.itemset[iterator].Equals(t2.itemset[iterator]) && iterator < k_count - 1)
                            {
                                merge = false;
                            }
                        }
                        if (t1.itemset[k_count - 1].Equals(t2.itemset[k_count - 1]))
                        {
                            merge = false;
                        }
                        if (merge==true)
                        {
                            new_set.Add(t1.itemset[k_count-1]);
                            new_set.Add(t2.itemset[k_count-1]);

                            List<int> tids = t1.tids.Intersect(t2.tids).ToList<int>();
                            double support = get_support(tids);
                            Vertical_transaction new_transaction = new Vertical_transaction(new_set, tids, support);
                            if (is_new(new_transaction, new_data) && support >= min_sup)
                            {
                                new_data.Add(new_transaction);
                            }
                            //bool add = true;
                            //add = is_new(new_candidates, new_set);
                            //if (add)
                            //{
                            //    new_candidates.Add(new_set);
                            //} 
                            //window.richTextBox1.Text += "cand set: ";
                            //foreach (string s in new_set.items) { window.richTextBox1.Text += s + " "; }
                        }
                        //
                        //Boolean merge = false;//new Boolean();
                        //for(int i=0;i<k_count-1;i++)
                        //{
                        //    window.richTextBox1.Text += "comparing " + t1.itemset[i] + " and " + t2.itemset[i];
                        //    if(t1.itemset[i].Equals(t2.itemset[i]))
                        //    {
                        //        merge = true;
                        //        window.richTextBox1.Text += " merge true, \n";
                        //    }
                        //    //else
                        //    //{
                        //    //    merge=false;
                        //    //    window.richTextBox1.Text += " merge false,";
                        //    //}
                        //}
                        

                        //if (merge == true)
                        //{
                        //    List<string> items_list = new List<string>();
                        //    items_list.AddRange(t1.itemset);
                        //    items_list.Add(t2.itemset[k_count - 1]);
                        //    //deal with duplicates
                        //    //items_list.Sort();
                        //    List<int> tids = new List<int>();
                        //    tids = t1.tids.Intersect(t2.tids).ToList<int>();
                        //    double support = get_support(tids);
                        //    vertical_transaction new_transaction = new vertical_transaction(items_list, tids, support);
                        //    if (is_new(new_transaction, new_data) && support>=min_sup)
                        //    {
                        //        new_data.Add(new_transaction);
                        //    }
                        //}
                    }
                }
                ////window.richTextBox1.Text += "generate exit 2:" + new_data.Count + " rows \n";
                return new_data;
            }
            //throw new NotImplementedException();
        }

        private bool is_new(Vertical_transaction new_transaction, List<Vertical_transaction> new_data)//check if vertical transaction is in list
        {
            foreach(Vertical_transaction v in new_data)
            {
                var diff = v.itemset.Except(new_transaction.itemset);
                if(diff.ToList().Count==0)
                {
                    return false;
                }
            }
            return true;
        }

        private List<Vertical_transaction> convert_to_vertical(List<string> one_itermsets, List<Transaction> data)//convert database to vertical format
        {
            List<Vertical_transaction> vertical_database = new List<Vertical_transaction>();

            foreach(string item in one_itermsets)
            {
                List<int> tids = new List<int>();
                List<string> itemset = new List<string>();
                itemset.Add(item);
                foreach(Transaction t in data)
                {
                    //window.richTextBox1.Text += "transaction "+t.tid+" \n";
                    if(t.items.Contains(item))
                    {
                        tids.Add(t.tid);
                        //window.richTextBox1.Text += "adding tid \n";
                    }
                }
                //window.richTextBox1.Text += "support "+tids.Count+" \n";
                double support = get_support(tids);
                //window.richTextBox1.Text += "support"+support+" \n";
                if(support>=min_sup)
                vertical_database.Add(new Vertical_transaction(itemset, tids, support));
            }
            return vertical_database;
        }

        private List<string> get_1_itemsets(List<Transaction> data)//find itemset with 1 element
        {
            List<string> list = new List<string>();
            foreach (Transaction t in data)
            {
                for (int i = 0; i < t.items.Count; i++)
                {
                    if (!list.Contains(t.items[i]))
                    {
                        list.Add(t.items[i]);
                    }
                }
            }
            ////window.richTextBox1.Text += "found "+list.Count+ " 1-itemsets \n";
            return list;
        }

        private double get_support(List<int> t)//calculate support
        {
            //window.richTextBox1.Text += "nr of tids"+t.Count+" \n";
            double support = t.Count / (double)nr_of_transactions;
            //window.richTextBox1.Text += "found support" + support + " \n";
            return support;
        }

        private List<Vertical_transaction> remove_infrequent(double support, List<Vertical_transaction> candidates)//remove infrequent candidates from list
        {
            foreach(Vertical_transaction t in candidates)
            {
                if (t.support<support)
                {
                    candidates.Remove(t);
                }
            }
            return candidates;
        }
    }
}
