using Ford.MFalHarnesAnalyze.Controls;
using Ford.MFalHarnesAnalyze.ViewModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Ford.MFalHarnesAnalyze
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MissingMFalAlertViewModel mvm;

        public MainWindow()
        {
            InitializeComponent();
            mvm = new MissingMFalAlertViewModel();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void DataGrid_RowDetailsVisibilityChanged(object sender, DataGridRowDetailsEventArgs e)
        {
            var row = e.Row.DataContext as MFalHarnesAnalyze.Model.AnalyzeCalculation;
            if (row.MfalDetail.Count < 1)
            {
                e.DetailsElement.Visibility = Visibility.Collapsed;
            }
            else
            {
                e.DetailsElement.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MissingMFalAlert alert = new MissingMFalAlert();
            var vm = this.DataContext as MainWindowViewModel;

            vm.CalculateByHarnessCommand.Execute(null);
            var list = vm.MissingMfals;

            if (list.Count > 0)
            {
                mvm.MissingMfals.Clear();
                list.ForEach(s => mvm.MissingMfals.Add(s));
                alert.DataContext = alert.DataContext ?? mvm;
                alert.Topmost = true;
                //alert.ShowInTaskbar = true;
                alert.Show();
            }
        }

        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    row.DetailsVisibility =
                    row.DetailsVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
                    break;
                }
        }

        private void ComboBox_Selected(object sender, RoutedEventArgs e)
        {
        }
    }
}