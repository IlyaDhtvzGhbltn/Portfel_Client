   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Custodian	Custodian  5   	   �Iclr-namespace:Custodian.DALs.InterfaceService.Financial_Plan_Data_Correct;Custodian.DALs.InterfaceService.Financial_Plan_Data_Correct  5
   	       Custodian.Financial_Plan   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Custodian     5   	   b ^Syncfusion.SfChart.WPF, Version=15.2460.0.40, Culture=neutral, PublicKeyToken=3d67ed1f87d44c89-chart!http://schemas.syncfusion.com/wpf  5   	   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	   	   WcorrectIclr-namespace:Custodian.DALs.InterfaceService.Financial_Plan_Data_Correct  5
   	     � WindowStyle$
  None=�5       � Title$ Financial_Plan��5   	   $	��700��5   	   $	��800��6   $
��1000��6"   .��5      �  � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      .+�5   
   � -   5         
  Gray26#��[  5      $��0��65   .+�5      �� $��FINANCIAL PLAN��6   $��Center=�6-     StyleTableHeader#��[ 5      $��Center=�6>   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        $��_��5      $��20��6%   $	��5,5q�60     MainFont#��[ 6=     ButtonControlTemplate#��[ 5        StyleButton#��[ 6G    � Cursor$
 Hand��6l   �� 5      -   5        $	��▀��5      $��20��6%   $	��5,5q�60   #��[ 6=   #��[ 5      #��[ 6G   $
 Hand��6l   �� 5      -   5        $��X��5      $��20��6%   $	��5,5q�60   #��[ 6=   #��[ 5      #��[ 6G   $
 Hand��6l   5      5       � 5!   
    
 Gray46#��[ 6   $��1��64    5"      �� 5#      $	��310 �6    �� 5$      .+�5&      � $��5q�6    � ColumnDefinitions 5'      �� 5(      $	��630 �6'   �� 5)      $��1* �6'   .+�5+      �� 
���   �$��1q�6-   ._�5,      �� $��0��6!   $ Vertical=�6.   $��10q�6E   .+�5-      �� -   5        $��ParentPanel1��5-   i   $ 
Horizontal=�6%   $��Stretch=�6>   $��10q�6]   .+�5.      �� -   5        $��InvSumm��5/   J   $	��100��5.   &   $��22��62   #��[ 6>   {�5/   "   �� *IsEnabledTextBoxs+.��6Y   ��50   "   �� 51   &    �� Path$ CurrentPortfel�6.    �� UpdateSourceTrigger$ PropertyChanged=�6D    �� NotifyOnValidationError . 	 �� ValidationRules	 52   *   Y  SCustodian.DALs.InterfaceService.Financial_Plan_Data_Correct.INTMinMaxFormat_Correct  53   .   

   Min$
 500000��6N   
   Max$ 
1000000000��6[   55   '   .��56   0   57      �� 59      $��Investment Summ (USD)��6$   
�������#��[ 6W   �� 5:      $
��40,5q�6%    �� TickFrequency$ 1Q�63   $	��310��6E    �� IsSnapToTickEnabled .  � Maximum$ 
1000000000Q�5;   !    � Minimum$ 500000Q�66   $��Stretch=�5<   _    � Value 6!   ��  �� ElementName$ InvSumm��$
 Text� �� Mode$ TwoWay=�{�5=   !   �� *IsEnabledTextBoxs+5>      5?      �� 5A      $ 
Horizontal=�6%   $��10q�6?   .+�5B      �� -   5        $	��Pri��5B   g   $	��100��6&   $��22��62   {�6?   �� *IsEnabledTextBoxs+.��6r   ��5C   "   �� 5D   &   $ 
CurrentPRI�6.   $ PropertyChanged=�6@    . 	 5E   *     5F   .   $
 1��6N   $ 6��6V   5H   '   .��5I   0   .  (System.Windows.Interactivity.Interaction   Triggers 5J   "   /  )System.Windows.Interactivity.EventTrigger  5K   &      	EventName$ TextChanged��65   .  (System.Windows.Interactivity.TriggerBase   Actions. 5L   *   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6@   �� *PropertyValidChanged+5M   '   .��5N   :   5O      �� 5P      $	��PRI��6$   
�������#��[ 6E   �� 5Q      $��142,0q�6%   $ 1Q�64   $	��310��6G   $ 1Q�6V   $ 6Q�6b   $��Stretch=�6n    .  5R   !   �� $	 Pri��$
 Text�$ TwoWay=�{�6v   �� *IsEnabledTextBoxs+5S      5T      �� 5V      $��Get from Current Portfell��6#     TemplateCheckBox#��[ 6G     
StyleInput#��[ 6t   #��[ 5W      $��15��6F   $��10q�6R    5X        5Y   "   $ Checked��61   . 5Z   &      6<   �� *InsertCurrentPortfelData+5[   #     5]   "   $ 	Unchecked��61   . 5^   &      6<   �� *	CheckNull+5_   #   5a      �� 5b      $ 
Horizontal=�6%   $��10q�6>   .+�5c      �� -   5        $��Profit��5c   >   $	��100��6&   $��22��62   .��6L   ��5d   "   �� 5e   &   $ Target�6.   $ PropertyChanged=�6<    . 	 5f   *     5g   .   $
 1��6N   $	 500��6V   5i   '   .��5j   0   5k      �� 5l      $��Target (% Profit)��6$   
�������#��[ 6S   �� 5m      $
��82,0q�6%   $ 1Q�63   $ 1Q�6?   $	 500Q�6Q   $	��310��6_    .  5n   !   �� $ Profit��$
 Text�$ TwoWay=�5p      5q      �� 5r      $ 
Horizontal=�6%   $��10q�6?   .+�5s      �� -	   5        $
��Time��5s   >   $	��100��6&   $��22��62   .��6J   ��5t   "   �� 5u   &   $ 
TargetTime�6.   $ TwoWay=�6@   $ PropertyChanged=�6N    . 	 5v   *     5w   .   $
 1��6N   $ 5��6V   5y   '   .��5z   0   5{      �� 5|      $��Time (Years)��6$   
�������#��[ 6O   �� 5}      $	��310��6%   $��100,0q�6h   $ 1Q�6w   $ 5Q�6�    .  65   �� *YearToPlain+$ TwoWay=� 5~   !   �� $
 Time��$
 Text�$ TwoWay=�5�      5�      �� 5�      $��0,-4,0,0q�6!   $��Get Plan��63   #��[ 6F    
 GrayEA#��[ 6x   $	��100��5�      $��26��6(   $
 Hand��64   $��Center=�6B    
	 Gray36#��[	 6_    5�        5�   "   $ PreviewMouseDown��61   . 5�   &      6<   �� *FillEtfCollections+5�   #   ��5�      �� 5�   "    �� 
TargetType" ��6(   .�5�   &   ��  �� Property � {� �� Value .  6B    �� Triggers 5�   &   ^� 5�   *    ^� 
Conditions 5�   .   �� 5�   2    �� Binding 6<   �� $	 Pri��$ (Validation.HasError)� �� Value	 false6|   �� 5�   2    6<   �� $ InvSumm��$ (Validation.HasError)�	 false6�   �� 5�   2    6<   �� $ Profit��$ (Validation.HasError)�	 false6   �� 5�   2    6<   �� $
 Time��$ (Validation.HasError)�	 false6}   .0�5�   .   ��  � {� . 6J   5�   +   5�   #   5�      5�      5�      �� 5�      $��1��6   $��1q�6)   
���   �._�5�      �� .��5�      �� $ Vertical=�6%   $��10q�6<   .+�5�   "   �� 
��� � �#��[ 6?   $��16(�6f   $��Center=�5�   ,   Good Script :5�   #   �� 5�      $
��Wrap=�6N   ��6(   �� *GoodScreenAnnotation+6N   �� 5�      
����� �#��[ 6:   $��16(�6a   $��Center=�5�   ,   Normal Script :5�   #   �� 5�      $
��Wrap=�6P   ��6(   �� *NormalScreenAnnotation+6P   �� 5�      
���  ��#��[ 69   $��16(�6`   $��Center=�5�   (   Bad Script :5�      �� 5�      $
��Wrap=�6M   ��6(   �� *BadScreenAnnotation+6M   5�      5�      5�      5�      �� 5�      $��1��6   $��10q�6"   
���   �$��1q�6B   ._�5�      '  !Syncfusion.UI.Xaml.Charts.SfChart  $��3q�6       Annotations 5�      8  2Syncfusion.UI.Xaml.Charts.HorizontalLineAnnotation  /  )Syncfusion.UI.Xaml.Charts.ShapeAnnotation   CanDrag .  6	  0Syncfusion.UI.Xaml.Charts.StraightLineAnnotation  	  ShowAxisLabel  . *
  $Syncfusion.UI.Xaml.Charts.Annotation	! 
  Y1! 69   �� *Target+6_   "   PrimaryAxis" 5�      ,  &Syncfusion.UI.Xaml.Charts.CategoryAxis  5�      )  #Syncfusion.UI.Xaml.Charts.ChartAxis#   AxisLineOffset$# 1000000Q�6-   $   
PlotOffset$$ 15Q�6F   ���#868686 
 
StyleLine2%   MajorTickLineStyle#% � 
 6k   &   TickLineSize$& 20Q�5�   !   '   MaximumLabels$' 80��63   (   ShowGridLines( .  $��12(�6\   )   TickLinesPosition$) Inside=�6j   *   SecondaryAxis* 5�      -  'Syncfusion.UI.Xaml.Charts.NumericalAxis  5�      $# 1000000Q�6.   +   RangePadding$+ Round=�6G   ,   Header$, %��6\   $��12(�6g   ���#868686$) Inside=�6�   ( .  #% � 
 5�   8   -   	Behaviors- 5�      4  .Syncfusion.UI.Xaml.Charts.ChartZoomPanBehavior  .   ZoomMode$. XY=�65   6E   /   Series./ 5�      ,  &Syncfusion.UI.Xaml.Charts.SplineSeries  /  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase0   EnableAnimation0 . 1   XBindingPath$1 	chartDate��5�      ,  &Syncfusion.UI.Xaml.Charts.XyDataSeries2   YBindingPath$2 chartVal��5�      3   ItemsSource3 5�      �� *MinEtf+  5�      0 . $1 	chartDate��5�      $2 chartVal��5�      3 5�      �� *MaxEtf+  5�      0 . $1 	chartDate��5�      $2 chartVal��5�      3 5�      �� *	MiddleEtf+5�      5�      5�      5�      5�      