   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ProjectPRN212.GUI.Page_AdminProjectPRN212.GUI.Page_Admin  5   	   :    4ProjectPRN212.GUI.Page_Admin.ProductManagementWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <local*clr-namespace:ProjectPRN212.GUI.Page_Admin     5   	     � Title$  Quản lý sản phẩm��5   	   $	��600��6"   $	��900��6/   .��5      ]� .+�5	   
   �� $��20(�6   $
��Bold"�6"   $��Quản lý sản phẩm��64   $��10q�6L   $	��Top=�6X   &   System.Windows.Controls.DataGrid  5   
      AutoGenerateColumns$ False��5      $��10q�5         CanUserAddRows$ False��5         
IsReadOnly$
 True��5      ��5      �� *
Products+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProductId+6O     5      $
 Tên��6%   $ * 6K    62   �� *Name+6K     5      $
 Giá��6%   $	 100 6P    62   �� *	BasePrice+6P     5      $ 
Danh mục��6%   $	 150 6X    67   �� *CategoryName+6X   4  .System.Windows.Controls.DataGridTemplateColumn  5      $ Hành động��6)   $	 250 6<      CellTemplate 5      �� 5      .R�5      �� 	 �� Orientation$	 
Horizontal=�6)   $��Center=�6B   .+�5   "   �� -   5        $��Sửa��5   )   $��60��6Z   $	��2,0q�6e   

 � Tag
 6J   �� 6e   �� 5   "   -   5        $��
Chi tiết��5   )   $��60��6b   $	��2,0q�6m   
 6R   �� 6m   �� 5   "   -   5        $��Biến thể��5   )   $��80��6c   $	��2,0q�6n   
 6S   �� 6n   5      5      5!      5#      �� 5&   
   $	 
Horizontal=�6   $��Center=�6.   $��10q�6K   $��Bottom=�6W   .+�5'      �� -   5        $��<<��5'      $��40��6(   {�6N   �� *CanGoPrevious+�� 5(      $��10q�65   $��Center=�6A   ��6   �� *CurrentPage+6A   �� 5)      -   5        $��>>��5)      $��40��6(   {�6J   �� *	CanGoNext+5*      5+      5,      