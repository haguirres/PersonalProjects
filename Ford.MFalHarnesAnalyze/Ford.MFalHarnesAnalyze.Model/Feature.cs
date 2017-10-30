using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ford.MFalHarnesAnalyze.Model
{
    public class Feature
    {
        #region Properties

        public string MFAL { get; set; }

        public List<Version> Series { get; set; }

        public List<Version> Packages { get; set; }

        public List<Version> Freestandings { get; set; }

        public double TotalTakeRate { get; set; }

        public string HarnessBaseNumber { get; set; }
        #endregion

        #region Constructor

        public Feature()
        {
            this.Series = new List<Version>();
            this.Packages = new List<Version>();
            this.Freestandings = new List<Version>();
        }

        #endregion

        #region Methods

        public string GetFamily()
        {
            return this.MFAL.Substring(0, 3);
        }

        #endregion
    }
}
