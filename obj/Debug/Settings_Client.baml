   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Custodian	Custodian  5   	       Custodian.Settings_Client   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Custodian     5   	     � WindowStyle$
  None=�5   	    � AllowsTransparency .  � Title$ Settings_Client��5	   	   $	��450��6!   $	��255��6.   .��5      �  
  Gray26#��[  6   .+�5      � -   5        $
��auto��5      $
��auto��6     StyleMainBorder#��[ 6'   $��2q�6    � RowDefinitions 5   
   �� 5      $��31 �6   �� 5      $��40 �6   �� 5      $��85 �6   �� 5      $��80 �6   �� 5      $��80 �6   �� 5      $��80 �6   �� 5      $��26 �6   �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $	��220 �6   �� 5      $��31 �6   .+�5   
   �� -   5         ��Name$ 	ExitClick��5   G     StyleCloseButton#��[ 6   $��31��6;   $��0��6Z   $��1��6g     ButtonControlTemplate#��[ 5   	   $��33��6P   �� 5!   
   $��CHANGE PASSWORD��6   $��1��6*   $��Center=�67   $	��Top=�6T   $��16(�6l   $	��170��6z   �� 5#   
   $��2��6   $o��iYour account password was created by your Consultant. For security reasons, please change password below.��6!   $
��Wrap=�5$        StyleRadioTitle#��[ 6-   � 5&   
   $��3��6   .+�5'      � $��10q�6   �� 5(      $��New Password��6   $��Center=�6+   $	��Top=�6H   $��15,2,0,0q�6a    J� RenderTransformOrigin$ 0.697,0.542&�6s   $	��117��6�   G� 5)      -   5         G�Name$ newpas��5)        
StyleInput#��[ 6*   $	��200��6N   $
��Left=�6Z   $	��Top=�5*      $��	11,24,0,0q�5+   E   5,      � 5.   
   $��4��6   .+�5/      � $��10q�6   .+�50      �� $��Repeat New Password��6   $��Center=�66   $	��Top=�6S   $��0,2,0,0q�6k   G� 51      -   5        $ currpassmore��51      $
��Left=�64   #��[ 6O   $��0,26,0,7q�6s   $	��200��52   8   53      54      � 55   
   $��5��6   .+�56      � $��10q�6   .+�57      �� -   5        $ buttonPassChange��57      $	��130��63   {�.  $��Change��6Q   #��[ 58        StyleButton#��[ 6I   $��25��59      6   5:      5;      � 5<   
   $��6��6   .+�5=      �� -   5         ��Name$ 
PassStatus��5=      $��_��6(   $��16(�64   $��Center=�6B   $	��211��6_   $��5,0,0,0q�6m   5>      5C      5D      5E      