   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Custodian.PagesCustodian.Pages  5      Q-clr-namespace:Custodian.DALs.InterfaceServiceCustodian.DALs.InterfaceService  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5
      ,    &Custodian.Pages.InvestmentDetails_mini   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Custodian.Pages     5      Aconvert-clr-namespace:Custodian.DALs.InterfaceService     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5
      -   5        .��5      � .+�5   
   �  
  Gray46#��[  6   .+�5      ��   StyleTabControl#��[ 6   $��5q�6C   .@�5      �� $��
INVESTMENT��6   .��5      �   � RowDefinitions  5      �� 5      $
��Auto �6,   6<   �� 5      $��* �6,   69   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ DGInvestmentDetails_mini��5   H     
StyleTable#��[ 6$   $��1��6j      AutoGenerateColumns .  $��13(�5   <      	RowHeight$ 24Q�5          
IsReadOnly .    CurrentCell 6B   �� *
CellInfo+ �� Mode$ OneWayToSource=� �� SelectedIndex 5       �� *SelectedIndexCurrent+��6O   �� *InvestCollection+ � 	Resources 5      :  4Custodian.DALs.InterfaceService.CellToBrushConverter  CellConverter��%   &	         5   "   6?   5      .  (System.Windows.Interactivity.Interaction	   Triggers	 5      /  )System.Windows.Interactivity.EventTrigger  5   "   
   	EventName$
 MouseLeftButtonUp��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *SelectDetails+5    #     5!   "   $
 MouseDoubleClick��61   . 5"   &      6<   �� *GetInfoInNew+5#   #      Columns 5%      4  .System.Windows.Controls.DataGridTemplateColumn  5&   "   ,  &System.Windows.Controls.DataGridColumn   Header$ Ticker��6:      MinWidth$ 50Q�6J      Width5	  /System.Windows.Controls.DataGridLengthConverter$
 auto	 6X      CellTemplate 5'   &   �� 5(   *   .R�5)   .   �� ��68   �� *Type+ � ToolTip 6N   �� *Type+5*   +   5,   #     5-   "   $ Currency��6:   $ 50Q�6L   $
 auto	 6Z    5.   &   �� 5/   *   .R�50   .   �� ��68   �� *Value+ 6O   �� *Value+51   +   53   #     54   "   $
 Date��69   $	 100Q�6G   $
 auto	 6V    55   &   �� 56   *   .R�57   .   �� ��68   �� *Date+ 6N   �� *Date+58   +   5:   #     5;   "   $ Units��69   $ 90Q�6H   $
 auto	 6V    5<   &   �� 5=   *   .R�5>   .   �� ��68   �� *Units+ 6O   �� *Units+5?   +   5A   #     5B   "   $ Aq.Price��69   $ 80Q�6K   $
 auto	 6Y    5C   &   �� 5D   *   .R�5E   .   �� ��68   �� *AqPr+ 6N   �� *AqPr+5F   +   5H   #     5I   "   $ Quote��69   $ 80Q�6H   $
 auto	 6V    5J   &   �� 5K   *   .R�5L   .   �� ��68   �� *Quote+ 6O   �� *Quote+5M   +   5O   #     5P   "   $
 ISIN��69   $ 95	 6H    5Q   &   �� 5R   *   .R�5S   .   �� ��68   �� *Isin+ 6N   �� *Isin+5T   +   5V   #     5W   "   $ Market Value��69   $ 90Q�6O   $
 auto	 6]    5X   &   �� 5Y   *   .R�5Z   .   �� ��68   �� *Markedvalue+ 6U   �� *Markedvalue+5[   +   5]   #     5^   "   $ Market Value, USD��69   $ 90Q�6T   $
 auto	 6b    5_   &   �� 5`   *   .R�5a   .   �� ��68   �� *MarkedvalueUSD+ 6X   �� *MarkedvalueUSD+5b   +   5d   #     5e   "   $ Indicative Perfomance��69   $
 auto	 6X    5f   &   �� 5g   *   .R�5h   .   �� ��68   �� *profit+ 6P   �� *profit+��5i   2   �� 5j   6    �� 
TargetType" ��6<   .�5k   :   ��  �� Property � �� �� Value 6W   ��  �� 	Converter# [ 5l   7   5n   3   5o   +   5q   #     5r   "   $ 	Weight, %��69   $ 70Q�6L   $
 auto	 6Z    5s   &   �� 5t   *   .R�5u   .   �� ��68   �� *	Percent+ 6Q   �� *	Percent+5v   +   5x   #     5y   "   $ Valuation Date��69   $	 100Q�6Q   $
 auto	 6`    5z   &   �� 5{   *   .R�5|   .   �� ��68   �� *currentDate+ 6U   �� *currentDate+5}   +   5   #   5�      5�      5�      �� 5�      $��INFLOW SUMMARY��6   .��5�      � .+�5�        -   5        $ FundingTools_mini��5�   N   #��[ 5�   '    .  ��5�      �� *InflowDetailsCollection+ 5�      0
  *System.Windows.Controls.DataGridTextColumn
  5�   "   $ Cash Account��65   $	 100Q�6k   $ *	 6z   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   �� *CashAccount+5�   #   
  5�   "   $ Inflow Summary��65   $	 100Q�6m   $ *	 6}    6M   �� *CashAccSumm+5�   #   
  5�   "   $
 ISIN��65   $ 60Q�6]   $ *	 6l    6C   �� *Isin+5�   #   
  5�   "   $ Security��65   $ 60Q�6d   $ *	 6s    6G   �� *
security+5�   #   
  5�   "   $ 	Aq. Price��65   $ 60Q�6d   $ *	 6s    6H   �� *	aqprice+5�   #   
  5�   "   $ Units��65   $ 60Q�6c   $ *	 6r    6D   �� *
countPaper+5�   #   
  5�   "   $
 Date��65   $ 90Q�6\   $ *	 6k    6C   �� *date+5�   #   5�      5�      5�      �� 5�      $��OUTFLOW��6   .��5�        -   5        $ DGWithdraw_mini��5�      #��[ 5�       .  ��5�      �� *WithdrawDetailsCollection+ 5�      
  5�      $ Summary��61   $	 240Q�6[   $ *	 6k    6B   �� *Summ+6k   
  5�      $
 Date��61   $ *	 6X    6?   �� *Date+6X   5�      5�      5�      5�      5�      5�      