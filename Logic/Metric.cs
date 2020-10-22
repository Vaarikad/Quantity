using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Metric
    {
        protected string name;
        protected string symbol;
        protected string definition;        
        public Metric() : this(null) { }
        public Metric(string name, string symbol = null, string definition = null)
        {
            name = name ?? string.Empty;
            symbol = symbol ?? name;
            definition = definition ?? name;
            this.name = name;
            this.symbol = symbol;
            this.definition = definition;            
        }

        public virtual string Formula(bool isLong = false)
        {
            return isLong ? Name : Symbol;
        }

        public string Name
        {
            get { return name ?? string.Empty; }
            set { name = value; }
        }
        public string Symbol
        {
            get { return symbol ?? string.Empty; }
            set { symbol = value; }
        }

        public string Definition
        {
            get { return definition ?? string.Empty; }
            set { definition = value; }
        }        
    }
}
