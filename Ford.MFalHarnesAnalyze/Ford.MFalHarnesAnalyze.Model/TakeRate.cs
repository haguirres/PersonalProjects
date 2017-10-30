using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ford.MFalHarnesAnalyze.Model
{
    public class TakeRate
    {
        #region Properties

        public string Name { get; set; }

        public List<Version> Series { get; set; }

        public List<Version> Packages { get; set; }

        public List<Version> Freestandings { get; set; }

        public List<Feature> Features { get; set; }

        #endregion

        #region Constructor

        public TakeRate()
        {
            this.Series = new List<Version>();
            this.Packages = new List<Version>();
            this.Freestandings = new List<Version>();
            this.Features = new List<Feature>();
        }

        #endregion
    }
}
