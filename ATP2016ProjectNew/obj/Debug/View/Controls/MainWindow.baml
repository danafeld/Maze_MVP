   M S B A M L   `   `   `  ����L  HATP2016ProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ATP2016ProjectNewATP2016ProjectNew  5   	   ?$clr-namespace:ATP2016ProjectNew.ViewATP2016ProjectNew.View  5   	   "    ATP2016ProjectNew.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ATP2016ProjectNew     5   	   9Controls$clr-namespace:ATP2016ProjectNew.View     5   	   -   5          � Title$  Project - Maze��5	   	   $	��480��6    $	��600��6-   .��5.      ]� .+�5/   
   �  � ColumnDefinitions 50      �� 51      $��1* �6#   60    � RowDefinitions 53      �� 54      $
��0.3* �6    61   �� 55      $��7* �6    6/   .+�58      �� |�.  .+�59      o� |�.  .@�5:      m� $
��File��6   |�.  .@�5;      m� -   5        $	��New��5;   B   |�.  $	��New��65   6M   m� 5<      -   5        $
��Save��5<   C   |�.  $
��Save��65   6O   m� 5=      -   5        $��loadmaze��5=   C   |�.  $
��Load��65   6S   5?      m� 5@      $��Options��6   |�.  .@�5A      m� -   5        $��
Properties��5A   I   $��
Properties��6#   |�.  6[   5B      m� 5C      -   5        $
��Exit��5C   ?   $
��Exit��6   |�.  6K   m� 5D      -   5        $
��Help��5D   ?   $
��Help��6   |�.  6K   m� 5E      -   5        $��About��5E   @   $��About��6   |�.  6M   5F      5G      ]� 5I      $��1��6   .+�5J      �  5K      �� 5L      $��1* �6'   64   �� 5M      $��4* �6'   64    5O      �� 5P      $��7* �6$   63   .+�5R      �� -	   5        $��Options��5R   0   |�.  ��5S      �� 5T       j� Stretch$
 Fill=�6)    j� 
AlignmentY$	 Top=�68    j� 
AlignmentX$ Center=�6I   .@�5W      �� -
   5        $��Center=�5W   '   
�������$��0,2,0,2q�6[   $��Display Maze��6l   
�������6�   �� 5Z      $��0,2,0,2q�6'   $��
Solve Maze��68   
�������
�������6{   �� 5[      $��0,2,0,2q�6'   $��Display Solution��68   
�������
�������6�   �� 5\      $��0,2,0,2q�6'   $
��Play��68   
�������
�������6u   5_      ]� 5`      -   5        $��Grid_generate��5`       $��0��65   $��1��6B   ��5a      �� 5b      $
 Fill=�6)   $	 Top=�68   $ Center=�6I   5e      5f      5g      5h      5i      5l      