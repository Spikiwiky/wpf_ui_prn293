   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectPRN212.GUI.Page_AdminProjectPRN212.GUI.Page_Admin  5   	   /    )ProjectPRN212.GUI.Page_Admin.OrderDetails   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ProjectPRN212.GUI.Page_Admin     5   	     � Title$  OrderDetails��5   	   $	��558��6   $	��876��6+   .��5	      � $��	0,0,24,55q�6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��95��6E   $	��Top=�6Q   $��	0,0,-22,0q�6i   .+�5      �� $��Order Detail��6   ���	#FF01579B$��24(�6C   $��Center=�6Q   $
��10,0q�6l   5      �� 5   
   $��10,100,-22,-48q�6   ���	#FFFFF3E0.+�5      �� $��Order Details��6   $��24(�6-   $
��Bold"�6;   $��10q�6M   ���	#FF01579B �� TextAlignment$ Center=�6p   � 5      $��10q�6    � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $
��Auto �6$    � ColumnDefinitions 5       �� 5!      $	��150 �6'   �� 5"      $��* �6'   .+�5&      �� $��0��6   $��0��6)   $��Order Date:��69   $
��Bold"�6L   $��Center=�6^   �� 5'      -   5        $��txtOrderDate��5'   9   $��0��6   $��1��6)   $��Center=�6M   �� 5*      $��1��6   $��0��6)   $��Receiver_fullname��69   $
��Bold"�6R   $��Center=�6d   $��0,5,0,0q�6   �� 5+      -   5        $��txtReceiver_fullname��5+   :   $��1��6   $��1��6)   $��Center=�6V   $��0,5,0,0q�6q   �� 5.      $��2��6   $��0��6)   $��Receiver_email:��69   $
��Bold"�6P   $��Center=�6b   $��0,5,0,0q�6}   �� 5/      -   5        $��txtReceiver_email��5/   :   $��2��6   $��1��6)   $��Center=�6U   $��0,5,0,0q�6p   �� 52      $��3��6   $��0��6)   $��Phone_number:��69   $
��Bold"�6N   $��Center=�6`   $��0,5,0,0q�6{   �� 53      -   5        $��txtPhone_number��53   9   $��3��6   $��1��6)   $��Center=�6P   $��0,5,0,0q�6k   �� 56      $��4��6   $��0��6)   $��Receiver_address:��69   $
��Bold"�6R   $��Center=�6d   $��0,5,0,0q�6   �� 57      -   5        $��txtReceiver_address��57   9   $��4��6   $��1��6)   $��Center=�6U   $��0,5,0,0q�6p   �� 58      $��5��6   $��0��6)   $��Note:��69   $
��Bold"�6F   $��Center=�6X   $��0,5,0,0q�6s   �� 59      -   5        $��txtNote��59   :   $��5��6   $��1��6)   $��Center=�6I   $��0,5,0,0q�6d   �� 5;      $��6��6   $��0��6)   $ ��Email of Customer order  :��69   $
��Bold"�6[   $��Center=�6m   $��0,5,0,0q�6�   �� 5<      -   5        $��txtEmailOfCustomer��5<   :   $��6��6   $��1��6)   $��Center=�6U   $��0,5,0,0q�6p   5=      �� 5?      -   5        $��lvOrderDetails��5?   C   $��1��6   $��10q�6$   
������� �� View 5@      �� 5A      .P�5B      �� $��Product Name��6)    �� Width$	 200��6l    �� DisplayMemberBinding 6?   �� *ProductName+6l   �� 5C      $��Quantity��6)   $	 100��6e    6;   �� *
Quantity+6e   �� 5D      $��Product Price��6)   $	 100��6n    6@   �� *ProductPrice+6n   �� 5E      $��Total Price��6)   $	 100��6j    6>   �� *
TotalPrice+6j   5F      5H      �� 5I      $��Total Order:��6   $��24(�6,   $
��Bold"�6:   $��10q�6L   
���  ��$ Right=�6i   �� 5J      -	   5        $��txtTotalOrder��5J      $��24(�6O   $
��Bold"�6]   $��10q�6o   
���  ��$ Right=�6�   ��6-   �� *TotalOrderAmount+6�   �� 5K      -
   5        $��btnBack��5K   $   $
��Back��6   
��� � �
�������$��16(�6Y   $	��100��6g   $��10q�6s   6   5L      5M      5N      