using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Unit : Metric
    {        
        protected Measure measure;
        protected double factor;

        public Unit(string name, string symbol = null, string definition = null) : base(name, symbol, definition) { }
        
        public Unit() : this(string.Empty) { }
      
        public Measure Measure
        {
            get { return measure ?? new BaseMeasure(); }
            set { measure = value; }
        }

        public double Factor
        {
            get { return factor; }
            set { factor = value; }
        }

        public double ToBase(double amount)
        {
            return amount * factor;
        }

        public double FromBase(double amount)
        {
            return amount / factor;
        }
    }
}
