
using System.Collections.Generic;

namespace Logic
{   
    public class DerivedUnit : Unit
    {
        protected List<UnitTerm> terms;
        public DerivedUnit() : this(null) { }

        public DerivedUnit(UnitTerms terms, string name = null, string symbol = null)
        {
            terms = terms ?? new UnitTerms();
            name = name ?? terms.Formula(true);
            symbol = symbol ?? terms.Formula();
            this.terms = terms;
            this.name = name;
            this.symbol = symbol;
            definition = name;            
        }

        public List<UnitTerm> Terms
        {
            get { return terms ?? new List<UnitTerm>(); }
            set { terms = value; }
        }

        public Unit Exponentiation(int i)
        {
            if (i == 0) return new BaseUnit();
            var a = new UnitTerms();
            foreach (var e in Terms)
            {
                var c = new UnitTerm { Unit = e.Unit, Power = e.Power };
                c.Power *= i;
                a.Add(c);
            }
            var b = new DerivedUnit(a);
            var d = (DerivedMeasure)this.measure;
            b.measure = d.Exponentiation(i);
            return b;
        }

        public Unit Reciprocal()
        {
            var a = new UnitTerms();
            foreach (var e in Terms)
            {
                var c = new UnitTerm { Unit = e.Unit, Power = e.Power};
                c.Power *= -1;
                a.Add(c);
            }
            var b = new DerivedUnit(a);
            var d = (DerivedMeasure)measure;
            b.measure = d.Reciprocal();
            return b;
        }

        public Unit Multiply(DerivedUnit d, bool isDivide = false)
        {
            if (isDivide)
                if (d == this) return new BaseUnit();
            var a = new UnitTerms();
            foreach (var e in Terms)
            {
                var c = new UnitTerm { Unit = e.Unit, Power = e.Power };
                a.Add(c);
            }
            foreach (var e in d.Terms)
            {
                var c = new UnitTerm { Unit = e.Unit, Power = e.Power };
                c.Power = isDivide ? -c.Power : c.Power;
                a.Add(c);
            }
            a.RemoveAll(x => x.Power == 0);
            var b = new DerivedUnit(a);
            var f = (DerivedMeasure)measure;
            b.measure = isDivide ? f.Divide((DerivedMeasure)d.measure) : f.Multiply((DerivedMeasure)d.measure);
            b.Factor = Factor * d.Factor;
            return b;
        }

        public Unit Divide(DerivedUnit d)
        {
            return Multiply(d, true);
        }
    }
}
