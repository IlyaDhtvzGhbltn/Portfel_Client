   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Custodian	Custodian  5   	       Custodian.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Custodian     5   	   -   5          � WindowStyle$
  None=�5	   	    � AllowsTransparency . ���#363636 � Title$
 Auth��5   	   $	��410��6   $	��410��6&   $	��370��66   $	��370��6E   $	��403��6T   $	��370��6a    � 
ResizeMode$ NoResize=�6�    � DataContext 5      �� 5   
    �� RelativeSource 6   �� *Self+.��5      �  
  Gray26#��[  6   .+�5      �  
 Gray36#��[ 6   $��3q�60    � ColumnDefinitions 5   
   �� 5      $	��330 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �� $��	65,0,20,0q�6   $��0��6(   $��1��68   .+�5   
   �� $��CLIENT LOG IN��6   $��Center=�6(   �� 5   
   -   5         ��Name$ lbl_Log��5      $��Contract No.��6!   �� 5   
   -   5        	 ��Name$	 	clientLOG��5      $
��q101��6     
StyleInput#��[ 61   �� 5   
   -   5        $ lbl_Pass��5      $��Password��6"   G� 5    
   -   5        
 G�Name$
 PassBox��5    %    G� Password$	 111��6   #��[ 67   �� 5!      -   5         ��Name$ enterClient��5!       �� 	IsDefault . $��ENTER��6;     ButtonControlTemplate#��[ 5"        StyleOkButton#��[ 5#      $��
46,18,42,0q�6<   $	��112��6P   �� 5&      -   5         ��Name$ savePass��5&      $��Save Login and Password��6*   #��[ 5'      $��Center=�6;   $��
30,15,30,0q�5(       d� 	IsChecked$
 TrueY�6+     TemplateCheckBox#���  5)      $��Futuris)�6E   �� 5*   
   -   5        $ errorClient��5*      $y�Hidden=�6%   $��Invalid login or Password��69   
���  ��$��	53,12,0,0q�6n   �� 5,   
   -	   5         ��Name$ rotIMG��5,   $   $y�Hidden=�6   $4��.pack://application:,,,/Resources/hourglass.png��64   $��50��6l   $��50��6x   z�5-      �� 5.      -
   5        
rotate�� �� CenterX$ 25Q�5.   2    �� CenterY$ 25Q�6?   50      �� 51   
   -   5        $
 help��51      $��
Contact Us��6   $��Center=�52      $��77��53       � Cursor$
 Hand��6!   55      56      �� 57   
   -   5        $ 	ExitClick��57   W     StyleCloseButton#��[ 6   $��1��6;   $��31��6K   $��0��6j   #��[ 58   	   $��33��6P   59      5:      5;      