using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class BaseMeasure : Measure
    {
        public BaseMeasure(string name, string symbol = null) : base(name, symbol) { }

        public BaseMeasure() : this(string.Empty) { }

        public static int Multiply(int a, int b)
        {
            return a * b;
        }
    }
}
