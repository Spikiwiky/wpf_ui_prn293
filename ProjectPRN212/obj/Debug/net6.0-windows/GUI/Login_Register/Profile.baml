   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ProjectPRN212.GUI.Login_Register ProjectPRN212.GUI.Login_Register  5   	   .    (ProjectPRN212.GUI.Login_Register.Profile   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:ProjectPRN212.GUI.Login_Register     5   	     � Title$  Profile��5   	   $	��605��6   $	��898��6&   .��5	      � $��	0,0,10,59q�6    � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   ���	#FFB3E5FC$��50��6R   $	��Top=�6^   .+�5      �� $��Profile��6   ���	#FF01579B$��24(�6>   $��Center=�6L   $
��10,0q�6g   5      � 5   
   $��1��6   $	��438��6   $	��Top=�6)   $��2��6A    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��20q�6%   $	��200��61   $	��200��6=   
�������._�5      �� -   5        $��	imgAvatar��5      $��UniformToFill=�6)   5      �� 5      $��1��6   $��20q�6)   .+�5      �� $��1��6   $��20q�6-   .+�5      �� $��Thông tin cá nhân��6    $
��Bold"�69   $��24(�6K   $��0,0,0,20q�6Y   �� 5       $
��Bold"�6    $��18(�62   $��0,0,0,10q�6@   Họ và Tên:6^   �� 5!      -   5         ��Name$ txtFullName��5!       $��0,0,0,10q�65   $
��Bold"�6G   $��16(�6Y   �� 5"      $
��Bold"�6    $��18(�62   $��0,0,0,10q�6@   Giới tính:6^   �� 5#      -   5        $ 	txtGender��5#       $��0,0,0,10q�63   $��16(�6E   �� 5$      $
��Bold"�6    $��18(�62   $��0,0,0,10q�6@   Địa chỉ:6\   �� 5%      -   5        $ 
txtAddress��5%       $��0,0,0,10q�64   $��16(�6F   �� 5&      $
��Bold"�6    $��18(�62   $��0,0,0,10q�6@   Số điện thoại:6b   �� 5'      -   5        $ txtPhoneNumber��5'       $��0,0,0,10q�68   $��16(�6J   �� 5(      $
��Bold"�6    $��18(�62   $��0,0,0,10q�6@   Email:6Z   �� 5)      -   5        $ txtEmail��5)       $��0,0,0,10q�62   $��16(�6D   5*      5+      5,      �� 5.   
   -   5        $��	btnUpdate��5.      $��Update��6"   $��2��63   $	��133��6@   $��	29,38,0,0q�6L   $
��Left=�6_   $��37��6z   $	��Top=�6�   6�   �� 5/   
   -   5        $��btnChangePassword��5/      $��Change Password��6*   $��2��6D   $	��133��6Q   $��	29,85,0,0q�6]   $
��Left=�6p   $��37��6�   $	��Top=�6�   
����ح�6�   �� 50   
   -	   5        $
��Back��50      $��2��6    $	��114��6-   $��
714,57,0,0q�69   $
��Left=�6M   $��78��6}   $	��Top=�6�   51      52      