using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;

namespace Cybersecurity_Chatbot
{
    class Logo
    {
        public static void showLogo()
        {
            /*
             * variable ascii will hold the format of the text: "Cybersecurity Awareness Bot"
             */
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.Yellow;//sets the console color to yellow
            string ascii = FiggleFonts.Big.Render("Cybersecurity Awareness Bot");
            Console.WriteLine(ascii);
            Console.ResetColor();//resets the  console color
        }

        public static void showWelcomeScreen(string name)
        {
            //Declared width for welcome screen
            const int boxWidth = 70;
            //Colors set for welcome screen
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Prints top border based on boxWidth
            Console.WriteLine("╔" + new string('═', boxWidth - 2) + "╗");

            string message = $"WELCOME {name.ToUpper()}";
            int padding = boxWidth - 2 - message.Length;
            int padLeft = padding / 2;
            int padRight = padding - padLeft;

            Console.WriteLine("║" + new string(' ', padLeft) + message + new string(' ', padRight) + "║");

            Console.WriteLine("╚" + new string('═', boxWidth - 2) + "╝");
            
            Console.ResetColor();

        }
    }
}
