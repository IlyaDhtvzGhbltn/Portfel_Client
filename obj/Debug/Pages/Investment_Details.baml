   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      @ <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Custodian.PagesCustodian.Pages 5      1clr-namespace:Custodian.ModelCustodian.Model 5      Q-clr-namespace:Custodian.DALs.InterfaceServiceCustodian.DALs.InterfaceService 5
      (   "Custodian.Pages.Investment_Details   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      /localclr-namespace:Custodian.Pages     5      1contextclr-namespace:Custodian.Model     5      Aconvert-clr-namespace:Custodian.DALs.InterfaceService     5
      -   5        $	��315��5       
  Gray26#��[  60   $��1q�6V   .��5      �  
 Gray46#��[ 6   .+�5   
   ��   StyleTabControl#��[ 6   $��0q�6>   .@�5      �� $��
INVESTMENT��6   $��0q�6+   .��5      �   � RowDefinitions  5      �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   �� 5      $
��auto �6(   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DGInvestmentDetails��5         AutoGenerateColumns .     
IsReadOnly . $��13(�5   a     
StyleTable#��[ 5   3   $��0��5   i   ��5   <   �� *InvestCollection+ �� SelectedIndex 5   W   �� *SelectedIndexCurrent+   CurrentCell 5   3   �� *
CellInfo+ �� Mode$ OneWayToSource=� � 	Resources 5      : 4Custodian.DALs.InterfaceService.CellToBrushConverter  CellConvert��%   &	         5      6;   5      .   (System.Windows.Interactivity.Interaction   Triggers 5      /   )System.Windows.Interactivity.EventTrigger  5       	   	EventName$	 MouseLeftButtonUp��6-   .   (System.Windows.Interactivity.TriggerBase
   Actions.
 5!   "   6   0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *SelectDetails+5"        5#      $	 MouseDoubleClick��6-   .
 5$   "      68   �� *GetInfoInNew+5%         Columns 5(      4  .System.Windows.Controls.DataGridTemplateColumn  5)      ,  &System.Windows.Controls.DataGridColumn   Header$ Ticker��66      MinWidth$ 50Q�6F      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6T      CellTemplate 5*   "   �� 5+   &   .R�5,   *   �� ��64   �� *Type+ � ToolTip 6J   �� *Type+5-   '   5/        50      $ Currency��66   $ 50Q�6H   $
 auto	 6V    51   "   �� 52   &   .R�53   *   �� ��64   �� *Value+ 6K   �� *Value+54   '   56        57      $
 Date��65   $	 100Q�6C   $
 auto	 6R    58   "   �� 59   &   .R�5:   *   �� ��64   �� *Date+ 6J   �� *Date+5;   '   5=        5>      $ Units��65   $ 90Q�6D   $
 auto	 6R    5?   "   �� 5@   &   .R�5A   *   �� ��64   �� *Units+ 6K   �� *Units+5B   '   5D        5E      $ Aq.Price��65   $ 80Q�6G   $
 auto	 6U    5F   "   �� 5G   &   .R�5H   *   �� ��64   �� *AqPr+ 6J   �� *AqPr+5I   '   5K        5L      $ Quote��65   $ 80Q�6D   $
 auto	 6R    5M   "   �� 5N   &   .R�5O   *   �� ��64   �� *Quote+ 6K   �� *Quote+5P   '   5R        5S      $
 Isin��65   $
 auto	 6D    5T   "   �� 5U   &   .R�5V   *   �� ��64   �� *Isin+ 6J   �� *Isin+5W   '   5Y        5Z      $ Market Value��65   $ 70Q�6K   $
 auto	 6Y    5[   "   �� 5\   &   .R�5]   *   �� ��64   �� *Markedvalue+ 6Q   �� *Markedvalue+5^   '   5`        5a      $ Market Value USD��65   $ 70Q�6O   $
 auto	 6]    5b   "   �� 5c   &   .R�5d   *   �� ��64   �� *MarkedvalueUSD+ 6T   �� *MarkedvalueUSD+5e   '   5g        5h      $ Indicative Perfomance��65   $
 auto	 6T    5i   "   �� 5j   &   .R�5k   *   �� ��64   �� *profit+ 6L   �� *profit+��5l   .   �� 5m   2    �� 
TargetType" ��68   .�5n   6   ��  �� Property � �� �� Value 6S   ��  �� 	Converter# [ 5o   3   5q   +   5r   '   5t        5u      $ 	Weight, %��65   $ 70Q�6H   $
 auto	 6V    5v   "   �� 5w   &   .R�5x   *   �� ��64   �� *	Percent+ 6M   �� *	Percent+5y   '   5{        5|      $ Valuation Date��65   $	 100Q�6M   $
 auto	 6\    5}   "   �� 5~   &   .R�5   *   �� ��64   �� *currentDate+ 6Q   �� *currentDate+5�   '   5�      5�      �� 5�      $��1��6#   $��10��60     StyleSplitter#��[ 6<   $��Stretch=�5�   7     5�       .  $��13(�5�   O   #��[ 5�   3    . $��3��5�   E   ��5�      �� *TotalInvestCollection+$ TwoWay=� 5�        5�      $ 	Operation��65   $ 50Q�6I   $
 auto	 6W    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *	Operation+ 6O   �� *	Operation+5�   '   5�        5�      $ Title��65   $ 90Q�6D   $
 auto	 6R    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *Title+ 6L   �� *Title+5�   '   5�        5�      $
 Isin��65   $ 50Q�6C   $
 auto	 6Q    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *Isin+ 6J   �� *Isin+5�   '   5�        5�      $ Value��65   $ 50Q�6D   $
 auto	 6R    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *value+ 6K   �� *value+5�   '   5�        5�      $ Units��65   $ 90Q�6D   $
 auto	 6R    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *Units+ 6K   �� *Units+5�   '   5�        5�      $ Aq.Price��65   $ 70Q�6G   $
 auto	 6U    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *AqP+ 6I   �� *AqP+5�   '   5�        5�      $
 Date��65   $ 70Q�6C   $
 auto	 6Q    5�   "   �� 5�   &   .R�5�   *   �� ��64   �� *Date+ 6J   �� *Date+5�   '   5�      5�      5�      5�      5�      5�      5�      