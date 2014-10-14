using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_magisterska
{
    class Itemsets_display
    {
        List<Itemset> itemsets = new List<Itemset>();
        string title = "";

        public Itemsets_display(List<Itemset> list, string title)
        {
            this.itemsets = list;
            this.title = title;
        }

        public void show()
        {
            Show_itemsets window = new Show_itemsets();
            window.Show();
            //if(itemsets.Count==0)
            //{
            //    return;
            //}
            foreach(Itemset i in itemsets)
            {
                
                DataGridViewRow row = new DataGridViewRow();
                //row.CreateCells(window.dataGridView1);
                string items = "{";
                foreach(string element in i.items)
                {
                    items += element + ", ";
                }
                //items[items.Last(',')] = "}";
                //items += "}";
                items = items.Substring(0, items.Length - 2) + "}";
                //row.Cells[0].Value = items;
                //row.Cells[1].Value = i.support.ToString();
                window.dataGridView1.Rows.Add(items, string.Format("{0:0.000}", i.support));
                
            }
            window.Text += "-" + title;
           
        }
    }
}
