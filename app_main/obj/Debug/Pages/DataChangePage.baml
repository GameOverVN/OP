   M S B A M L   `   `   `  ����C  ?app_main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:app_mainapp_main  5      #    app_main.Pages.DataChangePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:app_main     5        N� Title$  UsersControl��5	       N� 
Background
 �   � � 	Resources 5
         ButtonStyleDataChange �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius  ButtonStyleDataChangeObshie  ButtonStyleAprove��%  &	        &	 �     &	 �    �� 5   
   " ��6.   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���	#FF63A4CF$��1q�68   $ 10��6L   ._�5      �� $��Center=�6/   #��z��6L   $��Center=�6o   5      5      5      5      �� 5   
   " ��64   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���	#FF63A4CF$��1q�68   $ 10��6L   ._�5      �� $��Center=�6/   #��z��6L   $��Center=�6o   5      5      5      5       �� 5!   
   " ��6*   .�5"      ��  � �� 5#      �� 5$      " ��6&   .R�5%      �� ���	#FF63A4CF$��1q�68   $ 10��6L   ._�5&      �� $��Center=�6/   #��z��6L   $��Center=�6o   5'      5(      5*      5+      5,      .��5.      � ���	#FFA2E0F1 � RowDefinitions 5/   
   �� 50      $��50��6   $��50 �6+   69   �� 51      $	��400 �6   6+   �� 52      6   .+�56   
   � $��0��6   .+�57      �� 	 �� Orientation$	 
Horizontal=�6   $��Center=�62   .+�58      �� -   5        #���  58      $��	10 0 10 0q�6O   $��14(�6b   $	��100��6p   .��6�   
Общие6�   5:      5;      � 5<   
   $��1��6   .+�5=      �� -   5        
 ��Name$
 SettingsPanel��5=      $y�Visible=�60   $	 
Horizontal=�6E   $��30��6^   $	��Top=�6j   .+�5>      �� $��23(�6   $��Arial)�6*   Базовый тариф6L   �� 5?      -   5         ��Name$ TextBlockRatio��5?      $	��120��64   $��30 0 0 0q�6@   {�.  $��25(�6e   6u   �� 5@      -   5         ��Name$ textBoxChangeRatio��5@      
�������$	��120��6N   $��0 0 40 0q�6Z   $y�	Collapsed=�6l   6�   �� 5A      -   5         ��Name$ buttonConfirm��5A   E   #���  6   $��0 0 20 0q�6x   $y�	Collapsed=�6�   .��6�   Подтвердить6�   �� 5B      -   5        #���   5B      $��27��6p   .��6|   Изменить6�   5C      &   System.Windows.Controls.DataGrid  5D      -   5          Name$ dataGridCities��5D      $y�	Collapsed=�6/   5F      5H      � 5I   
   $��2��6   6   5K      5L      