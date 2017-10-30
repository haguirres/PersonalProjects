namespace Ford.MFalHarnesAnalyze.Model
{
    public class Wirelist
    {
        public string HarnessBaseNumber { get; set; }
        public string ConductorWirename { get; set; }
        public string OptionTextDisplay { get; set; }
        public string BooleanExpression { get; set; }
        public Composite CompositeElement { get; set; }
        public Wirelist()
        {
            CompositeElement = new Composite();
        }
    }
}