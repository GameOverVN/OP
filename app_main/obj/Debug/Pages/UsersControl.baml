   M S B A M L   `   `   `  ����C  ?app_main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:app_mainapp_main  5          app_main.UsersControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:app_main     5        N� Title$  UsersControl��5	       � 	Resources 5
         ButtonStyleUserDelete �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius��%  &	        �� 5   
   " ��6.   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� ���	#FF63A4CF$��1q�68   $ 10��6L   ._�5      �� $��Center=�6/   #��z��6L   $��Center=�6o   5      5      5      5      5      .��5      � ���	#FFA2E0F1 � RowDefinitions 5   
   �� 5      $	��130��6   $
��130* �6,   6<   �� 5      $
��283* �6   6,   .+�5   
   � $��0��6   .+�5       ��  �� Orientation$ 
Horizontal=�6   $��Bottom=�62   .+�5"      �� -   5        	 ��Name$	 deleteUserDG��5"   I   #���   6   $��	10 0 10 0q�6_   $��30��6�   .��6�   Удалить6�   5#      5$      � 5%   
   $��1��6   .+�5&      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 DataGridUsers��5&         
IsReadOnly . 
����������	#FFA2E0F15'      5)      5+      5,      