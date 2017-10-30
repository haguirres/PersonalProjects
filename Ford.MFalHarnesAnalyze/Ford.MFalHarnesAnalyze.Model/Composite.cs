using System.ComponentModel;

namespace Ford.MFalHarnesAnalyze.Model
{
    public class Composite : INotifyPropertyChanged
    {
        private string compositeCode;
        private bool isSelected;

        public string CompositeCode
        {
            get
            {
                return compositeCode;
            }

            set
            {
                this.compositeCode = value;
                OnPropertyChanged("CompositeCode");
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                this.isSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handled = PropertyChanged;
            if (handled != null)
            {
                handled(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion INotifyPropertyChanged
    }
}