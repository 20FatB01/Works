   M S B A M L   `   `   `  ����@  <Works, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WorksWorks  5   	       Works.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Works     5   	     � Title$  Сервисы��5   	   $	��556��6   $��602.6��6&    � WindowStartupLocation$ CenterScreen=�64   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��134* �6   �� 5      $
��461* �6   .+�5   
   �� $��Center=�6   $	��100��6-   $��337,10,10,0q�6:   $	��Top=�6O   $	��114��6g   $��school_logo.png��6s   $��1��6�   �� 5   
   -   5         ��Name$ table��5      $��
0,115,10,0q�6&   $��2��6:   .��5      �� .+�5      &   System.Windows.Controls.DataGrid  -   5        $��
DGServises��5         AutoGenerateColumns .  $
��Left=�6I      
IsReadOnly .     CanUserAddRows .     Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5         CellTemplate 5      �� 5   "   .R�5   &   �� -   5        	 �� Orientation$	 
Horizontal=�5   1   .+�5   *   r� 
 r�Name$
 media��67   -   5        $��50��5   F   $��50��6Q   6]   �� 5   *   .+�5   .   �� -   5        5   8   �� 5   .   -   5        5   8   �� 5   .   -   5        5   8   �� 5   .   $
��BRed��65   -   5        $ ��Редактировать��5   A   6x   �� 5   .   $��
JoinButton��65   -	   5        $/��)Записать пользователя��5   G   6�   5   +   5   '   5    #   5"      5$      5%      5&      �� 5'   
   -
   5        $#��Добавить услугу��5'      $
��Left=�6+   $��	10,10,0,0q�6F   $	��Top=�6Y   $	��114��6q   $	��100��6}   6�   �� 5(   
   -   5         ��Name$ sortings��5(      $��Сортировки��6#   $
��Left=�68   $��
129,10,0,0q�6S   $	��Top=�6g   $	��114��6   $	��100��6�   $��2��6�   6�   �� 5)   
   -   5        $ filter��5)      $��Фильтрация��6!   $
��Left=�66   $��
114,10,0,0q�6Q   $	��Top=�6e   $	��114��6}   $	��100��6�   $��1��6�   6�   5*      5,      