   M S B A M L   `   `   `  ����?  ;WAVE, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:WAVEWAVE  5   	       WAVE.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:WAVE     5   	   -   5          �Name$  window��5   	    � Title$ 
MainWindow��5   	   $	��360��6   $	��360��6)    � 
ResizeMode$ NoResize=�6K    � WindowStartupLocation$ CenterScreen=�6b    � WindowStyle$
 None=�6�    � AllowsTransparency . $��Corbel)�6�   $��Center=�6�   $��Center=�6�   ��65   Z�  � 	Resources 5	         Logo �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame	 O� KeyTime
 O� Value  lblConectarMouseEnter8  2System.Windows.Media.Animation.EasingColorKeyFrame �� KeyTime �� Value R� KeyTime R� Value  lblConectarMouseLeave  lblCloseEnter  lblCloseLeave  lblRegistrarEnter  LblRegistrarLeave  LoadingLogo g� RepeatBehavior��%�	  &	        &	 �     &	     &	 l    &	 �    &	     &	 m    &	 �    �� 5
   
   .��5      U� $ (UIElement.Opacity)�6,   $ window��6\   .\�5        $	 0��6'   $
 0Q�63     5      $	 0:0:0.4��6'   $
 1Q�69   5      5      �� 5   
   .��5      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ lblConectar��6x   .g�5        $ 0��6&   $ 	#FF8D8D8D��62   5      T� 5      $ (FrameworkElement.Cursor)�6,   $ lblConectar��6b   ..�5      i� $ 0��6)    5      ��5      Hand��6'   5      5      5      �� 5   
   .��5      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ lblConectar��6x   .g�5        $ 0��6&   $ White��62   5       T� 5!      $ (FrameworkElement.Cursor)�6,   $ lblConectar��6b   ..�5"      i� $ 0��6)    5#      ��5$      	Arrow��6(   5&      5'      5(      �� 5)   
   .��5*      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ lblClose��6x   .g�5+        $ 0��6&   $ 	#FF8D8D8D��62   5,      T� 5-      $ (FrameworkElement.Cursor)�6,   $ lblClose��6b   ..�5.      i� $ 0��6)    5/      ��50      Hand��6'   52      53      54      �� 55   
   .��56      T� $ (FrameworkElement.Cursor)�6,   $ lblClose��6b   ..�57      i� $ 0��6)    58      ��59      	Arrow��6(   5;      5<      �� 5=      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ lblClose��6x   .g�5>        $ 0��6&   $ White��62   5?      5@      �� 5A   
   .��5B      T� $ (FrameworkElement.Cursor)�6,   $ lblRegistrar��6b   ..�5C      i� $ 0��6)    5D      ��5E      Hand��6'   5G      5H      �� 5I      $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ lblRegistrar��6x   .g�5J        $ 0��6&   $ 	#FF8D8D8D��62   5K      5L      �� 5M   
   .��5N      �� $6 0(TextElement.Foreground).(SolidColorBrush.Color)�6+   $ lblRegistrar��6x   .g�5O        $ 0��6&   $ White��62   5P      T� 5Q      $ (FrameworkElement.Cursor)�6,   $ lblRegistrar��6b   ..�5R      i� $ 0��6)    5S      ��5T      	Arrow��6(   5V      5W      5X      �� 5Y   
   $ Forever��6)   .��5Z      U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[2].(RotateTransform.Angle)�6,   $
 logo��6�   .\�5[        $	 0:0:3��6'   $	
 360Q�67   5\      5]      5_       � Triggers 5`      :� 5a   
    :� RoutedEvent$ FrameworkElement.Loaded��6   .[�5b      �� -   5         ��Name$ Logo_BeginStoryboard��5b      #��[  6<   5c      :� 5d   
   $ UIElement.MouseEnter��6    :� 
SourceName$ lblConectar��6:   .[�5e      �� -   5        $  ZoomClose_BeginStoryboard1��5e      #��[ 6B   5f      :� 5h   
   $ UIElement.MouseLeave��6   $ lblConectar��6:   .[�5i      �� -   5        $+ %lblConectarMouseLeave_BeginStoryboard��5i      #��[ 6M   5j      :� 5k   
   $ UIElement.MouseEnter��6   $ lblClose��6:   .[�5l      �� -   5        $# lblCloseEnter_BeginStoryboard��5l      #��[ 6E   5m      :� 5n   
   $ UIElement.MouseLeave��6   $ lblClose��6:   .[�5o      �� -   5        $# lblCloseLeave_BeginStoryboard��5o      #��[ 6E   5p      :� 5q   
   $ UIElement.MouseEnter��6   $ lblRegistrar��6:   .[�5r      �� -   5        $' !lblRegistrarEnter_BeginStoryboard��5r      #��[ 6I   5s      :� 5t   
   $ UIElement.MouseLeave��6   $ lblRegistrar��6:   .[�5u      �� -   5        $' !LblRegistrarLeave_BeginStoryboard��5u      #��[ 6I   5v      .��5y      �� -	   5         ��Name$ brdLogin��5y   Q   }�.  �� CornerRadius$ 	0,0,10,10��6!   ���	#FF151515
�������$��1q�6w   ._�5z   
   �� -
   5         ��Name$ 	cnvsLogin��5z      .+�5|      �� -   5        $ 	canvasTop��5|      $	��127��6(   $	��351��65   ���	#FF151515 �� Left$ 4��6X   .+�5}      F� -   5         F�Name$
 logo��5}      
������� J� RenderTransformOrigin$ 
0.47,0.535&�62   $	 154��6U   
 �� Top$ 50��6g   $��52.333��6w   $��52��6�   ]����u{��t�wʊ�*� �6<�R�e!@�g������g��נ�t�    �t�wʊ    ��t�t�u{��t	z�5~      V� 5      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      5�      �� 5�      -   5         ��Name$ lblClose��5�      $��x��6&   $	 340��62   
�������$��16(�6W   $ -4��6e   $��Corbel)�6u   $ 0.5,0.5&�6�    � ToolTip$ Fechar��6�   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      5�      5�      �� 5�      -   5        $ lblLogin��5�      $��LOGIN��6&   $	 149��66   $	 131��6H   ���	#FFADADAD$��Corbel)�6p   $��18.667(�6�   $��Center=�6�   $��Center=�6�   �� 5�      
���   �$	 168��6)   $��Center=�6:   $��Center=�6U   $	 120��6r   ._�5�      �� -   5         ��Name$ txtLogin��5�      $��18��6,   $	 163��68    �� TextWrapping$
 Wrap=�6J   $�� ��6^   $	 186��6f   $	��120��6w   $��0,0,0,1q�6�   $��Center=�6�   $��Center=�6�   
�������$ Email de Login Rocketz��6�   ��6�   Z� 6�   5�      �� 5�      -   5        $ lblSenha��5�      $��SENHA��6&   $	 146��66   $	 205��6H   ���	#FFADADAD$��Corbel)�6p   $��18.667(�6�   $��Center=�6�   $��Center=�6�   �� 5�      
���   �$	 244��6)   $��Center=�6:   $��Center=�6U   $	 120��6r   ._�5�      G� -   5         G�Name$ txtPass��5�      $��18��6/   $	 163��6;   $	 186��6M   $	��120��6^   $��0,0,0,1q�6�   $��Center=�6�   $��Center=�6�   
���������6j   Z� 6�   5�      �� 5�      -   5        $ cnvsButtonsLoginRegister��5�      $��37��67   $ 99��6C   $	 285��6T   $	��160��6e   .+�5�      �� -   5        $ lblRegistrar��5�      $��	REGISTRAR��6.   $ 8��6B   $ 6��6R   
�������$��Corbel)�6t   $ 0.477,0.591&�6�   �� 5�      -   5        $ lblConectar��5�      $��CONECTAR��6-   $ 82��6@   $ 6��6Q   
�������$��Corbel)�6s   $��Center=�6�   $ 0.477,0.591&�6�   �� 5�      -   5        $ lblDiv��5�      $��|��6(   $ 73��64   $ 3��6E   
�������$��Corbel)�6g   $ 0.531,0.416&�6{   $��13.333(�6�   5�      5�      5�      5�      