   M S B A M L   `   `   `  ����A  =Umetzu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UmetzuUmetzu  5          Umetzu.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   a ]Telerik.Windows.Data, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2012.1.215.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation     5   	   &localclr-namespace:Umetzu     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  Umetzu��5	   	   $	��350��6   $	��850��6%    � WindowStartupLocation$ CenterScreen=�6H    � 	Resources 5
         Flat �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value   Umetzu.Personas  PersonasDataSource  DataTemplateMensaje	 �� TextWrapping
 �� AcceptsReturn" �� VerticalScrollBarVisibility �� Mode �� UpdateSourceTrigger  DataTemplateCCPais  DataTemplateNivel �� SelectedIndex��%�  &	        &	 �    &	 �    &	 n    &	 �    �� 5   
   " ��6   .�5      ��  � ��$ 0,0,5,0q�6/   �� 5       � �� 63   Z� �� 5       � �� 64   Z� �� 5       � ��
 �����63    5      P� 5       �@J�IsMouseOver . . �5      ��  � ��$
 Bold"�6;   �� 5       � ��
 �   �6;   5      P� 5       �@J�	IsFocused . . �5      ��  � ��$
 Bold"�6;   5      5        5   
   6   �� 5   
   .R�5      �� $��30��6[   $��9(�5       $
	 Wrap=�5!      
 . $ Visible=�6?   ��5      �� *	Mensaje+$ TwoWay=�$ 	LostFocus=�5!   ?   5"      �� 5#   
   .R�5$      �� ��6   �� *CCPais+$ TwoWay=�$ 	LostFocus=�5%      �� 5&   
   .R�5'      ��  6   �� *Nivel+$ TwoWay=�$ 	LostFocus=�.@�5(      �� $
��None��6   �� 5)      $��Debit��6   �� 5*      $��EntroPay��6   �� 5+      $��Standard��6   �� 5,      $
��Gold��6   �� 5-      $��Platinum��6   �� 5.      $��	Signature��6   �� 5/      $��Business��6   �� 50      $��
Purchasing��6   �� 51      $��Infinite��6   52      53      54      .��55      � .+�56      *  $Telerik.Windows.Controls.RadGridView  -   5          Name$ radGridView1��56   9   $��Stretch=�6   $��Stretch=�6O   ;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     RowDetailsVisibilityMode$ VisibleWhenSelected=�58         RowIndicatorVisibility$ 	Collapsed=�6M      
IsReadOnly . +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Expression_Dark 5:   O   *  $Telerik.Windows.Controls.DataControl   ItemsSource 57      ��  �� Source# [ !   Umetzu.CustomFilterBehavior   TextBox 59      ��  �� ElementName$ textBoxFilterValue��   Columns 5;      1  +Telerik.Windows.Controls.GridViewDataColumn  5<      -	  'Telerik.Windows.Controls.GridViewColumn 	  
UniqueName$ id��6-   6
  0Telerik.Windows.Controls.GridViewBoundColumnBase 
  Header$ id��6=    	  Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 40 6I    	  AggregateFunctions 5=      (  "Telerik.Windows.Data.CountFunction  5>      ,  &Telerik.Windows.Data.AggregateFunction   Caption$ Count: ��60   5@        5A      $
 name��6-   $
 name��6?   $	 110 6M     5B      $ Nivel��6-    	  CellTemplate# �  6@   $ Nivel��5C   -   $	 110 6<     5D      $ country��6-   $ country��6B   $ 40 6S     5E      $ CCPais��6-   # �  6A   $ CCPais��5F   -   $ 40 6=     5G      $ Mensaje��6-   # �  6B   $ Mensaje��5H   -   $	 150 6>     5I      $
 card��6-   $
 card��6?     5J      $	 cvv��6-   $	 cvv��6>   $ 40 6K     5K      $ expire��6-   $ expire��6A     5L      $ amount��6-   $ amount��6A   $ 40 6Q     5M      $ fecha��6-   $ fecha��6@     5N      $
 city��6-   $
 city��6?     5O      $ street��6-   $ street��6A     5P      $ cardtype��6-   $ cardtype��6C     5Q      $ pCode��6-   $ pCode��6@     5R      $ email��6-   $ email��6@     5S      $ phone��6-   $ phone��6@     5T      $	 pin��6-   $	 pin��6>     5U      $ ip��6-   $ ip��6=       RowDetailsTemplate  5W      �� 5X      .R�5Y      � ! � RowDefinitions! 5Z      �� 5[      $��* �6,   �� 5\      $��* �6,   �� 5]      $��24 �6,   �� 5^      $��50 �6,   .+�5`      �� " �� Orientation$" 
Horizontal=�6%   $��
10,10,10,1q�6>   $��0��6R   .+�5a      �� -   5        #��[  5a   %   # �� ContentStringFormat$# country: {0}��6`   ��6C   �� *	country+6�   �� 5b      -   5        #��[  5b   %   $# 
pCode: {0}��6^   ��6C   �� *pCode+6   �� 5c      -   5        #��[  5c   %   $# 	city: {0}��6]   ��6C   �� *city+6}   �� 5d      -   5        #��[  5d   %   $# street: {0}��6_   ��6C   �� *street+6�   �� 5e      -   5        #��[  5e   %   $# 
email: {0}��6^   ��6C   �� *email+6   �� 5f      -   5        #��[  5f   %   $# 
phone: {0}��6^   ��6C   �� *phone+6   5g      �� 5h      $" 
Horizontal=�6%   $��	10,1,10,1q�6>   $��1��6Q   .+�5i      �� -	   5        #��[  5i   %   $# 	name: {0}��6]   ��6C   �� *name+6}   �� 5j      -
   5        #��[  5j   %   $# 	card: {0}��6]   ��6C   �� *card+6}   �� 5k      -   5        #��[  5k   %   $# cvv: {0}��6\   ��6C   �� *cvv+6{   �� 5l      -   5        #��[  5l   %   $# expire: {0}��6_   ��6C   �� *expire+6�   �� 5m      -   5        #��[  5m   %   $# ip: {0}��6[   ��6C   �� *ip+6y   �� 5n      -   5        #��[  5n   %   $# amount: {0}��6_   ��6C   �� *amount+6�   �� 5o      -   5        #��[  5o   %   $# 
fecha: {0}��6^   ��6C   �� *fecha+6   5p      �� 5q      $" 
Horizontal=�6%   $��	10,1,10,1q�6>   $��2��6Q   .+�5r      �� -   5        #��[  5r   %   $�� Verificar CC ��6D   $	��Top=�6w   $
��Left=�6�   $��22��6�   �� 5s      -   5        #��[  5s   %   $�� Verificar IP ��6D   $	��Top=�6w   $
��Left=�6�   $��22��6�   5t      �� 5u      $" 
Horizontal=�6%   $��
13,1,10,10q�6>   $��3��6R   .+�5v      �� $	��400��6A   ��6(   �� *	Mensaje+6A   5w      5x      5y      5{      �� 5|   
   -   5        $ ��Name$$ textBoxFilterValue��5|      $��Right=�6.   $��	0,4,255,0q�6J   $	��Top=�6]   $��75��6u   �� 5}   
   -   5        % ��Name$% button2��5}   \   $��Get DB��6   $��23��6"   $��Right=�6.   $��0,4,12,0q�6J   $	��Top=�6m   $��75��6�   6�   �� 5~   
   -   5        $% button3��5~   ]   $��Migrate��6   $��23��6#   $��Right=�6/   $��0,4,93,0q�6K   $	��Top=�6n   $��75��6�   6�   �� 5   
   -   5        $��button1��5   A   $��Export��6   $��23��6"   $��	0,4,174,0q�6.   $	��Top=�6P   $��Right=�6h   $��75��6�   6�   5�      5�      