   M S B A M L   `   `   `  ����  ProjectPRN212+    %ProjectPRN212.GUI.Page_Admin.EditUser   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  	Edit User��5   	   $	��600��6   $	��400��6(    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $��* �6   �� 5
      $
��Auto �6   .+�5   
   �� $��	Edit User��6   $��24(�6%   $
��Bold"�63   $��Center=�6E   $
��0,10q�6b   �� 5   
   $��1��6   $��0,20,0,0q�6"   .+�5      �� $��
User Name:��6   �� 5      $��0,5,0,15q�60   ��6   �� *
UserName+60   �� 5      $��Email:��6   �� 5      $��0,5,0,15q�6-   ��6   �� *Email+6-   �� 5      $��Phone:��6   �� 5      $��0,5,0,15q�6-   ��6   �� *Phone+6-   �� 5      $��Address:��6   �� 5      $��0,5,0,15q�6/   ��6   �� *	Address+6/   �� 5      $��Date of Birth:��6   �� 5      $��0,5,0,15q�6T   ��6   �� *DateOfBirth+ �� StringFormat$ {0:yyyy-MM-dd}��6T   �� 5      $��Status:��6   �� 5       $��0,5,0,15q�68    �� SelectedValue 6   �� *Status+.@�5!      �� $��0 (Inactive)��6   
 � Tag$ 0��66   �� 5"      $��
1 (Active)��6   $ 1��64   5#      �� 5%      $��Role ID:��6   �� 5&      -   5         ��Name$ RoleIdTextBox��5&      $��0,5,0,15q�6E   ��6-   �� *RoleId+6E   5'      �� 5)   
   $��2��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   $��0,20,0,0q�6W   .+�5*      �� -   5        $
��Save��5*      $��80��6$   $��0,0,10,0q�6/   6A   �� 5+      -   5        $��Cancel��5+      $��80��6&   61   5,      5-      5.      