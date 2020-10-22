using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BaseUnit : Unit
    {
        public BaseUnit() : this(new BaseMeasure(), 0, string.Empty, string.Empty) { }
        public BaseUnit(Measure m, double factor, string symbol, string name) : base(name, symbol)
        {
            m = m ?? new BaseMeasure();
            measure = m;
            this.factor = factor;
        }
    }
}
