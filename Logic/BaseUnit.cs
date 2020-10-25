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

        public Unit Exponentiation(int i)
        {
            if (i == 0) return new BaseUnit();
            UnitTerm t1;
            
            t1 = new UnitTerm(this, i);
            var t = new UnitTerms { t1 };
            var a = new DerivedUnit(t);
            var b = (BaseMeasure)this.measure;
            a.Measure = b.Exponentiation(i);
            a.Factor = Math.Pow(Factor, i);
            Measures.Instance.Add(a.Measure);
            return a;
        }

        public Unit Reciprocal()
        {
            var t1 = new UnitTerm(this, -1);
            var t = new UnitTerms { t1 };
            var a = new DerivedUnit(t);
            var b = (BaseMeasure)this.measure;
            a.Measure = b.Reciprocal();
            return a;
        }

        public Unit Multiply(BaseUnit i, bool isDivide = false)
        {
            var t1 = new UnitTerm(this, 1);
            var t2 = isDivide ? new UnitTerm(i, -1) : new UnitTerm(i, 1);
            var t = new UnitTerms { t1, t2 };
            var a = new DerivedUnit(t);
            var b = (BaseMeasure)measure;
            a.Measure = isDivide ? b.Multiply((BaseMeasure)i.Measure, true) : b.Multiply(i.Measure);
            return a;
        }

        public Unit Multiply(DerivedUnit m)
        {
            var t = new UnitTerms();
            t.Add(new UnitTerm(this, 1));
            foreach (var e in m.Terms)
            {
                t.Add(new UnitTerm(e.Unit as BaseUnit, e.Power));
            }
            var a = new DerivedUnit(t);
            var b = (BaseMeasure)measure;
            a.Measure = b.Multiply((DerivedMeasure)m.Measure);
            return a;
        }

        public Unit Multiply(Unit m)
        {
            if (m is DerivedUnit) return Multiply(m as DerivedUnit);
            return Multiply(m as BaseUnit);
        }

        public Unit Divide(BaseUnit i)
        {
            var a = Multiply(i, true);
            return a;
        }        
    }
}
