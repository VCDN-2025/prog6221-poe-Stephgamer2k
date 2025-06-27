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
            task.ShowDialog();
        }

        private void btn_QuizGame_Click(object sender, RoutedEventArgs e)
        { 
            QuizGame quizgame = new QuizGame();
            quizgame.ShowDialog(); //Shows Chatbot Window

        }

        private void btn_LogWindow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}