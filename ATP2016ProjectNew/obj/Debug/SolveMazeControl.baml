   M S B A M L   `   `   `  ����L  HATP2016ProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ATP2016ProjectNewATP2016ProjectNew  5      (    "ATP2016ProjectNew.SolveMazeControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ATP2016ProjectNew     5      .��5	      �   � ColumnDefinitions  5
      �� 5      $��1* �6#   60   �� 5      $��1* �6#   60    � RowDefinitions 5      �� 5      $��1* �6    6/   �� 5      $��1* �6    6/   �� 5      $��1* �6    6/   �� 5      $��1* �6   6+   .+�5   
   �� 
��� ���$��1��6(   $��Center=�6<   $��Center=�6W   $��0��6t   
Fill In:6�   �� 5   
   
��� ���$��Center=�6(   $��Center=�6C   $��1��6`   Choose Maze:6{   �� 5   
   -   5        $��NameTextBox��5      $��Center=�6%   $��1��6@   $��1��6P   ��6]   ��  �� Path$ Value� �� ElementName$ NameTextBox��6�   �� 5   
   
��� ���$��Center=�6(   $��Center=�6C   $��2��6`   Choose Algorithm:6�   �� 5   
   -   5        $��
algTextBox��5      $��Center=�6$   $��1��6?   $��2��6O   ��6\   �� $ Value�$ 
algTextBox��6�   �� 5   
   -   5        $��Ok��5   j   $��Center=�6   $��Center=�6,   $��2��6I   $��3��6]   .��6t   Solve6{   5      5       