   M S B A M L   `   `   `  ����L  HATP2016ProjectNew, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:ATP2016ProjectNew.View.WindowsATP2016ProjectNew.View.Windows  5   	   +    %ATP2016ProjectNew.View.Windows.Help_w   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:ATP2016ProjectNew.View.Windows     5   	     � Title$
  Help��5   	   $	��400��6   $	��300��6#   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��0.1* �6   6.   �� 5      $
��0.5* �6   6.   �� 5      $��1* �6   6,   �� 5      $
��0.1* �6   6.    � RowDefinitions 5   
   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $��1* �6   6+   �� 5      $
��0.5* �6   6-   �� 5      $��1* �6   6+   �� 5      $
��0.5* �6   6-   .+�5   
   � -   5        $
��Wall��5      $��1��6   $��1��6+   $��	20,5,20,5q�68   6M   � 5    
   -   5        $��Grass��5       $��1��6   $��2��6-   $��	20,5,20,5q�6:   6O   � 5!   
   -   5        $��Start��5!      $��1��6   $��3��6-   $��	20,5,20,5q�6:   6O   � 5"   
   -   5        $
��Goal��5"      $��1��6   $��4��6,   $��	20,5,20,5q�69   6N   � 5#   
   -   5        $��Steps��5#      $��1��6   $��5��6-   $��	20,5,20,5q�6:   6O   � 5$   
   -   5        $��Jumper��5$      $��1��6   $��6��6.   $��	20,5,20,5q�6;   6P   �� 5&   
   $��4��6   $��Center=�6(    �� TextAlignment$ Center=�6C   
����·��� 6q   .�6v   Information about The Maze6�   6�   �� 5'   
   $��10(�6   $��2��6"   $��1��63   $��Center=�6@   $ Center=�6[   	- Wall.�� 6{   6�   You cant move on it.5)      �� 5*   
   $��10(�6   $��2��6"   $��2��63   $��Center=�6@   $ Center=�6[   
- Grass.�� 6|   6�   You can move on it.5,      �� 5-   
   $��10(�6   $��2��6"   $��3��63   $��Center=�6@   $ Center=�6[   - Start Point.�� 6�   6�   You start from here.5/      �� 50   
   $��10(�6   $��2��6"   $��4��63   $��Center=�6@   $ Center=�6[   - Goal Point.�� 6�   6�   You need to go here.�� 51   "   6.   Here you finish the maze!53      �� 54   
   $��10(�6   $��2��6"   $��5��63   $��Center=�6@   $ Center=�6[   
- Steps.�� 6|   6�    Show the solution of the Maze.56      �� 57   
   $��10(�6   $��2��6"   $��6��63   $��Center=�6@   $ Center=�6[   - Jumper (Move up/down)�� 6�   6�   " You can move between the layers.�� 58   ,   68   !using controls: PageUp/PageDown5;      �� 5<   
   $��10(�6   $��1��6$   $��2��64   $��8��6I   $��Center=�6V   $ Center=�6q   �� 5=      .�6   .�6!   Pay attention! .�� 6-    if you leave the game with the�� 5>   ,   68   '%(X) button all the data will be lost!5@      5A      5C      5D      