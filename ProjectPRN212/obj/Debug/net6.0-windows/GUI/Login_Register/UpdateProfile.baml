   M S B A M L   `   `   `  ����H  DProjectPRN212, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:ProjectPRN212.GUI.Login_Register ProjectPRN212.GUI.Login_Register  5   	   4    .ProjectPRN212.GUI.Login_Register.UpdateProfile   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @local.clr-namespace:ProjectPRN212.GUI.Login_Register     5   	     � Title$  UpdateProfile��5   	   $	��450��6   $	��800��6,   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   ���	#FFB3E5FC$��50��6R   $	��Top=�6^   .+�5      �� $��Update Profile��6   ���	#FF01579B$��24(�6E   $��Center=�6S   $
��10,0q�6n   5      � 5   
   $��1��6   $��20q�6    � ColumnDefinitions 5      �� 5      $
��Auto �6#   �� 5      $��* �6#   .+�5      �� $��0��6   $��0,0,20,0q�6)   .+�5      �� $��
Full Name:��6   $
��Bold"�6.   �� 5      $��Gender:��6   $
��Bold"�6+   $��0,10,0,0q�6=   �� 5      $��Phone Number:��6   $
��Bold"�61   $��0,10,0,0q�6C   �� 5!      $��Address:��6   $
��Bold"�6,   $��0,10,0,0q�6>   5"      �� 5%      $��1��6   .+�5&      �� -   5         ��Name$ txtFullName��5&      $��0,0,0,10q�6/   �� 5'      -   5        $ 	txtGender��5'      $��0,0,0,10q�6-   �� 5(      -   5        $ txtPhoneNumber��5(      $��0,0,0,10q�62   �� 5)      -   5        $ 
txtAddress��5)      $��0,0,0,10q�6.   5*      5+      �� 5.   
   $��1��6   $��Right=�6"   $��Bottom=�6>   $��	0,0,20,20q�6Y   $ 
Horizontal=�6l   .+�5/      �� -   5        $��	btnUpdate��5/      $��Update��6&   $	��150��67   $��0,0,10,0q�6C   $��38��6U   6a   �� 50      -   5        $��	btnCancel��50      $��Cancel��6&   $	��100��67   
���  ��6T   51      53      54      