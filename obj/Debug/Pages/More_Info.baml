   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Custodian.PagesCustodian.Pages  5      Q-clr-namespace:Custodian.DALs.InterfaceServiceCustodian.DALs.InterfaceService  5          Custodian.Pages.More_Info   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Custodian.Pages     5      Aconvert-clr-namespace:Custodian.DALs.InterfaceService     5      $	��600��5      .��5
      � .+�5   
   � -   5        $��RecomendedTable��5      $��4��6    
  Gray36#��[  63   .+�5      �� $)��#Recommended Portfolio - Description��6   $��22��6B   $	��250��6N   $��Center=�6Z   $	��Top=�6w   �� 5        StyleMainBorder#��[ 6   $��0,36,0,0q�6>   ._�5      &   System.Windows.Controls.DataGrid  -   5           Name$  
Recomended��5   c   $��10q�5   L      
IsReadOnly .   
StyleTable#��[ 5   #      AutoGenerateColumns .  ��5      �� *RecommendTableCollection+ � 	Resources 5      9  3Custodian.DALs.InterfaceService.RowToBrushConverter  RowType��%   &	         5      66   5         RowStyle 5      �� 5       �� 
TargetType)  #System.Windows.Controls.DataGridRow"  6    .�5      ��  �� Property � �� �� Value 6;   ��  �� 	Converter# [ 5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Type��6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 1* 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Type+6T     5      $
 
Risk Level��6-   $ 50 6\    6A   �� *RLevel+6\     5      $

 Name��6-   $ 1* 6T    6;   �� *Name+6T     5      $
 Description��6-   $
 auto 6^    6C   �� *Advice+6^     5      $
 
Value, USD��6-   $ 1* 6[    6A   �� *Value+6[     5      $

 ISIN��6-   $ 1* 6T    6;   �� *Isin+6T     5       $
 	Weight, %��6-   $ 1* 6]    6@   �� *Weight+6]   5"      5#      5$      5%      5&      