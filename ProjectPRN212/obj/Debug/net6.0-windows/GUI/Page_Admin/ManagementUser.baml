   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectPRN212.GUI.Page_AdminProjectPRN212.GUI.Page_Admin  5   	   1    +ProjectPRN212.GUI.Page_Admin.ManagementUser   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ProjectPRN212.GUI.Page_Admin     5   	     � Title$  ManagementUser��5   	   $	��544��6    $
��1081��6-   .��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��Management User��6   ���	#FF01579B$��24(�6F   $��Center=�6T   $
��10,0q�6o   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� -   5        $��btnManageProduct��5   4   $��Manage Products��6   $	��120��6M   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      $��Manage Users��6   $	��120��60   ���	#FFFFCC80���	#FF01579B
������ 6j   5      �� 5      -   5        $��	btnLogout��5      $��Logout��6&   $	��100��67   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   6�   �� 5      -   5         ��Name$ 
btnProfile��5      $��Profile��6+   $	��100��6=   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgUsers��5      $��
10,95,10,4q�6$      AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         SelectionMode$ Single=�5         SelectionUnit$ FullRow=�5      ��5      �� *	Customers+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
CustomerId+6P     5       $
	 Name��6%   $	
 150 6P      
FontWeight$
 Bold"�6\    63   �� *
Fullname+6\     5!      $	 Gender��6%   $	
 150 6P    65   �� *Gender+6P     5#      $	 Email��6%   $	
 200 6N    64   �� *Email+6N     5$      $	 Phone��6%   $	
 150 6T    64   �� *PhoneNumber+6T     5%      $	 Address��6%   $	
 200 6R    66   �� *	Address+6R     5&      $	 Status��6%   $	
 100 6P    65   �� *Status+6P   4  .System.Windows.Controls.DataGridTemplateColumn  5(      $	 Actions��6)   $
 * 6:      CellTemplate 5)      �� 5*      .R�5+      �� $ 
Horizontal=�6)   .+�5,   "   �� -   5        $��	Lock User��5,   )   
���  ��$��5q�6l   ��5-   &   �� 5.   *    �� 
TargetType" ��60   .�5/   .   ��  �� Property � y� �� Value$ 	Collapsed=�6K    �� Triggers 50   .   �� 51   2    �� Binding 6>   �� *Status+ �� Value True6Y   .a�52   6   ��  � y�$ Visible=�6S   53   3   55   +   57   #   �� 59   "   -   5        $��Unlock User��59   )   $��5q�6^   ��5:   &   �� 5;   *   " ��60   .�5<   .   ��  � y�$ 	Collapsed=�6K    5=   .   �� 5>   2    6>   �� *Status+	 False6Y   .a�5?   6   ��  � y�$ Visible=�6S   5@   3   5B   +   5D   #   5E      5F      5H      5J      5K      5L      