   M S B A M L   `   `   `  ����J  FWpfLightProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:WpfLightProject.ViewsWpfLightProject.Views  5   	   *    $WpfLightProject.Views.RegisterWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:WpfLightProject.Views     5   	     � Title$  Company Registration��5   	   $	��411��6&   $	��401��63    � WindowStyle$ 
ToolWindow=�6?   .��5	      � $��	0,0,0,104q�6    � ColumnDefinitions 5
   
   �� 5      $
��338* �6   �� 5      $	��63* �6   .+�5   
   ��  �� Orientation$ Vertical=�6   $��2��6,   $	��198��6@   $	��Top=�6M   .+�5      �� $
��Nome��6   �� 5      ��6   �� *Name+�� 5      $
��CNPJ��6   �� 5      ��6   �� *RegisterNumber+�� 5      $
��Ramo��6   �� 5      -   5        $��BusinessComboBox��5       �� Text 6/   �� *
Business+�� 5      $��	Endereço��6   �� 5      ��6   �� *	Address+�� 5      $��Tamanho��6   �� 5      -   5        $��CompanySizeComboBox��5       62   �� *CompanySize+�� 5      �� 5      $��Data de Abertura��6   62   (  "System.Windows.Controls.DatePicker  5         SelectedDate 6   �� *	BirthDate+� 5      $��25��6    5      �� 5      $��5* �6'   �� 5      $��5* �6'   5!      5"      �� 5#   
   -   5         ��Name$ OKButton��5#      $��0��5$      $��OK��5%      $��50,225,150,10q�5&       �� 	IsDefault$
 True��5'      5(      �� 5)   
   $��Cancelar��5*      $��220,225,40,0q�5+       �� IsCancel$
 True��5,      $��49��6)   $	��Top=�65   $��2��6M   5-      5.      