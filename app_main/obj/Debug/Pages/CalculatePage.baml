   M S B A M L   `   `   `  ����C  ?app_main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:app_main.Pagesapp_main.Pages  5      "    app_main.Pages.CalculatePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:app_main.Pages     5        N� Title$  CalculatePage��5
      $
��1000��6    � 	Resources 5         ButtonStyleCalculate �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  ButtonStyleBuyClose  ButtonStyleBuy��%  &	        &	 �     &	 �    �� 5   
   " ��6-   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���	#FF3FBEB5$��1q�68   $ 10��6L   ._�5      �� $��Center=�6/   #��z��6L   $��Center=�6o   5      5      5      5      �� 5   
   " ��6,   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���	#FFB54C3F$��1q�68   $ 10��6L   ._�5      �� $��Center=�6/   #��z��6L   $��Center=�6o   5      5      5       5!      �� 5"   
   " ��6'   .�5#      ��  � �� 5$      �� 5%      " ��6&   .R�5&      �� ���	#FF3FBEB5$��1q�68   $ 10��6L   ._�5'      �� $��Center=�6/   #��z��6L   $��Center=�6o   5(      5)      5+      5,      5-      .��5/      � ���	#FF63A4CF.+�50   
   � -   5         �Name$ MainGrid��50       � RowDefinitions 52      �� 53      6"   �� 54      6"   �� 55      6"   �� 56      6"   �� 57      6"   	 � ColumnDefinitions	 59      �� 5:      6%   �� 5;      6%   �� 5<      6%   �� 5=      6%   �� 5>      6%   �� 5?      6%   �� 5@      6%   �� 5A      6%   .+�5C      � -   5        $ 	titleGrid��5C      $��0��6&   $��8��66   .+�5D      �� $/��)Калькулятор страховки��6   $��30(�69   
 �� Padding$
 0 25 0 0q�6G    �� TextAlignment$ Center=�6Z   $��Center=�6q   $��Consolas)�6�   5E      � 5F      $��1��6   $��0��6!   $��3��61   $��3��6E   .+�5G      �� $��1q�6   
���   �$��	10,0,41,0q�6A   ._�5H      �� .+�5I      �� $��20(�6$   $��DemiBold"�62   $��Center=�6H   $��Gadugi)�6e   ���	#FF3B2048$"Информация об авто6�   � 5J      $��0 10 0 0q�6   63   �� 5K      $��15(�6$   $

 50 0q�62   $��Gadugi)�6A   ���	#FF3B2048
Марка6s   �� 5L      -   5         ��Name$ brandCombobox��5L   #     ComboBoxStyle1#���  6:    �� 
IsEditable .  ��. $��Visible=�6�   $	��150��6�   $��20��6�   $
��Left=�6�   $��	50 5 0 20q�6  5M      �� 5N      $��15(�6$   $

 50 0q�62   $��Gadugi)�6A   ���	#FF3B2048Модель6t   �� 5O      -   5        $ modelCombobox��5O   #   #���  6:    .  $	��150��6w   $��20��6�   $
��Left=�6�   $��	50 5 0 20q�6�   ���	#FFD9D1D1���	#FF9191926�   �� 5P      $��15(�6$   $

 50 0q�62   $��Gadugi)�6A   ���	#FF3B2048%#Мощность двигателя6�   �� 5Q      -   5        $ powerCombobox��5Q   #   #���  6:   $	��150��6c   $��20��6o   $
��Left=�6{   $��	50 5 0 20q�6�   ���	#FFD9D1D1���	#FF9191926�   �� 5R      $��15(�6$   $

 50 0q�62   ���	#FF3B2048Год выпуска6e   �� 5S      -   5        $ releaseYearCombobox��5S   $   #���  6A   $	��150��6j   $��20��6v   $
��Left=�6�   $��	50 5 0 20q�6�   ���	#FFD9D1D1���	#FF9191926�   5T      5U      �� 5V      -   5         ��Name$ TextBlockNoMark��5V      
���  ��$y�Hidden=�6F   $
��Wrap=�6Z   $��Поле пустое��6n   $��219,65,85,220q�6�   �� 5W      -   5        $ TextBlockNoModel��5W      
���  ��$y�Hidden=�6G   $
��Wrap=�6[   $��Поле пустое��6o   $��219,128,85,154q�6�   �� 5X      -	   5        $ TextBlockNoPower��5X      
���  ��$y�Hidden=�6G   $
��Wrap=�6[   $��Поле пустое��6o   $��219,194,85,90q�6�   �� 5Y      -
   5        $ TextBlockNoYear��5Y      
���  ��$y�Hidden=�6F   $
��Wrap=�6Z   $��Поле пустое��6n   $��219,259,85,26q�6�   5Z      � 5\      $��0 0 70 0q�6   $��1��6%   $��3��62   $��5��6B   $��3��6V   .+�5]      �� $��1q�6   
���   � �� Padding$ 5q�6A   ._�5^      �� -   5         ��Name$ stackPanel_driver��5^   !   $��0,0,0,4q�6<   .+�5_      �� $��20(�6$   $��DemiBold"�62   $��Center=�6H   $��Gadugi)�6e   ���	#FF3B2048*(Информация о водителе6�   � 5a      $��0 10 0 0q�6   	 5b      �� 5c   "   65   �� 5d   "   65   �� 5e   "   65   .+�5g      �� $��0��6)   .+�5h   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048Фамилия6|   �� 5i   "   -   5         ��Name$ surnameTextBox��5i   *   $	��130��6u   $��25��6�   $
��Left=�6�   $��0 5 0 20q�6�   
����������	#FF9191926�   5j      �� 5k      $��1��6)   .+�5l   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048Имя6x   �� 5m   "   -   5        $ nameTextBox��5m   *   $	��130��6o   $��25��6{   $
��Left=�6�   $��0 5 0 20q�6�   
����������	#FF9191926�   5n      �� 5o      $��2��6)   .+�5p   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048Отчество6}   �� 5q   "   -   5        $ middlenameTextBox��5q   *   $	��128��6{   $��25��6�   $
��Left=�6�   $��0 5 0 20q�6�   
����������	#FF9191926�   5r      5u      � 5v      	 5w      �� 5x   "   $	��130 �63   6A   �� 5y   "   $	��110 �63   6A   �� 5z   "   66   .+�5|      �� $��0��6)   .+�5}   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048Год рождения6�   �� 5~   "   -   5        $ ageComboBox��5~   ,   #���  6A    �� MaxDropDownHeight$	 120��6j    .  $	��130��6�   $��23��6�   $
��Left=�6�   $��0 5 0 20q�6�   ���	#FFD9D1D1���	#FF9191926  5      �� 5�      $��1��6)   $��10 0 0 0q�69   .+�5�   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048
Стаж6y   �� 5�   "   -   5        $ experienceTextBox��5�   +   $	��100��6|   $��23��6�   $
��Left=�6�   $��0 5 0 20q�6�   
����������	#FF9191926�   5�      �� 5�      $��2��6)   $��10 0 0 0q�69   .+�5�   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048'%ДТП за последний год6�   �� 5�   "   -   5        $ amountOfAccidentsTextBox��5�   +   $	��165��6�   $��23��6�   $
��Left=�6�   $��0 5 0 20q�6�   
����������	#FF9191926�   5�      5�      � 5�      	 5�      �� 5�   "   65   �� 5�   "   65   .+�5�      �� $��0��6)   .+�5�   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048,*Город регистрации авто6�   �� 5�   "   -   5        $ cityCombobox��5�   +   #���  6A   $	 110��6j   $	��200��6�   $��23��6�   $
��Left=�6�   $��0 5 0 20q�6�   ���	#FFD9D1D1���	#FF9191926�   5�      �� 5�      $��1��6)   $��10 0 0 0q�69   .+�5�   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   ���	#FF3B2048)'Количество водителей6�   �� 5�   "   -   5        $ driversTextBox��5�   *   $	��190��6u   $��23��6�   $
��Left=�6�   $��0 5 0 20q�6�   
����������	#FF9191926�   5�      5�      �� 5�       �� Orientation$ 
Horizontal=�6%   .+�5�      �� .+�5�   "   �� $��15(�6,   $	
 0 0q�6:   $��Gadugi)�6H   $��23��6\   ���	#FF3B2048�� 6�   $-�'Гос. номер автомобиля��6�   6�   �� 5�   "   -   5        $ regnumTextBox��5�   *   $	��250��6s   $��25��6   
����������	#FF9191926�   5�      �� 5�      $��Center=�6)   .+�5�   "   	� -   5         	�Name$ osagoBtn��5�   .    d� 	IsChecked$
 trueY�6@   $��
ОСАГО��6o   	� 5�   "   -   5        $ kaskoBtn��5�   .   $��
КАСКО��6@   5�      5�      5�      5�      �� 5�      -   5        $ TextBlockNoCarNumber��5�      
���  ��$y�Hidden=�6K   $
��Wrap=�6_   $^��XГос. номер должен быть подобного формата: А000АА000��6s   $��327,264,0,5q�6�   5�      � 5�      -   5        $ 
buttonGrid��5�      $��0��6(   $��4��68   $��8��6E   .+�5�      ��  K� ZIndex$ 10��6   $ 2��6+   ._�5�      �� -   5         ��Name$ 	calculate��5�   L   #���   6   $��50��6   $��Рассчитать��6�   $��20(�6�   ���	#FF3FBE82
�������$��Candara Light)�6�   $��440,25,425,25q�6�   5�      �� 5�      -   5        $ TextBlockNoDriverInfo��5�      
���  ��$y�Hidden=�6L   $
��Wrap=�6`   $Q��KЗаполните все поля информации о водителе��6t   $��362,0,-154,80q�6�   $��14(�6�   5�      5�      � 5�   
   -   5        $ totalPriceGrid��5�      $	��400��6'   $	��200��63   $y�	Collapsed=�6@   ���	#FFA2E0F1.+�5�      �� $��10 30 10 100q�6   .+�5�      �� -   5        $ totalPriceTB��5�      $��Center=�62   5�      5�      �� 5�      $ 
Horizontal=�6   $��0 80 0 0q�62   .+�5�      �� $	��100��6   $��50��6%   $��
40 0 100 0q�61   ._�5�      �� -   5        #���  5�      $��18(�6K   ���	#FFB54C3F$��0,9,-7,9q�6�   
�������.��6�   Закрыть6�   5�      �� 5�      $	��100��6   $��50��6%   ._�5�      �� -   5        #���  5�      $��18(�6F   ���	#FF3FBE82
�������.��6�   Купить6�   5�      5�      5�      5�      5�      