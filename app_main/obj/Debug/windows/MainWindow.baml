   M S B A M L   `   `   `  ����C  ?app_main, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:app_mainapp_main  5   	       app_main.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:app_main     5   	     � Title$  
MainWindow��5   	   $	��760��6   $
��1360��6)    � WindowState$ 	Maximized=�66    � 	Resources 5	         TextBox.Static.Border �� Color  textBoxEllipse �� 
TargetType �� Property �� Value-  'System.Windows.Input.KeyboardNavigation �� 
TargetType ��Name	 �� CornerRadius
 J� SnapsToDevicePixels ��Name �� Triggers P� Property P� Value �� 
TargetName �� Triggers ]� 
Conditions �� Property �� Value��%�  &	        &	 #     7   �� 5
   
   $ 	#FFABAdB3��68   �� 5   
   " ��6'   .�5      ��  � ��# � ��6+   �� 5       � ��8   6,   �� 5       � ��# � ��6+   �� 5       � ��$ 1q�60   �� 5       �@ TabNavigation$
 None=�6A   �� 5       � ��$
 Left=�6;   �� 5       �@�FocusVisualStyle 61   Z� �� 5       �@J�	AllowDrop . 6*   �� 5       �@��PanningMode$ VerticalFirst=�69   �� 5       �@��IsFlicksEnabled .  67   �� 5       � ��$ 20(�6)   66   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   $	 10��61   
�������#��z��6V   #��z��6�   
 . ._�5      �� $ PART_ContentHost��6+   |�.  $��Hidden=�6W   $��Hidden=�6~   5       5      P� 5        � {� .  . �5!   "   �� $ border��6<    �@J�Opacity$
 0.56Q�6P   5"      5&      5(       5)      ]� 5*       5+      �� 5,      + �@��#IsInactiveSelectionHighlightEnabled . 6S   �� 5-       �@��IsSelectionActive .  6A   ./�5/      ��  �@��SelectionBrush# � /�67   50      52      53      .��54      � ���	#FFD2D2D2.+�56   
    � -   5          �Name$ frameMainWindow��56        � NavigationUIVisibility$ Hidden=�6)   ���	#FFA2E0F16b   57      58      