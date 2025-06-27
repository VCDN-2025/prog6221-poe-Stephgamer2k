using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Media;

namespace ST10434082_PROG6221_Part3
{
    /// <summary>
    /// Interaction logic for QuizGame.xaml
    /// </summary>
    /// Added Quiz game
    public partial class QuizGame : Window
    {
        
        
        //Dictionary: questions and answers
        Dictionary<string, string> questions = new Dictionary<string, string>
        {
            {"Antivirus software can protect against all types of cyber threats.True or False?","false" },
            {"Which of the following is the strongest password?\nA) 123456\nB) Password1\nC) mydogmax\nD) 9$Gp@#3xQl!","d" },
            {"What is the act of attempting to trick someone into revealing sensitive information, often via email?","phishing" },
            {"What does HTTPS in a URL indicate?\nA) A website uses Flash\nB) A secure connection\nC) A government website\nD) High-speed access","b" },
            {" It is safe to use the same password for all your accounts. Ture or False","false" },
            {"What is the term for software that locks your data and demands money to unlock it?","ransomeware" },
            {"Which of the following is NOT a good practice?\nA) Keeping software updated\nB) Clicking unknown email links\nC) Using two-factor authentication\nD) Backing up data regularly","b" },
            {"Public Wi-Fi networks can pose security risks. True or False","true" },
            {"What do you call an attempt to guess passwords by trying many combinations quickly?","brute-force" },
            {"Which of these is an example of multi-factor authentication?\nA) Just entering a password\nB) Answering a security question\nC) Password + SMS code\nD) Logging in from your home Wi-Fi","c" }


        };

        //Dictionary: questions and feedback
        Dictionary<string, string> feedback = new Dictionary<string, string>
        {
            {"Antivirus software can protect against all types of cyber threats.True or False?","Antivirus software is helpful, but it cannot protect against every threat, especially new or sophisticated ones like zero-day exploits, phishing, or insider attacks." },
            {"Which of the following is the strongest password?\nA) 123456\nB) Password1\nC) mydogmax\nD) 9$Gp@#3xQl!","A strong password should include a mix of uppercase, lowercase, numbers, and special characters. Simple or common words are easy to crack." },
            {"What is the act of attempting to trick someone into revealing sensitive information, often via email?","The correct answer is phishing. It’s one of the most common cyberattacks and often uses fake emails that look legitimate to steal data." },
            {"What does HTTPS in a URL indicate?\nA) A website uses Flash\nB) A secure connection\nC) A government website\nD) High-speed access","HTTPS stands for Hypertext Transfer Protocol Secure, which means the site encrypts data sent between your browser and the website." },
            {" It is safe to use the same password for all your accounts. Ture or False","Reusing passwords increases the risk. If one account is compromised, all other accounts using the same password become vulnerable." },
            {"What is the term for software that locks your data and demands money to unlock it?","That type of malicious software is called ransomware. It can encrypt your files and demand a ransom to restore access." },
            {"Which of the following is NOT a good practice?\nA) Keeping software updated\nB) Clicking unknown email links\nC) Using two-factor authentication\nD) Backing up data regularly","Clicking unknown links can lead to phishing sites or malware. Always verify email sources before clicking any link." },
            {"Public Wi-Fi networks can pose security risks. True or False","Public Wi-Fi is often unencrypted and can allow attackers to intercept your data. Always use a VPN when connecting to public networks." },
            {"What do you call an attempt to guess passwords by trying many combinations quickly?","This is known as a brute-force attack. Using long, complex passwords and account lockouts can help defend against it." },
            {"Which of these is an example of multi-factor authentication?\nA) Just entering a password\nB) Answering a security question\nC) Password + SMS code\nD) Logging in from your home Wi-Fi","Multi-factor authentication (MFA) requires two or more verification steps — like something you know (password) and something you have (SMS code or app)." }


        };

        //Correct sound player object
        SoundPlayer correct = new SoundPlayer("correct.wav");

        
        //Wrong sound player object
        SoundPlayer wrong = new SoundPlayer("wrong.wav");

        private IEnumerator<KeyValuePair<string, string>> questionEnumerator;

        private int score = 0;
        private string currentQuestion;

        public QuizGame()
        {
            InitializeComponent();
            questionEnumerator = questions.GetEnumerator();
            ShowNextQuestion();
        }

        public void ShowNextQuestion()
        {
            if (questionEnumerator.MoveNext())
            {
                currentQuestion = questionEnumerator.Current.Key;
                questionText.Text = currentQuestion;
                answerInput.Text = "";
                answerInput.Focus();
            }
            else
            {
                string log;
               log = questionText.Text = $"Quiz finished! Your score: {score}/{questions.Count}";
                ActivityLogManager.AddLog(log);
                answerInput.IsEnabled = false;
            }
        }

        private void SubmitAnswer_Click(object sender, RoutedEventArgs e)
        {
            quizQuestions();
        }
        public void quizQuestions()
        {
            string userAnswer = answerInput.Text.Trim().ToLower();
            string correctAnswer = questions[currentQuestion].ToLower();

            if (userAnswer == correctAnswer)
            {
                correct.Play();
                quizHistory.Items.Add($"✔ {currentQuestion}\nCorrect: {userAnswer}");
                score++;
            }
            else
            {
                wrong.Play();
                quizHistory.Items.Add($"✘ {currentQuestion}\nYour Answer: {userAnswer}\nCorrect Answer: {correctAnswer}");
            }

            // Add feedback
            if (feedback.TryGetValue(currentQuestion, out string fb))
            {
                quizHistory.Items.Add($"Feedback: {fb}\n");
            }

            Thread.Sleep(1500); // simulate pause between questions
            ShowNextQuestion();
        }
    }
}
