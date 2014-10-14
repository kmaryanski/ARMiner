using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praca_magisterska
{
    class Data_loader
    {
        public String file = "";

        public Data_loader(string filename)
        {
            this.file = filename;
        }

        public List<Transaction> load_data()
        {
            List<Transaction> data = new List<Transaction>();
            //otwarcie pliku
            try
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    string line;
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        i++;
                        string[] transaction_array = line.Split('\t');
                        Transaction transaction = new Transaction(i, transaction_array);
                        data.Add(transaction);
                    }
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Nie znaleziono pliku \n." + file, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return data;
            }
            return data;
            //throw new NotImplementedException();
        }

    }
}
