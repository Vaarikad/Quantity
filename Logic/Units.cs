
using System.Collections.Generic;

namespace Logic
{
    public class Units : List<Unit>
    {
        public static Units Instance { get; } = new Units();

        internal static Unit Add(Measure m, double factor, string symbol, string name = null)
        {
            var u = Instance.Find(x => x.Measure == m && x.Symbol == symbol);
            if (u != null) return u;
            u = new BaseUnit(m , factor, symbol, name);
            Instance.Add(u);
            return u;
        }

        internal static Unit Add(DerivedMeasure m, double factor, string symbol, string name = null)
        {
            var u = Instance.Find(x => x.Measure == m && x.Symbol == symbol);
            if (u != null) return u;
            u = new BaseUnit(m, factor, symbol, name);
            Instance.Add(u);
            return u;
        }

        internal static Unit Find(string unit)
        {
            return Instance.Find(x => x.Name == unit);
        }        
    }
}
