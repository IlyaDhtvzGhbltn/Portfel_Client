   M S B A M L   `   `   `  ����D  @Custodian, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Custodian	Custodian  5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5          Custodian.Portfel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Custodian     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5        � 	Resources  5         TextFont �� Property �� Value��%w   &	        �� 5   
   .�5      ��  � ��$ 12(�61   �� 5       � ��$ Comic Sans MS)�63   5      5      .��5      � ���	#FFE5E5E5$��	10,10,0,0q�6"   .+�5   
   � -   5        $��Summar��5      $��	0,0,560,0q�6   .+�5      � -   5         �Name$ OrderDetails��5      $	��230��6)   $	��320��65   $
��Left=�6B   $	��Top=�6]   #��[  6u   
�������.+�5      �� $��Summary��6   $��18(�6*   $��	0,0,0,283q�69   �� 5      $��Cell Details��6   $��16(�6/   $��
0,32,0,250q�6=   �� 5      $��
0,65,0,225q�62   ��6   �� *Order+62   �� 5      $��Currency��6   $��0,95,150,190q�6+   �� 5      $��80,95,0,190q�62   ��6   �� *Value+62   �� 5      $��Status��6   $��0,130,0,150q�6*   �� 5      $��80,130,0,150q�63   ��6   �� *Status+63   �� 5      $��0,165,0,125q�64   ��6   �� *	DateReg+64   �� 5      $��	Adviser :��6   $��
0,194,0,91q�6-   �� 5      $��
0,224,0,66q�64   ��6   �� *	Adviser+64   �� 5      $��
0,254,0,36q�64   ��6   �� *	Company+64   5       � 5!      -   5        $ Details��5!      $	��230��6$   $	��147��60   $
��Left=�6=   $	��Top=�6X   #��[  6p   
�������$��	0,320,0,0q�6�   .+�5"      �� $��Client Details��6   $��16(�61   $��	0,0,65,65q�6?   �� 5#      $
��Name��6   $��0,25,110,93q�6'   �� 5$      $��125,25,0,93q�60   ��6   �� *FIO+60   �� 5%      $��Date of Birth��6   $��0,54,110,60q�60   �� 5&      $��120,54,0,60q�68   $
��Left=�6M   $	��100��6h   ��6   �� *DateofBirth+6h   5(      5)      � 5*   
   -   5        $��FondSumm��5*      #��[  6    $��	252,0,0,0q�6B   ���	#FFEBE0FF$	��Top=�6l   $	��320��6�   .+�5+      �� $��Cell Summary��6   $��18(�6+   $��	0,0,0,270q�69   �� 5,      $��
0,40,0,124q�6   $
��Left=�6-   $	��755��6H   .@�5-      �� $��Details��6   .��5.      &   System.Windows.Controls.DataGrid     AutoGenerateColumns .     	RowHeight$ 24Q�6_      RowBackground �	#FFDCD58C$��	0,0,-23,0q�6�   ��6    �� *
Collection+   Columns 5/      0  *System.Windows.Controls.DataGridTextColumn  50      ,  &System.Windows.Controls.DataGridColumn   Header$
 Type��61   	   
IsReadOnly	 . 
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6R   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6\   �� *Type+  51      $ Balance��61   	 .    MaxWidth$	 200Q�6U      MinWidth$	 200Q�6d    6s   �� *	Balance+53      54      55      � 56      $��760,60,15,124q�6   
�������$
��Auto��6>   .+�57      �� $��Information about :��6   $��25��66   $	��130��6B   $
��Left=�6N   $	��Top=�6i   �� 58      $��0,26,0,0q�6J   $��24��6\   $	��218��6h   $
��Left=�6t   $	��Top=�6�   ��6   �� *activeInfoString+ �� Mode$ TwoWay=�6�   �� 59      $��From Yahoo FINANCE��6   $��25��66   $
��Left=�6B   $	��150��6]   ��6i   �� *GetInfoInNew+5:      5;      � 5<   
   -   5        $��InvestDetails��5<      $��252,209,0,10q�6$   ���	#FF9AACFF.+�5=      �� $��Investment Details��6   $��18(�61   $��
0,10,0,331q�6?   �� 5@      $��0,40,0,0q�6   .@�5A      �� $��Investments��6   .��5B      � .+�5C        -   5          Name$ DGInvestmentDetails��5C   #    .  $ 32Q�6�      
IsReadOnly . $	��Top=�6�   $	��200��6�   $��0,40,0,0q�6�    �	#FFB28C8C��6@   �� *InvestCollection+   CurrentCell 5D      �� *
CellInfo+$ OneWayToSource=�.  (System.Windows.Interactivity.Interaction   Triggers 5E      /  )System.Windows.Interactivity.EventTrigger  5F   "      	EventName$ MouseLeftButtonUp��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5G   &   6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 6<   �� *SelectDetails+5H   #    5K        5L   "   $
 Type��65   $	 200Q�6C   $
 * 6R    6\   �� *Type+  5M   "   $ Value��66   $ 50Q�6E    6S   �� *Value+  5N   "   $
 Date��65   $	 100Q�6C    6R   �� *Date+  5O   "   $ Units��65   $ 90Q�6D    6R   �� *Units+  5P   "   $ Aq.Price��65   $ 80Q�6G    6U   �� *AqPr+  5Q   "   $ Quote��65   $ 80Q�6D    6R   �� *Quote+  5R   "   $
 Isin��65   $ 50Q�6C    6Q   �� *Isin+  5S   "   $ Markedvalue��65   $	 100Q�6J    6Y   �� *Markedvalue+  5T   "   $ Market Value USD��65   $	 100Q�6O    6^   �� *MarkedvalueUSD+  5U   "   $ 
Profit USD��65   $	 100Q�6I    6X   �� *profit+  5V   "   $ Percent��65   $ 80Q�6F    6T   �� *	Percent+  5W   "   $ Valuation Date��65   $	 100Q�6M    6\   �� *currentDate+5Y        5Z      $	��140��6#   $	��Top=�63   $��	0,260,0,0q�6K   $ 34Q�6�    .   �	#FFD8C096 . ���	#FFD8C096��6^   �� *TotalInvestCollection+$ TwoWay=� 5[        5\   "   $ 	Operation��65   $
 * 6H    6R   �� *	Operation+5]   #     5^   "   $ Title��65   $	
 200 6D    6P   �� *Title+5_   #     5`   "   $
 Isin��65   $ 50Q�6C   $	
 100 6Q    6]   �� *Isin+5a   #     5b   "   $ Value��65   $ 50Q�6D    6R   �� *value+5c   #     5d   "   $ Units��65   $ 90Q�6D    6R   �� *Units+5e   #     5f   "   $ Aq.Price��65   $ 70Q�6G    6U   �� *AqP+$ TwoWay=�5g   #     5h   "   $
 Date��65   $ 70Q�6C    6Q   �� *Date+5i   #   5l      5n      5o      �� 5p      $��Inflow��6   .��5q      � .+�5r        -   5        $ FundingTools��5r   o    .  ���	#FF9AACFF$ 35Q�6�   
 �������6#   �� *InflowDetailsCollection+ 5s        5t   "   $ Cash Account��65   $	 100Q�6k   $
 * 6z    6K   �� *CashAccount+5u   #     5v   "   $ Inflow Summ��65   $	
 100 6j    6J   �� *CashAccSumm+5w   #     5x   "   $
 ISIN��65   $ 60Q�6]    6C   �� *Isin+5y   #     5z   "   $ Security��65   $ 60Q�6d    6G   �� *
security+5{   #     5|   "   $ Aq.Prise��65   $ 60Q�6c    6G   �� *	aqprice+5}   #     5~   "   $ Units��65   $ 60Q�6c    6D   �� *
countPaper+5   #     5�   "   $
 Data��65   $ 90Q�6\    6C   �� *date+5�   #   5�      5�      5�      �� 5�      $��Outflow��6   .��5�        -   5        $ 
DGWithdraw��5�       .  $ 30Q�6�    �	#FFA28BB9��63   �� *WithdrawDetailsCollection+ 5�        5�      $
 Summ��61   $	
 240 6X    6?   �� *Summ+6X     5�      $
 Date��61   $
 * 6X    6?   �� *Date+6X   5�      5�      5�      5�      5�      5�      