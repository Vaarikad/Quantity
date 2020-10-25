using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public abstract class Unit : Metric
    {
        protected SystemOfUnits systemOfUnits;
        protected Measure measure;
        protected double factor;

        public Unit(string name, string symbol = null, string definition = null) : base(name, symbol, definition) { }
        
        public Unit() : this(string.Empty) { }

        public SystemOfUnits SystemOfUnits
        {
            get { return systemOfUnits ?? new SystemOfUnits(); }
            set { systemOfUnits = value; }
        }

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

        public static double SetFactor(string s)
        {
            if (s.Length == 1) return 1;
            string firstLetter = s.Substring(0, 1);
            string secondLetter = s.Substring(1, 1);
            if (firstLetter == "c") return Factors.Centi;
            if (firstLetter == "d" && secondLetter == "a") return Factors.Deca;
            if (firstLetter == "d") return Factors.Deci;
            if (firstLetter == "h") return Factors.Hecto;
            if (firstLetter == "k") return Factors.Kilo;
            if (firstLetter == "M") return Factors.Mega;
            if (firstLetter == "G") return Factors.Giga;
            if (firstLetter == "T") return Factors.Tera;
            if (firstLetter == "μ") return Factors.Micro;
            if (firstLetter == "n") return Factors.Nano;
            if (firstLetter == "p") return Factors.Pico;
            return 1;
        }
    }
}
