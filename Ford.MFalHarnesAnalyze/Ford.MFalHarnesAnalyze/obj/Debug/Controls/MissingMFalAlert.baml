   M S B A M L   `   `   `  ����Q  MFord.MFalHarnesAnalyze, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Ford.MFalHarnesAnalyze.ControlsFord.MFalHarnesAnalyze.Controls  5   	   [ WFord.MFalHarnesAnalyze.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:Ford.MFalHarnesAnalyze.ViewModel;assembly=Ford.MFalHarnesAnalyze.ViewModel Ford.MFalHarnesAnalyze.ViewModel 5   	   6    0Ford.MFalHarnesAnalyze.Controls.MissingMFalAlert   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ?local-clr-namespace:Ford.MFalHarnesAnalyze.Controls     5   	   gvmXclr-namespace:Ford.MFalHarnesAnalyze.ViewModel;assembly=Ford.MFalHarnesAnalyze.ViewModel     5   	   -   5          � Title$  Alert!��5	   	   $��299.268��6   $��327.805��6)    � WindowStartupLocation$ CenterScreen=�69    � WindowStyle$ ThreeDBorderWindow=�6^    � 
ResizeMode$ NoResize=�6   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   6,   �� 5      $��* �6   6)   .+�5   
   �� $��	5 10 5 10q�6   
���  ��;9Your selected Harness has more Mfals than your Trim File.6s   &   System.Windows.Controls.DataGrid  5   
   $��1��6   $��Stretch=�6E   $��Stretch=�5         CanUserAddRows .     CanUserDeleteRows .     AutoGenerateColumns .     
IsReadOnly . ��5       �� *MissingMfals+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Harness��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6\   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *HarnessBaseNumber+6h     5      $

 MFal��6%   $
 Auto 6L    63   �� *MFAL+6[   5      5      5      