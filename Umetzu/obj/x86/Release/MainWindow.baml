   M S B A M L   `   `   `  ���� A  =Umetzu, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:UmetzuUmetzu      Umetzu.MainWindow   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     a ]Telerik.Windows.Data, Version=2011.2.725.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7e aTelerik.Windows.Controls, Version=2011.2.725.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7n jTelerik.Windows.Controls.GridView, Version=2011.2.725.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7k gTelerik.Windows.Controls.Input, Version=2011.2.725.40, Culture=neutral, PublicKeyToken=5803cfa389c90ce7Etelerik1http://schemas.telerik.com/2008/xaml/presentation     &localclr-namespace:Umetzu     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     � Title$  Umetzu��$	��350��$	��850�� � WindowStartupLocation$ CenterScreen=� � 	Resources    Flat �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value   Umetzu.Personas  PersonasDataSource  DataTemplateMensaje	 �� TextWrapping
 �� AcceptsReturn" �� VerticalScrollBarVisibility �� Mode �� UpdateSourceTrigger  DataTemplateCCPais  DataTemplateNivel �� SelectedIndex��%�  &	        &	 �     &	     &	 q    &	 �    �� " ��.���  � ��$ 0,0,5,0q���  � �� Z� ��  � �� Z� ��  � ��
 ����� P�  �@J�IsMouseOver . . ���  � ��$
 Bold"���  � ��
 �   �P�  �@J�	IsFocused . . ���  � ��$
 Bold"�  �� .R��� $��30��$��9(�$
	 Wrap=�
 . $ Visible=����� *	Mensaje+$ TwoWay=�$ 	LostFocus=��� .R��� ���� *CCPais+$ TwoWay=�$ 	LostFocus=��� .R���  �� *Nivel+$ TwoWay=�$ 	LostFocus=�.@��� $
��None���� $��Debit���� $��EntroPay���� $��Standard���� $
��Gold���� $��Platinum���� $��	Signature���� $��Business���� $��
Purchasing���� $��Infinite��.��� .+�*  $Telerik.Windows.Controls.RadGridView  -     Name$ radGridView1��$��Stretch=�$��Stretch=�;  5Telerik.Windows.Controls.GridView.GridViewDataControl   AutoGenerateColumns .     RowDetailsVisibilityMode$ VisibleWhenSelected=�   RowIndicatorVisibility$ 	Collapsed=�   
IsReadOnly . +  %Telerik.Windows.Controls.StyleManager   Theme-  'Telerik.Windows.Controls.ThemeConverter$ Expression_Dark *  $Telerik.Windows.Controls.DataControl   ItemsSource ��  �� Source# [ !   Umetzu.CustomFilterBehavior   TextBox ��  �� ElementName$ textBoxFilterValue��   Columns 1  +Telerik.Windows.Controls.GridViewDataColumn  -	  'Telerik.Windows.Controls.GridViewColumn 	  
UniqueName$ id��6
  0Telerik.Windows.Controls.GridViewBoundColumnBase 
  Header$ id�� 	  Width?  9Telerik.Windows.Controls.GridView.GridViewLengthConverter$ 40  	  AggregateFunctions (  "Telerik.Windows.Data.CountFunction  ,  &Telerik.Windows.Data.AggregateFunction   Caption$ Count: ��  $
 name��$
 name��$	 110   $ Nivel�� 	  CellTemplate# �  $ Nivel��$	 110   $ country��$ country��$ 40   $ CCPais��# �  $ CCPais��$ 40   $ Mensaje��# �  $ Mensaje��$	 150   $
 card��$
 card��  $	 cvv��$	 cvv��$ 40   $ expire��$ expire��  $ amount��$ amount��$ 40   $ fecha��$ fecha��  $
 city��$
 city��  $ street��$ street��  $ cardtype��$ cardtype��  $ pCode��$ pCode��  $ email��$ email��  $ phone��$ phone��  $	 pin��$	 pin��  $ ip��$ ip��    RowDetailsTemplate  �� .R�� ! � RowDefinitions! �� $��* ��� $��* ��� $��24 ��� $��50 �.+��� " �� Orientation$" 
Horizontal=�$��
10,10,10,1q�$��0��.+��� -   #��[  # �� ContentStringFormat$# country: {0}������ *	country+�� -   #��[  $# 
pCode: {0}������ *pCode+�� -   #��[  $# 	city: {0}������ *city+�� -   #��[  $# street: {0}������ *street+�� -   #��[  $# 
email: {0}������ *email+�� -   #��[  $# 
phone: {0}������ *phone+�� $" 
Horizontal=�$��	10,1,10,1q�$��1��.+��� -	   #��[  $# 	name: {0}������ *name+�� -
   #��[  $# 	card: {0}������ *card+�� -   #��[  $# cvv: {0}������ *cvv+�� -   #��[  $# expire: {0}������ *expire+�� -   #��[  $# ip: {0}������ *ip+�� -   #��[  $# amount: {0}������ *amount+�� -   #��[  $# 
fecha: {0}������ *fecha+�� $" 
Horizontal=�$��	10,1,10,1q�$��2��.+��� -   #��[  $�� Verificar CC ��$	��Top=�$
��Left=�$��22���� -   #��[  $�� Verificar IP ��$	��Top=�$
��Left=�$��22���� $" 
Horizontal=�$��
13,1,10,10q�$��3��.+��� $	��400������ *	Mensaje+�� -   $ ��Name$$ textBoxFilterValue��$��Right=�$��	0,4,255,0q�$	��Top=�$��75���� -   % ��Name$% button2��$��Get DB��$��23��$��Right=�$��0,4,12,0q�$	��Top=�$��75���� -   $% button3��$��Migrate��$��23��$��Right=�$��0,4,93,0q�$	��Top=�$��75���� -   $��button1��$��Export��$��23��$��	0,4,174,0q�$	��Top=�$��Right=�$��75��