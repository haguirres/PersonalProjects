   M S B A M L   `   `   `  ����Q  MFord.MFalHarnesAnalyze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Ford.MFalHarnesAnalyzeFord.MFalHarnesAnalyze  5   	   Q-clr-namespace:Ford.MFalHarnesAnalyze.ControlsFord.MFalHarnesAnalyze.Controls  5   	   [ WFord.MFalHarnesAnalyze.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:Ford.MFalHarnesAnalyze.ViewModel;assembly=Ford.MFalHarnesAnalyze.ViewModel Ford.MFalHarnesAnalyze.ViewModel 5	   	   Q-clr-namespace:Ford.MFalHarnesAnalyze.ControlsFord.MFalHarnesAnalyze.Controls  5
   	   '    !Ford.MFalHarnesAnalyze.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:Ford.MFalHarnesAnalyze     5   	   Hi:http://schemas.microsoft.com/expression/2010/interactivity     5   	   Fusercontrols-clr-namespace:Ford.MFalHarnesAnalyze.Controls     5   	   gvmXclr-namespace:Ford.MFalHarnesAnalyze.ViewModel;assembly=Ford.MFalHarnesAnalyze.ViewModel     5	   	   >viws-clr-namespace:Ford.MFalHarnesAnalyze.Controls     5
   	     � Title$  Ford MFal Harnes Analyze��5   	   $	��550��6*   $	��712��67    � DataContext 5      :  4Ford.MFalHarnesAnalyze.ViewModel.MainWindowViewModel  5   
   -   5        
MainVM��5   3   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   o� $��0��6   .@�5      m� $	��New��6   6&   m� 5      $
��Load��6    m� Command 6%   �� *
LoadJSON+6D   m� 5      $
��Save��6   .@�5      m� $
��Save��6    6)   �� *SaveCommand+6K   m� 5      $��Save As��6    6,   �� *SaveAsCommand+6P   5      m� 5      $��Clean��6   .@�5       m� $��Clean Composite��6    64   �� *CleanCompositeCommand+6`   m� 5!      $��Clean Harness��6    62   �� *CleanHarnessCommand+6\   m� 5"      $��	Clean All��6    6.   �� *CleanCommand+6Q   5#      5$      � 5.   
   $��1��6   $��7q�6    5/      �� 50      $��Auto  �6    �� 51      $��Auto  �6     � ColumnDefinitions 53      �� 54      $��* �6#   �� 55      $��* �6#   �� 56      $��* �6#   .+�59      � $��0��6   $��Stretch=�6#   $��3q�6A    5:      �� 5;      $
��Auto �6'   �� 5<      $��* �6'   �� 5=      $
��Auto �6'   .+�5?      �� .��6   TRIM:6   �� 5@      $��1��6   ��6*   �� *TrimFileName+ �� Mode$ TwoWay=�6V   �� 5A      $��2��6   ��6)   �� *LoadTrimCommand+.��5B      �� .+�5C      �� $"��./Icons/folder-open-icon.png��6    6H   5D      5E      5F      � 5H      $��1��6   $��Stretch=�6#   $��3q�6A    5I      �� 5J      $
��Auto �6'   �� 5K      $��* �6'   �� 5L      $
��Auto �6'   .+�5N      �� $��0��6   .��6(   	WireList:63   �� 5O      $��1��6   ��6*   �� *WirelistFileName+$ TwoWay=�6Z   �� 5P      $��2��6   ��6)   �� *LoadWirelistCommand+.��5Q      �� .+�5R      �� $"��./Icons/folder-open-icon.png��6    6H   5S      5T      5U      � 5W      $��2��6   $��Stretch=�6#   $��3q�6A    5X      �� 5Y      $
��Auto �6'   �� 5Z      $��* �6'   .+�5\      �� $��0��6   .��6(   
Composite:64   �� 5]      $��1��6   ��6+   �� *CompositeList+$ TwoWay=���5^      �� 5_      .R�5`      �� ��6'   ��  �� Path$ CompositeCode� d� 	IsChecked 6N   �� $ 
IsSelected�$ TwoWay=�5a      5c      5d      5e      �� 5f   
   $��4��6   .@�5g      �� $
��MFAL��6   .��5h      �  5i      �� 5j      $��* �6+   �� 5k      $��* �6+    5m      �� 5n      $
��Auto �6(   �� 5o      $��* �6(   �� 5p      $
��Auto �6(   .+�5r      � $��2��6   $��0,0,0.333,0q�6/    5s      �� 5t      $
��Auto �6/   �� 5u      $��* �6/   �� 5v      $
��Auto �6/   .+�5x      �� $��0��6    .��60   	Region:69   �� 5y      $��1��6"   ��62   �� *
RegionName+$ TwoWay=�6\   �� 5z      $��2��6!   $��3��6.   $��3q�6B   $��Right=�6M   ��6i   �� *CalculateCommand+.��6�   	Calculate6�   5{      &   System.Windows.Controls.DataGrid  5|      -   5        $��1��5|      $��5,3,1.333,2.667q�6,      AutoGenerateColumns .  	   RowDetailsVisibilityMode$	 VisibleWhenSelected=�5}      
   
IsReadOnly
 . $��2��5~   1   ��5|   E   �� *CalculationList+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5�         CellTemplate 5�   "   �� 5�   &   .R�5�   *   �� -   5        $��3q�5�   2   .��6U   	Details6^   5�   '   5�      0  *System.Windows.Controls.DataGridTextColumn  5�      ,  &System.Windows.Controls.DataGridColumn   Header$
 MFal��61      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Mfal+6g     5�      $ 	Take Rate��61   $
 Auto 6f    6D   �� *TotalTakeRate+6u     5�      $ Harness��61   $ * 6h    6B   �� *HarnessBaseNumber+6t     5�      $ Circuit Counter��61   $
 Auto 6k    6J   �� *CircuitCount+6z     5�      $ 	Wire Name��61   $ * 6a    6D   �� *
WireName+6m      RowDetailsTemplate 5�      �� 5�      .R�5�   "      .  
�������
 . ��6+   �� *
MfalDetail+y�5�   >   �� *HiddenDetail+ 5�   &     5�   *   $
 MFal��6=   $
 Auto 6d    6K   �� *Mfal+6s     5�   *   $ Harness��6=   $
 Auto 6t    6N   �� *HarnessBaseNumber+6�     5�   *   $ Circuit Counter��6=   $
 Auto 6w    6V   �� *CircuitCount+6�     5�   *   $ 	Wire Name��6=   $
 Auto 6m    6P   �� *
WireName+6|   5�   #   5�      5�      � 5�      $��2��6   $��2��6(   $��0,0.333,0.333,-0.333q�6<    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��0��6    $y�Hidden=�60   .��6D   
File Name:6P   �� 5�      $��1��6"   $y�Hidden=�62   ��6F   �� *
FileName+$ TwoWay=�6n   �� 5�      $��2��6!   $��Right=�61   $��3q�6M   ��6X   �� *ExportCommand+.��6z   Export to Excel6�   5�      5�      5�      �� 5�      $��Harness��6   .��5�      �  5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �  5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��0��6    .��60   	Region:69   �� 5�      $��1��6"   $��Center=�6Z   ��62   �� *
RegionName+$ TwoWay=�6w   �� 5�      $��2��6    .��60   
Harness:6:   �� 5�      $��3��6#   ��63   �� *HarnessList+$ TwoWay=���5�      �� 5�   "   .R�5�   &   �� ��6/   �� $ HarnessBaseNumber� 6Z   �� $ 
IsSelected�$ TwoWay=�5�   #   5�      �� 5�      -   5        $��2��5�   !   $��4��6.   $��3q�6>   $��Right=�6I   .��6z   	Calculate6�   5�        5�      -   5        $��1��5�      $��3q�6,    .  $	 VisibleWhenSelected=�5�   ;   
 . ��5�   7   �� *CalculationByHarnessList+ 5�        5�      $ Harness��61   $ * 6h    6B   �� *HarnessBaseNumber+6t     5�      $
 MFal��61   $
 Auto 6X    6?   �� *Mfal+6g     5�      $ 	Take Rate��61   $
 Auto 6f    6D   �� *TotalTakeRate+6u     5�      $ Circuit Counter��61   $
 Auto 6k    6J   �� *CircuitCount+6z     5�      $ 	Wire Name��61   $ * 6a    6D   �� *
WireName+6m    5�      �� 5�      .R�5�   "      .  
�������
 . ��6+   �� *
MfalDetail+ 5�   &     5�   *   $
 MFal��6=   $
 Auto 6d    6K   �� *Mfal+6s     5�   *   $ Harness��6=   $
 Auto 6t    6N   �� *HarnessBaseNumber+6�     5�   *   $ Circuit Counter��6=   $
 Auto 6w    6V   �� *CircuitCount+6�     5�   *   $ 	Wire Name��6=   $
 Auto 6m    6P   �� *
WireName+6|   5�   #   5�      5�      � 5�      $��2��6    5�      �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��0��6    $y�Hidden=�60   .��6D   
File Name:6P   �� 5�      $��1��6"   $y�Hidden=�62   ��6F   �� *
FileName+$ TwoWay=�6n   �� 5�      $��2��6!   $��Right=�61   $��3q�6M   ��6X   �� *ExportHarnessCommand+.��6�   Export to Excel6�   5�      5�      5�      �� 5�      $��Level��6   .��5�      �  5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      �  5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      �� $��2��6    .��60   
DataSet:6:   �� 5�      $��3��6"   $��Center=�6_   ��62   �� *DataSetFileName+$ TwoWay=�6�   �� 5�      $��4��6!   ��61   �� *LoadDataSetCommand+.��5�      �� .+�5�   "   �� $"��./Icons/folder-open-icon.png��6(   6P   5�      5      �� 5     $��5��6    .��60   
Harness:6:   �� 5     $��6��6#   ��63   �� *HarnessLevelList+$ TwoWay=���5     �� 5  "   .R�5  &   �� ��6/   �� $ HarnessBaseNumber� 6Z   �� $ 
IsSelected�$ TwoWay=�5  #   5     �� 5	     $��2��6!   $��7��6.   $��3q�6>   $��Right=�6I   ��6e   �� *ValidateDataSetCommand+.��6�   
Validate6�   5
       5     -   5        $��1��5     $��3q�6,    .  $	 VisibleWhenSelected=�5  ;   
 . ��5  7   �� *CalculationToLevelList+ 5       5     $
 MFal��61   $ * 6X    6?   �� *Mfal+6d     5     $ 	Take Rate��61   $ * 6f    6D   �� *TotalTakeRate+6r   5     � 5     $��3��6    5     �� 5     $
��Auto �6/   �� 5     $��* �6/   �� 5     $
��Auto �6/   .+�5     �� $��0��6    $y�Hidden=�60   .��6D   
File Name:6P   �� 5     $��1��6"   $y�Hidden=�62   ��6F   �� *
FileName+$ TwoWay=�6n   �� 5     $��2��6!   $��Right=�61   $��3q�6M   ��6X   �� *SaveDataSetFileCommand+.��6�   Save DataSet6�   5     5     5      �� 5!     $	��Car��6   {�.  67   5"     5#     5$     