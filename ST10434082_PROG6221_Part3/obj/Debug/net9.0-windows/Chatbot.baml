   M S B A M L   `   `   `  ����T  PST10434082_PROG6221_Part3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ST10434082_PROG6221_Part3ST10434082_PROG6221_Part3  5   	   '    !ST10434082_PROG6221_Part3.Chatbot   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:ST10434082_PROG6221_Part3     5   	     � Title$  Chatbot��5   	   $	��600��6   $
��1050��6&    � WindowStartupLocation$ CenterScreen=�63   .��5	      � ��5
   
   �� 5       �� ImageSource$ 
/chatb.jpg��6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ ChatbotListView��5      $��0��5      $��Consolas)�5      $��14(�5      $��41,10,41,153q�6   ��5      �� 5      .R�5      �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve5      $
��Wrap=�5      $��Consolas)�5      $��14(�5      $��0 0 0 10q�5      ��5       �� *	Message+5      5      5!      �� 5#   
   -   5         ��Name$ txtb_Chatbot��5#      $��96,401,0,142q�5$      $
��Left=�6$   $	��866��6?   �� 5%   
   -   5         ��Name$ 
sendButton��5%      $
��Send��6%   $
��Left=�64   $��371,491,0,0q�6O   $	��Top=�6d   $��45��6|   $	��269��6�   $��25(�6�   ���	#FF38EB28$��Impact)�6�   5'      5(      