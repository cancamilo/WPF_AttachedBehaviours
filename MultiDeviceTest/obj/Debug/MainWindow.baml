   M S B A M L   `   `   `  ����J  FMultiDeviceTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MultiDeviceTestMultiDeviceTest  5   	        MultiDeviceTest.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:MultiDeviceTest     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)   .��5
      ]� ��.  � DataContext 6   �� *MainViewModel+   Locator �� Source# [  .+�5   
   �� $	��Top=�6   $	��200��6N   $
��Left=�6]   $��0,0,0,10q�6x   ��6'   �� *LoadDevicesCommand+.��6�   Load Devices5      �� 5   
   $	��Top=�6   $	��200��6O   $
��Left=�6^   $��0,0,0,10q�6y   ��6'   �� *StartDevicesCommand+��5      �� 5       �� 
TargetType" ��6    �� Triggers 5      �� 5       �� Binding 6&   �� *	IsRunning+ �� Value True6D   .a�5      ��  �� Property � {� �� Value .  6:   5      �� 5       6&   �� *	IsRunning+	 False6D   .a�5      ��  � {� . 6:   5      5      .��5      Start Devices5      �� 5   
   $	��Top=�6   $	��200��6M   $
��Left=�6\   $��0,0,0,10q�6w   ��6&   �� *StopDevicesCommand+��5      �� 5      " ��6    5       �� 5!       6&   �� *	IsRunning+ True6D   .a�5"      ��  � {� . 6:   5#      �� 5$       6&   �� *	IsRunning+	 False6D   .a�5%      ��  � {� .  6:   5&      5(      .��5)      Stop Devices5+      �� 5,   
   $	��Top=�6   $��Stretch=�6K   
���   �$��1q�6}   $��0,0,0,10q�6�   ��6(   �� *
DeviceList+��5-      �� 5.      .R�5/      ]� $	��400��6    $��Stretch=�6/   $��Stretch=�6K   .+�50      �� $
��Left=�6$   $��0,0,10,0q�6T   ��6:   �� *
DeviceID+6T   �� 51      $��Right=�6$   	 �� TextAlignment$	 Right=�6W   ��6;   �� *
PowerValue+6W   52      53      55      ]� 56   
   $	��Top=�6   .+�57      �� -   5        
 ��Name$
 settignsDock��57      .+�58      ��  �� Orientation$ 
Horizontal=�6   $��0,0,0,10q�66   .+�59      �� $��Device 1��6    $��0,0,15,0q�60   �� 5:      -   5         ��Name$ 
selection1��5:      $��70��63   $��0,0,15,0q�6A   ��5;      �� *
DeviceList+ �� SelectedIndex 5<      �� *FirstSelection+��5=      �� 5>      .R�5?   "   �� ��6,   �� *SerialNumber+5@      5B      5C      �� 5D      $ 
Horizontal=�6   $��0,0,0,10q�66   .+�5E      �� $��Device 2��6    $��0,0,15,0q�60   �� 5F      -   5        $ 
selection2��5F      $��70��63   $��0,0,15,0q�6A   ��5G      �� *
DeviceList+ 5H      �� *SecondSelection+��5I      �� 5J      .R�5K   "   �� ��6,   �� *SerialNumber+5L      5N      5O      �� 5P      $ 
Horizontal=�6   .+�5Q      �� $��	Operation��6    $��0,0,15,0q�61   �� 5R      $��0,0,15,0q�6    61   �� *SelectedOperation+.@�5S      �� $	��Add��6$   �� 5T      $��	Substract��6$   �� 5U      $��Multiply��6$   5V      5W      �� 5X      $	��Top=�6   $��Result��61   $��25(�6?   $	 Center=�6M   $��Center=�6d   $��Center=�6�   �� 5Y      $	��Top=�6   $��20(�6R   $	 Center=�6`   $��Center=�6w   $��Center=�6�   ��61   �� *OperationResult+6�   5Z      �� 5[      $��10��6   $��2q�6#   
���   �6M   ]� 5\      -   5         ]�Name$ 
resultDock��5\      .+�5^      &    MultiDeviceTest.InfraPlotControl  $	��Top=�6)   5_      5`      5b      5c      