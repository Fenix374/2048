   M S B A M L   `   `   `  ����C  ?Game2048, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Game2048.View.PageGame2048.View.Page  5      7 clr-namespace:Game2048.ViewModelGame2048.ViewModel  5      7 clr-namespace:Game2048.ConverterGame2048.Converter  5      !    Game2048.View.Page.GamePage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:Game2048.View.Page     5      /vm clr-namespace:Game2048.ViewModel     5      0cnv clr-namespace:Game2048.Converter     5      $
|�True��5
        � DataContext  5      &    Game2048.ViewModel.GameViewModel  5   
    � 	Resources 5      @   :Game2048.Converter.IntArrayToObservableCollectionConverter +  'IntArrayToObservableCollectionConverter.   (Game2048.Converter.ValueToColorConverter  ValueToColorConverter  CellTemplate  CellBorderStyle �� 	Converter  CellLabelStyle �� TextAlignment  BoardTemplate �� Orientation��%o  &	        &	      &	 &     7  7  7  &	 �       5   
   66     5   
   6$   �� 5   
   .R�5      �� 8��  ��6>   �� 8  ._�5      �� 8�� $ Center=�6D   ��6[   �� 5      5      �� 5   
   .R�5      �� #���  63   ��6   �� ��5      �� 5      .R�5      �� $ 
Horizontal=�6%   5      5       5!      5"       J� InputBindings 5$      �� 5%   
   
 �� Key$
 Left��6    �� Command 6    �� *ShiftLeftCommand+�� 5&   
   $ Right��6    6!   �� *ShiftRightCommand+�� 5'   
   $
 Down��6    6    �� *ShiftDownCommand+�� 5(   
   $ Up��6    6   �� *ShiftUpCommand+.��5+      �  � RowDefinitions 5,   
   �� 5-      $��* �6   �� 5.      $
��Auto �6   �� 5/      $��* �6   	 � ColumnDefinitions	 52   
   �� 53      $��* �6    �� 54      $
��Auto �6    �� 55      $��* �6    .+�58   
   � $��1��6    59      �� 5:      $��* �6!   �� 5;      $
��Auto �6!   �� 5<      $��* �6!   	 5?      �� 5@      $	��.5* �6$   �� 5A      $	��.5* �6$   �� 5B      $��* �6$   �� 5C      $��* �6$   .+�5G      ��   SmallButtonStyle#��[ 6   $��1��6?   $��0��6L   ��5H      �� *NavigateToMenuPage+��5I      �� 
 �� RelativeSource
 ��  �� Mode$ FindAncestor=� �� AncestorType" N�.��5J      �� $$��../../Pictures/Images/home.jpg��6   5K      �� 5M      #��[ 6   $��1��6?   $��1��6L   ��5N      �� *ResetCommand+��5O      �� 5P       j� Stretch$ Uniform=�6!   .��5R      �� $&�� ../../Pictures/Images/arrows.jpg��6   5S      �� 5V        InfoTabStyle#��[ 6   $��1��6;   $��3��6H   ._�5W      ��   InfoTabLabelStyle#��[ 6   ��5X      �� *Score+ �� StringFormat$ 
Score: {0}��6I   5Y      5Z      �� 5[   
   $��1��6   $��1��6    	 BoardBorderStyle#��[	 6.   ._�5\      �� #���  6}   ��6   �� *Board+# [  6}   5]      5^      5_      