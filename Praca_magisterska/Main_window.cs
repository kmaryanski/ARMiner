using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Praca_magisterska
{
    public partial class main_window : Form
    {
        String data_file = "";
        bool data_loaded = false;
        List<Transaction> data = new List<Transaction>();
        double support = new double();
        double confidence = new double();
        int algorythm_id = 0;
        string frequent_itemsets = "";
        Working working;

        List<Itemset> apriori_Litemsets = new List<Itemset>();
        List<Itemset> aprioriTiD_Litemsets = new List<Itemset>();
        List<Itemset> eclat_Litemsets = new List<Itemset>();

        List<Rule> apriori_rules = new List<Rule>();
        List<Rule> aprioriTiD_rules = new List<Rule>();
        List<Rule> eclat_rules = new List<Rule>();

        public main_window()
        {
            InitializeComponent();
        }

        private void dummy_transaction()
        {
            Transaction t1 = new Transaction();
            Transaction t2 = new Transaction();
            Transaction t3 = new Transaction();
            Transaction t4 = new Transaction();
            t1.items.Add("A");
            t1.items.Add("C");
            t1.items.Add("D");
            t1.tid = 1;

            t2.items.Add("B");
            t2.items.Add("C");
            t2.items.Add("E");
            t2.tid = 2;

            t3.items.Add("A");
            t3.items.Add("B");
            t3.items.Add("C");
            t3.items.Add("E");
            t3.tid = 3;

            t4.items.Add("B");
            t4.items.Add("E");
            t4.tid = 4;

            data.Add(t1);
            data.Add(t2);
            data.Add(t3);
            data.Add(t4);
            data_loaded = true;
        }

        private void start_apriori_button_Click(object sender, EventArgs e)//start Apriori
        {
            algorythm_id = 1;
            if (backgroundWorker1.IsBusy != true)
            {
                working = new Working();
                working.progressBar1.Style = ProgressBarStyle.Marquee;
                working.progressBar1.MarqueeAnimationSpeed = 30;
                Enabled = false;
                working.Show();
                backgroundWorker1.RunWorkerAsync();
            }
                                    
        } 

        private void start_TiD_button_Click(object sender, EventArgs e)//start AprioriTiD
        {
            algorythm_id = 2;
            if (backgroundWorker1.IsBusy != true)
            {
                working = new Working();
                working.progressBar1.Style = ProgressBarStyle.Marquee;
                working.progressBar1.MarqueeAnimationSpeed = 30;
                Enabled = false;
                working.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        } 

        private void start_eclat_button_Click(object sender, EventArgs e)//start Eclat
        {
            algorythm_id = 3;
            if (backgroundWorker1.IsBusy != true)
            {
                working = new Working();
                working.progressBar1.Style = ProgressBarStyle.Marquee;
                working.progressBar1.MarqueeAnimationSpeed = 30;
                Enabled = false;
                working.Show();
                backgroundWorker1.RunWorkerAsync();
            }
        } 

        private void data_browse_button_Click(object sender, EventArgs e)//browse for data
        {
            data_loaded = false;
            data_FileDialog.Filter = "Pliki tekstowe (.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            data_FileDialog.FilterIndex = 1;
            if (data_FileDialog.ShowDialog() == DialogResult.OK)
            {
                data_file = data_FileDialog.FileName;
                textBox_data.Text = data_file;
                data_loaded = false;
                aprioriTiD_Litemsets.Clear();
                apriori_Litemsets.Clear();
                eclat_Litemsets.Clear();
                apriori_Litemsets.Clear();
                aprioriTiD_Litemsets.Clear();
                eclat_Litemsets.Clear();
                button_save_apriori.Enabled = false;
                button_save_eclat.Enabled = false;
                button_save_TiD.Enabled = false;

                button_show_litemsetsApriori.Enabled = false;
                button_itemset_eclat.Enabled = false;
                button_litemsets_TiD.Enabled = false;

                button_rules_aprioriTid.Enabled = false;
                button_rules_eclat.Enabled = false;
                button_rulesApriori.Enabled = false;

                generate_rules_apriori_button.Enabled = false;
                generate_rules_TiD_button.Enabled = false;
                generate_rules_eclat_button.Enabled = false;
                frequent_itemsets = "";
                start_apriori_button.Enabled = true;
                start_eclat_button.Enabled = true;
                start_TiD_button.Enabled = true;
            }
        }

        private void support_setbox_ValueChanged(object sender, EventArgs e)//change minsup
        {
            support = (double)support_setbox.Value/100;
        }

        private void confidence_setbox_ValueChanged(object sender, EventArgs e)//change minconf
        {
            confidence = (double)confidence_setbox.Value/100;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (algorythm_id == 1)
            {
                if (!data_loaded)
                {
                    //dummy_transaction();
                    Data_loader loader = new Data_loader(data_file);
                    data = loader.load_data();
                    if (data.Count > 0)
                    {
                        data_loaded = true;
                    }
                }

                Apriori apriori = new Apriori(data, support);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                apriori.start_apriori();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                try
                {
                    label_apriori_time.Text = ts.Minutes + " m " + ts.Seconds.ToString() + " s " + ts.Milliseconds.ToString() + " ms";
                }
                catch(Exception exception)
                {}

                apriori_Litemsets = apriori.L_itemsets;

                //progressBar_apriori.Style = ProgressBarStyle.Continuous;
                //progressBar_apriori.MarqueeAnimationSpeed = 0;
                
                //MessageBox.Show("done");
            }
            if (algorythm_id == 2)
            {
                if (!data_loaded)
                {
                    //dummy_transaction();
                    Data_loader loader = new Data_loader(data_file);
                    data = loader.load_data();
                    if (data.Count > 0)
                    {
                        data_loaded = true;
                    }
                }
                AprioriTiD aprioritid = new AprioriTiD(data, support);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                aprioritid.start_aprioriTiD();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;

                try
                {
                    label_aprioriTiD_time.Text = ts.Minutes + " m " + ts.Seconds.ToString() + " s " + ts.Milliseconds.ToString() + " ms";
                }
                catch (Exception exception) { }
                aprioriTiD_Litemsets = aprioritid.L_itemsets;
            }

            if (algorythm_id == 3)
            {
                if (!data_loaded)
                {
                    //dummy_transaction();
                    Data_loader loader = new Data_loader(data_file);
                    data = loader.load_data();
                    if (data.Count > 0)
                    {
                        data_loaded = true;
                    }
                }
                Eclat eclat = new Eclat(data, support);

                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                eclat.start_eclat();
                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                try
                {
                    label_eclat_time.Text = ts.Minutes + " m " + ts.Seconds.ToString() + " s " + ts.Milliseconds.ToString() + " ms";
                }
                catch (Exception exception) { }

                eclat_Litemsets = eclat.L_itemsets;
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                MessageBox.Show("Przerwano na życzenie użytkownika", "Anulowanie", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (!(e.Error == null))
            {
                MessageBox.Show("Przerwano z powodu błędu.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (algorythm_id == 1)
                {
                    frequent_itemsets = "";
                    foreach (Itemset itemset in apriori_Litemsets)
                    {
                        frequent_itemsets += itemset.ToString() + "\n";
                    }
                    //MessageBox.Show(frequent_itemsets, "apriori");
                    working.Close();
                    Focus();
                    MessageBox.Show("Ukończono generowanie zbiorów algorytmem Apriori", "Apriori");
                    button_show_litemsetsApriori.Enabled = true;
                    generate_rules_apriori_button.Enabled = true;
                    button_save_apriori.Enabled = true;
                    Enabled = true;
                    //return;
                }
                if (algorythm_id == 2)
                {
                    frequent_itemsets = "";
                    foreach (Itemset itemset in aprioriTiD_Litemsets)
                    {
                        frequent_itemsets += itemset.ToString() + "\n";
                    }
                    //MessageBox.Show(frequent_itemsets, "aprioriTiD");
                    working.Close();
                    Focus();
                    MessageBox.Show("Ukończono generowanie zbiorów algorytmem AprioriTiD", "AprioriTiD");
                    button_litemsets_TiD.Enabled = true;
                    generate_rules_TiD_button.Enabled = true;
                    button_save_TiD.Enabled = true;
                    Enabled = true;
                    //return;
                }
                if (algorythm_id == 3)
                {
                    frequent_itemsets = "";
                    foreach (Itemset itemset in eclat_Litemsets)
                    {
                        frequent_itemsets += itemset.ToString() + "\n";
                    }
                    //MessageBox.Show(frequent_itemsets, "Eclat");
                    working.Close();
                    Focus();
                    MessageBox.Show("Ukończono generowanie zbiorów algorytmem Eclat", "Eclat");
                    button_itemset_eclat.Enabled = true;
                    generate_rules_eclat_button.Enabled = true;
                    button_save_eclat.Enabled = true;
                    Enabled = true;   
                    //return;
                }
                //MessageBox.Show("done");
                Enabled = true;
                Focus();
                working.Close();
            }
        }

        private void button_show_litemsetsApriori_Click(object sender, EventArgs e)//show Apriori generated Itemset
        {
            Itemsets_display display = new Itemsets_display(apriori_Litemsets, "Apriori");
            display.show();
        }

        private void button_litemsets_TiD_Click(object sender, EventArgs e)//show AprioriTiD generated Itemset
        {
            Itemsets_display display = new Itemsets_display(aprioriTiD_Litemsets, "AprioriTiD");
            display.show();
        }

        private void button_itemset_eclat_Click(object sender, EventArgs e)//show Eclat generated Itemset
        {
            Itemsets_display display = new Itemsets_display(eclat_Litemsets, "Eclat");
            display.show();
        }

        private void button_rulesApriori_Click(object sender, EventArgs e)//show rules for Apriori L-itemsets
        {
            Rules_display display = new Rules_display(apriori_rules, "Apriori");
            display.show();
        }

        private void button_rules_aprioriTid_Click(object sender, EventArgs e)//show rules for AprioriTiD L-itemsets
        {
            Rules_display display = new Rules_display(aprioriTiD_rules, "AprioriTiD");
            display.show();
        }

        private void button_rules_eclat_Click(object sender, EventArgs e)//show rules for Eclat L-itemsets
        {
            Rules_display display = new Rules_display(eclat_rules, "Eclat");
            display.show();
        }

        private void button_save_apriori_Click(object sender, EventArgs e)//save rules and L-itemsets from Apriori
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Data_saver saver = new Data_saver(folderBrowserDialog1.SelectedPath, "apriori", apriori_rules, apriori_Litemsets);
                saver.save();                  
            }                     
        }

        private void button_save_TiD_Click(object sender, EventArgs e)//save rules and L-itemsets from AprioriTiD
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Data_saver saver = new Data_saver(folderBrowserDialog1.SelectedPath, "aprioriTiD", aprioriTiD_rules, aprioriTiD_Litemsets);
                saver.save();
            }
        }

        private void button_save_eclat_Click(object sender, EventArgs e)//save rules and L-itemsets from Eclat
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Data_saver saver = new Data_saver(folderBrowserDialog1.SelectedPath, "eclat", eclat_rules, eclat_Litemsets);
                saver.save();
            }
        }

        private void generate_rules_apriori_button_Click(object sender, EventArgs e)//generate rules and L-itemsets from Apriori
        {
            Rules_generator generator = new Rules_generator(support, confidence, apriori_Litemsets);
            generator.generate_rules();
            apriori_rules = generator.rules;
            //button_save_apriori.Enabled = true;
            button_rulesApriori.Enabled = true;
        }

        private void generate_rules_TiD_button_Click(object sender, EventArgs e)//generate rules and L-itemsets from AprioriTiD
        {
            Rules_generator generator = new Rules_generator(support, confidence, aprioriTiD_Litemsets);
            generator.generate_rules();
            aprioriTiD_rules = generator.rules;
            //button_save_TiD.Enabled = true;
            button_rules_aprioriTid.Enabled = true;
        }

        private void generate_rules_eclat_button_Click(object sender, EventArgs e)//generate rules and L-itemsets from Eclat
        {
            Rules_generator generator = new Rules_generator(support, confidence, eclat_Litemsets);
            generator.generate_rules();
            eclat_rules = generator.rules;
            //button_save_eclat.Enabled = true;
            button_rules_eclat.Enabled = true;
        }

        
    }
}
