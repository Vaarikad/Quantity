namespace Logic
{
    public class MeasureTerm
    {
        private int power;
        protected Measure measure;
        public MeasureTerm() : this(null)
        {
        }
        public MeasureTerm(BaseMeasure m, int power = 0)
        {
            this.measure = m ?? new BaseMeasure();
            this.power = power;
        }

        public Measure Measure
        {
            get { return measure; }
            set { measure = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        
        public string Formula(bool isLong = false)
        {
            var n = isLong ? Measure.Name : Measure.Symbol;
            if (Power == 0) return $"{n}";
            return $"{n}^{Power}";
        }       
    }
}
