   M S B A M L   `   `   `  ����  MasterRecon$    MasterRecon.Forms.Registration   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          N� Title$  Registration��5      .��5	      �  � RowDefinitions 5
   
   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*   �� 5      $��40 �6   6*    � ColumnDefinitions 5   
   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   �� 5      $��2* �6   6,   .+�5   
   �� $��0��6   $��0��6   $��Center=�6-   .��6H   Activation Key6X   �� 5   
   -   5         ��Name$ txtActivationKey��5   _   $��0��6   $��2��6   $��1��60   $��3��6@   $��5q�6T   6{   �� 5   
   -   5         ��Name$ btnValidate��5      $��2��6&   $��4��63   $	��150��6G   $��Validate Key��6S   $	��0,5q�6j   6�   �� 5    
   $��3��6   $��4��6!   67   �� 5!   
   -   5         ��Name$ lblFullName��5!   8   $��4��6   $��Center=�6   $y�	Collapsed=�6M   .��6d   	Full Name6o   �� 5"   
   -   5        $ txtFullName��5"      $y�	Collapsed=�6'   $��Center=�6>   6[   �� 5#   
   -   5        $ lblMobileName��5#   -   $��4��6   $��2��6   $��Center=�6D   $y�	Collapsed=�6_   .��6v   	Mobile No6�   �� 5$   
   -   5        $ txtMobileNo��5$      $y�	Collapsed=�6'   $��Center=�6>   6[   �� 5%   
   -   5        $ 
lblEmailID��5%   -   $��5��6   $��0��6   $��Center=�6A   $y�	Collapsed=�6\   .��6s   
Email-ID6}   �� 5&   
   -	   5        $ 
txtEmailID��5&   /   $��5��6   $��1��6   $��Center=�6C   $y�	Collapsed=�6^   6w   �� 5'   
   -
   5        $ lblValidityDate��5'   -   $��5��6   $��2��6   $��Center=�6F   $y�	Collapsed=�6a   .��6x   
Valid Upto6�   (  "System.Windows.Controls.DatePicker  5(   
   -   5          Name$ txtValidUpto��5(   2   $��5��6   $��3��6"   $��5q�6H   $y�	Collapsed=�6S   6l   �� 5)   
   -   5        $ btnActivate��5)      $��6��6&   $��4��63   $	��150��6G   $��Activate��6S   $	��0,5q�6f   $y�	Collapsed=�6�   6�   5*      5+      