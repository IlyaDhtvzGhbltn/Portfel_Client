   M S B A M L   `   `   `  ����@  <CGAAF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Custodian	Custodian  5   	   1clr-namespace:Custodian.PagesCustodian.Pages  5   	       Custodian.RiskTT   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Custodian     5   	   .Userclr-namespace:Custodian.Pages     5   	     � WindowStyle$
  None=�5       � Title$ PRI Test��5	   	   $	��600��6   $	��800��6'   .��5      � .+�5   
   � -   5         
  Gray26#��[  5   4   $��0��6Y   $��32��6g   $	��Top=�6s   .+�5      �� $��PRI TEST��6   $��Center=�6'   $��18(�6D     StyleTableHeader#��[ 5      $��Center=�6>   �� 5       �� Orientation$ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5        $��_��5      $��20��6%   $	��5,5q�60     MainFont#��[ 6=     ButtonControlTemplate#��[ 5        StyleButton#��[ 6G    � Cursor$
 Hand��6l   �� 5      -   5        $	��▀��5      $��20��6%   $	��5,5q�60   #��[ 6=   #��[ 5      #��[ 6G   $
 Hand��6l   �� 5      -   5        $��X��5      $��20��6%   $	��5,5q�60   #��[ 6=   #��[ 5      #��[ 6G   $
 Hand��6l   5      5      �� 5   
   $��Visible=�6   ��. $��0,32,0,0q�6U   #��[  6g   .��5      � $��1��6     StyleInnerBorder#��[ 6!   .+�5!      � -   5         �Name$ TestContent��5!       � RowDefinitions 5"      �� 5#      $
��auto �6(   �� 5$      $
��auto �6(   �� 5%      $
��auto �6(   �� 5&      $��32 �6(   .+�5)      � $��0��6    5*      �� 5+      �� 5,      �� 5-      �� 5.      �� 5/      �� 50      .+�53      �   StyleInfoBorder#��[ 6   $��0��6H    54      �� 55   "   �� 56   "   .+�58      �� $��18(�6$   $H��BIMPORTANT – PLEASE READ BEFORE COMPLETING THIS RISK PROFILE FORM��59      $	��Top=�6i   $��Center=�6�   �� 5;      $��1��6(   $��10q�65   $��17(�6A   $����The series of questions below may help us appraise your risk attitude, financial means and investment objectives prior to your selection of appropriate investment product(s). If you do not wish to provide any particular information, please inform us accordingly. If you feel that none of the suggested responses to a question apply to you, please inform us accordingly. Any recommendation will be solely based on the information you provide (or choose not to provide) hereunder. It is thus very important that you provide accurate and complete information as it may affect the appropriateness of our recommendation. You acknowledge and agree that if you provide inaccurate and/or incomplete information, and/or choose not to disclose certain information, such action will adversely affect the results of this profiling, for which we take no responsibility. ��5<      $
��Wrap=�5=   #   5>      �� 5@      $��2��6%   $ Vertical=�62   .+�5A      �� $��What is your age?��6$   $	��Top=�6@   $��20q�6X   $
��Left=�6e   $��16(�6�   	� 5C      -   5        $	��A10��5C   X     
StyleRadio#��[ 6*   
 � Tag$ 1��6P   $��	Under 64 ��5D   "   $	��200��68   $
��Left=�6D   $	��Top=�6_   	� 5E      -   5        $	��A20��5E   V   #��[ 6*   $ 2��6N   $��Between 64 and 79��5F   "   $	��200��6@   $
��Left=�6L   $	��Top=�6g   	� 5G      -   5        $	��A30��5G   W   #��[ 6*   $ 3��6O   $��80 or over ��5H   "   $	��200��69   $
��Left=�6E   $	��Top=�6`   5I      �� 5K      $��3��6%   $ Vertical=�62   .+�5L      �� $9��3How long do you want to hold onto your investments?��6$   $��20q�6b   $	��Top=�6o   $
��Left=�6�   $��16(�6�   	� 5M      -	   5        $	��B11��5M   V   #��[ 6*   $ 1��6N   $��Less than 3 years��5N   "   $	��200��6?   $
��Left=�6K   $	��Top=�6f   	� 5O      -
   5        $	��B21��5O   V   #��[ 6*   $ 2��6N   $��At least 3 years��5P   "   $	��200��6>   $
��Left=�6J   $	��Top=�6e   	� 5Q      -   5        $	��B31��5Q   V   #��[ 6*   $ 3��6N   $��No specific period ��5R   "   $	��200��6B   $
��Left=�6N   $	��Top=�6i   5S      �� 5U      $��4��6%   $ Vertical=�62   .+�5V      �� $��16(�6(     StyleRadioTitle#��[ 67   $��20q�6`   $����Percentage of your liquid net worth you would like to invest in financial instruments. Liquid Net Worth (or money you can access quickly) = [Current accounts + savings + investments] - total loans outstanding. Please do not include real estate or the value of any businesses you own.  ��6m   $	��Top=�5Y      $
��Left=�6   $
��Wrap=�66   	� 5[      -   5        $	��C12��5[   O   #��[ 6*   $ 1��6Z   $��Less than 25%    ��5\   "   $	��200��6@   $
��Left=�6O   $	��Top=�6j   	� 5]      -   5        $	��C22��5]   P   #��[ 6*   $ 2��6\   $��Between 25% and 50%  ��5^   "   $	��200��6D   $
��Left=�6S   $	��Top=�6n   	� 5_      -   5        $	��C32��5_   N   #��[ 6*   $ 3��6Z   $��More than 50%  ��5`   "   $	��200��6>   $
��Left=�6M   $	��Top=�6h   5a      �� 5c      $��5��6%   $ Vertical=�62   .+�5d      �� $��16(�6(   #��[ 66   $��20q�6_   $����Complete this sentence: I am relying on ______ of the money I have invested in financial products, including any earnings, to cover my spending this year.  ��6l   $	��Top=�5f      $
��Left=�6   $
��Wrap=�66   	� 5g      -   5        $	��D13��5g   N   #��[ 6*   $ 1��5h   "   $��Less than 25% ��6,   $	��200��6F   $
��Left=�6U   $	��Top=�6p   	� 5j      -   5        $	��D23��5j   O   #��[ 6*   $ 2��5k   "   $��Between 25% and 50% ��6+   $��20��6J   $	��200��6X   $
��Left=�6d   $	��Top=�6   	� 5m      -   5        $	��D33��5m   O   #��[ 6*   $ 3��5n   "   $��Between 25% and 50% ��6*   $��20��6I   $	��200��6W   $
��Left=�6c   $	��Top=�6~   5o      5p      � 5r      $��1��6    5s      �� 5t      �� 5u      �� 5v      .+�5y      �� $��0��6%   #��[ 62   $ Vertical=�6[   .+�5z      �� $��RISK ATTITUDE ��6$   $��18(�6=   $	��100��6K   $	��Top=�6Z   $��Center=�6r   �� 5|      $��10q�6(   $��17(�66   $����The following questions are designed to help us evaluate your comfort level in taking investment risks in the account(s) in this relationship.��5}   (   $	��Top=�5~   (   $
��Left=�6@   $
��Wrap=�6[   5      �� 5�      $��1��6%   .+�5�      �� $��16(�6(   #��[ 66   $��20q�6_   $g��aWhich of the following statements best describes your investment objectives in this relationship?��6l   $	��Top=�6�   $
��Left=�6�   $
��Wrap=�5�   $   	� 5�      -   5        $	��E14��5�   X   #��[ 6+   $ 1��6P   $d��^Safety – I aim to protect my capital and will accept returns in line with savings accounts. ��5�   B   $��20��5�   '   $	��700��63   $
��Left=�6B   $	��Top=�6]   	� 5�      -   5        $	��E24��5�   2   $ 2��6*   $��10,0,0,0q�6[   $��30��6n   $	��700��5�   #   $
��Left=�62   $	��Top=�6N   ��5�   "   �� 5�   &   #��[ 61   $k��eDefensive – I seek to maintain my investment value and will accept returns above savings accounts. ��5�   -   $
��Wrap=�6�   5�      	� 5�      -   5        $	��E34��5�   P   #��[ 6+   $ 3��6[   $T��N Income Oriented – I prefer regular income along with some capital growth.  ��5�   '   $��20��5�   '   $	��700��63   $
��Left=�6B   $	��Top=�6]   	� 5�      -   5        $	��E44��5�   O   #��[ 6*   $ 4��6[   $W��Q Growth and Income – I prefer a balance of capital growth and regular income.  ��6�   $��20��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6  	� 5�      -   5        $	��E54��5�   O   #��[ 6*   $ 5��6Z   $	��700��5�   $   $
��Left=�63   $	��Top=�6N   ��5�   "   �� 5�   &   $
��Wrap=�60   $U��OGrowth Oriented – I primarily want capital growth with some regular income.  ��6D   5�      	� 5�      -   5        $	��E64��5�   P   #��[ 6+   $ 6��6[   $Z��TGrowth – I am looking only for capital growth and do not require regular income.  ��6�   $��20��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6  	� 5�      -   5        $	��E74��5�   N   #��[ 6*   $ 6��6Y   $	��700��6�   $
��Left=�6�   $	��Top=�6�   ��5�   "   �� 5�   &   $
��Wrap=�60   $����Specialist Investing – I am looking for specialist investments, which may have uncertain pricing, substantial fluctuations in value, limited liquidity and/or lack of redemption rights. Examples of specialist investment include Margin FX, Hedge funds, Private Equity.  ��6D   5�      5�      �� 5�      $��2��6%   .+�5�      �� $��16(�6(   #��[ 66   $��20q�6_   $����Which of the following statements best describes the amount of risk fluctuation you will tolerate in the value of your investments?  ��5�   (   $	��Top=�5�   (   $
��Left=�6@   $
��Wrap=�6\   	� 5�      -   5        $	��F15��5�   V   #��[ 6*   $ 1��6N   $��40��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6�   ��5�   "   �� 5�   &   $����I prefer investments with negligible price movements which can normally be sold within a week or promise to repay what I invested within a year. ��61   $
��Wrap=�6�   5�      	� 5�      -   5        $	��F25��5�   N   #��[ 6*   $ 2��6Z   $��40��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6�   ��5�   "   �� 5�   &   $����I can tolerate investments with limited negative price movements which can normally be sold within a week for a price that is close to the recent market average.    ��60   $
��Wrap=�6�   5�      	� 5�      -   5        $	��F35��5�   N   #��[ 6*   $ 3��6Z   $��40��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6�   ��5�   "   �� 5�   &   $���� I can tolerate investments with moderate negative price movements which can normally be sold within a week for a price that is close to the recent market average.  ��60   $
��Wrap=�6�   5�      	� 5�      -   5        $	��F45��5�   N   #��[ 6*   $ 4��6Z   $��40��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6�   ��5�   "   �� 5�   &   $����I can tolerate investments with substantial negative price movements, which may have a small risk of losing their entire value, may be difficult to sell or may only be sold at a price below the recent market average.  ��60   $
��Wrap=�6  5�      	� 5�      -   5        $	��F55��5�   O   #��[ 6+   $ 5��6[   $��40��6�   $	��700��6�   $
��Left=�6�   $	��Top=�6�   ��5�   "   �� 5�   &   $����I can tolerate investments with substantial negative price movements which may have a significant risk of losing their entire value and may be difficult or impossible to sell over an extended period.  ��60   $
��Wrap=�5�      5�      	� 5�      -   5        $	��F65��5�   *   $ 6��66   $��50��6]   $	��700��6i   $
��Left=�6x   $	��Top=�6�   ��5�   "   �� 5�   &   #��[ 60   $����I can tolerate investments that may have a high risk of losing their entire value or even more than my initial investment and may have a highly uncertain value at any given time and also be very difficult or impossible to sell over an extended period. ��6U   $
��Wrap=�6Y  5�      5�      5�      � 5�      $��2��6    5�      �� 5�      �� 5�      .+�5�      � $��0��6   #��[ 6,    5�      �� 5�   "   �� 5�   "   .+�5�      �� $��18(�6$    	 StyleInfoTitle#��[	 62   $��KNOWLEDGE AND EXPERIENCE��5�   $   $��25��6G   $	��200��6S   $	��Top=�6b   $��Center=�6z   �� 5�       
 StyleInfoText#��[
 6(   $��17(�6O   $��1��6]   $
��Wrap=�5�   $   $��10q�68   $����The following questions are designed to help us evaluate the extent of your familiarity and knowledge of different types of investment products.��6D   5�      �� 5�      $��1��6%   $ Vertical=�62   .+�5�      �� $
��Wrap=�6(   $��16(�6<   $��20q�6J   $8��2Describe your investment knowledge and experience:��5�   $   #��[ 6^   	� 5�      -   5        $	��J16��5�   *   $ 1��66   $	��700��6]   $
��Left=�6l   $	��Top=�6�   #��[ 6�   ��5�   "   �� 5�   &   $m��gLimited – I have little or no knowledge of investments outside of savings accounts or time deposits. ��60   $
��Wrap=�6�   5�      	� 5�      -    5        $	��J26��5�   *   $ 2��65   $	��700��6\   $
��Left=�6k   $	��Top=�6�   #��[ 6�   ��5�   "   �� 5�   &   $����Moderate – I have general knowledge and understanding of investments that are not savings accounts or time deposits, and I am aware of the general risks related to investing. ��60   $
��Wrap=�6�   5�      	� 5�      -!   5        $	��J36��5�   *   $ 3��65   $	��700��6\   $
��Left=�6k   $	��Top=�6�   #��[ 6�   ��5�   "   �� 5�   &   $����Extensive – I have extensive knowledge and understanding of investments, and I am experienced enough to make my own investment decisions.��60   $
��Wrap=�6�   5�      5�      5�      �� 5�      -"   5        $��25��5�      #��[ 6)   $��3��6N   #��[ 5�      $	��100��6O   $��Ready��6[   $��Center=�5�      $��Center=�6:   6U   5�      5�      5�      5      5     