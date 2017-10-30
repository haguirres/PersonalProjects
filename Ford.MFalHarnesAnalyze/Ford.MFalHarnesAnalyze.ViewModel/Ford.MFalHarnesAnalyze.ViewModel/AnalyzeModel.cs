using Ford.MFalHarnesAnalyze.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Ford.MFalHarnesAnalyze.ViewModel
{
    public class AnalyzeModel
    {
        public string TrimFileName { get; set; }
        public string WirelistFileName { get; set; }
        public string RegionName { get; set; }
        public string FileName { get; set; }
        public List<Composite> CompositeList { get; set; }
        public TakeRate takeRate { get; set; }
        public List<Wirelist> wirelist { get; set; }
        public ObservableCollection<AnalyzeCalculation> CalculationList { get; set; }
        
    }
}
