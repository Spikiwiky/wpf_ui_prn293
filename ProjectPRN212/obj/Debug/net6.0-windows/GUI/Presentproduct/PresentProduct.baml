   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectPRN212.PresentproductProjectPRN212.Presentproduct  5   	   1    +ProjectPRN212.Presentproduct.PresentProduct   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:ProjectPRN212.Presentproduct     5   	     � Title$  PresentProduct��5   	   $	��563��6    $	��980��6-   .��5	      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��	Store App��6   ���	#FF01579B$��24(�6@   $��Center=�6N   $
��10,0q�6i   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� -   5        $
��Home��5      $	��100��6(   ���	#FFFFCC80���	#FF01579B
������ 6|   �� 5      $��Products��6   $	��100��6,   ���	#FFFFCC80���	#FF01579B
������ 6f   �� 5      -   5        $��btnCart��5   (   $
��Cart��6   $	��100��67   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $��
btnMyOrder��5      $��My Order��6+   $	��100��6>   ���	#FFFFCC80���	#FF01579B
������ 6�   5      �� 5      -   5         ��Name$ 	btnLogout��5      $��Logout��6(   $	��100��69   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   �� 5      -   5        $��	btn_Login��5      $��Login/Register��6&   $	��100��6?   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   �� 5      -   5        $ 
btnProfile��5      $��Profile��6)   $	��100��6;   ���	#FFFFCC80���	#FF01579B
������ $��Right=�6�   $��Right=�6�   6�   5      ]� 5   
   ���	#FFB3E5FC$��40��6+   $	��Top=�67   $��0,90,0,0q�6O   .+�5      �� -   5         ��Name$ 
cbCategory��5      ���	#FFFFF3E0$��	10,0,10,0q�6B   $	��291��6U   $��28��6a    J� RenderTransformOrigin$ 0.465,3.253&�6m   6�   �� 5      -   5         ��Name$ 	txtSearch��5      $	��209��6)   $��28��65   $��80,0,0,0q�6A   $ 
0.684,0.44&�6S   �� 5       -	   5        $��bnSearch��5       $��Search��6%   $	��100��66   ���	#FFFFCC80���	#FF01579B
������ $��Center=�6�   $��
-100,0,0,0q�6�   6�   5!      � 5$   
   $��10,130,10,10q�6   .+�5%      �� -
   5         ��Name$ ProductListBox��5%      ���	#FFFFF3E0$��Disabled=�6E   ��5&      �� 5'      .R�5(      �  � Orientation$ 
Horizontal=�6$   5)      ��5+      �� 5,      .R�5-      �� ���	#FF01579B$��2q�69    �� CornerRadius$ 10��6M   $��5q�6_   $	��200��6j   
�������._�5.      �� .+�5/   "   �� $	��200��6E   $��UniformToFill=�6R   $��5q�6j   ��6(   �� *	Thumbnail+6j   �� 50   "   $
��Bold"�6I   $��14(�6[   $��5,2,5,0q�6i   	 �� TextAlignment$	 Center=�6z   ��6,   �� *ProductName+6z   �� 51   "   
��� � �$��5,2,5,0q�6p   $	 Center=�6�   ��6,   �� *	SalePrice+
 �� StringFormat$
 {0:C}��6�   �� 52   "   $ Vertical=�6-   $��Center=�6D   .+�53   &   �� -   5        $��Buy Now��53   -   
���  ��
�������$��5q�6c   
������ $	��100��6�   $��40��6�   6�   �� 54   &   -   5        $��Detail��54   -   ���	#FF01579B
�������$��5q�6h   
������ $��60��6�   $��20��6�   6�   55   #   56      57      58      5:      5;      5<      5=      