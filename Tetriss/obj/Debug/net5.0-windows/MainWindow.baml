   M S B A M L   `   `   `  ����A  =Tetris, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:TetrissTetriss  5   	       Tetriss.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Tetriss     5   	   -   5          � Title$  Tetris��5   	   $	��600��6   $	��800��6%   $	��600��5	   	   $	��600��6   
�������$��=Segoe UI Light)�5   	   $��28(�6&   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6    � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $
��auto �6'   �� 5      $��* �6'   ��5      �� 5       �� ImageSource$ Assets/Background.png��6   .+�5   
   (� $��1��5      $��1��5      $��0,0,0,20q�5       .��5!   
   �� -   5         ��Name$ 
GameCanvas��5!      ���#101010$	��250��5#      $	��510��5$      $
}�true��5%      5&      5(      �� 5)   
   -   5         ��Name$ 	ScoreText��5)      $��0��5*      $��1��5+      $��Score:��5,      $��0, 10q�5-       �� TextAlignment$ Center=�5.      �� 5/   
   $��1��6   $��0��50      $��Center=�51      $��Right=�52      .+�53      �� -   5        $ HoldText��54      $
��Hold��55      $ Center=�56       �� 57      -   5         ��Name$ 	HoldImage��57      $��20q�58      $	��125��59      5:      �� 5;   
   $��1��6   $��2��5<      $��Center=�5=      $
��Left=�5>      .+�5?      �� $
��Next��6   $ Center=�5@       �� 5A      -   5        $ 	NextImage��5A      $��20q�5B      $	��125��5C      5D      � 5F   
   -   5         �Name$ GameOverMenu��5F      ���	#CC000000$��2��5H      $��3��5I      $y�Hidden=�5J      .+�5K      �� $��Center=�6   $��Center=�5L      .+�5N      �� $��	Game Over��6   $��48(�5O      $ Center=�5P      �� 5Q      -   5        $ FinalScoreText��5Q      $��Score:��5R      $��36(�5S      $ Center=�5T      �� 5U      -	   5        $��
Play Again��5U      
������$��0,20,0,0q�5W      $��5q�5X      5Y   4   5[      5]      5_      5`      