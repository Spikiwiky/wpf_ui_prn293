   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ProjectPRN212ProjectPRN212  5   	       ProjectPRN212.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ProjectPRN212     5   	     � Title$
  Home��5   	   $	��588��6   $	��862��6#   .��5	      � .+�5   
   ��  �� Orientation$ 
Horizontal=�6   ���	#FFB3E5FC$��50��6E   $	��Top=�6Q   .+�5      �� $��	Store App��6   ���	#FF01579B$��24(�6@   $��Center=�6N   $
��10,0q�6i   5      ]� 5   
   ���	#FFFFF9C4$��40��6+   $	��Top=�67   $��0,50,0,0q�6O   .+�5      �� $ 
Horizontal=�6   $
��Left=�62   .+�5      �� $
��Home��6   $	��100��6(   ���	#FFFFCC80���	#FF01579B
������ 6b   �� 5      -   5        $��btnPresentProduct��5      $��Products��62   $	��100��6E   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $��btnCart��5      $
��Cart��6(   $	��100��67   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $��
btnMyOrder��5      $��My Order��6+   $	��100��6>   ���	#FFFFCC80���	#FF01579B
������ 6�   5      �� 5      $ 
Horizontal=�6   $��Right=�62   .+�5      �� -   5         ��Name$ 
btnProfile��5      $��Profile��6-   $	��100��6?   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $��	btn_Login��5      $��Login/Register��6*   $	��100��6C   ���	#FFFFCC80���	#FF01579B
������ 6�   �� 5      -   5        $ 	btnLogout��5      $��Logout��6,   $	��100��6=   ���	#FFFFCC80���	#FF01579B
������ 6�   5      5      � 5!   
   $��10,100,10,10q�6   ���	#FFFFF3E0 � ColumnDefinitions 5"      �� 5#      $��* �6#   �� 5$      $	��300 �6#   .+�5(      �� $��0��6   $��10q�6)   .+�5)      �� $0��*Chào mừng bạn đến với Store App!��6   $
��Bold"�6D   $��20(�6V   ���	#FF01579B$��Center=�6{   $��0,0,0,20q�6�   �� 5*      $����Tại đây bạn sẽ tìm thấy những sản phẩm mới nhất và tốt nhất. Hãy duyệt qua các danh mục sản phẩm của chúng tôi để tìm ra những sản phẩm phù hợp với nhu cầu của bạn.��6   $
��Wrap=�6�   $��10q�6�    �� TextAlignment$ Center=�6�   5+      �� 5.      $��1��6   $��10q�6)   .+�5/      �� $��Sản phẩm mới nhất��6   $
��Bold"�65   $��20(�6G   ���	#FF01579B$��Center=�6l   $��0,0,0,20q�6�   �� 50      ���	#FF01579B$��2q�61    �� CornerRadius$ 10��6E   $	��280��6W   
�������$��Center=�6v   ._�51      �� .+�52      �� -   5        $��LatestProductImage��52       $	��150��6:   $��UniformToFill=�6G   $��10q�6_   �� 53      -   5        $��LatestProductName��53   $   $
��Bold"�6=   $��18(�6O   $��	10,5,10,0q�6]   $ Center=�6p   �� 54      -	   5        $��LatestProductPrice��54   $   
��� � �$��16(�6Q   $��	10,2,10,0q�6_   $ Center=�6r   �� 55      -
   5        $��LatestProductDescription��55   $   $
��Wrap=�6D   $��	10,5,10,0q�6X   $ Center=�6k   �� 56      -   5        $��BtnShowProduct��56   3   $��Buy Now��6!   ���	#FF01579B
�������$��10,10,10,10q�6s   
������ $��Center=�6�   6�   57      58      59      5:      5;      5<      