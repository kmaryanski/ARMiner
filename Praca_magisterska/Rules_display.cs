using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_magisterska
{
    class Rules_display
    {
        List<Rule> rules = new List<Rule>();
        string title = "";

        public Rules_display(List<Rule> list, string title)
        {
            this.rules = list;
            this.title = title;
        }

        public void show()
        {
            Show_rules window = new Show_rules();
            window.Show();

            foreach (Rule r in rules)
            {
                DataGridViewRow row = new DataGridViewRow();
                //row.CreateCells(window.dataGridView1);
                string prv = "{";
                foreach (string element in r.prev)
                {
                    prv += element + ", ";
                }
                //prv += "}";
                prv = prv.Substring(0, prv.Length - 2) + "}";

                string nxt = "{";
                foreach (string element in r.next)
                {
                    nxt += element + ", ";
                }
                //nxt += "}";
                nxt = nxt.Substring(0, nxt.Length - 2) + "}";

                //row.Cells[0].Value = items;
                //row.Cells[1].Value = i.support.ToString();
                window.dataGridView1.Rows.Add(prv, "=>", nxt, string.Format("{0:0.000}", r.support), string.Format("{0:0.000}", r.confidence));

            }
            window.Text += "-" + title;
        }
    }
}
