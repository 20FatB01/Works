   M S B A M L   `   `   `  ����@  <Works, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WorksWorks  5   	       Works.Sortings   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Works     5   	     � Title$2  ,Сортировка по стоимости��5   	   $	��556��6)   $��602.6��66    � WindowStartupLocation$ CenterScreen=�6D   .��5	      �  � ColumnDefinitions 5
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
 media��67   -   5        $��50��5   F   $��50��6Q   6]   �� 5   *   .+�5   .   �� -   5        5   8   �� 5   .   -   5        5   8   �� 5   .   -   5        5   8   5   +   5   '   5   #   5       5"      5#      5$      �� 5%   
   -   5         ��Name$ up��5%      $>��8Отсортировать 
по возрастанию��6   $
��Left=�6N   $��	10,10,0,0q�6i   $	��Top=�6|   $	��114��6�   $	��100��6�   6�   �� 5&   
   -	   5        $
 down��5&      $8��2Отсортировать 
по убыванию��6   $
��Left=�6M   $��
129,10,0,0q�6h   $	��Top=�6|   $	��114��6�   $	��100��6�   $��2��6�   6�   �� 5'   
   -
   5        $ search��5'      $$��Вернуться в меню��6!   $
��Left=�6<   $��
114,10,0,0q�6W   $	��Top=�6k   $	��114��6�   $	��100��6�   $��1��6�   6�   5(      5)      