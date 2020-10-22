using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Measure: Metric
    {

        public Measure(string name, string symbol = null) : base(name, symbol)
        {
        }

        public Measure() : this(String.Empty)
        {

        }        
    }
}
