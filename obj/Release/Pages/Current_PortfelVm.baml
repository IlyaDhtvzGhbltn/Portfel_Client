   M S B A M L   `   `   `  ���� c  _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  	 CGAAF'   !Custodian.Pages.Current_PortfelVm   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     b ^Syncfusion.SfChart.WPF, Version=15.2460.0.40, Culture=neutral, PublicKeyToken=3d67ed1f87d44c892
syncfusion!http://schemas.syncfusion.com/wpf  XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  $��10(�.���  
  Gray36#��[    � ColumnDefinitions  �� $
��378* ��� $
��137* �.+�� $��0��$��20q�.+�'  !Syncfusion.UI.Xaml.Charts.SfChart  -     Name$ cInner��   AreaBorderThickness$ 0q�   Series. )  #Syncfusion.UI.Xaml.Charts.PieSeries  -     Name$ sInner��2  ,Syncfusion.UI.Xaml.Charts.CircularSeriesBase   EnableSmartLabels .   StyleDSeries#��[ 6  0Syncfusion.UI.Xaml.Charts.AccumulationSeriesBase   SegmentSelectionBrush
 �����/  )Syncfusion.UI.Xaml.Charts.ChartSeriesBase   ShowTooltip .    XBindingPath$
 Name��	   YBindingPath$	 Value��
   ItemsSource
 �� *CurrentISINs+   
ColorModel /  )Syncfusion.UI.Xaml.Charts.ChartColorModel     CustomBrushes ��  �� Color$ #FFC087���� $	 Red���� $ #F98E3C���� $ 	#FFDEFF87���� $ 	#FF87FFB8���� $ 	#FF87C3FF���� $ 	#FF5949FF���� $ 	#FFFF87E9���� $ 	#FFBB275D���� $ 	#FF5DFF00��.   (System.Windows.Interactivity.Interaction   Triggers /   )System.Windows.Interactivity.EventTrigger     	EventName$ 	MouseMove��.	   (System.Windows.Interactivity.TriggerBase 	  Actions. 6
   0System.Windows.Interactivity.InvokeCommandAction
   
  Command ��  �� Path$ ClickMouseP� 
  CommandParameter ��  �� ElementName$ sInner��$ SelectedIndex�   	Behaviors 6  0Syncfusion.UI.Xaml.Charts.ChartSelectionBehavior     SelectionCursor$
 Hand��   SelectionMode$ 	MouseMove=�  -   $ cMidder��$ 0q� J� IsHitTestVisible .  ��Z� . .  (Syncfusion.UI.Xaml.Charts.DoughnutSeries  -     Name$ doughnutSeries2��   DoughnutCoefficient$	 0.5Q�   DoughnutSize$	 0.8Q�}�.   .    LabelPosition$ Outside=� . $
 Name��
 �����$	 Value��#��[ ��Z� 
 �� *DiagrammValueCollection+    �� $ #FFC087���� $	 Red���� $ #F98E3C���� $ 	#FFDEFF87���� $ 	#FF87FFB8���� $ 	#FF87C3FF���� $ 	#FF5949FF���� $ 	#FFFF87E9���� $ 	#FFBB275D���� $ 	#FF5DFF00��/  )Syncfusion.UI.Xaml.Charts.AdornmentSeries   AdornmentsInfo 2  ,Syncfusion.UI.Xaml.Charts.ChartAdornmentInfo  -   vvv��  LabelTemplate6  0Syncfusion.UI.Xaml.Charts.ChartAdornmentInfoBase   LabelTemplate# [    	ShowLabel .     ShowConnectorLine  . !   ConnectorHeight$! 30Q�"   AdornmentsPosition$" Bottom=�#   HorizontalAlignment$# Center=�$   VerticalAlignment$$ Center=�  	StyleLine%   ConnectorLineStyle#% �  &   SegmentLabelContent$& LabelContentPath=�'   LabelPosition$' Outer=�(   UseSeriesPalette( .    $
 Hand��$ 	MouseMove=�  -   $ cOuter��$ 0q� .  ��Z� .   -   $ doughnutSeries3��#��[ 
 ����� . )   Label$) Outer��$	 0.4Q�$ 1Q�$ Inside=�$
 Name��$	 Value��
 �� *RiskActivesCollection+    �� $ #FFC087���� $	 Red���� $ #F98E3C���� $ 	#FFDEFF87���� $ 	#FF87FFB8���� $ 	#FF87C3FF���� $ 	#FF5949FF���� $ 	#FFFF87E9���� $ 	#FFBB275D���� $ 	#FF5DFF00��   $& LabelContentPath=� .   LabelTemplate2# [ $# Center=�$$ Center=�$" Bottom=�$! 50Q�$
' Auto=�   $
 Hand��$ 	MouseMove=��� $��1��$��10q�.���� -   $��iLegend������ .R��� * �� Orientation$* 
Horizontal=�.+��� $��8��$��8������ *Value+�� $��5,0,0,0q�$��12(� 
 Gray86#��[ ���� *
Key.Name+