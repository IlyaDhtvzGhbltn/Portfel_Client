   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Custodian.PagesCustodian.Pages  5      1clr-namespace:Custodian.ModelCustodian.Model  5          Custodian.Chat   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:Custodian.Pages     5      /modelclr-namespace:Custodian.Model     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      -   5          � WindowStyle$
  None=�5	      $	��550��5      $	��400��6   .��5      �  � RowDefinitions 5   
   �� 5      $��32 �6   �� 5      $��1* �6   .+�5   
   � -   5         
  Gray26#��[  5      $��0��65   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        $��_��5      $��20��6%   $	��5,5q�60     MainFont#��[ 6=     ButtonControlTemplate#��[ 5        StyleButton#��[ 6G    � Cursor$
 Hand��6l   �� 5      -   5        $	��▀��5      $��20��6%   $	��5,5q�60   #��[ 6=   #��[ 5      #��[ 6G   $
 Hand��6l   �� 5      -   5        $��X��5      $��20��6%   $	��5,5q�60   #��[ 6=   #��[ 5      #��[ 6G   $
 Hand��6l   5      5       �� 5!   
    
 Gray46#��[ 6    �� Padding$ 8q�66   $��1��6B   ._�5"      �  5#      �� 5$      $��16 �6$   �� 5%      $��1* �6$    � ColumnDefinitions 5(      �� 5)      $	��220 �6'   �� 5*      $
��Auto �6'   �� 5+      $��1* �6'   .+�5.      �� $#��CHAT WITH PERSONAL CONSULTANT��6   $
��Left=�6@     StyleTableHeader#��[ 5/      $��Center=�6>   $��2��6Y   �� 50      $��CONSULTANT INFO��6   $
��Left=�62   $��Center=�6N   #��[ 51      $��0��6>   �� 53      $��1��6   $��8��6/   $��Stretch=�69   $
��Left=�6U     StyleSplitter#��[ 54      
������ 6>   �� 5C        StyleMainBorder#��[ 6   #��[  5D      $��1q�6<    
 Gray36#��[ 5E      $��1��66   ._�5F      � $��0��6    5G      �� 5H      $
��auto �6,   �� 5I      $	��160 �6,   �� 5J      $��26 �6,   �� 5K      $��70 �6,   .+�5N      � $��1��6    5O      �� 5P   "   $��1* �60   �� 5Q   "   $	��160 �60   �� 5R   "   $��1* �60    5T      �� 5U   "   $��1* �63   �� 5V   "   $	��160 �63   �� 5W   "   $��1* �63   .+�5Y      �� $��5q�6$   $
��Fill=�6/   $��1��6>   $��1��6N   ��6[   �� *AdviserPhoto+5Z      �� 5\      $��2��6I    	 StyleRadioTitle#��[	 6V   $��Center=�5]      $��Center=�6:   $��22��6U   $��0q�6a   ��5\       �� *LastFirstAdviserName+5]   a   &   System.Windows.Controls.DataGrid  5^      $��3��6Q      AutoGenerateColumns .     	RowHeight$ 30Q�5_         
IsReadOnly . 	   GridLinesVisibility$
	 None=�6@   #��[  5`      $��0q�6E    
 
StyleTable#��[
 5a      
   HeadersVisibility$

 None=�6C   ��5^   #   �� *AdviserInfoCollection+   Columns 5b      0  *System.Windows.Controls.DataGridTextColumn  5c   "   ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 65 6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *StaticsNames+6V     5d   "   $ * 6U    65   �� *FromDBNames+6U   5f      5g      5h      � 5j      $��2��6   $��1��6'   #��[ 64    5k      �� 5l      $
��Auto �6(   �� 5m      $	��71* �6(   �� 5n      $
��Auto �6(   �� 5o      $	��200 �6(   .+�5r      �� $��1��6   #��[  6*   $��1q�6P   ._�5s      �  
 Gray86#��[ 6   .+�5t      �� -   5        $��
ChatScroll��5t   Q   $��Visible=�6+   .��5u   "   �� $��5q�6\   ��6/   �� *MessangersCollection+��5v   &   �� 5w   *   .R�5x   .   ��  K� IsItemsHost .  69   5y   +   5{   #   5|      5}      5~      �� 5�      $��2��6#   $��8��60   $	��Top=�6;   $��Stretch=�6S   #��[ 5�      
������ 6B   � 5�      $��3��6    5�      �� 5�      $	��71* �6,   �� 5�      $
��Auto �6,    5�      �� 5�      $��50 �6/   �� 5�      $��1* �6/   .+�5�      � $��0��6   .+�5�      �� $ Vertical=�6)    � 	Resources 5�   "     B2V��%   &	       �� 5�   &   6C   5�   #   .+�5�   "   �� $��Uniform=�6(   $/��)pack://application:,,,/Resources/clip.png��6:   $��10q�6m   $��30��5�   $   $��30��6/   $
��Left=�6;   $	��Top=�6V   $
 Hand��6n   .  (System.Windows.Interactivity.Interaction   Triggers 5�   &   /  )System.Windows.Interactivity.EventTrigger  5�   *      	EventName$ MouseLeftButtonUp��69   .  (System.Windows.Interactivity.TriggerBase   Actions. 5�   .   6	  0System.Windows.Interactivity.InvokeCommandAction	   	  Command 6D   �� *
SelectFile+5�   +   5�   #   �� 5�   "   $��30��6(   $��30��63   $
 Hand��5�   $   y�5�   ?   �� *FileOkVisible+ �� 	Converter# [ ��5�   &   �� 5�   *    �� 
TargetType" ��60    �� Triggers 5�   .   P� 5�   2    P� Property �@J�IsMouseOver P� Value . . �5�   6   ��  �� Property � �� �� Value$9 3pack://application:,,,/Resources/reminder_Delet.png��6O   5�   3   P� 5�   2    �@J�IsMouseOver .  . �5�   6   ��  � ��$3 -pack://application:,,,/Resources/reminder.png��6O   5�   3   5�   +    5�   &     5�   *   $ MouseLeftButtonUp��69   . 5�   .   	   6D   �� *DeleteFiles+5�   +   5�   #   5�      5�      � 5�      $��1��6    5�      �� 5�   "   $
��auto �60   �� 5�   "   $��5 �60   �� 5�   "   $��1* �60   �� 5�   "   $
��Auto �60   .+�5�      �� $
��Auto=�6+   $��Hidden=�6P   .��5�   "   �� #��[ 6[   ��6/   �� *LoadFilesCollection+��5�   &   �� 5�   *   .R�5�   .   �� $ 
Horizontal=�69    .  6h   5�   +   5�   #   5�      �� 5�       �� TextWrapping$
 Wrap=�6&   $��2��6:   $��2��6J   #��[ 6W   #��[ 5�   c   $��16(�6�   #��[  5�   "   #��[ 6I   ��5�   "   �� *
TextToSend+ �� UpdateSourceTrigger$ PropertyChanged=�5�   I   �� 5�      $
��SEND��6%   $��1��6V   {�. #��[ 5�   !   $��Right=�6S   $��3��5�   !     StyleOkButton#��[ 6.   $��0,8,0,0q�6U    �� 	IsDefault . #��[ 5�   !   #��[  6F   #��[ 5�   !   $
��40,0q�5�   !   ��5�   4   �� *InsertMessage+5�      �� 5�      $��1��6+   5�      5�      5�      5�      5�      5�      5�      