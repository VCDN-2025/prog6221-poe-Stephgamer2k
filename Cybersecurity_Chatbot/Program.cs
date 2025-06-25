using System.Media;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Media;
using System.Text.RegularExpressions;

namespace Cybersecurity_Chatbot
{
    internal class Program
    {
        // Delegate to handle chatbot responses
        delegate void ChatbotResponse(string input, string name);

        
        // Memory store
        static string rememberedTopic = "";
        static string lastKeyword = "";

        static void Main(string[] args)
        {
            Response output = new Response();
            Logo.showLogo();
            SoundPlayer welcome = new SoundPlayer("Welcome.wav");
            welcome.PlaySync();



            string name = output.GetValidName();
            Logo.showWelcomeScreen(name);
            Console.WriteLine($"Hi there {name}, ask me anything cybersecurity related or you can type 'exit'.");
            Console.WriteLine("Try questions like 'What is your purpose' or 'What can I ask you about'.");
            Console.WriteLine();


            while (true)
            {
                
                Console.Write("> ");
                string input = Console.ReadLine()?.Trim();

                if (input == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Thank you {name}. I hope my responses were helpful, please come again if needed.");
                    Console.ResetColor();
                    Console.WriteLine();
                    break;
                }
                
                Response.respond(input, name);
                
            }
        }

      
    }
}

