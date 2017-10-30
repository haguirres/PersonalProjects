using Ford.MFalHarnesAnalyze.Model;
using Ford.MFalHarnesAnalyze.ViewModel;
using System.Collections.Generic;
using System.Windows;

namespace Ford.MFalHarnesAnalyze.Controls
{
    /// <summary>
    /// Interaction logic for MissingMFalAlert.xaml
    /// </summary>
    public partial class MissingMFalAlert : Window
    {
        public MissingMFalAlert()
        {
            InitializeComponent();
        }

        internal void Show(List<Feature> missingMfals)
        {
            MissingMFalAlertViewModel vm = new MissingMFalAlertViewModel();
            missingMfals.ForEach(s=> vm.MissingMfals.Add(s));
            this.DataContext = vm;
            this.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }
    }
}