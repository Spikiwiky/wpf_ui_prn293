   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectPRN212.GUI.Page_AdminProjectPRN212.GUI.Page_Admin  5   	   2    ,ProjectPRN212.GUI.Page_Admin.ManagementOrder   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ProjectPRN212.GUI.Page_Admin     5   	     � Title$  ManagementOrder��5   	   $	��450��6!   $
��1200��6.   .��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��Order Management ��6   ���	#FF01579B$��24(�6H   $��Center=�6V   $
��10,0q�6q   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� $��Manage Orders��6   $	��120��61   ���	#FFFFCC80���	#FF01579B
������ 6k   �� 5      -   5        $��ExportToExcel��5      $��Export to Excel��61   $	��120��6K   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      �� 5      -   5        $��Logout��5      $	��100��6&   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6z   $��Right=�6�   6�   �� 5      -   5         ��Name$ 
btnProfile��5      $��Profile��6)   $	��100��6;   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      � 5   
   $��10,100,10,10q�6   ���	#FFFFF3E0 � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��* �6    .+�5      �� $
��Auto=�6   $
��Auto=�6>   $��1��6c   .��5      �� -   5        $��OrdersListView��5      
�������$
��Auto=�6D   $
��Auto=�6v    �� View 5       �� 5!      .P�5"      �� $��OrderId��6-    �� Width$
 Auto��6>    �� DisplayMemberBinding 6K   �� *	OrderId+�� 5$      $��Email Customer Order ��6-   $	 150��6L    6X   �� *Customer.Email+�� 5%      $��Receiver Name ��6-   $	 100��6E    6Q   �� *ReceiverFullname+�� 5&      $��Receiver Gender��6-   $	 120��6F    6R   �� *ReceiverGender+�� 5'      $��Receiver Email��6-   $	 150��6E    6Q   �� *ReceiverEmail+�� 5(      $��Phone Number��6-   $	 100��6C    6O   �� *PhoneNumber+�� 5)      $��Receiver Address��6-   $	 150��6G    6S   �� *ReceiverAddress+�� 5*      $��
Order Date��6-   $	 150��6A    6M   �� *	OrderDate+�� 5+      $��
Total Cost��6-   $	 150��6A    6M   �� *	TotalCost+�� 5,      $
��Note��6-   $	 150��6;    6G   �� *Note+�� 5-      $��Order Status��6-   $	 150��6C    6O   �� *OrderStatus+�� 5.      $��Actions��6-   $	 200��6>    �� CellTemplate 5/   "   �� 50   &   .R�51   *   �� $ 
Horizontal=�65   .+�52   .   �� -   5        $
��Send��52   5   $��0,0,5,0q�6\   
 � Tag 6D   �� *	OrderId+��53   2   �� 54   6   	 �� 
TargetType"	 ��6<   .�55   :   �� 
 �� Property
 � y� �� Value$ 	Collapsed=�6W    �� Triggers 56   :   �� 57   >    �� Binding 6J   �� *OrderStatus+ �� Value Ordered6j   .a�58   B   �� 
 � y�$ Visible=�6_   59   ?   5;   7   5=   /   �� 5>   .   -   5        $��Cancel��5>   5    6G   �� *	OrderId+��5?   2   �� 5@   6   "	 ��6<   .�5A   :   �� 
 � y�$ Visible=�6W    5B   :   �� 5C   >    6J   �� *OrderStatus+ 	Cancelled6j   .a�5D   B   �� 
 � y�$ 	Collapsed=�6_   5E   ?   �� 5F   >    6J   �� *OrderStatus+ Received6j   .a�5G   B   �� 
 � y�$ 	Collapsed=�6_   5H   ?   5J   7   5N   /   5O   +   5P   '   5R      �� 5S      $��Detail��6-   $	 100��6=    5T   "   �� 5U   &   .R�5V   *   �� -   5        $��Detail��5V   1    6B   �� *	OrderId+6Z   5W   '   5Y      5Z      5\      5]      5^      5_      5`      