   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ProjectPRN212.GUI.OrderProjectPRN212.GUI.Order  5   	   %    ProjectPRN212.GUI.Order.MyOrder   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:ProjectPRN212.GUI.Order     5   	     � Title$  MyOrder��5   	   $	��456��6   $	��811��6&   .��5	      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��	Store App��6   ���	#FF01579B$��24(�6@   $��Center=�6N   $
��10,0q�6i   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� -   5        $
��Home��5      $	��100��6(   ���	#FFFFCC80���	#FF01579B
������ 6|   �� 5      -   5        $��Products��5      $	��100��6,   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $
��Cart��5      $	��100��6(   ���	#FFFFCC80���	#FF01579B
������ 6|   �� 5      -   5        $��
btnMyOrder��5      $��My Order��6+   $	��100��6>   ���	#FFFFCC80���	#FF01579B
������ 6x   5      �� 5      -   5         ��Name$ 	btnLogout��5      $��Logout��6(   $	��100��69   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   �� 5      -   5        $��	btn_Login��5      $��Login/Register��6&   $	��100��6?   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   �� 5      -   5        $ 
btnProfile��5      $��Profile��6)   $	��100��6;   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      � 5   
   $��10,100,10,10q�6   ���	#FFFFF3E0 � RowDefinitions 5      �� 5       $
��Auto �6    �� 5!      $��* �6    .+�5$      �� $��	My Orders��6   $��24(�6)   $
��Bold"�67   $��10q�6I   ���	#FF01579B �� TextAlignment$ Center=�6l   $��0��6�   �� 5'      $
��Auto=�6   $
��Auto=�6>   $��1��6c   .��5(      �� .+�5)      ��  �� Columns 61   ��  �� Path$ View.Columns� �� RelativeSource ��  �� AncestorType ListView�� 5*      -   5        $��MyOrdersListView��5*      
�������$
��Auto=�6J   	 �� View	 5+      �� 5,      .P�5-   "   �� $��Order ID��61   
 �� Width$	
 100��6C    �� DisplayMemberBinding 6O   �� *	OrderId+�� 5.   "   $��Receiver Name��61   $	
 100��6H    6T   �� *ReceiverFullname+�� 5/   "   $��Receiver Gender��61   $	
 100��6J    6V   �� *ReceiverGender+�� 50   "   $��Receiver Email��61   $	
 150��6I    6U   �� *ReceiverEmail+�� 51   "   $��Phone Number��61   $	
 100��6G    6S   �� *PhoneNumber+�� 52   "   $��Receiver Address��61   $	
 150��6K    6W   �� *ReceiverAddress+�� 53   "   $��
Order Date��61   $	
 150��6E    6Q   �� *	OrderDate+�� 54   "   $��
Total Cost��61   $	
 150��6E    6Q   �� *	TotalCost+�� 55   "   $
��Note��61   $	
 150��6?    6K   �� *Note+�� 56   "   $��Order Status��61   $	
 150��6G    6S   �� *OrderStatus+�� 57   "   $��Actions��61   $	
 200��6B    �� CellTemplate 58   &   �� 59   *   .R�5:   .   �� $ 
Horizontal=�69   .+�5;   2   �� -	   5        $��Received��5;   9   $��0,0,5,0q�6d   
 � Tag 6L   �� *	OrderId+��5<   6   �� 5=   :    �� 
TargetType" ��6@   .�5>   >   ��  �� Property � y� �� Value$ 	Collapsed=�6[    �� Triggers 5?   >   �� 5@   B    �� Binding 6N   �� *OrderStatus+ �� Value 
Delivering6n   .a�5A   F   ��  � y�$ Visible=�6c   5B   C   5D   ;   5F   3   �� 5G   2   -
   5        $��Cancel��5G   9    6K   �� *	OrderId+��5H   6   �� 5I   :   " ��6@   .�5J   >   ��  � y�$ Visible=�6[    5K   >   �� 5L   B    6N   �� *OrderStatus+ 	Cancelled6n   .a�5M   F   ��  � y�$ 	Collapsed=�6c   5N   C   �� 5O   B    6N   �� *OrderStatus+ Received6n   .a�5P   F   ��  � y�$ 	Collapsed=�6c   5Q   C   5S   ;   5U   3   5V   /   5W   +   5Y   #   �� 5Z   "   $��Detail��61   $	
 100��6A    5[   &   �� 5\   *   .R�5]   .   �� -   5        $��Detail��5]   5    6F   �� *	OrderId+6^   5^   +   5`   #   5a      5c      5d      5e      5f      5g      5h      