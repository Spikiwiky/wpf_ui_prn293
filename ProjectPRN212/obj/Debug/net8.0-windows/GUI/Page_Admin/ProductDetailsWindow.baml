   M S B A M L   `   `   `  ����  ProjectPRN2127    1ProjectPRN212.GUI.Page_Admin.ProductDetailsWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Chi tiết sản phẩm��5   	   $	��400��6#   $	��600��60    � 
ResizeMode$ NoResize=�6<    � WindowStartupLocation$ CenterOwner=�6R   .��5      � $��20q�6   .+�5   
   �� .+�5      �� $��Chi tiết sản phẩm��6   $��20(�61   $
��Bold"�6?   $��0,0,0,10q�6Q   �� 5	       �� Orientation$ 
Horizontal=�6   .+�5
      �� $	��ID:��6   $	��120��6'   $
��Bold"�63   �� 5      ��6   �� *Product.ProductId+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Tên:��6   $	��120��6(   $
��Bold"�64   �� 5      ��6   �� *Product.Name+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Giá:��6   $	��120��6(   $
��Bold"�64   �� 5      ��6   �� *Product.BasePrice+ �� StringFormat$ N0��5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Danh mục:��6   $	��120��6-   $
��Bold"�69   �� 5      ��6   �� *Product.CategoryName+5      �� 5      $ 
Horizontal=�6   .+�5      �� $��	Mô tả:��6   $	��120��6*   $
��Bold"�66   �� 5      ��6   �� *Product.Description+5       �� 5"      $ 
Horizontal=�6   .+�5#      �� $��Ngày tạo:��6   $	��120��6-   $
��Bold"�69   �� 5$      ��6   �� *Product.CreatedAt+$ dd/MM/yyyy HH:mm��5%      �� 5'      $ 
Horizontal=�6   .+�5(      �� $��Ngày cập nhật:��6   $	��120��62   $
��Bold"�6>   �� 5)      ��6   �� *Product.UpdatedAt+$ dd/MM/yyyy HH:mm��5*      �� 5,      -   5        $��Đóng��5,      $	��100��6$   $��0,20,0,0q�60   $��Right=�6B   6^   5-      5.      5/      