using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.VisualBasic;

namespace ST10434082_PROG6221_Part3
{
    /// <summary>
    /// Interaction logic for Chatbot.xaml
    /// </summary>

    
    public partial class Chatbot : Window
    {
        ObservableCollection<Output> Outputs = new ObservableCollection<Output>();

        public string userName;
        public Chatbot()
        {
            InitializeComponent();
            ChatbotListView.ItemsSource = Outputs;
            this.Loaded += Chatbot_Loaded;
            
        }

        private void Chatbot_Loaded(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Chatbot Loaded");
            userName = GetUserName();

            try
            {
                SoundPlayer welcome = new SoundPlayer("Welcome.wav");
                welcome.PlaySync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to play sound: " + ex.Message);
            }

            Outputs.Add(new Output { Message = Logo.showLogo() });
            Outputs.Add(new Output { Message = Logo.showWelcomeScreen(userName) });
            Outputs.Add(new Output { Message = $"Hi {userName}, ask me anything cybersecurity related or you can type 'exit'.\n" +
                $"Try questions like 'What is your purpose' or 'What can I ask you about'" });
        }


        private string GetUserName()
        {
            string name;
            var namePattern = @"^[a-zA-Z\s\-]+$";

            do
            {
                name = Interaction.InputBox("Please enter your name:", "User Name", "User").Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Name can't be empty.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    continue;
                }

                if (!System.Text.RegularExpressions.Regex.IsMatch(name, namePattern))
                {
                    MessageBox.Show("Name can't contain numbers or special characters.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    continue;
                }

                break;

            } while (true);

            return name;
        }

        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            string input = txtb_Chatbot.Text.Trim();
            if (string.IsNullOrEmpty(input)) return;

            Outputs.Add(new Output { Message = ">" + input });
            txtb_Chatbot.Clear();

            string response = ChatbotResponse(input, userName);

            // Add response line-by-line
            foreach (var line in response.Split('\n'))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    Outputs.Add(new Output { Message = line.TrimEnd() });
            }

            // Optional: Auto-scroll to latest message
            ChatbotListView.ScrollIntoView(ChatbotListView.Items[ChatbotListView.Items.Count - 1]);
        }

        private string ChatbotResponse(string input, string name)
        {
            using (StringWriter writer = new StringWriter())
            {
                TextWriter originalOut = Console.Out;
                Console.SetOut(writer);

                Response.respond(input, name);

                Console.SetOut(originalOut); // Important: Reset Console output
                return writer.ToString();
            }
        }

    }
}
