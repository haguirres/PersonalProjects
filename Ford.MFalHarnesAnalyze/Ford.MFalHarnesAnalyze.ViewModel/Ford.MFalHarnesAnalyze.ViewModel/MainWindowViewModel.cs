using CsvHelper;
using Ford.MFalHarnesAnalyze.Model;
using Ford.MFalHarnesAnalyze.Office;
using Ford.MFalHarnesAnalyze.ViewModel.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ford.MFalHarnesAnalyze.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Commands

        public SimpleCommand LoadTrimCommand { get; private set; }
        public SimpleCommand LoadWirelistCommand { get; private set; }
        public SimpleCommand LoadDataSetCommand { get; private set; }
        public SimpleCommand CalculateCommand { get; private set; }
        public SimpleCommand ExportCommand { get; private set; }
        public SimpleCommand LoadJSON { get; private set; }
        public SimpleCommand SaveCommand { get; private set; }
        public SimpleCommand SaveAsCommand { get; private set; }
        public SimpleCommand SaveDataSetFileCommand { get; set; }
        public SimpleCommand CleanCompositeCommand { get; private set; }
        public SimpleCommand CleanHarnessCommand { get; private set; }
        public SimpleCommand CleanCommand { get; private set; }
        public SimpleCommand CheckCompositeCommand { get; private set; }
        public SimpleCommand CalculateByHarnessCommand { get; private set; }
        public SimpleCommand ExportHarnessCommand { get; private set; }
        public SimpleCommand ValidateDataSetCommand { get; set; }

        #endregion Commands

        #region Properties

        private AnalyzeModel model;
        private const string filterJSON = "JSON Files | *.json";
        private const string filterCSV = "Comma-Separated Values | *.csv";
        private const string filterAllFiles = "All Files | *.*";
        private const string filterTxtFiles = "Text File | *.txt";

        private bool showAlertHarness;
        private bool enableMFalTab;
        private bool enableHarnessTab;
        private bool enableLevelTab;
        private bool enableSaveDataset;
        private string trimFileName;
        private string wirelistFileName;
        private string dataSetFileName;
        private string regionName;
        private string fileName;
        private TakeRate takeRate;
        private DataSetModel datasetModel;
        private List<Wirelist> wirelist;
        private List<Composite> compositeList;
        private List<Harness> harnessList;
        private List<Harness> harnessLevelList;
        private List<Feature> missingMfals;
        private ObservableCollection<AnalyzeCalculation> calculationList;
        private ObservableCollection<AnalyzeCalculation> calculationByHarnessList;
        private ObservableCollection<AnalyzeCalculation> calculationToLevelList;

        public bool EnableLevelTab
        {
            get
            {
                return enableLevelTab;
            }

            set
            {
                this.enableLevelTab = value;
                OnPropertyChanged("EnableLevelTab");
            }
        }

        public string RegionName
        {
            get
            {
                return regionName;
            }

            set
            {
                this.regionName = value;
                OnPropertyChanged("RegionName");
            }
        }

        public string FileName
        {
            get
            {
                return fileName;
            }

            set
            {
                this.fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public string TrimFileName
        {
            get
            {
                return trimFileName;
            }

            set
            {
                this.trimFileName = value;
                this.OnPropertyChanged("TrimFileName");
            }
        }

        public string WirelistFileName
        {
            get
            {
                return wirelistFileName;
            }

            set
            {
                this.wirelistFileName = value;
                OnPropertyChanged("WirelistFileName");
            }
        }

        public string DataSetFileName
        {
            get
            {
                return dataSetFileName;
            }

            set
            {
                this.dataSetFileName = value;
                OnPropertyChanged("DataSetFileName");
            }
        }

        public List<Composite> CompositeList
        {
            get
            {
                return compositeList;
            }

            set
            {
                this.compositeList = value;

                OnPropertyChanged("CompositeList");
            }
        }

        public List<Harness> HarnessList
        {
            get
            {
                return harnessList;
            }

            set
            {
                this.harnessList = value;
                OnPropertyChanged("HarnessList");
            }
        }

        public List<Harness> HarnessLevelList
        {
            get
            {
                return harnessLevelList;
            }

            set
            {
                this.harnessLevelList = value;
                OnPropertyChanged("HarnessLevelList");
            }
        }

        public ObservableCollection<AnalyzeCalculation> CalculationList
        {
            get
            {
                return calculationList;
            }

            set
            {
                this.calculationList = value;
                OnPropertyChanged("CalculationList");
            }
        }

        public ObservableCollection<AnalyzeCalculation> CalculationByHarnessList
        {
            get
            {
                return calculationByHarnessList;
            }

            set
            {
                this.calculationByHarnessList = value;
                OnPropertyChanged("CalculationByHarnessList");
            }
        }

        public ObservableCollection<AnalyzeCalculation> CalculationToLevelList
        {
            get
            {
                return calculationToLevelList;
            }

            set
            {
                this.calculationToLevelList = value;
                OnPropertyChanged("CalculationToLevelList");
            }
        }

        public bool ShowAlertHarness
        {
            get
            {
                return showAlertHarness;
            }

            set
            {
                this.showAlertHarness = value;
                OnPropertyChanged("ShowAlertHarness");
            }
        }

        public List<Feature> MissingMfals
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

        public bool EnableMFalTab
        {
            get
            {
                return enableMFalTab;
            }

            set
            {
                this.enableMFalTab = value;
                OnPropertyChanged("EnableMFalTab");
            }
        }

        public bool EnableHarnessTab
        {
            get
            {
                return enableHarnessTab;
            }

            set
            {
                this.enableHarnessTab = value;
                OnPropertyChanged("EnableHarnessTab");
            }
        }

        public bool EnableSaveDataset
        {
            get
            {
                return enableSaveDataset;
            }

            set
            {
                this.enableSaveDataset = value;
                OnPropertyChanged("EnableSaveDataset");
            }
        }

        #endregion Properties

        #region Constructor

        public MainWindowViewModel()
        {
            model = new AnalyzeModel();
            datasetModel = new DataSetModel();
            LoadTrimCommand = new SimpleCommand(LoadTrim);
            LoadWirelistCommand = new SimpleCommand(LoadWirelist);
            LoadDataSetCommand = new SimpleCommand(LoadDataSet);
            CalculateCommand = new SimpleCommand(Calculate);
            ExportCommand = new SimpleCommand(ExportToExcel);
            SaveCommand = new SimpleCommand(Save);
            SaveAsCommand = new SimpleCommand(SaveAsTrim);
            SaveDataSetFileCommand = new SimpleCommand(SaveDataSet);
            ExportHarnessCommand = new SimpleCommand(ExportHarnessToExcel);
            CleanHarnessCommand = new SimpleCommand(CleanHarness);
            CleanCompositeCommand = new SimpleCommand(CleanComposite);
            CleanCommand = new SimpleCommand(Clean);
            LoadJSON = new SimpleCommand(LoadJson);
            CalculateByHarnessCommand = new SimpleCommand(CalculateByHarness);
            ValidateDataSetCommand = new SimpleCommand(ValidateDataSet);
            CompositeList = new List<Composite>();
            wirelist = new List<Wirelist>();
            CalculationList = new ObservableCollection<AnalyzeCalculation>();
            CalculationByHarnessList = new ObservableCollection<AnalyzeCalculation>();
            CalculationToLevelList = new ObservableCollection<AnalyzeCalculation>();
            ShowAlertHarness = false;
            EnableLevelTab = false;
            EnableMFalTab = true;
            EnableHarnessTab = true;
            EnableSaveDataset = false;
        }

       

        #endregion Constructor

        #region Private Methods

        private void CleanComposite()
        {
            CompositeList.ForEach(s => s.IsSelected = false);
        }

        private void CleanHarness()
        {
            HarnessList.ForEach(s => s.IsSelected = false);
        }

        private void Clean()
        {
            model = new AnalyzeModel();
            CompositeList = new List<Composite>();
            wirelist.Clear();
            CalculationList.Clear();
            CalculationByHarnessList.Clear();
            TrimFileName = string.Empty;
            WirelistFileName = string.Empty;
            RegionName = string.Empty;
            EnableHarnessTab = true;
            EnableMFalTab = true;
            EnableMFalTab = false;
        }

        private void LoadTrim()
        {
            string[] fileNames = OpenDialogFiles(filterJSON);
            try
            {
                TrimFileName = fileNames[0];
                takeRate = ReadTrimFiles(fileNames);
            }
            catch (System.Exception)
            {
                System.Windows.Forms.MessageBox.Show("There was a problem reading the file, ensure it has the correct format and try angain.", "File loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadWirelist()
        {
            string[] fileNames = OpenDialogFiles(filterCSV);
            try
            {
                WirelistFileName = fileNames[0];
                wirelist = ReadWirelist(WirelistFileName);
                CompositeList = GetCompositeList(wirelist);
                HarnessList = GetHarnessList(wirelist);
                HarnessLevelList = GetHarnessList(wirelist);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("There was a problem reading the file, ensure it has the correct format and try again.", "File loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataSet()
        {
            string[] fileNames = OpenDialogFiles(filterAllFiles);
            try
            {
                DataSetFileName = fileNames[0];
                datasetModel = ReadDataSet(DataSetFileName);
            }
            catch (System.Exception e)
            {
                System.Windows.Forms.MessageBox.Show("There was a problem reading the file, ensure it has the correct format and try again.", "File loading", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Calculate()
        {
            CalculationList.Clear();
            var compositeSelected = compositeList.Where(p => p.IsSelected).ToList();
            var excessMfals = ValidateMfalInTrim(takeRate, wirelist, harnessList, compositeSelected);
            if (excessMfals.Count == 0)
            {
                CalculateByMFal(takeRate, wirelist, compositeSelected);
                CalculateStandard(wirelist, compositeSelected);
                CalculateBoolean(takeRate, wirelist, compositeSelected);
                EnableHarnessTab = false;
                EnableLevelTab = true;
            }
            else
            {
                var dialog = MessageBox.Show("Your Trim file has more Mfal than the Harness, you want to eliminate the excess? ", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dialog == DialogResult.No)
                {
                    MessageBox.Show("You can't continue the process, please correct the Trim file.");
                    EnableLevelTab = false;
                }
                else
                {
                    EnableLevelTab = true;
                    CalculateByMFal(takeRate, wirelist, compositeSelected);
                    CalculateStandard(wirelist, compositeSelected);
                    CalculateBoolean(takeRate, wirelist, compositeSelected);
                }
            }
        }

        private void CalculateByHarness()
        {
            MissingMfals = new List<Feature>();
            CalculationByHarnessList = new ObservableCollection<AnalyzeCalculation>();
            var compositeSelected = compositeList.Where(p => p.IsSelected).ToList();
            var harnessSelected = harnessList.Where(p => p.IsSelected).ToList();
            wirelist = ReadWirelist(WirelistFileName);
            MissingMfals = ValidateMfalInTrim(takeRate, wirelist, harnessSelected, compositeSelected, true);
            if (MissingMfals.Count == 0)
            {
                this.CalculateByMFal(this.takeRate, this.wirelist, harnessSelected, compositeSelected);
                this.CalculateStandard(this.wirelist, harnessSelected, compositeSelected.ToList());
                this.CalculateBoolean(this.takeRate, this.wirelist, harnessSelected, compositeSelected);
                EnableMFalTab = false;
                EnableLevelTab = true;
            }
        }

        #region ByMfal

        private void CalculateByMFal(TakeRate takeRate, List<Wirelist> wirelist, List<Composite> compositeList)
        {
            foreach (var composite in compositeList)
            {
                foreach (var feature in takeRate.Features)
                {
                    var mfals = wirelist.Where(s => s.OptionTextDisplay == feature.MFAL && s.CompositeElement.CompositeCode == composite.CompositeCode).GroupBy(p => p.HarnessBaseNumber).Select(group => new
                    {
                        Harnes = group.Key,
                        Count = group.Count()
                    });
                    if (mfals.Count() > 0)
                    {
                        foreach (var item in mfals)
                        {
                            List<AnalyzeCalculation> temp = new List<AnalyzeCalculation>();
                            var data = wirelist
                                .Where(s => s.OptionTextDisplay == feature.MFAL && s.HarnessBaseNumber == item.Harnes)
                                .GroupBy(s => s.ConductorWirename).Select(group => new
                                {
                                    WireName = group.Key,
                                    Count = group.Count()
                                });
                            foreach (var wire in data)
                            {
                                temp.Add(new AnalyzeCalculation() { WireName = wire.WireName, CircuitCount = wire.Count, HarnessBaseNumber = item.Harnes, Mfal = feature.MFAL });
                            }

                            CalculationList.Add(new AnalyzeCalculation()
                            {
                                CircuitCount = item.Count,
                                Mfal = feature.MFAL,
                                TotalTakeRate = feature.TotalTakeRate,
                                HarnessBaseNumber = item.Harnes,
                                MfalDetail = temp
                            });
                        }
                    }
                }
            }
        }

        private void CalculateByMFal(TakeRate takeRate, List<Wirelist> wirelist, List<Harness> harnessSelected, List<Composite> compositeSelected)
        {
            foreach (var harnes in harnessSelected)
            {
                foreach (var feature in takeRate.Features)
                {
                    var mfals = wirelist.Where(s => s.OptionTextDisplay == feature.MFAL && s.HarnessBaseNumber == harnes.HarnessBaseNumber).GroupBy(p => p.HarnessBaseNumber).Select(group => new
                    {
                        Harnes = group.Key,
                        Count = group.Count()
                    });
                    if (mfals.Count() > 0)
                    {
                        foreach (var item in mfals)
                        {
                            List<AnalyzeCalculation> temp = new List<AnalyzeCalculation>();
                            var data = wirelist
                                .Where(s => s.OptionTextDisplay == feature.MFAL && s.HarnessBaseNumber == item.Harnes)
                                .GroupBy(s => s.ConductorWirename).Select(group => new
                                {
                                    WireName = group.Key,
                                    Count = group.Count()
                                });
                            foreach (var wire in data)
                            {
                                temp.Add(new AnalyzeCalculation() { WireName = wire.WireName, CircuitCount = wire.Count, HarnessBaseNumber = item.Harnes });
                            }

                            CalculationByHarnessList.Add(new AnalyzeCalculation()
                            {
                                CircuitCount = item.Count,
                                Mfal = feature.MFAL,
                                TotalTakeRate = feature.TotalTakeRate,
                                HarnessBaseNumber = item.Harnes,
                                MfalDetail = temp
                            });
                        }
                    }
                }
            }
        }

        #endregion ByMfal

        #region ByStandard

        private void CalculateStandard(List<Wirelist> wirelist, List<Composite> compositeList)
        {
            foreach (var item in compositeList)
            {
                var data = wirelist.Where(s => string.IsNullOrEmpty(s.OptionTextDisplay) && s.CompositeElement.CompositeCode == item.CompositeCode).ToList();
                foreach (var harnes in data)
                {
                    CalculationList.Add(new AnalyzeCalculation
                    {
                        Mfal = "Standard",
                        CircuitCount = 1,
                        HarnessBaseNumber = harnes.HarnessBaseNumber,
                        WireName = harnes.ConductorWirename
                    });
                }
            }
        }

        private void CalculateStandard(List<Wirelist> wirelist, List<Harness> harnessSelected, List<Composite> list)
        {
            foreach (var harness in harnessSelected)
            {
                var data = wirelist.Where(s => string.IsNullOrEmpty(s.OptionTextDisplay) && s.HarnessBaseNumber == harness.HarnessBaseNumber).ToList();

                foreach (var harnessWirelist in data)
                {
                    CalculationByHarnessList.Add(new AnalyzeCalculation
                    {
                        Mfal = "Standard",
                        CircuitCount = 1,
                        HarnessBaseNumber = harnessWirelist.HarnessBaseNumber,
                        WireName = harnessWirelist.ConductorWirename
                    });
                }
            }
        }

        #endregion ByStandard

        #region ByBoolean

        private void CalculateBoolean(TakeRate takeRate, List<Wirelist> wirelist, List<Composite> compositeList)
        {
            List<Wirelist> wirelistWithOperator = new List<Wirelist>();
            foreach (var composite in compositeList)
            {
                wirelistWithOperator.AddRange(wirelist.Where(s => s.CompositeElement.CompositeCode == composite.CompositeCode && (s.OptionTextDisplay.Contains("|") || s.OptionTextDisplay.Contains("&"))).ToList());
            }

            foreach (var feature in takeRate.Features)
            {
                foreach (var item in wirelistWithOperator)
                {
                    if (item.OptionTextDisplay.Contains(feature.MFAL))
                    {
                        item.OptionTextDisplay = item.OptionTextDisplay.Replace(feature.MFAL, "true").Replace("|", "or").Replace("&", "and");
                    }
                }
            }

            var wirelistWithBoolean = wirelistWithOperator.Where(s => s.OptionTextDisplay.Contains("true"));
            foreach (var wire in wirelistWithBoolean)
            {
                if (wire.OptionTextDisplay.Any(c => char.IsUpper(c)))
                {
                    var strings = wire.OptionTextDisplay.Split(' ');

                    foreach (var item in strings)
                    {
                        string replaceMfal = string.Empty;
                        foreach (char letter in item)
                        {
                            if (char.IsUpper(letter) || letter == '_' || char.IsNumber(letter) || letter == '-')
                            {
                                replaceMfal += letter;
                            }
                        }
                        if (!string.IsNullOrEmpty(replaceMfal))
                        {
                            wire.OptionTextDisplay = wire.OptionTextDisplay.Replace(replaceMfal, "false");
                        }
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("", typeof(bool));
                dt.Columns[0].Expression = wire.OptionTextDisplay;

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                var result = (Boolean)dr[0];
                if (result)
                {
                    CalculationList.Add(new AnalyzeCalculation
                    {
                        Mfal = wire.BooleanExpression,
                        CircuitCount = 1,
                        HarnessBaseNumber = wire.HarnessBaseNumber,
                        WireName = wire.ConductorWirename
                    });
                }
            }
        }

        private void CalculateBoolean(TakeRate takeRate, List<Wirelist> wirelist, List<Harness> harnessSelected, List<Composite> compositeSelected)
        {
            var wirelistWithOperator = wirelist.Where(s => s.OptionTextDisplay.Contains("|") || s.OptionTextDisplay.Contains("&")).ToList();

            foreach (var feature in takeRate.Features)
            {
                foreach (var item in wirelistWithOperator)
                {
                    if (item.OptionTextDisplay.Contains(feature.MFAL))
                    {
                        item.OptionTextDisplay = item.OptionTextDisplay.Replace(feature.MFAL, "true").Replace("|", "or").Replace("&", "and");
                    }
                }
            }

            foreach (var harness in harnessSelected)
            {
                var wirelistWithBoolean = wirelistWithOperator.Where(s => s.HarnessBaseNumber == harness.HarnessBaseNumber && s.OptionTextDisplay.Contains("true"));
                foreach (var wire in wirelistWithBoolean)
                {
                    if (wire.OptionTextDisplay.Any(c => char.IsUpper(c)))
                    {
                        var strings = wire.OptionTextDisplay.Split(' ');

                        foreach (var item in strings)
                        {
                            string replaceMfal = string.Empty;
                            foreach (char letter in item)
                            {
                                if (char.IsUpper(letter) || letter == '_' || char.IsNumber(letter) || letter == '-')
                                {
                                    replaceMfal += letter;
                                }
                            }
                            if (!string.IsNullOrEmpty(replaceMfal))
                            {
                                wire.OptionTextDisplay = wire.OptionTextDisplay.Replace(replaceMfal, "false");
                            }
                        }
                    }
                    DataTable dt = new DataTable();
                    dt.Columns.Add("", typeof(bool));
                    dt.Columns[0].Expression = wire.OptionTextDisplay;

                    DataRow dr = dt.NewRow();
                    dt.Rows.Add(dr);
                    var result = (Boolean)dr[0];
                    if (result)
                    {
                        CalculationByHarnessList.Add(new AnalyzeCalculation
                        {
                            Mfal = wire.BooleanExpression,
                            CircuitCount = 1,
                            HarnessBaseNumber = wire.HarnessBaseNumber,
                            WireName = wire.ConductorWirename
                        });
                    }
                }
            }
        }

        #endregion ByBoolean

        private List<MFalHarnesAnalyze.Model.Feature> ValidateMfalInTrim(TakeRate takeRate, List<Wirelist> wirelist, List<Harness> harnessSelected, List<Composite> compositeSelected, bool validateHarness = false)
        {
            List<MFalHarnesAnalyze.Model.Feature> missingMfalHarnes = new List<Feature>();

            List<Harness> harnessWithComposite = new List<Harness>();
            List<Feature> featureList = new List<Feature>();

            foreach (var composite in compositeSelected)
            {
                harnessWithComposite.AddRange(harnessSelected.Where(s => s.CompositeCode == composite.CompositeCode));
            }

            foreach (var harness in harnessWithComposite)
            {
                var wirelistFilteres = wirelist.Where(s => s.HarnessBaseNumber == harness.HarnessBaseNumber && !string.IsNullOrEmpty(s.OptionTextDisplay)).ToList();
                var mfalsInHarness = wirelistFilteres.Where(s => !s.OptionTextDisplay.Contains("|") && !s.OptionTextDisplay.Contains("&")).Select(s => s.OptionTextDisplay).Distinct().ToList();
                var mfalsInTrim = takeRate.Features.Select(s => s.MFAL).Distinct().ToList();

                List<string> missingMfals = new List<string>();

                missingMfals = validateHarness ? mfalsInHarness.Except(mfalsInTrim).ToList() : mfalsInTrim.Except(mfalsInHarness).ToList();
                foreach (var item in missingMfals)
                {
                    missingMfalHarnes.Add(new Feature { MFAL = item, HarnessBaseNumber = harness.HarnessBaseNumber });
                }
            }

            return missingMfalHarnes;
        }

        private List<Wirelist> ValidateMFalInHarness(TakeRate takeRate, List<Wirelist> wirelist, List<Harness> harnessSelected, List<Composite> compositeSelected)
        {
            List<Wirelist> aux = new List<Wirelist>();

            return aux;
        }

        private List<Wirelist> ValidateMFalInHarness(TakeRate takeRate, List<Wirelist> wirelist, List<Composite> compositeSelected)
        {
            List<Wirelist> aux = new List<Wirelist>();
            Dictionary<string, string> missing = new Dictionary<string, string>();
            foreach (var composite in compositeSelected)
            {
                var harnessByComposite = wirelist.Where(s => s.CompositeElement.CompositeCode == composite.CompositeCode).ToList();
                var harnessList = harnessByComposite.Select(s => s.HarnessBaseNumber).Distinct().ToList();
                foreach (var harness in HarnessList)
                {
                    var mfalByHarness = harnessByComposite.Where(s => s.HarnessBaseNumber == harness.HarnessBaseNumber).Where(S => !String.IsNullOrEmpty(S.OptionTextDisplay)).Where(s => !s.OptionTextDisplay.Contains("|") && !s.OptionTextDisplay.Contains("&")).Select(s => s.OptionTextDisplay).ToList();
                    var missinMfals = mfalByHarness.Except(takeRate.Features.Select(s => s.MFAL)).Distinct().ToList();
                    missinMfals.ForEach(i =>
                    {
                        aux.Add(new Wirelist { HarnessBaseNumber = harness.HarnessBaseNumber, OptionTextDisplay = i });
                    });
                }
            }
            return aux;
        }

        private void ExportToExcel()
        {
            ExcelHelper.GenerateExcelReport(CalculationList.ToList(), RegionName);
        }

        private void ExportHarnessToExcel()
        {
            ExcelHelper.GenerateExcelReportByHarness(CalculationByHarnessList.ToList(), RegionName);
        }

        private void LoadJson()
        {
            string[] fileNames = OpenDialogFiles(filterJSON, false);
            ReadJsonFiles(fileNames);
        }

        private void Save()
        {
            model.CalculationList = CalculationList;
            model.CompositeList = CompositeList;
            model.FileName = FileName;
            model.RegionName = RegionName;
            model.takeRate = takeRate;
            model.TrimFileName = TrimFileName;
            model.wirelist = wirelist;
            model.WirelistFileName = WirelistFileName;
            var fileDialog = new SaveFileDialog()
            {
                Filter = filterJSON
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                this.FileName = fileDialog.FileName;

                using (var file = File.Open(FileName, FileMode.Create))
                {
                    using (var writter = new StreamWriter(file))
                    {
                        writter.Write(JsonConvert.SerializeObject(model));
                    }
                }
            }
        }

        private void SaveAsTrim()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filterJSON;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileName = saveFileDialog.FileName;
                using (var writter = new StreamWriter(fileName))
                {
                    writter.Write(JsonConvert.SerializeObject(model));
                }
            }
        }

        private List<Composite> GetCompositeList(List<Wirelist> wirelist)
        {
            List<Composite> compositeList = new List<Composite>();

            var compositeListTemp = wirelist.Where(s => !string.IsNullOrEmpty(s.CompositeElement.CompositeCode)).Select(p => p.CompositeElement.CompositeCode).Distinct().OrderBy(p => p).ToList();
            compositeListTemp.ForEach(item => compositeList.Add(new Composite { CompositeCode = item, IsSelected = false }));

            return compositeList;
        }

        private List<Harness> GetHarnessList(List<Wirelist> wirelist)
        {
            List<Harness> harnessList = new List<Harness>();
            var harness = wirelist.Select(s => s.HarnessBaseNumber).Distinct().OrderBy(S => S).ToList();

            foreach (var item in harness)
            {
                var compositeCode = item.Contains('-');
                if (compositeCode)
                {
                    harnessList.Add(new Harness
                    {
                        HarnessBaseNumber = item,
                        CompositeCode = item.Split('-')[1],
                        IsSelected = false
                    });
                }
            }

            return harnessList;
        }

        private TakeRate ReadTrimFiles(string[] fileNames)
        {
            TakeRate takeRate = new TakeRate();

            foreach (var fileName in fileNames)
            {
                using (var file = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(file))
                    {
                        var helperTakeRate = JsonConvert.DeserializeObject<TakeRate>(reader.ReadToEnd());

                        takeRate.Features.AddRange(helperTakeRate.Features);
                        takeRate.Freestandings.AddRange(helperTakeRate.Freestandings);
                        takeRate.Packages.AddRange(helperTakeRate.Packages);
                        takeRate.Series.AddRange(helperTakeRate.Series);
                    }
                }
            }

            foreach (var mfal in takeRate.Features)
            {
                mfal.MFAL = mfal.MFAL.Replace('_', '-');
                mfal.MFAL = mfal.MFAL.Replace("--", "-");
            }

            return takeRate;
        }

        private List<Wirelist> ReadWirelist(string wirelistFile)
        {
            List<Wirelist> lista = new List<Wirelist>();
            using (TextReader file = File.OpenText(wirelistFile))
            {
                var csv = new CsvReader(file);

                while (csv.Read())
                {
                    var harnes = csv.GetField<string>("Harness Base Number");
                    if (!string.IsNullOrEmpty(harnes))
                    {
                        var arrayHarnes = harnes.Split('-');
                        var composite = arrayHarnes.Count() > 1 ? arrayHarnes[1] : string.Empty;
                        var conductor = csv.GetField<string>("Conductor/Wire name");
                        var optionTextDisplay = csv.GetField<string>("Option Text Display").Replace('_', '-');

                        Wirelist item = new Wirelist()
                        {
                            HarnessBaseNumber = harnes.Replace('_', '-'),
                            ConductorWirename = conductor,
                            OptionTextDisplay = optionTextDisplay,
                            BooleanExpression = optionTextDisplay,
                            CompositeElement = new Composite { CompositeCode = composite, IsSelected = false }
                        };

                        lista.Add(item);
                    }
                }
            }

            return lista;
        }

        private DataSetModel ReadDataSet(string dataSetFileName)
        {
            DataSetModel model = new DataSetModel();
            try
            {
                model.fileLines = File.ReadAllLines(dataSetFileName, Encoding.UTF8);
                var mfalsArray = model.fileLines[7].Split(',');
                var takerateArray = model.fileLines[8 + mfalsArray.Count()].Split(',');
                for (int i = 0; i < mfalsArray.Count(); i++)
                {
                    takerateArray[i] = GetTakeRateFromTrim(mfalsArray[i]);
                    CalculationToLevelList.Add(new AnalyzeCalculation
                    {
                        Mfal = mfalsArray[i].Replace("  ", "-"),
                        TotalTakeRate = double.Parse(takerateArray[i])
                    });
                }

                if (calculationToLevelList.Any(s => s.TotalTakeRate == 0))
                {
                    EnableSaveDataset = false;
                    MessageBox.Show("Not all your MFals in the DataSet have a Takerate value in the Trim File. Please correct files.");
                }
                else
                {
                    EnableSaveDataset = true;
                }
            }
            catch (Exception e)
            {
                throw;
            }

            return model;
        }

        private void SaveDataSet()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = filterTxtFiles;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var joinedLine = string.Join(",", calculationToLevelList.Select(s => s.TotalTakeRate.ToString("F")).ToArray());
                datasetModel.fileLines[8 + calculationToLevelList.Select(s => s.TotalTakeRate).Count()] = joinedLine;

                using (var write = new StreamWriter(saveFileDialog.FileName))
                {
                    datasetModel.fileLines.ToList().ForEach(s =>
                    write.WriteLine(s));
                }
            }
        }

        private List<string> GetCombinations(string[] fileLines)
        {
            List<string> combinations = new List<string>();
            var lastItem = fileLines.Count() - 2;
            int endCondition = 0;
            for (int i = lastItem; i >= 0; i--)
            {
                var line = fileLines[i];
                if (int.TryParse(line, out endCondition))
                {
                    break;
                }
                else
                {
                    combinations.Add(line);
                }
            }

            return combinations;
        }

        private string GetTakeRateFromTrim(string mfal)
        {
            string mfalTrim = mfal.Replace("  ", "-");
            var tRate = takeRate.Features.Where(s => s.MFAL == mfalTrim).Select(s => s.TotalTakeRate).SingleOrDefault();
            return tRate == 0 ? "0.0" : tRate.ToString("F");
        }

        private void ReadJsonFiles(string[] fileNames)
        {
            AnalyzeModel model = new AnalyzeModel();

            foreach (var fileName in fileNames)
            {
                using (var file = File.Open(fileName, FileMode.Open))
                {
                    using (var reader = new StreamReader(file))
                    {
                        var helperAnalyzeModel = JsonConvert.DeserializeObject<AnalyzeModel>(reader.ReadToEnd());
                        TrimFileName = helperAnalyzeModel.TrimFileName;
                        WirelistFileName = helperAnalyzeModel.WirelistFileName;
                        RegionName = helperAnalyzeModel.RegionName;
                        FileName = helperAnalyzeModel.FileName;
                        CompositeList = helperAnalyzeModel.CompositeList;
                        takeRate = helperAnalyzeModel.takeRate;
                        wirelist = helperAnalyzeModel.wirelist;
                        CalculationList = helperAnalyzeModel.CalculationList;
                    }
                }
            }
        }

        private string[] OpenDialogFiles(string filter, bool multiselect = false)
        {
            string[] fileNamesArray = null;

            OpenFileDialog dialog = new OpenFileDialog() { Filter = filter, Multiselect = multiselect };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (multiselect)
                {
                    fileNamesArray = dialog.FileNames;
                    //TrimFileName = fileNamesArray[0] ?? "";
                }
                else
                {
                    fileNamesArray = new string[] { dialog.FileName };
                    //TrimFileName = dialog.FileName;
                }
            }

            return fileNamesArray;
        }

        private void ValidateDataSet()
        {
            var harnessSelected = HarnessLevelList.Where(s => s.IsSelected).ToList();
            var combinations = GetCombinations(datasetModel.fileLines);
            var wirel = new List<Wirelist>();
            foreach (var harness in harnessSelected)
            {
                var data = wirelist.Where(s => s.HarnessBaseNumber == harness.HarnessBaseNumber);
                wirel.AddRange(data);
            }
            for (int i = 0; i < combinations.Count(); i++)
            {
                var mfals = combinations[i].Split(',');
                List<string> mfalsAux = new List<string>();
                for (int j = 0; j < mfals.Count(); j++)
                {
                    if (!mfals[j].Contains("AA"))
                    {
                        mfalsAux.Add(mfals[j].Replace("  ","-"));

                    }
                }
                combinations[i] = string.Join(" & ", mfalsAux);
                

            }
            var datos = wirel.Where(s => s.OptionTextDisplay == string.Join(" | ", combinations));
            if (datos.Count() == 0)
            {
                MessageBox.Show("Your harness selection don't have coincidences with your dataset file. Please select other Harness or change dataset file.");
            }
            else
            {
                EnableSaveDataset = true;
                MessageBox.Show("Your harness selection is valid!.");
            }
        }

        #endregion Private Methods
    }
}