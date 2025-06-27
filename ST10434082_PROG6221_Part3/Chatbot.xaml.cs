using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
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
            ActivityLogManager.AddLog("Chatbot session started.");

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

            HandleUserInput(input);
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

        //Gets the curernt state of the Chatbot
        private enum ChatBotState
        {
            Idle,
            AwaitingDescription,
            AwaitingReminder
        }

        private ChatBotState currentState = ChatBotState.Idle;
        private string newTitle = "";
        private string newDescription = "";

        private List<string> actionLog = new List<string>();
        private void HandleUserInput(string input)
        {
            
                input = input.ToLower().Trim();
            switch (currentState)
            {
                case ChatBotState.Idle:

                    // --- Check for Action Summary ---
                    if (Regex.IsMatch(input, @"(what.*done|show.*(tasks|reminders)|list.*(all|actions))"))
                    {
                        if (actionLog.Count == 0)
                        {
                            Outputs.Add(new Output { Message = "No actions have been recorded yet." });
                        }
                        else
                        {
                            Outputs.Add(new Output { Message = "Here’s a summary of recent actions:" });

                            foreach (var entry in ActivityLogManager.Log.Take(5))
                                Outputs.Add(new Output { Message = entry.Display });
                            ActivityLogManager.AddLog($"{userName} viewed the activity log.");
                        }
                        break;
                    }

                    // --- Check for Task/Reminder Intent ---
                    if (Regex.IsMatch(input, @"(add|create|remind|set).*(task|reminder|note|todo|something)", RegexOptions.IgnoreCase))
                    {
                        var titleMatch = Regex.Match(input, @"(?:to|for)\s+(.*)"); // e.g., "add a task to review logs"
                        newTitle = titleMatch.Success ? titleMatch.Groups[1].Value : "Untitled Task";

                        currentState = ChatBotState.AwaitingDescription;
                        Outputs.Add(new Output { Message = "Please enter a description for the task." });
                        ActivityLogManager.AddLog("NLP: Detected intent to create task titled '" + newTitle + "'.");
                    }
                    
                    else
                    {
                        string response = ChatbotResponse(input, userName);
                        Outputs.Add(new Output { Message = response });
                    }
                    break;

                case ChatBotState.AwaitingDescription:
                    newDescription = input;
                    currentState = ChatBotState.AwaitingReminder;
                    Outputs.Add(new Output { Message = "Would you like to set a reminder? (e.g. 'tomorrow', 'in 2 days', 'next week', or a date like '2025-07-01') or type 'no'" });
                    break;

                case ChatBotState.AwaitingReminder:
                    DateTime? reminder = ParseNaturalDate(input);

                    TaskItem newTask = new TaskItem
                    {
                        Title = newTitle,
                        Description = newDescription,
                        Reminder = reminder,
                        IsCompleted = false
                    };

                    TaskManager.AllTasks.Add(newTask);

                    // Log Action
                    string action = $"Task added: '{newTitle}'" + (reminder.HasValue ? $" with reminder on {reminder.Value:g}" : " (no reminder set)");
                    actionLog.Add(action);

                    Outputs.Add(new Output
                    {
                        Message = action
                    });

                    ActivityLogManager.AddLog(action);
                    // Reset
                    currentState = ChatBotState.Idle;
                    newTitle = "";
                    newDescription = "";
                    break;
            }

        }//End of HandleUserInput method


        private DateTime? ParseNaturalDate(string input)
        {
            input = input.ToLower().Trim();

            if (input == "no") return null;

            if (input.Contains("tomorrow")) return DateTime.Now.AddDays(1);
            if (input.Contains("next week")) return DateTime.Now.AddDays(7);
            if (input.Contains("in a week")) return DateTime.Now.AddDays(7);

            var inMatch = Regex.Match(input, @"in (\d+) (day|days|week|weeks|hour|hours)");
            if (inMatch.Success)
            {
                int value = int.Parse(inMatch.Groups[1].Value);
                string unit = inMatch.Groups[2].Value;
                if (unit.Contains("day")) return DateTime.Now.AddDays(value);
                if (unit.Contains("week")) return DateTime.Now.AddDays(value * 7);
                if (unit.Contains("hour")) return DateTime.Now.AddHours(value);
            }

            if (DateTime.TryParse(input, out DateTime parsedDate)) return parsedDate;

            return null;
        }


    }

    public static class TaskManager
    {
        public static ObservableCollection<TaskItem> AllTasks { get; } = new ObservableCollection<TaskItem>();
    }

    

}
