   M S B A M L   `   `   `  ����L  HATP2016ProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ATP2016ProjectNewATP2016ProjectNew  5      *    $ATP2016ProjectNew.GenerateMaze3dMaze   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ATP2016ProjectNew     5      .��5	      �   � ColumnDefinitions  5
   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   .+�5   
   �� 
��� ���$��3��6(   $��Center=�6<   $��Stretch=�6W   $��0��6u   Please fill the maze sizes:6�   �� 5   
   
��� ���$��Center=�6(   $��Center=�6C   $��1��6`   Name:6t   �� 5   
   -   5        $��NameTextBox��5      $��Center=�6%   $��1��6@   $��1��6P   ��6]   ��  �� Path$ Value� �� ElementName$ NameTextBox��6�   �� 5   
   
��� ���$��Center=�6(   $��Center=�6C   $��2��6`   Width:6u   �� 5   
   -   5        $��WidthSlider��5   c   $��2��6   $��2��6   $��Center=�6.    � Minimum$ 0Q�6I    � Maximum$ 30Q�6V   $��0,15,0,16.6q�6v   �� 5    
   -   5        $��WidthTextBox��5       $��Center=�6'   $��1��6B   $��2��6R   ��6_   �� $ Value�$ WidthSlider��6�   �� 5"   
   
��� ���$��Center=�6(   $��Center=�6C   $��3��6`   	Length:6v   �� 5#   
   -   5        $��LengthSlider��5#   w   $��3��6   $��2��6   $��1��6.   $��Center=�6B   $ 0Q�6]   $ 30Q�6j   $��0,16.4,0,17q�6�   6�   �� 5$   
   -   5        $��LengthTextBox��5$      $��Center=�6'   $��1��6B   $��3��6R   ��6_   �� $ Value�$ LengthSlider��6�   �� 5&   
   
��� ���$��Center=�6(   $��Center=�6C   $��4��6`   Depth:6u   �� 5'   
   -   5        $��DepthSlider��5'   c   $��4��6   $��2��6   $��Center=�6.   $ 0Q�6I   $ 30Q�6V   $��0,15,0,16.6q�6v   6�   �� 5(   
   -   5        $��DepthTextBox��5(      $��Center=�6&   $��1��6A   $��4��6Q   ��6^   �� $ Value�$ DepthSlider��6�   �� 5*   
   -   5        $��Ok��5*   f   $��Center=�6   $��Center=�6,   $��1��6I   $��5��6Y   .��6p   
Generate6z   5+      5,      