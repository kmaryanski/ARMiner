using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class Apriori
    {
        public List<Transaction> data = new List<Transaction>();
        public List<Itemset> candidate_itemsets = new List<Itemset>();
        public List<Itemset> L_itemsets = new List<Itemset>();
        public double min_sup;
        int nr_of_transactions_in_data = new int();
        ////Log window = new Log();
        
        public Apriori (List<Transaction> data, double min_sup)
        {
            this.data = data;
            this.min_sup = min_sup;
        }

        public Apriori()
        {
        }

        bool is_subset(Itemset itemset, List<String> transaction)//check if is subset 
        {
            bool result = true;
            foreach(string i in itemset.items)
            {
                if(!transaction.Contains(i))
                {
                    result = false;
                }
            }
            return result;
            //bool result = b.Except(a).Any();
            //return !transaction.Except(itemset.items).Any();//TODO
        }

        List<Itemset> get_1_itemsets(List<Transaction> data)// get itemset containing 1 element
        {
            List<string> list=new List<string>();
            foreach(Transaction t in data)
            {
                for(int i=0; i<t.items.Count;i++) 
                {
                    if(!list.Contains(t.items[i]))
                    {
                        list.Add(t.items[i]);
                    }
                }
            }
            List<Itemset> unique_1_itemsets=new List<Itemset>();
            foreach(string item in list)
            {
                Itemset tmp=new Itemset();
                tmp.items.Add(item);
                tmp.support=0;
                unique_1_itemsets.Add(tmp);
            }
            return unique_1_itemsets;
        }

        double get_support(Itemset itemset)// calculate support
        {
            double support=0;
            foreach(Transaction t in data)
            {
                if (is_subset(itemset, t.items))
                {
                    support++;
                }
            }
            //window.richTextBox1.Text += "support: "+support.ToString() + "\n";//log
            support=support/nr_of_transactions_in_data;
            itemset.support=support;
            return support;
        }
        
        List<Itemset> remove_infrequent(double support, List<Itemset> candidates)//remove infrequent itemset form list
        {
            List<Itemset> L_k_sets=new List<Itemset>();
            for(int i=0;i<candidates.Count; i++)
            {
                if(candidates[i].support>=min_sup)
                {
                    this.L_itemsets.Add(candidates[i]);
                    L_k_sets.Add(candidates[i]);
                }
            }
            return L_k_sets;
        }
        
        public void start_apriori()
        {
            nr_of_transactions_in_data = data.Count;
            ////window.Show();            
            List<Itemset> L_sets=new List<Itemset>();
            List<Itemset> infrequent = new List<Itemset>();
            ////window.richTextBox1.Text +="starting apriori with "+data.Count+" transactions in data\n";
            //find 1-l itemsets
            ////window.richTextBox1.Text +="find 1 itemsets\n";
            this.candidate_itemsets = get_1_itemsets(data);
            int one_itemsts_count = candidate_itemsets.Count;
            ////window.richTextBox1.Text +="found "+one_itemsts_count+" candidate one-itemsets ,get support\n";
            foreach(Itemset i in candidate_itemsets)
            {
                get_support(i);
                ////window.richTextBox1.Text += i.support.ToString() + "\n";
            }
            //save infrequent sets for use in apriorigen prune step
            ////window.richTextBox1.Text +="remove infrequent\n";
            L_sets=remove_infrequent(min_sup, candidate_itemsets);
            infrequent = candidate_itemsets.Except(L_sets).ToList<Itemset>();           
            //add l-1 itemsets to L_itemsets
            //foreach(itemset i in L_sets)
            //{
            //    this.L_itemsets.Add(i);
            //}
            //generate candidates
            ////window.richTextBox1.Text += "generete candidates\n";
            int iterations = 0;
            //while (iterations <8 || candidate_itemsets.Count <= one_itemsts_count || candidate_itemsets.Count != 0)
            for (int x = 0; ; x++)
            {
                iterations++;
                ////window.richTextBox1.Text += "apriorigen, nr of (k-1)L_sets " + L_sets.Count + "\n";
                ////window.richTextBox1.SelectionStart = window.richTextBox1.Text.Length;
                ////window.richTextBox1.ScrollToCaret();
                this.candidate_itemsets = apriori_gen(L_sets, infrequent);
                if (candidate_itemsets.Count == 0)
                {
                    ////window.richTextBox1.Text += "terminate - no more candidates\n";
                    return;
                }
                //check support if each itemset and remove infrequent
                //save infrequent sets for use in apriorigen prune step
                foreach (Itemset i in candidate_itemsets)
                {
                    get_support(i);
                    ////window.richTextBox1.Text += i.support.ToString() + "\n";
                }
                L_sets = remove_infrequent(min_sup, candidate_itemsets);
                ////window.richTextBox1.Text += "L_sets " + L_sets.Count + "\n";
                infrequent = candidate_itemsets.Except(L_sets).ToList<Itemset>();
                //add l-itemsets to L_itemsets
                //foreach (itemset i in L_sets)
                //{
                //    this.L_itemsets.Add(i);
                //}
            }            
            return;
        }

        Boolean is_new(List<Itemset> list, Itemset item)//check if itemset is in list
        {
            foreach (Itemset set in list)
            {
                var diff = item.items.Except(set.items);
                if (diff.ToList().Count == 0)
                {
                    return false;
                }
            }
            return true;
        }

        List<Itemset> apriori_gen(List<Itemset> L_sets, List<Itemset> infrequent) //AprioriGen
        {
            List<Itemset> candidates = new List<Itemset>();
            //merge
            if(L_sets.Count==0)
            {
                return candidates;
            }
            candidates = merge(L_sets);

            //prune - odrzuć rozszerzenia nieczęstych 
            //(te zawierające (k-1)-elementowe podzbiory, 
            //które nie występują w zbiorze (k-1)-elementowych zbiorów częstych)
            candidates = prune(candidates, infrequent);
           
            return candidates;
        }

        List<Itemset> merge(List<Itemset> L_sets)//Apriori merge step
        {

            ////window.richTextBox1.Text += "starting merge \n";

            List<Itemset> new_candidates=new List<Itemset>();
            Boolean good = false;
            //window.richTextBox1.Text += "nr of items \n";
            int nr_of_items=L_sets.Count;
            ////window.richTextBox1.Text += "sets count " + nr_of_items + "\n";
            if (L_sets.Count == 1)//jeśli nie da się już zrobić więcej zbiorów kandydujących
            {
                ////window.richTextBox1.Text += "merge exit 1\n";
                return new_candidates;
            }
            if (L_sets[0].items.Count == 1)//jeśli zbiory są jednoelementowe
            {
                foreach (Itemset i in L_sets)
                {  
                    foreach(Itemset i2 in L_sets)
                    {
                        Itemset new_set = new Itemset();
                        if(i2.items[0]!=i.items[0])
                        {
                            new_set.items.Add(i.items[0]);
                            new_set.items.Add(i2.items[0]);
                            new_set.items.Sort();
                            //deal with duplicates
                            bool add = true;
                            add = is_new(new_candidates, new_set);
                            //foreach (itemset set in new_candidates)
                            //{
                            //    var diff = new_set.items.Except(set.items);
                            //    if (diff.ToList().Count==0)
                            //    {
                            //        add = false;
                            //    }
                            //}
                            //window.richTextBox1.Text += new_candidates.Contains(new_set);
                            if (add)
                            {
                                new_candidates.Add(new_set);
                            }
                        }
                    }
                }
                //foreach (itemset i in new_candidates) { i.items.Sort(); }
                ////foreach(Itemset i in new_candidates)//for log
                ////{
                ////    foreach (string s in i.items)
                ////    { window.richTextBox1.Text += s + " "; }
                ////    window.richTextBox1.Text += ", ";
                ////}

                ////window.richTextBox1.Text += new_candidates.Count+"\n sets merge exit 2\n";
                return new_candidates;
            }
            int nr_of_elements_in_k_1_L_itemset = L_sets[0].items.Count;
            foreach (Itemset i in L_sets)//pozostale przypadki
            {
                i.items.Sort();
                foreach(Itemset i2 in L_sets)
                {
                    Boolean merge=true;
                    i2.items.Sort();
                    //try harder
                    //FOR LOG
                    ////window.richTextBox1.Text += "set one: ";
                    ////foreach (string s in i.items) { window.richTextBox1.Text += s + " "; }
                    //// window.richTextBox1.Text += "\n set two: ";
                    ////foreach (string s in i2.items) { window.richTextBox1.Text += s + " "; }
                    ////window.richTextBox1.Text += "\n";
                    //FOR LOG
                    Itemset new_set = new Itemset();
                    for (int iterator = 0; iterator < nr_of_elements_in_k_1_L_itemset; iterator++)
                    {
                        ////window.richTextBox1.Text += iterator + " \n";
                        if (i.items[iterator].Equals(i2.items[iterator]) && iterator < nr_of_elements_in_k_1_L_itemset - 1)//i.items[iterator]==i2.items[iterator])
                        {
                            new_set.items.Add(i.items[iterator]);
                        }
                        else if (!i.items[iterator].Equals(i2.items[iterator]) && iterator < nr_of_elements_in_k_1_L_itemset - 1)
                        {
                            merge = false;
                        }
                    }
                    if (i.items[nr_of_elements_in_k_1_L_itemset - 1].Equals(i2.items[nr_of_elements_in_k_1_L_itemset - 1]))
                    {
                        merge = false;
                    }
                    if (merge==true)
                    {
                        new_set.items.Add(i.items[nr_of_elements_in_k_1_L_itemset-1]);
                        new_set.items.Add(i2.items[nr_of_elements_in_k_1_L_itemset-1]);

                        bool add = true;
                        add = is_new(new_candidates, new_set);
                        if (add)
                        {
                            new_candidates.Add(new_set);
                        }
                        ////window.richTextBox1.Text += "cand set: ";
                        ////foreach (string s in new_set.items) { window.richTextBox1.Text += s + " "; }
                    }
                    
                    ////new try
                    //var diff = i.items.Except(i2.items);
                    ////FOR LOG
                    //window.richTextBox1.Text += "set one: ";
                    //foreach(string s in i.items){window.richTextBox1.Text += s+ " ";}
                    //window.richTextBox1.Text += "\n set two: ";
                    //foreach (string s in i2.items) { window.richTextBox1.Text += s + " "; }
                    //window.richTextBox1.Text += "\n";
                    ////FOR LOG
                    //if (diff.ToList().Count == 1)
                    //{
                    //    merge= true;
                    //}
                    //if(merge==true)
                    //{
                    //    itemset new_set=new itemset();
                    //    new_set.items=i.items;
                    //    new_set.items.Add(diff.ToList()[0]);
                    //    bool add = true;
                    //    add = is_new(new_candidates, new_set);
                    //    if (add)
                    //    {
                    //        new_candidates.Add(new_set);
                    //    }
                        
                    //}
                    //old try
                    //for(int item_number=0; item_number<nr_of_items-1;item_number++)
                    //{
                    //    if(i.items[item_number]==i2.items[item_number])
                    //    {
                    //        merge=true;
                    //    }
                    //    else
                    //    {
                    //        merge=false;
                    //    }
                    //}
                    //if(merge==true)
                    //{
                    //    itemset new_set = new itemset();
                    //    for (int item_number = 0; item_number < nr_of_items - 1; item_number++)
                    //    {
                    //        new_set.items.Add(i.items[item_number]);
                    //    }
                    //    new_set.items.Add(i.items[nr_of_items - 1]);
                    //    new_set.items.Add(i2.items[nr_of_items - 1]);
                    //    if(new_set.items.Count==nr_of_items+1)
                    //    {
                    //        good = true;
                    //    }
                    //    //deal with duplicates
                    //    bool add = true;
                    //    add = is_new(new_candidates, new_set);
                    //    if (add)
                    //    {
                    //        new_candidates.Add(new_set);
                    //    }
                    //}
                }
                
            }
            ////foreach (Itemset i in new_candidates)//for log
            ////{
            ////    foreach (string s in i.items)
            ////    { window.richTextBox1.Text += s + " "; }
            ////    window.richTextBox1.Text += ", ";
            ////}
            ////window.richTextBox1.Text += "returning" + new_candidates.Count + "candidate sets (exit 3)\n";
            return new_candidates;
        }

        List<Itemset> prune(List<Itemset> new_candidates, List<Itemset> infrequent)//Apriori prune step
        {
            ////window.richTextBox1.Text += new_candidates.Count + " sets pruning\n";            
            List<Itemset> candidates=new List<Itemset>();
            if (new_candidates.Count == 0)
            {
                return candidates;
            }
            candidates = new_candidates;
            foreach(Itemset i in candidates)
            {
                if(infrequent.Contains(i))
                {
                    candidates.Remove(i);
                }
            }
            ////window.richTextBox1.Text += candidates.Count + " sets after prune\n";
            return candidates;
        }

    }
}
