   M S B A M L   `   `   `  ����E  AChatClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ChatClient
ChatClient  5   	       ChatClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ChatClient     5   	     � Title$  
MainWindow��5   	   $	��470��6   $	��620��6)    � 	Resources 5
       �� 
TargetType �� Property �� Value��%_  '��       '�� }     '�� �     �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       �@��TextAlignment$ Center=�6.   5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 3q�6'   �� 5       �@��TextAlignment$ Center=�6.   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $	��350 �6   �� 5      $
��auto �6   .+�5   
   �� .+�5       A�  A� Columns$ 4��6   .+�5!      �� $��IP��6   �� 5"      $
��Port��6   �� 5#      $��Benutzername��6   5$      A� 5%      $ 4��6   .+�5&      �� ��6   �� *Ip+�� 5'      ��6   �� *SPort+�� 5(      ��6   �� *Nick+�� 5)      -   5        $��	Verbinden��5)      6-   5*      5+      �� 5.   
   $��1��6   ��6!   �� *Chat+� 5/   
   $��2��6    � ColumnDefinitions 50      �� 51      $��3* �6#   �� 52      .+�54      �� -   5         ��Name$ messageField��54      	 �� TextAlignment$
	 Left=�6,   $
��10 5q�6[   ��6A   �� *	Message+6[   �� 55      -   5        
 ��Name$
 
sendButton��55   %   $��1��6   $��Schicken��69   6L   56      57      58      