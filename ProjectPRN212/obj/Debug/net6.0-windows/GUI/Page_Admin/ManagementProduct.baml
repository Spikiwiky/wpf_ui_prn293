   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectPRN212.GUI.Page_AdminProjectPRN212.GUI.Page_Admin  5   	   4    .ProjectPRN212.GUI.Page_Admin.ManagementProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ProjectPRN212.GUI.Page_Admin     5   	     � Title$  ManagementProduct��5   	   $	��656��6#   $
��1483��60   .��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��Management Product ��6   ���	#FF01579B$��24(�6J   $��Center=�6X   $
��10,0q�6s   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� $��Manage Products��6   $	��120��63   ���	#FFFFCC80���	#FF01579B
������ 6m   �� 5      -   5        $��Manage Users��5      $	��120��60   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $��btn_createNewProduct��5      $��Create new product��65   $	��120��6R   ���	#FFFFCC80���	#FF01579B
������ 6�   5      �� 5      -   5        $��	btnLogout��5      $��Logout��6&   $	��100��67   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   6�   �� 5      -   5         ��Name$ 
btnProfile��5      $��Profile��6+   $	��100��6=   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 
dgProducts��5      $��
10,95,10,4q�6'      AutoGenerateColumns$ False��5         CanUserAddRows$ False��5         SelectionMode$ Single=�5         SelectionUnit$ FullRow=�5       ��5      �� *
Products+   Columns 5!      0  *System.Windows.Controls.DataGridTextColumn  5"      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProductId+6O     5#      $
	 Name��6%   $	
 150 6S      
FontWeight$
 Bold"�6_    63   �� *ProductName+6_     5$      $	 Image ��6%   $	
 200 6S    65   �� *	Thumbnail+6S     5%      $	 Price��6%   $	
 100 6R    64   �� *	SalePrice+6R     5&      $	 Summary��6%   $	
 200 6R    66   �� *	Summary+6R     5'      $	 ProductDetail��6%   $	
 200 6^    6<   �� *ProductDetail+6^     5(      $	 Quantity��6%   $	
 100 6T    67   �� *
Quantity+6T     5)      $	 Status��6%   $	
 100 6W    65   �� *ProductStatus+6W   4  .System.Windows.Controls.DataGridTemplateColumn  5*      $	 Actions��6)   $
 * 6:      CellTemplate 5+      �� 5,      .R�5-      �� $ 
Horizontal=�6)   .+�5.   "   �� -   5        $
��Hide��5.   )   $��5q�6R   ��5/   &   �� 50   *    �� 
TargetType" ��60   .�51   .   ��  �� Property � y� �� Value$ 	Collapsed=�6K    �� Triggers 52   .   �� 53   2    �� Binding 6>   �� *ProductStatus+ �� Value True6`   .a�54   6   ��  � y�$ Visible=�6S   55   3   57   +   59   #   �� 5;   "   -   5        $
��Show��5;   )   $��5q�6R   ��5<   &   �� 5=   *   " ��60   .�5>   .   ��  � y�$ 	Collapsed=�6K    5?   .   �� 5@   2    6>   �� *ProductStatus+	 False6`   .a�5A   6   ��  � y�$ Visible=�6S   5B   3   5D   +   5F   #   �� 5H   "   -   5        
����  �$��Update��5H   ;   $��5q�6g   �� 5J   "   -	   5        
���  ��$��Delete��5J   :   $��5q�6f   5K      5L      5N      5P      5R      5S      