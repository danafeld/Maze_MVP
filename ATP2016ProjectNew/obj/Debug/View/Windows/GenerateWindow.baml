   M S B A M L   `   `   `  ����L  HATP2016ProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ATP2016ProjectNewATP2016ProjectNew  5   	   &     ATP2016ProjectNew.GenerateWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ATP2016ProjectNew     5   	     � Title$  Generate The Maze��5   	   $	��350��6#   $	��380��60   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,    � RowDefinitions 5   
   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   .+�5   
   �� $��3��6   $��Center=�6(   $��Center=�6C   $��0��6`   Please fill the maze sizes:6�   �� 5   
   $��Center=�6   $��Center=�6/   $��1��6L   Name:6`   �� 5   
   -   5        $��NameTextBox��5      $��Center=�6%   $��	12,0,12,0q�6@   $��1��6S   $��1��6c   ��6p   ��  �� Path$ Value� �� ElementName$ NameTextBox��6�   �� 5   
   $��Center=�6   $��Center=�6/   $��2��6L   Width:6b   �� 5   
   -   5        $��WidthSlider��5       �� IsSnapToTickEnabled . $��2��6,   $��2��69   $��Center=�6I    � Minimum$ 1Q�6d    � Maximum$	 100Q�6q   $��5,15,5,16.6q�6�   �� 5    
   -   5        $��WidthTextBox��5       $��Center=�6'   $��	20,0,20,0q�6B   $��1��6U   $��2��6e   ��6r   �� $ Value�$ WidthSlider��6�   �� 5"   
   $��Center=�6   $��Center=�6/   $��3��6L   	Length:6b   �� 5#   
   -   5        $��LengthSlider��5#   �    . $��3��6,   $��2��69   $��1��6I   $��Center=�6]   $ 1Q�6x   $	 100Q�6�   $��5,16.4,5,17q�6�   6�   �� 5$   
   -   5        $��LengthTextBox��5$      $��Center=�6'   $��	20,0,20,0q�6B   $��1��6U   $��3��6e   ��6r   �� $ Value�$ LengthSlider��6�   �� 5&   
   $��Center=�6   $��Center=�6/   $��4��6L   Depth:6a   �� 5'   
   -   5        $��DepthSlider��5'       . $��4��6,   $��2��69   $��Center=�6I   $ 1Q�6d   $	 100Q�6q   $��5,15,5,16.6q�6�   6�   �� 5(   
   -   5        $��DepthTextBox��5(      $��Center=�6&   $��	20,0,20,0q�6B   $��1��6U   $��4��6e   ��6r   �� $ Value�$ DepthSlider��6�   �� 5)   
   -   5        $��generate3dmaze��5)   ~   $��Center=�6)   $��Center=�6D   $��1��6a   $��5��6q   .��6�   
Generate6�   �� 5*   
   -	   5        $��
btn_cancel��5*      $��5��6#   $��2��60   $��Center=�6@   $��Center=�6[   $��0q�6x   $��Cancel��6�   6�   5+      5,      