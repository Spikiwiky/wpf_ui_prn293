   M S B A M L   `   `   `  ����  ProjectPRN2124    .ProjectPRN212.GUI.Page_Admin.ProductEditWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$   Chỉnh sửa sản phẩm��5   	   $	��500��6$   $	��600��61    � WindowStartupLocation$ CenterScreen=�6=   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��0��6,   $��0,0,0,10q�69   .+�5      �� $��Tên sản phẩm��6   �� 5      -   5         ��Name$ NameTextBox��5      �� 5      $��Thương hiệu��6   $��0,10,0,0q�6+   �� 5      -   5        $ BrandTextBox��5      �� 5      $��Giá cơ bản��6   $��0,10,0,0q�6*   �� 5      -   5        $ BasePriceTextBox��5      �� 5      $��Mô tả��6   $��0,10,0,0q�6%   �� 5      -   5        $ DescriptionTextBox��5       �� AcceptsReturn$
 True��62   $��60��6G   �� 5      $��
Danh mục��6   $��0,10,0,0q�6(   �� 5      -   5         ��Name$ CategoryComboBox��5       �� DisplayMemberPath$ Value��61    �� SelectedValuePath$	 Key��6K   �� 5      $��Hình ảnh��6   $��0,10,0,0q�6(   �� 5      -   5        	 ��Name$	 ProductImagePreview��5      $	��120��61   $��UniformToFill=�6>   $	��0,5q�6V   �� 5      -   5        
 ��Name$
 SelectImageButton��5      $��Chọn ảnh...��60   $	��100��6`   $	��0,5q�6l   5      �� 5!   
   $ 
Horizontal=�6   $��Right=�6.   $��2��6J   $��0,10,0,0q�6W   .+�5"      �� -   5        $
 
SaveButton��5"      $
��Lưu��6)   $��80��6P   $��5q�6[   �� 5#      -	   5        $
 CancelButton��5#      $��Huỷ��6+   $��80��6T   $��5q�6_   5$      5%      5&      