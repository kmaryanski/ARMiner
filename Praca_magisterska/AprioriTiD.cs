using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class AprioriTiD
    {
        //inny get support
        //dodatkowa counting base
        public List<Transaction> data = new List<Transaction>();
        public List<Itemset> candidate_itemsets = new List<Itemset>();
        public List<Itemset> L_itemsets = new List<Itemset>();
        public double min_sup;
        int nr_of_transactions_in_data = new int();
        ////Log window = new Log();

        public AprioriTiD() { }

        public AprioriTiD(List<Transaction> data, double min_sup)
        {
            this.data = data;
            this.min_sup = min_sup;
        }

        bool is_subset(Itemset itemset, List<String> transaction)//check if itemset is subset
        {
            bool result = true;
            foreach (string i in itemset.items)
            {
                if (!transaction.Contains(i))
                {
                    result = false;
                }
            }
            return result;
            //bool result = b.Except(a).Any();
            //return !transaction.Except(itemset.items).Any();//TODO
        }

        List<Itemset> get_1_itemsets(List<Transaction> data)//find 1 element itemset
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
            List<Itemset> unique_1_itemsets = new List<Itemset>();
            foreach (string item in list)
            {
                Itemset tmp = new Itemset();
                tmp.items.Add(item);
                tmp.support = 0;
                unique_1_itemsets.Add(tmp);
            }
            return unique_1_itemsets;
        }

        double get_support(Itemset itemset)//calculate support
        {
            double support = 0;
            foreach (Transaction t in data)
            {
                if (is_subset(itemset, t.items))
                {
                    support++;
                }
            }
            //window.richTextBox1.Text += "support: "+support.ToString() + "\n";//log
            support = support / nr_of_transactions_in_data;
            itemset.support = support;
            return support;
        }
              
        int cb_transaction_exist(Counting_base_transaction transaction, List<Counting_base_transaction> counting_base)//check if transaction exists in counting base
        {
            ////window.richTextBox1.Text += "counting base size " + counting_base.Count+"\n";
            foreach(Counting_base_transaction t in counting_base)
            {
                if(t.TiD==transaction.TiD)
                {
                    ////window.richTextBox1.Text += "tr "+transaction.TiD+"exists @" + counting_base.IndexOf(t)+" ("+t.TiD+")\n";
                    return counting_base.IndexOf(t);
                }
            }
            ////window.richTextBox1.Text += "\n doesn't exist in countingbase\n";
            return -1;
        }

        List<Counting_base_transaction> get_support_from_counting_base(List<Itemset> candidates, List<Counting_base_transaction> counting_base)//calculate support using counting base
        {
            List<Counting_base_transaction> new_counting_base = new List<Counting_base_transaction>();
            //new try
            foreach (Itemset itemset in candidates) // przejście po zbiorach kandydujących
            {
                double support = 0;
                ////window.richTextBox1.Text += "next candidate\n";
                foreach(Counting_base_transaction transaction in counting_base)
                {
                    //check if transaction supports itemset
                    bool transaction_contains_all_strings = new bool();
                    bool second_pass = false;
                    // checking procedure
                    foreach(string item in itemset.items) //sprawdz każdy element zbioru kandydującego
                    {
                        ////window.richTextBox1.Text += "checking "+item;
                        bool contains_single_string = false;
                        foreach(Itemset cb_itemset in transaction.itemsets)//z każdym zbiorem w transakcji
                        {
                            if(cb_itemset.items.Contains(item)==true)
                            {
                                contains_single_string = true;
                                ////window.richTextBox1.Text += " match at: "+transaction.itemsets.IndexOf(cb_itemset);
                                break;
                            }
                        }
                        ////window.richTextBox1.Text += contains_single_string + " " + transaction_contains_all_strings + "\n";
                        if(transaction_contains_all_strings==false && second_pass==true)
                        {
                            break;
                        }
                        second_pass = true;
                        transaction_contains_all_strings = contains_single_string;   
                    }
                    // end of checking procedure
                    if (transaction_contains_all_strings == true)
                    {
                        ////window.richTextBox1.Text += "found!\n";
                        support++;
                        Counting_base_transaction new_cb = new Counting_base_transaction(transaction.TiD, itemset);
                        //if(transaction nr exist) - add itemset to this number
                        int i=cb_transaction_exist(new_cb, new_counting_base);
                        if(i>=0)
                        {
                            ////window.richTextBox1.Text += "adding\n";
                            new_counting_base[i].itemsets.Add(itemset);
                        }
                        //else - create new transaction
                        else
                        {
                            ////window.richTextBox1.Text += "creating new\n";
                            new_counting_base.Add(new_cb);
                        }
                    }
                    else
                    {
                        ////window.richTextBox1.Text += "not found!\n";
                    }
                }
                ////window.richTextBox1.Text += "support:"+support+"\n";
                itemset.support = support / (double)nr_of_transactions_in_data;
            }
            //log
            ////window.richTextBox1.Text += "new counting base:\n";
            ////foreach (Counting_base_transaction t in new_counting_base)
            ////{
            ////    window.richTextBox1.Text += "\n " + t.TiD + " ";
            ////    foreach (Itemset i in t.itemsets)
            ////    {
            ////        window.richTextBox1.Text += "{";
            ////        foreach (string s in i.items)
            ////        {
            ////            window.richTextBox1.Text += s + " ";
            ////        }
            ////        window.richTextBox1.Text += "} ";
            ////    }
            ////}
            //log
             return new_counting_base;
        }

        List<Itemset> remove_infrequent(double support, List<Itemset> candidates)//remove infrequent itemset from list
        {
            List<Itemset> L_k_sets = new List<Itemset>();
            for (int i = 0; i < candidates.Count; i++)
            {
                if (candidates[i].support >= min_sup)
                {
                    this.L_itemsets.Add(candidates[i]);
                    L_k_sets.Add(candidates[i]);
                }
            }
            return L_k_sets;
        }

        public void start_aprioriTiD()
        {
            nr_of_transactions_in_data = data.Count;
            ////window.Show();
            ////window.richTextBox1.Text += "starting AprioriTiD with " + nr_of_transactions_in_data + " transactions in data\n";
            
            List<Itemset> L_sets = new List<Itemset>();
            List<Itemset> infrequent = new List<Itemset>();

            //find 1-l itemsets
            ////window.richTextBox1.Text += "find 1 itemsets\n";
            candidate_itemsets = get_1_itemsets(data);
            int one_itemsts_count = candidate_itemsets.Count;

            //build counting base 1
            List<Counting_base_transaction> counting_base_prv = new List<Counting_base_transaction>();
            List<Counting_base_transaction> counting_base_next = new List<Counting_base_transaction>(); 
            foreach (Transaction t in data)
            {
                counting_base_prv.Add(new Counting_base_transaction(t));
            }
            //log
            ////foreach(Counting_base_transaction t in counting_base_prv)
            ////{
            ////    window.richTextBox1.Text += "\n " + t.TiD + " ";
            ////    foreach(Itemset i in t.itemsets)
            ////    {
            ////        window.richTextBox1.Text += "{";
            ////        foreach(string s in i.items )
            ////        {
            ////            window.richTextBox1.Text += s + " ";
            ////        }
            ////        window.richTextBox1.Text +="} ";
            ////    }
            ////}
            //log
            //^^^^^            
            //get 1- itemsets support
            ////window.richTextBox1.Text += "found " + one_itemsts_count + " candidate one-itemsets ,get support\n";
            foreach (Itemset i in candidate_itemsets)
            {
                get_support(i);
                ////window.richTextBox1.Text += i.support.ToString() + "\n";
            }
            //save infrequent sets for use in apriorigen prune step
            ////window.richTextBox1.Text += "remove infrequent\n";
            L_sets = remove_infrequent(min_sup, candidate_itemsets);
            infrequent = candidate_itemsets.Except(L_sets).ToList<Itemset>();
            ////window.richTextBox1.Text += "generete candidates\n";
            //-----------------------------------------------------------------<
            int iterations = 0;
            for (int x = 0; ; x++)
            {
                
                iterations++;
                ////window.richTextBox1.Text += iterations + " ";
                ////window.richTextBox1.Text += "apriorigen, nr of (k-1)L_sets " + L_sets.Count + "\n";
                ////window.richTextBox1.SelectionStart = window.richTextBox1.Text.Length;
                ////window.richTextBox1.ScrollToCaret();
                this.candidate_itemsets = apriori_gen(L_sets, infrequent);
                if (candidate_itemsets.Count == 0)
                {
                    ////window.richTextBox1.Text += "terminate - no more candidates\n";
                    ////window.Close();
                    return;
                }
                //check support if each itemset and remove infrequent
                //save infrequent sets for use in apriorigen prune step
                counting_base_next = get_support_from_counting_base(candidate_itemsets, counting_base_prv); // nowy sposób na strukture tid
                //foreach (itemset i in candidate_itemsets)
                //{
                //    counting_base_next = get_support_from_counting_base(i, counting_base_prv);
                //    window.richTextBox1.Text += i.support.ToString() + "\n";
                //}
                L_sets = remove_infrequent(min_sup, candidate_itemsets);
                ////window.richTextBox1.Text += "L_sets " + L_sets.Count + "\n";
                infrequent = candidate_itemsets.Except(L_sets).ToList<Itemset>();
                
                //set counting base next as prv
                counting_base_prv = counting_base_next;
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

        List<Itemset> apriori_gen(List<Itemset> L_sets, List<Itemset> infrequent)//AprioriGen
        {
            List<Itemset> candidates = new List<Itemset>();
            //merge
            if (L_sets.Count == 0)
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

        List<Itemset> merge(List<Itemset> L_sets)//merge step apriorigen
        {

            ////window.richTextBox1.Text += "starting merge \n";

            List<Itemset> new_candidates = new List<Itemset>();
            Boolean good = false;
            //window.richTextBox1.Text += "nr of items \n";
            int nr_of_items = L_sets.Count;
            ////window.richTextBox1.Text += "sets count " + nr_of_items + "\n";
            if (L_sets.Count <= 1)//jeśli nie da się już zrobić więcej zbiorów kandydujących
            {
                ////window.richTextBox1.Text += "merge exit 1\n";
                return new_candidates;
            }
            if (L_sets[0].items.Count == 1)//jeśli zbiory są jednoelementowe
            {
                foreach (Itemset i in L_sets)
                {
                    foreach (Itemset i2 in L_sets)
                    {
                        Itemset new_set = new Itemset();
                        if (i2.items[0] != i.items[0])
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
                //log
                ////foreach (Itemset i in new_candidates)//for log
                ////{
                ////    foreach (string s in i.items)
                ////    { window.richTextBox1.Text += s + " "; }
                ////    window.richTextBox1.Text += ", ";
                ////}

                ////window.richTextBox1.Text += new_candidates.Count + "\n sets merge exit 2\n";
                //log
                return new_candidates;
            }
            int nr_of_elements_in_k_1_L_itemset = L_sets[0].items.Count;
            foreach (Itemset i in L_sets)//pozostale przypadki
            {
                i.items.Sort();
                foreach (Itemset i2 in L_sets)
                {
                    Boolean merge = true;
                    i2.items.Sort();
                    //try harder
                    //FOR LOG
                    ////window.richTextBox1.Text += "set one: ";
                    ////foreach (string s in i.items) { window.richTextBox1.Text += s + " "; }
                    ////window.richTextBox1.Text += "\n set two: ";
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
                    if (merge == true)
                    {
                        new_set.items.Add(i.items[nr_of_elements_in_k_1_L_itemset - 1]);
                        new_set.items.Add(i2.items[nr_of_elements_in_k_1_L_itemset - 1]);

                        bool add = true;
                        add = is_new(new_candidates, new_set);
                        if (add)
                        {
                            new_candidates.Add(new_set);
                        }
                        ////window.richTextBox1.Text += "cand set: ";
                        ////foreach (string s in new_set.items) { window.richTextBox1.Text += s + " "; }
                    }

                    //new try
                    //var diff = i.items.Except(i2.items);
                    //FOR LOG
                    //window.richTextBox1.Text += "set one: ";
                    //foreach(string s in i.items){window.richTextBox1.Text += s+ " ";}
                    //window.richTextBox1.Text += "\n set two: ";
                    //foreach (string s in i2.items) { window.richTextBox1.Text += s + " "; }
                    //window.richTextBox1.Text += "\n";
                    //FOR LOG
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
            //log
            ////foreach (Itemset i in new_candidates)//for log
            ////{
            ////    foreach (string s in i.items)
            ////    { window.richTextBox1.Text += s + " "; }
            ////    window.richTextBox1.Text += ", ";
            ////}
            ////window.richTextBox1.Text += "returning" + new_candidates.Count + "candidate sets (exit 3)\n";
            //log
            return new_candidates;
        }

        List<Itemset> prune(List<Itemset> new_candidates, List<Itemset> infrequent)//prune step apriorigen
        {
            ////window.richTextBox1.Text += new_candidates.Count + "sets pruning\n";
            List<Itemset> candidates = new List<Itemset>();
            if (new_candidates.Count == 0)
            {
                return candidates;
            }
            candidates = new_candidates;
            foreach (Itemset i in candidates)
            {
                if (infrequent.Contains(i))
                {
                    candidates.Remove(i);
                }
            }
            ////window.richTextBox1.Text += candidates.Count + " sets after prune\n";
            return candidates;
        }

    }
}
