   M S B A M L   `   `   `  ���� J  FMultiDeviceTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:MultiDeviceTestMultiDeviceTest       MultiDeviceTest.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:MultiDeviceTest     -     � Title$  
MainWindow��$	��350��$	��525��.��]� ��.  � DataContext �� *MainViewModel+   Locator �� Source# [  .+��� $	��Top=�$	��200��$
��Left=�$��0,0,0,10q����� *LoadDevicesCommand+.��Load Devices�� $	��Top=�$	��200��$
��Left=�$��0,0,0,10q����� *StartDevicesCommand+.��Start Devices�� $	��Top=�$	��200��$
��Left=�$��0,0,0,10q����� *StopDevicesCommand+.��Stop Devices�� $	��Top=�$��Stretch=�
���   �$��1q�$��0,0,0,10q����� *
DeviceList+���� .R�]� $	��400��$��Stretch=�$��Stretch=�.+��� $
��Left=�$��0,0,10,0q����� *
DeviceID+�� $��Right=� �� TextAlignment$ Right=����� *
PowerValue+]� $	��Top=�.+��� -    ��Name$ settignsDock��.+���  �� Orientation$ 
Horizontal=�$��0,0,0,10q�.+��� $��Device 1��$��0,0,15,0q��� -    ��Name$ 
selection1��$��70��$��0,0,15,0q����� *
DeviceList+ �� SelectedIndex �� *FirstSelection+���� .R��� ���� *SerialNumber+�� $ 
Horizontal=�$��0,0,0,10q�.+��� $��Device 2��$��0,0,15,0q��� -   $ 
selection2��$��70��$��0,0,15,0q����� *
DeviceList+ �� *SecondSelection+���� .R��� ���� *SerialNumber+�� $ 
Horizontal=�.+��� $��	Operation��$��0,0,15,0q��� $��0,0,15,0q� �� *SelectedOperation+.@��� $	��Add���� $��	Substract���� $��Multiply���� $	��Top=�$��Result��$��25(�$ Center=�$��Center=�$��Center=��� $	��Top=�$��20(�$ Center=�$��Center=�$��Center=����� *OperationResult+�� $��10��$��2q�
���   �]� -    ]�Name$ 
resultDock��.+�!   MultiDeviceTest.PlotControl  $	��Top=�