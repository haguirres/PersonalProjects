   M S B A M L   `   `   `  ���� Q  MFord.MFalHarnesAnalyze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Ford.MFalHarnesAnalyzeFord.MFalHarnesAnalyze  Q-clr-namespace:Ford.MFalHarnesAnalyze.ControlsFord.MFalHarnesAnalyze.Controls  [ WFord.MFalHarnesAnalyze.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:Ford.MFalHarnesAnalyze.ViewModel;assembly=Ford.MFalHarnesAnalyze.ViewModel Ford.MFalHarnesAnalyze.ViewModel Q-clr-namespace:Ford.MFalHarnesAnalyze.ControlsFord.MFalHarnesAnalyze.Controls  '    !Ford.MFalHarnesAnalyze.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     6local$clr-namespace:Ford.MFalHarnesAnalyze     Hi:http://schemas.microsoft.com/expression/2010/interactivity     Fusercontrols-clr-namespace:Ford.MFalHarnesAnalyze.Controls     gvmXclr-namespace:Ford.MFalHarnesAnalyze.ViewModel;assembly=Ford.MFalHarnesAnalyze.ViewModel     >viws-clr-namespace:Ford.MFalHarnesAnalyze.Controls       � Title$  Ford MFal Harnes Analyze��$	��550��$	��712�� � DataContext :  4Ford.MFalHarnesAnalyze.ViewModel.MainWindowViewModel  -   
MainVM��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* �.+�o� $��0��.@�m� $	��New��m� $
��Load�� m� Command �� *
LoadJSON+m� $
��Save��.@�m� $
��Save�� �� *SaveCommand+m� $��Save As��m� $��Clean��.@�m� $��Clean Composite�� �� *CleanCompositeCommand+m� $��Clean Harness�� �� *CleanHarnessCommand+m� $��	Clean All�� �� *CleanCommand+� $��1��$��7q� �� $��Auto  ��� $��Auto  � � ColumnDefinitions �� $��* ��� $��* ��� $��* �.+�� $��0��$��Stretch=�$��3q� �� $
��Auto ��� $��* ��� $
��Auto �.+��� .��TRIM:�� $��1������ *TrimFileName+ �� Mode$ TwoWay=��� $��2������ *LoadTrimCommand+.���� .+��� $"��./Icons/folder-open-icon.png��� $��1��$��Stretch=�$��3q� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.��	WireList:�� $��1������ *WirelistFileName+$ TwoWay=��� $��2������ *LoadWirelistCommand+.���� .+��� $"��./Icons/folder-open-icon.png��� $��2��$��Stretch=�$��3q� �� $
��Auto ��� $��* �.+��� $��0��.��
Composite:�� $��1������ *CompositeList+$ TwoWay=����� .R���  �� Orientation$ 
Horizontal=�.+���  ��Name$ chbComposite��$��20�� d� 	IsChecked �� *
IsSelected+$ TwoWay=��� $	��100������ *CompositeCode+�� $��4��.@��� $
��MFAL��.���  �� $��* ��� $��* � �� $
��Auto ��� $��* ��� $
��Auto �.+�� $��2��$��0,0,0.333,0q� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.��	Region:�� $��1������ *
RegionName+$ TwoWay=��� $��2��$��3��$��3q�$��Right=����� *CalculateCommand+.��	Calculate&   System.Windows.Controls.DataGrid  -   $��1��$��3,3,3.333,2.667q�	   AutoGenerateColumns	 .  
   RowDetailsVisibilityMode$
 VisibleWhenSelected=�   
IsReadOnly . $��2������ *CalculationList+   Columns 4  .System.Windows.Controls.DataGridTemplateColumn     CellTemplate �� .R��� -   .��	Details0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$
 MFal��   Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Mfal+  $ 	Take Rate��$
 Auto  �� *TotalTakeRate+  $ Harness��$ *  �� *HarnessBaseNumber+  $ Circuit Counter��$
 Auto  �� *CircuitCount+  $ 	Wire Name��$ *  �� *
WireName+   RowDetailsTemplate �� .R�  	 .  
������� . ���� *
MfalDetail+y��� *HiddenDetail+   $
 MFal��$
 Auto  �� *Mfal+  $ Harness��$
 Auto  �� *HarnessBaseNumber+  $ Circuit Counter��$
 Auto  �� *CircuitCount+  $ 	Wire Name��$
 Auto  �� *
WireName+� $��2��$��2��$��0,0.333,0.333,-0.333q� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$y�Hidden=�.��
File Name:�� $��1��$y�Hidden=����� *
FileName+$ TwoWay=��� $��2��$��Right=�$��3q����� *ExportCommand+.��Export to Excel�� $��Harness��.���  �� $
��Auto ��� $��* ��� $
��Auto �.+��  �� $
��Auto ��� $��* ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��.��	Region:�� $��1��$��Center=����� *
RegionName+$ TwoWay=��� $��2��.��
Harness:�� $��3������ *HarnessList+$ TwoWay=����� .R��� $ 
Horizontal=�.+��� $��20�� �� *
IsSelected+$ TwoWay=��� $	��100������ *HarnessBaseNumber+�� -   $��2��$��4��$��3q�$��Right=�.��	Calculate  -   $��1��$��3q�	 .  $
 VisibleWhenSelected=� . ���� *CalculationByHarnessList+   $ Harness��$ *  �� *HarnessBaseNumber+  $
 MFal��$
 Auto  �� *Mfal+  $ 	Take Rate��$
 Auto  �� *TotalTakeRate+  $ Circuit Counter��$
 Auto  �� *CircuitCount+  $ 	Wire Name��$ *  �� *
WireName+ �� .R�  	 .  
������� . ���� *
MfalDetail+   $
 MFal��$
 Auto  �� *Mfal+  $ Harness��$
 Auto  �� *HarnessBaseNumber+  $ Circuit Counter��$
 Auto  �� *CircuitCount+  $ 	Wire Name��$
 Auto  �� *
WireName+� $��2�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$y�Hidden=�.��
File Name:�� $��1��$y�Hidden=����� *
FileName+$ TwoWay=��� $��2��$��Right=�$��3q����� *ExportHarnessCommand+.��Export to Excel�� $��Level��.���  �� $
��Auto ��� $��* ��� $��* ��� $
��Auto �.+��  �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto �.+��� $��2��.��
DataSet:�� $��3��$��Center=����� *DataSetFileName+$ TwoWay=��� $��4������ *LoadDataSetCommand+.���� .+��� $"��./Icons/folder-open-icon.png���� $��5��.��
Harness:�� $��6������ *HarnessLevelList+$ TwoWay=����� .R��� $ 
Horizontal=�.+��� $��20�� �� *
IsSelected+$ TwoWay=��� $	��100������ *HarnessBaseNumber+�� $��2��$��7��$��3q�$��Right=����� *ValidateDataSetCommand+.��
Validate  -   $��1��$��3q�	 .  $
 VisibleWhenSelected=� . ���� *CalculationToLevelList+   $
 MFal��$ *  �� *Mfal+  $ 	Take Rate��$ *  �� *TotalTakeRate+� $��3�� �� $
��Auto ��� $��* ��� $
��Auto �.+��� $��0��$y�Hidden=�.��
File Name:�� $��1��$y�Hidden=����� *
FileName+$ TwoWay=��� $��2��$��Right=�$��3q����� *SaveDataSetFileCommand+.��Save DataSet�� $	��Car��{�.  