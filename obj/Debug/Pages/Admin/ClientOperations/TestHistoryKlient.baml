   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_4clr-namespace:Custodian.Pages.Admin.ClientOperations&Custodian.Pages.Admin.ClientOperations  5      1clr-namespace:Custodian.ModelCustodian.Model  5      >    8Custodian.Pages.Admin.ClientOperations.TestHistoryKlient   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Flocal4clr-namespace:Custodian.Pages.Admin.ClientOperations     5      1contextclr-namespace:Custodian.Model     5      -   5        
�������.��5      �    StyleInnerBorder#��[  6   .+�5   
   �� $��Test Rating History��6   $��Stretch=�6.     MainFont#��[ 6L   $��35��6s   $	��125��6   $	��Top=�6�   $��199,99,176,0q�6�   �� 5   
   $��Stretch=�6)   $��35��6H   $	��480��6T   $	��Top=�6`   $��
10,10,10,0q�6x     J� RenderTransformOrigin$  0.278,0.571&�6�   ��6   �� *Name+6�   �� 5   
   $��Current Risk profile : P��6   $
��Left=�63   $��35��6N   $	��160��6Z   $	��Top=�6f   $��	15,55,0,0q�6~   �� 5   
   $
��Left=�63   $��35��6N   $��21��6Z   $	��Top=�6e   $��
176,55,0,0q�6}   ��6   �� *CurrRiskProfil+6}   �� 5   
   $
��Left=�61   $��35��6L   $	��168��6X   $	��Top=�6d   $��
202,55,0,0q�6|   ��6   �� *RiskOrientir+6|   &   System.Windows.Controls.DataGrid  5   
     
StyleTable#��[ 6      
IsReadOnly . #��[ 6J   $	��Top=�5         GridLinesVisibility$ 
Horizontal=�6,   $	��215��6M   $��Center=�5      $��10,145,10,0q�61      AutoGenerateColumns .  ��6b   �� *historyTableCollection+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$! Risk class / Product rating��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6J   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6T   �� *result+  5      $
 Date��6%   $ * 63    6=   �� *Date+5      �� 5   
   $��10,365,10,10q�6   #��[ 6K    
 GrayEA#��[ 5      $
��Wrap=�69   ��5   *   �� *RiskPrifillInfo+5   O   5       5!      