using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BaseMeasure : Measure
    {
        public BaseMeasure(string name, string symbol = null) : base(name, symbol) { }

        public BaseMeasure() : this(string.Empty) { }       

        public Measure Multiply(BaseMeasure m, bool isDivide = false)
        {
            var t1 = new MeasureTerm(this, 1);
            var t2 = isDivide ? new MeasureTerm(m, -1) : new MeasureTerm(m, 1);
            var t = new MeasureTerms { t1, t2 };
            return new DerivedMeasure(t);
        }

        public Measure Multiply(DerivedMeasure m)
        {
            var t = new MeasureTerms();
            t.Add(new MeasureTerm(this, 1));
            foreach (var e in m.Terms)
            {
                t.Add(new MeasureTerm(e.Measure as BaseMeasure, e.Power));
            }
            return new DerivedMeasure(t);
        }

        public Measure Multiply(Measure m)
        {
            if (m is DerivedMeasure) return Multiply(m as DerivedMeasure);
            return Multiply(m as BaseMeasure);
        }

        public Measure Divide(BaseMeasure m)
        {
            var s = Multiply(m, true);
            return s;
        }

        public Measure Exponentiation(int i)
        {
            if (i == 0) return new BaseMeasure();
            MeasureTerm t1;
            if (i == 1)
                t1 = new MeasureTerm(this);
            else
                t1 = new MeasureTerm(this, i);
            var t = new MeasureTerms { t1 };
            return new DerivedMeasure(t);
        }

        public Measure Reciprocal()
        {
            var t1 = new MeasureTerm(this, -1);
            var t = new MeasureTerms { t1 };
            return new DerivedMeasure(t);
        }
    }
}
