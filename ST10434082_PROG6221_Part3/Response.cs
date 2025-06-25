using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ST10434082_PROG6221_Part3
{
    internal class Response
    {
        public static Dictionary<string, string> responses = new Dictionary<string, string>
            {
                {"What is your purpose","My purpose is to assist you with any cybersecurity problems or queries." },
                {"What can I ask you about","You can ask me about password strength, updating software, malware, phsing,\n" +
                    " cyberbullying or if you are being cyberbullied, ransomware, hacking or if you are getting hacked and scamming or if you are getting scammed. " +
                    "You can ask me tips on phishing, malware, getting hacked, ransomware and cyberbullying" },
                {"phishing","Phishing is a cyber attack where an attacker tricks you into revealing your personal information by pretending to  be  someone trustworthy." },
                {"password","To have strong password use a mix of uppercase, lowercase, numbers and special characters. Try avoid using common words and use at least 10 to 12 characters." },
                {"website","Look for 'https://' in the URL and a padlock icon in the address bar." },
                {"update","As soon as updates are available you should update your devices or software. Updates contain security patches to protect you from new threats."},
                {"malware","Malware is a malicious software designed to damage, disrupt, or gain unauthorized access to a computer system. Make sure you have an antivirus software installed and updated regularly." },
                {"ransomware","Ransomware is a type of malware that locks your files and demands a payment to unlock them. To avoid being a victim to this don't open attachments or links form untrusted sources and regulary back up impotant data to offline or cloud storage." },
                {"cyberbullying","Cyberbullying is when someone uses digital platforms like social media, texts, or emails to harass, threaten, or humiliate others." },
                {"cyberbullied","If you or your friend is being cyberbullied, don't respond. Save the evidence, block the bully, and report it to the platform and a trusted adult." },
                {"hacked","Being hacked is serious. Secure your accounts, notify affected contacts, and report the incident to the appropriate platforms or authorities." },
                {"hacking","Hacking is the act of gaining unauthorized access to a computer system or network to steal, change, or destroy information."},
                {"scamming", "Scamming is a form of fraud where someone tricks you into giving away money or sensitive information, usually through lies or deception."},
                {"scammed", "If you or your friend got scammed, report it to your bank, change your passwords, and file a report with cybercrime authorities or relevant platforms."},
                {"privacy", "Privacy is important. Review app permissions and use privacy settings on all social media platforms."}
            };

        public static Dictionary<string, List<string>> randomTips = new Dictionary<string, List<string>>
            {
                {
                    "phishing", new List<string>
                    {
                        "Be cautious of emails asking for personal information. Scammers often disguise themselves as trusted organisations.",
                        "Check for spelling errors and suspicious links in emails.",
                        "Never click on unknown links or download unexpected attachments.",
                        "Verify the sender’s identity before responding to any request.",
                        "Hover over links to see where they really go. If it looks odd or has misspellings, don’t click."
                    }
                },
                {
                    "malware",new List<string>
                    {
                        "Save copies of important files on an external drive or cloud storage in case of infection.",
                        "Avoid clicking on strange links or ads—especially if they look too good to be true.",
                        "Don't download files or apps from unknown websites or pop-ups.",
                        "Update your apps, antivirus, and operating system regularly to fix security holes.",
                        "Always use trusted antivirus software to detect and block harmful programs."
                    }
                },
                {
                    "hacked",new List<string>
                    {
                        "Don’t use the same password everywhere. Make them hard to guess and use a password manager if needed.",
                        "Use two-factor authentication. This adds a second layer of security (like a code sent to your phone) when logging in.",
                        "Don't share personal information publicly. Hackers can use public information to guess passwords or security questions.",
                        "Be wary of public Wi-Fi. Avoid connecting to illegitimate Wi-Fi networks."

                    }
                  },
                {
                    "ransomware",new List<string>
                    {
                        "Back up your files often so you don’t lose them if you're attacked.",
                        "Never open email attachments from people you don’t trust.",
                        "Keep your computer and apps updated to stay protected.",
                        "Use antivirus software and a firewall to stop threats early.",
                        "Don’t pay the ransom—it’s risky and often doesn’t work."
                    }
                },
                {
                    "cyberbullying",new List<string>
                    {
                        "Block and report bullies on the platform where it happens.",
                        "Take screenshots or save messages as proof if things get serious.",
                        "Tell someone you trust like a parent teacher or friend if you’re being bullied.",
                        "Don’t respond or retaliate as it can make things worse.",
                        "Adjust your privacy settings so only trusted people can contact or view your profile.",
                        "Stay calm and take a break from social media if it’s affecting your mood.",
                        "Support others who are bullied speak up or report it if you see it happening.",
                        "Use positive content and kindness to counter negativity online."
                    }
                }

            };



        // Sentiment-based responses
        public static Dictionary<string, string> sentimentResponses = new Dictionary<string, string>
            {
                {"worried", "It's completely understandable to feel that way. Let's go through some steps to make you feel more secure."},
                {"curious", "I'm glad you're curious! Let’s dive into that topic and explore some tips."},
                {"frustrated", "I know cybersecurity can feel overwhelming, but you're doing the right thing by asking questions."}
            };

        // Delegate to handle chatbot responses
        public delegate void ChatbotResponse(string input, string name);

        // Memory store
        static string rememberedTopic = "";
        static string lastKeyword = "";






        //General response intance
        public static ChatbotResponse respond = (input, userName) =>
        {
            string userinput = input.ToLower();
            bool responded = false;


            // Check if user is explicitly asking for tips
            string[] tipTriggers = { "tip", "tips", "any advice", "suggestion", "recommendation", "tell me more" };
            bool wantsTips = tipTriggers.Any(trigger => userinput.Contains(trigger));

            //Recall remembered topic
            if (userinput.Contains("remembered topic") && !string.IsNullOrEmpty(rememberedTopic))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"As someone interested in {rememberedTopic}, you might want to check your privacy settings.");
                Console.ResetColor();
                Console.WriteLine();

            }


            //Random tips (phishing, etc.)
            if (wantsTips)
            {
                foreach (var tipEntry in randomTips)
                {
                    if (!string.IsNullOrEmpty(tipEntry.Key) && userinput.Contains(tipEntry.Key.ToLower()))
                    {
                        var tips = tipEntry.Value;
                        if (tips.Count > 0)
                        {
                            Random rand = new Random();
                            int index = rand.Next(tips.Count);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine(tips[index]);
                            Console.ResetColor();
                            Console.WriteLine();
                            responded = true;
                            return;
                        }
                    }
                }
            }

            //Sentiment detection
            foreach (var sentiment in sentimentResponses)
            {


                if (userinput.Contains(sentiment.Key.ToLower()))
                {
                    if (userinput.Contains("worried"))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(sentiment.Value);
                        Console.ResetColor();
                        Console.WriteLine();
                        responded = true;
                        return;

                    }



                }
            }

            //Keyword-based static responses
            foreach (var keyword in responses.Keys)
            {
                if (userinput.Contains(keyword.ToLower()))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(responses[keyword]);
                    Console.ResetColor();
                    Console.WriteLine();
                    rememberedTopic = keyword;
                    lastKeyword = keyword;
                    responded = true;
                    return;
                }
            }


            //Random tips 
            if (wantsTips)
            {
                foreach (var tipEntry in randomTips)
                {
                    //Follow-up request for more
                    if (!responded && userinput.Contains("more") && !string.IsNullOrEmpty(lastKeyword))
                    {
                        if (randomTips.ContainsKey(lastKeyword))
                        {
                            var tips = tipEntry.Value;
                            if (tips.Count > 0)
                            {
                                Random rand = new Random();
                                int index = rand.Next(tips.Count);
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine(tips[index]);
                                //Console.WriteLine($"Let me give you more details about {lastKeyword}: {randomTips[lastKeyword]}");
                                Console.ResetColor();
                                Console.WriteLine();
                                responded = true;
                            }
                        }
                    }
                }
            }


            //Message if nothing matched
            if (!responded)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Sorry {userName}, I’m not sure I understand. Can you try rephrasing?");
                Console.ResetColor();
                Console.WriteLine();
            }

            //Message if user didn't enter anything
            if (userinput == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Sorry {userName}, Please ask me a question so I can help you.");
                Console.ResetColor();
                Console.WriteLine();
            }

        };



        // Validates and returns a user name
        public string GetValidName()
        {
            string name;
            var namePattern = @"^[a-zA-Z\s\-]+$";

            while (true)
            {
                Response output = new Response();
                Console.WriteLine("Please enter your name:");
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Name can't be empty.");
                    Console.ResetColor();
                    continue;
                }

                if (!Regex.IsMatch(name, namePattern))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Name can't contain numbers or special characters.");
                    Console.ResetColor();
                    continue;
                }

                return name;
            }
        }
    }
}
