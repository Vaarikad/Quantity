
namespace Logic
{
    public class DerivedMeasure : Measure
    {
        private MeasureTerms terms;
        public MeasureTerms Terms
        {
            get { return terms; }
            set { terms = value; }
        }
        public static void Initialize()
        {
            var a = Measures.Add("area");
            Logic.Units.Add(a, 1, "m2", "ruutmeeter");

            var v = Measures.Add("volume");
            Logic.Units.Add(v, 1, "m3", "kuupmeeter");

            var s = Measures.Add("speed");
            Logic.Units.Add(s, 1, "m/s", "meetrit sekundis");

            var t = Measures.Add("acceleration");
            Logic.Units.Add(t, 1, "m/s2", "meetrit ruutsekundis");

            var c = Measures.Add("current density");
            Logic.Units.Add(c, 1, "A/m2", "amprit ruutmeetris");

            var u = Measures.Add("concentration");
            Logic.Units.Add(u, 1, "mol/m3", "mooli kuumpeetris");

            var l = Measures.Add("luminance");
            Logic.Units.Add(l, 1, "cd/m2", "meetrit sekundis");

        }
        public DerivedMeasure() : this(null) { }

        public DerivedMeasure(MeasureTerms terms, string name = null, string symbol = null)
        {
            terms = terms ?? new MeasureTerms();
            this.terms = terms;
            this.name = name ?? terms.Formula();
            this.symbol = symbol ?? name;
            definition = name;            
        }                

        public override string Formula(bool isLong = false)
        {
            return terms.Formula(isLong);
        }

        public Measure Multiply(DerivedMeasure d)
        {
            var a = new MeasureTerms();
            foreach (var e in Terms)
            {
                var c = new MeasureTerm { Measure = e.Measure, Power = e.Power };
                a.Add(c);
            }
            foreach (var e in d.Terms)
            {
                var c = new MeasureTerm { Measure = e.Measure, Power = e.Power };
                a.Add(c);
            }
            return new DerivedMeasure(a);
        }

        public Measure Divide(DerivedMeasure d)
        {
            if (d == this) return new BaseMeasure();
            var a = new MeasureTerms();
            foreach (var e in Terms)
            {
                var c = new MeasureTerm { Measure = e.Measure, Power = e.Power };
                a.Add(c);
            }
            foreach (var e in d.Terms)
            {
                var c = new MeasureTerm { Measure = e.Measure, Power = e.Power };
                c.Power = -c.Power;
                a.Add(c);
            }
            a.RemoveAll(x => x.Power == 0);
            return new DerivedMeasure(a);
        }

        public Measure Exponentiation(int i)
        {
            if (i == 0) return new BaseMeasure();
            var a = new MeasureTerms();
            foreach (var e in Terms)
            {
                var c = new MeasureTerm { Measure = e.Measure, Power = e.Power };
                c.Power *= i;
                a.Add(c);
            }
            return new DerivedMeasure(a);
        }

        public Measure Reciprocal()
        {
            var a = new MeasureTerms();
            foreach (var e in Terms)
            {
                var c = new MeasureTerm { Measure = e.Measure, Power = e.Power };
                c.Power *= -1;
                a.Add(c);
            }
            return new DerivedMeasure(a);
        }
    }
}
