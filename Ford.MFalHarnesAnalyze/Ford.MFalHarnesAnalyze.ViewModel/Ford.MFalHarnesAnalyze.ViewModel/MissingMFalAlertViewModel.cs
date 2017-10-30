using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ford.MFalHarnesAnalyze.Model;
using System.Collections.ObjectModel;

namespace Ford.MFalHarnesAnalyze.ViewModel
{
   public class MissingMFalAlertViewModel  :ViewModelBase
    {
        private ObservableCollection<Feature> missingMfals;

        public MissingMFalAlertViewModel()
        {
            MissingMfals = new ObservableCollection<Feature>();
        }
      
        public ObservableCollection<Feature> MissingMfals
        {
            get
            {
                return missingMfals;
            }

            set
            {
                this.missingMfals = value;
                OnPropertyChanged("MissingMfals");
            }
        }
    }
}
