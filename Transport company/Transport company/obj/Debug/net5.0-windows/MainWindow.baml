   M S B A M L   `   `   `  ����L  HTransport company, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Transport_companyTransport_company  5   	   "    Transport_company.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Transport_company     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��359* �6   6.   �� 5      $
��137* �6   6.   �� 5      $
��304* �6   6.   .+�5   
   �� -   5         ��Name$ AddAuto��5      $��Добавить авто��6"   $��0,10,0,0q�6:   $��20��6a   $	��Top=�6m   $��Center=�6�   $	��120��6�   $��1��6�   �� 5   
   -   5        $ AddTrace��5      $%��Добавить маршрут��6#   $��0,35,0,0q�6>   $��20��6g   $	��Top=�6s   $��Center=�6�   $	��120��6�   $��1��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��TableCompany��5         AutoGenerateColumns$
 True��6'   $��10,10,10,10q�6B      SelectionUnit$ FullRow=�6�      SelectionMode$ Single=�6�     5   
   -   5          Name$ 
TableTrace��5      $��10,10,10,10q�6'   $��2��6<   �� 5   
   -   5        $
��Save��5      $��Center=�6    $��21��6=   $��0,85,0,0q�6I   $	��Top=�6[   $	��120��6s   $��1��6   6�   �� 5   
   -   5        $
��Open��5      $��1��6    $��Center=�60   $��	0,111,0,0q�6M   $	��Top=�6`   $	��120��6x   6�   �� 5   
   -   5        $#��Удалить маршрут��5      $��1��6+   $��Center=�6;   $��0,60,0,0q�6X   $	��Top=�6j   $	��120��6�   6�   5      5      