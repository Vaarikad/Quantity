using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Quantity
    {
        private double amount;
        private Unit unit;
        public Quantity() : this(0, null) { }
        public Quantity(double amount, Unit u)
        {
            u = u ?? new BaseUnit();
            Unit = u;
            Amount = amount;
        }

        public Unit Unit
        {
            get { return unit ?? new BaseUnit(); }
            set { unit = value; }
        }

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }     
    }
}
