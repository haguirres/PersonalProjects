using System.Collections.Generic;

namespace Ford.MFalHarnesAnalyze.Model
{
    public class AnalyzeCalculation
    {
        public string Mfal { get; set; }
        public double TotalTakeRate { get; set; }
        public string HarnessBaseNumber { get; set; }
        public int CircuitCount { get; set; }
        public string WireName { get; set; }
        public List<AnalyzeCalculation> MfalDetail { get; set; }
        public bool HiddenDetail
        {
            get {

                return MfalDetail.Count <= 0;
            }
        }
        public AnalyzeCalculation()
        {
            MfalDetail = new List<AnalyzeCalculation>();
        }
    }
}