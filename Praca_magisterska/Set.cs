using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Praca_magisterska
{
    class Set
    {
        public List<string> items = new List<string>();
        public Set() { }
        public Set(String item)
        {
            this.items.Add(item);
        }
    }
}
