   M S B A M L   `   `   `  ����T  PST10434082_PROG6221_Part3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ST10434082_PROG6221_Part3ST10434082_PROG6221_Part3  5   	   (    "ST10434082_PROG6221_Part3.QuizGame   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ST10434082_PROG6221_Part3     5   	     � Title$  QuizGame��5   	   $	��700��6   $
��1000��6'    � WindowStartupLocation$ CenterScreen=�64   .��5	      � $��10q�6   ��5
   
   �� 5       �� ImageSource$ 
/chatb.jpg��6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ questionText��5      $
��Wrap=�6*   $��16(�6>   $��
36,0,36,40q�6L   
���   �$��2��6s   ���	#FFF7F5F56�   �� 5   
   -   5         ��Name$ answerInput��5      $��30��6'   $��36,26,36,447q�63   $��14(�6I   $��3��6W   �� 5   
   -   5         ��Name$ SubmitButton��5      $��Submit Answer��6'   $	��150��6Z   $��35��6f   $��3��6r   $��401,78,0,390q�6   $
��Left=�6�   ���	#FF4EF327$��Arial)�6�   $
��Bold"�6�   �� 5   
   -   5         ��Name$ quizHistory��5      $��3��6'   $��36,295,36,0q�64   $��14(�6I   5      5       