using System.Collections.Generic;

namespace Logic
{
    public class MeasureTerms : List<MeasureTerm>
    {
        public string Formula(bool isLong = false)
        {
            var s = string.Empty;
            foreach (var e in this)
            {
                var f = e.Formula(isLong);
                if (string.IsNullOrEmpty(s)) s = f;
                else s = $"{s}*{f}";
            }
            return s;
        }


        public new void Add(MeasureTerm item)
        {
            var t = Find(x => x.Measure.Name == item.Measure.Name);
            if (t == null) base.Add(item);
            else t.Power = t.Power + item.Power;
        }       
    }
}
