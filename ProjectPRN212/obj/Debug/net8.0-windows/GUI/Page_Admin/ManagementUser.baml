   M S B A M L   `   `   `  ����  ProjectPRN2121    +ProjectPRN212.GUI.Page_Admin.ManagementUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  User Management��5   	   $	��550��5   	   $
��1080��6    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��User Management��6   ���	#FF01579B$��24(�5      $��Center=�6&   $
��10,0q�5      5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� -   5        $��btnManageProduct��5   3   $��Manage Products��6   $	��120��6K   ���	#FFFFCC80���	#FF01579B
������ 5   3   �� 5      $��Manage Users��6   $	��120��60   ���	#FFFFCC80���	#FF01579B
������ 5      5      �� 5      $ 
Horizontal=�6   $��Right=�62   $��Right=�6N   .+�5      �� -   5         ��Name$ 
btnAddUser��5      $��Add User��6-   $	��100��6@   ���	#FF81C784
�������
������ $	��5,0q�5!   3   5"      �� 5#      -   5        $ 
btnProfile��5#      $��Profile��6-   $	��100��6?   ���	#FFFFCC80���	#FF01579B
������ $	��5,0q�5%   3   6@   �� 5&      -   5        $ 	btnLogout��5&      $��Logout��6,   $	��100��6=   ���	#FFFFCC80���	#FF01579B
������ $	��5,0q�5(   3   6@   5)      5*      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ dgUsers��5-      $��10,95,10,10q�6$      AutoGenerateColumns$ False��5.         CanUserAddRows$ False��5/         SelectionMode$ Single=�51         SelectionUnit$ FullRow=�52      	   
IsReadOnly$
	 True��53      ��50      �� *Users+
   Columns
 55      0  *System.Windows.Controls.DataGridTextColumn  56      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 60 6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *UserId+6L     57      $ 	Full Name��6%   $	 150 6U      
FontWeight$
 Bold"�6a    68   �� *
UserName+6a     58      $ Email��6%   $	 200 6N    64   �� *Email+6N     59      $ Phone��6%   $	 130 6N    64   �� *Phone+6N     5:      $ Address��6%   $	 200 6R    66   �� *	Address+6R     5;      $ Status��6%   $ 80 6P    65   �� *Status+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5>      $ Actions��6)   $	 220 6:      CellTemplate 5?      �� 5@      .R�5A      �� $ 
Horizontal=�6)   $��Center=�6B   .+�5B   "   �� -   5        $
��Lock��5B   )   $	��5,0q�5C   )   
���  ��
���������5F   &   �� 5G   *    �� 
TargetType" ��60   .�5H   .   ��  �� Property � y� �� Value$ 	Collapsed=�6K    �� Triggers 5I   .   �� 5J   2    �� Binding 6>   �� *Status+ �� Value 16Y   .a�5K   6   ��  � y�$ Visible=�6S   5L   3   5N   +   5P   #   �� 5R   "   -   5        $��Unlock��5R   )   $	��5,0q�5S   )   
��� � �
���������5V   &   �� 5W   *   " ��60   .�5X   .   ��  � y�$ 	Collapsed=�6K    5Y   .   �� 5Z   2    6>   �� *Status+ 06Y   .a�5[   6   ��  � y�$ Visible=�6S   5\   3   5^   +   5`   #   �� 5b   "   -   5        $
��Edit��5b   )   $	��5,0q�5c   )   ���	#FF64B5F6
�������5e   )   5f      5g      5i      5k      5l      5m      