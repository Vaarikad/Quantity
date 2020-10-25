using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class UnitTerm
    {
        protected int power;
        protected Unit unit;
        public UnitTerm() : this(null) { }
        public UnitTerm(Unit u, int power = 0)
        {
            this.unit = u;
            this.power = power;
        }
        
        public Unit Unit
        {
            get { return unit ?? new BaseUnit(); }
            set { unit = value; }
        }

        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public string Formula(bool isLong = false)
        {
            var n = isLong ? Unit.Name : Unit.Symbol;
            if (Power == 1 || Power == 0) return $"{n}";
            return $"{n}^{Power}";
        }
    }
}
