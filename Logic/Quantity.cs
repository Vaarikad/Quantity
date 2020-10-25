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

        public bool IsEqual(Quantity q)
        {
            var u1 = Unit;
            var u2 = q.Unit;
            if (u1.Measure != u2.Measure) return false;
            var q1 = Convert(u2);
            return Math.Abs(q1.Amount - q.Amount) < 0.0000000001;
        }

        public bool IsGreaterThan(Quantity q, bool isLess = false)
        {
            var u1 = Unit;
            var u2 = q.Unit;
            if (u1.Measure != u2.Measure) return false;
            var q1 = Convert(u2);
            return isLess ? q.Amount < q1.Amount : q.Amount > q1.Amount;
        }

        public bool IsLessThan(Quantity q)
        {
            return IsGreaterThan(q, true);
        }

        public Quantity Convert(Unit u)
        {
            var a = Unit.ToBase(amount);
            a = u.FromBase(a);
            return new Quantity(a, u);
        }
        public Quantity ConvertTo(Unit u)
        {
            u = u ?? new BaseUnit();
            var d = ConvertTo(amount, u);
            return new Quantity(d, u);
        }
        private double ConvertTo(double d, Unit u)
        {
            if (ReferenceEquals(null, u)) return double.NaN;
            if (!IsSameMeasure(u)) return double.NaN;
            d = Unit.ToBase(d);
            return u.FromBase(d);
        }
        private bool IsSameMeasure(Unit u)
        {
            return Unit.Measure.Name == u.Measure.Name;
        }

        public Quantity Add(Quantity q)
        {
            var u1 = Unit;
            var u2 = q.Unit;
            if (u1.Measure.Name != u2.Measure.Name) return new Quantity();
            var a = Unit.ToBase(amount);
            a += q.Unit.ToBase(q.amount);
            return new Quantity(q.Unit.FromBase(a), q.Unit);
        }

        public Quantity Subtract(Quantity q)
        {
            var u1 = Unit;
            var u2 = q.Unit;
            if (u1.Measure.Name != u2.Measure.Name) return new Quantity();
            var a = Unit.ToBase(amount);
            a = a - q.Unit.ToBase(q.amount);
            return new Quantity(q.Unit.FromBase(a), q.Unit);
        }

        public Quantity Multiply(double a) { return new Quantity(Amount * a, Unit); }

        public Quantity Divide(double a) { return new Quantity(Amount / a, Unit); }

        public Quantity Multiply(Quantity q, bool isDivide = false)
        {
            if (Unit.Measure.Name != q.Unit.Measure.Name) return new Quantity();
            var b = Convert(q.Unit);
            Unit u;
            if (q.Unit is DerivedUnit)
            {
                var u1 = (DerivedUnit)Unit;
                var u2 = (DerivedUnit)q.Unit;
                u = isDivide ? u1.Divide(u2) : u1.Multiply(u2);
            }
            else
            {
                var u1 = (BaseUnit)Unit;
                var u2 = (BaseUnit)q.Unit;
                u = isDivide ? u1.Divide(u2) : u1.Multiply(u2);
            }
            var a = isDivide ? b.Amount / q.Amount : b.Amount * q.Amount;
            return new Quantity(a, u);
        }

        public Quantity Divide(Quantity q)
        {
            return Multiply(q, true);
        }
        public Quantity Round(RoundingPolicy policy)
        {
            var d = RoundNumber(amount, policy);
            return new Quantity(d, Unit);
        }
        private static double RoundNumber(double d, RoundingPolicy p)
        {
            switch (p.Strategy)
            {
                case RoundingStrategy.Up:
                    return Logic.Round.Up(d, p.Decimals);
                case RoundingStrategy.Down:
                    return Logic.Round.Down(d, p.Decimals);
                case RoundingStrategy.UpByStep:
                    return Logic.Round.UpByStep(d, p.Step);
                case RoundingStrategy.DownByStep:
                    return Logic.Round.DownByStep(d, p.Step);
                case RoundingStrategy.TowardsPositive:
                    return Logic.Round.TowardsPositive(d, p.Decimals);
                case RoundingStrategy.TowardsNegative:
                    return Logic.Round.TowardsNegative(d, p.Decimals);
                default:
                    return Logic.Round.Off(d, p.Decimals, p.Digit);
            }
        }
    }
}
