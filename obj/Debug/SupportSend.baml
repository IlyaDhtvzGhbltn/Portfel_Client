   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Custodian	Custodian  5   	   1clr-namespace:Custodian.PagesCustodian.Pages  5	   	       Custodian.Send   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Custodian     5   	   .pageclr-namespace:Custodian.Pages     5	   	     � WindowStyle$
  None=�5   	    
  Gray46#��[  5       � Title$
 Send��5   	   $	��400��6   $	��400��6#   $	��400��6/   $	��400��6?   $	��400��6N   $	��400��6]   .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      $��32 �6    �� 5      $
��0.7* �6    �� 5      $
��0.4* �6    �� 5      �� 5      $
��0.7* �6    .+�5      � -   5         
 Gray26#��[ 5   8   $��0��6]   .+�5      �� $��TECHNICAL SUPPORT��6   $��Center=�64     StyleTableHeader#��[ 5      $��Center=�6>   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�66   .+�5      �� -   5        $��_��5      $��20��6)   $	��5,5q�64     MainFont#��[ 6A     ButtonControlTemplate#��[ 5        StyleButton#��[ 6G    � Cursor$
 Hand��6l   �� 5      -   5        $	��▀��5      $��20��6)   $	��5,5q�64   #��[ 6A   #��[ 5      #��[ 6G   $
 Hand��6l   �� 5       -   5        $��X��5       $��20��6)   $	��5,5q�64   #��[ 6A   #��[ 5!      #��[ 6G   $
 Hand��6l   5"      5#      �� 5$      $��1��6   $
��Wrap=�6%   $��Center=�69   $��Center=�6W     
StyleLabel#��[ 6r   $-��'Contact us regarding technical support.��5%      5&      �� 5'      #��[ 6   $(��"Choose the subject of the letter :��6=   $��Center=�5(      $��Center=�66   $	��170��6Q   $��0,50,0,0q�6]   6q   �� 5*      -   5         ��Name$ 
subjct_cmb��5*      $��2��6+   $��20��68   $	��120��6D   #��[ 5+      $��Center=�6>   .@�5-      �� $��About Platform��6    $��16��69   
�������  ComboBoxItemStyle#��[ 6X   �� 5.      $��
Bug Report��6    $��16��65   
�������#��[ 6T   �� 5/      $��Feedback��6    $��16��63   
�������#��[ 6R   �� 50      $��Other��6    $��16��60   
�������#��[ 6O   51      �� 53      -   5         ��Name$ text_bx��53       �� TextWrapping$
 Wrap=�6'   $��3��6e   $��5q�6r    
 Gray36#��[ 54      #��[ 67    
	 Gray86#��[	 6^   ��53   ;   �� *
TextToSend+ �� Mode$ TwoWay=�54   ^   �� 56      -   5        $��4��56      $�� Send Message ��6"    
 StyleCalendarButton#��[
 6;   #��[ 57      $��Center=�66   #��[ 58      $	��103��6C   $��Center=�6P   5:      5;      5<      