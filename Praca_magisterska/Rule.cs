using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Praca_magisterska
{
    class Rule
    {
        public List<String> prev = new List<String>();
        public List<String> next = new List<String>();
        public double support = new double();
        public double confidence = new double();

        public Rule(List<String> prev, List<String> next, double support, double confidence)
        {
            this.prev = prev;
            this.next = next;
            this.support = support;
            this.confidence = confidence;
        }

        public Rule(List<String> prev, List<String> next, double support)
        {
            this.prev = prev;
            this.next = next;
            this.support = support;
            this.confidence = 0;
        }

        public Rule(){ }
    }
}
