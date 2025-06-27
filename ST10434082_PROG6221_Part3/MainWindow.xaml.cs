using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ST10434082_PROG6221_Part3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Chatbot_Click(object sender, RoutedEventArgs e)
        {
            Chatbot chatbot = new Chatbot();
            chatbot.ShowDialog(); //Shows Chatbot Window
        }

        private void btn_ViewTask_Click(object sender, RoutedEventArgs e)
        {
            TaskWindow task = new TaskWindow();
            task.ShowDialog(); //Shows Task Window
        }

        private void btn_QuizGame_Click(object sender, RoutedEventArgs e)
        { 
            QuizGame quizgame = new QuizGame();
            quizgame.ShowDialog(); //Shows Quiz Game Window

        }

        private void btn_LogWindow_Click(object sender, RoutedEventArgs e)
        {
            LogWindow log = new LogWindow();
            log.ShowDialog(); //Shows Log Window

        }
    }
}

/*****************************************
******************************************
*
*
* Title: 52,970 royalty-free wrong sound effect sound effects
*
* Author: pixaboy
*
* Date: 22 June 2025
*
* Availability: https://pixabay.com/sound-effects/search/wrong%20sound%20effect/
*
*
*****************************************
*****************************************/



/*****************************************
******************************************
*
*
* Title: Regular Expression Language - Quick Reference
*
* Author: Microsoft
*
* Date: 22 June 2025
*
* Availability: https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
*
*
*****************************************
*****************************************/

/*****************************************
******************************************
*
*
* Title: ObservableCollection<T> Class
*
* Author: Microsoft
*
* Date: 21 June 2025
*
* Availability: https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-9.0
*
*
*****************************************
*****************************************/



/*****************************************
******************************************
*
*
* Title: ListView Overview
*
* Author: Microsoft
*
* Date: 21 June 2025
*
* Availability: https://learn.microsoft.com/en-us/dotnet/desktop/wpf/controls/listview-overview
*
*
*****************************************
*****************************************/