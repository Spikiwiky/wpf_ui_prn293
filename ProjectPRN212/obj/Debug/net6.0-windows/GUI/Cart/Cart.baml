   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ProjectPRN212.GUI.CartProjectPRN212.GUI.Cart  5   	   !    ProjectPRN212.GUI.Cart.Cart   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ProjectPRN212.GUI.Cart     5   	     � Title$
  Cart��5   	   $	��704��6   $	��873��6#   .��5	      � .+�5
   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��	Store App��6   ���	#FF01579B$��24(�6@   $��Center=�6N   $
��10,0q�6i   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� -   5        $
��Home��5      $	��100��6(   ���	#FFFFCC80���	#FF01579B
������ 6|   �� 5      -   5        $��Products��5      $	��100��6,   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      $
��Cart��6   $	��100��6(   ���	#FFFFCC80���	#FF01579B
������ 6b   �� 5      -   5         ��Name$ 
btnMyOrder��5      $��My Order��60   $	��100��6C   ���	#FFFFCC80���	#FF01579B
������ 6�   5      �� 5      -   5        $ 	btnLogout��5      $��Logout��6*   $	��100��6;   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   6�   �� 5      -   5        $��	btn_Login��5      $��Login/Register��6&   $	��100��6?   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   �� 5      -   5        $ 
btnProfile��5      $��Profile��6)   $	��100��6;   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      �� 5   
   $��10,100,10,10q�6   ���	#FFFFF3E0.+�5      �� $��	Your Cart��6   $��24(�6)   $
��Bold"�67   $��10q�6I   ���	#FF01579B �� TextAlignment$ Center=�6l   �� 5      -   5        $��CartItemsListView��5      $��10q�60   
���������6O   �� *	CartItems+ �� View 5      �� 5      .P�5       �� $��Product��6)    �� Width$	 200��6:    �� CellTemplate 5!      �� 5"   "   .R�5#   &   �� ��60   �� *ProductName+5$   #   5&      �� 5'      $��Price��6)   $	 100��68    5(      �� 5)   "   .R�5*   &   �� ��60   �� *	SalePrice+5+   #   5-      �� 5.      $��Quantity��6)   $	 100��6;    5/      �� 50   "   .R�51   &   �� ��60   �� *
Quantity+52   #   54      �� 55      $��Total��6)   $	 100��68    56      �� 57   "   .R�58   &   �� ��60   �� *
TotalPrice+59   #   5;      �� 5<      $��	Thumbnail��6)   $	 100��6<    5=      �� 5>   "   .R�5?   &   �� $��50��6I   $��50��6T   ��6,   �� *	Thumbnail+6T   5@   #   5B      5D      5F      �� 5G      $ 
Horizontal=�6   $��Right=�62   $��10q�6N   .+�5H      �� $��Total: $��6   $��16(�6,   $
��Bold"�6:   $
��10,0q�6L   �� 5I      -   5        $��TotalAmountTextBlock��5I      $��16(�6U   $
��Bold"�6c   
��� � ���68   �� *TotalAmount+6u   5J      �� 5K      -	   5        $ btnOrderNow��5K   )   $��	Order Now��6   $	��100��6>   ���	#FF01579B
�������$��Right=�6t   $
��10,0q�6�   6�   5L      5M      5N      