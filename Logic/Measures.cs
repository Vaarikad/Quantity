using System.Collections.Generic;

namespace Logic
{
    public class Measures : List<Measure>
    {
        public static Measures Instance { get; } = new Measures();

        internal static Measure Add(string name)
        {
            var m = Instance.Find(x => x.Name == name);
            if (m != null) return m;
            m = new BaseMeasure(name);
            Instance.Add(m);
            return m;
        }


        internal static Measure Find(string measure)
        {
            return Instance.Find(x => x.Name == measure);
        }
    }
}
