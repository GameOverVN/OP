   M S B A M L   `   `   `  ����C  ?app_main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:app_main.windowsapp_main.windows  5   	       app_main.CustomMessageBox   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:app_main.windows     5   	     � Title$  Message Box��5   	   $	��200��6   $	��300��6*    � WindowStartupLocation$ CenterScreen=�66    � WindowStyle$
 None=�6[   .��5	      � ���	#FF91D8F4 � RowDefinitions 5
   
   �� 5      �� 5      $
��Auto �6   $��34��6*   .+�5   
   �� -   5        $��MessageContainer��5      $��WrapWithOverflow=�6,   $��10,10,10,10q�6L   �� 5   
   -   5        $��ButtonContainer��5      $��1��6,    �� Orientation$ 
Horizontal=�69   $��Center=�5      $	��300��62    � 	Resources 5       �� 
TargetType �� Property �� Value��%�   '��       �� 5      " ��6   .�5      ��  � ��$ 25��62   �� 5       � ��$ 75��61   �� 5       � ��$ 10,0,0,0q�6/   5      5      .+�5      �� -   5        $
��ОК��5   4   ���	#FF63A4CF$��	112,0,0,0q�6X   
�������$��30��6~   $��68��6�   ���	#FF4690D2 5      ��%d   '��       �� 5      " ��6   .�5      ��  �@��CornerRadius$ 10��69   6F   5      5      5      5      �� 5    
   -   5        	 ��Name$	 TextBlockMessage��5       $��Center=�6.   $��0,77,0,0q�6K   $
��Wrap=�6]   $	��Top=�6q   $	��216��6�   $��48��6�   
 �� TextAlignment$
 Center=�6�   $��Arial)�6�   $��16(�6�   ���	#FF3B20486�   5!      5"      