   M S B A M L   `   `   `  ����T  PST10434082_PROG6221_Part3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ST10434082_PROG6221_Part3ST10434082_PROG6221_Part3  5   	   *    $ST10434082_PROG6221_Part3.TaskWindow   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ST10434082_PROG6221_Part3     5   	     � Title$  
TaskWindow��5   	   $	��600��6   $	��900��6)    � WindowStartupLocation$ CenterScreen=�65   .��5	      � ��5
   
   �� 5       �� ImageSource$ 
/chatb.jpg��6   .+�5   
   �� -   5         ��Name$ TaskListView��5      $��28,19,28,88q�6*    J� RenderTransformOrigin$ 
0.53,0.479&�6?    � 	Resources 5       �� 
TargetType �� Triggers �� Binding	 �� Value
 �� Property �� Value��%  '��       �� 5      " ��6    5      �� 5       6&   �� *IsCompleted+	 True6F   .a�5      �� 
 � ��
 ����6;   5      �� 5       6&   �� *IsCompleted+		 False6F   .a�5      �� 
 � �� �#FFDDDD6;   5      5      5      ��5      �� 5      .R�5      �� $��0 0 0 10q�6!   ���#EEE.+�5      �� $
��Bold"�6;   $��14(�6M   ��6$   �� *Title+6M   �� 5      $
��Wrap=�6A   $��0,2,0,0q�6U   ��6$   �� *Description+6U   �� 5       
���  ��$��0,2,0,0q�6s   ��6$   �� *
Reminder+ �� StringFormat$ Reminder: {0:G}��6s   �� 5!      $��	Completed��6#   $��0,5,0,0q�6Y    d� 	IsChecked 67   �� *IsCompleted+6Y   5%      5&      5(      �� 5)   
   -   5         ��Name$ DeleteTaskButton��5)      $��Delete Task��6+   $��388,501,388,0q�6B   $	��Top=�6Y   $��57��6q   $	��124��6}   $��19(�6�   ���	#FFFA1414$��Impact)�6�   
 � Tag 6�   �� 5*      5+      