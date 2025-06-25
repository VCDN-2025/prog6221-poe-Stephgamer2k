using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figgle;
using Figgle.Fonts;

namespace ST10434082_PROG6221_Part3
{
    internal class Logo
    {
        public static string showLogo()
        {
            /*
             * variable ascii will hold the format of the text: "Cybersecurity Awareness Bot"
             */
           
             string ascii = FiggleFonts.CyberMedium.Render("Cybersecurity Awareness Bot");
            return ascii;
            
        }

        public static string showWelcomeScreen(string name)
        {
            //Declared width for welcome screen
            const int boxWidth = 70;
            ////Colors set for welcome screen
            //Console.BackgroundColor = ConsoleColor.DarkBlue;
            //Console.ForegroundColor = ConsoleColor.Yellow;

            ////Prints top border based on boxWidth
            //Console.WriteLine("╔" + new string('═', boxWidth - 2) + "╗");

            string message = $"WELCOME {name.ToUpper()}";
            int padding = boxWidth - 2 - message.Length;
            int padLeft = padding / 2;
            int padRight = padding - padLeft;

            return "╔" + new string('═', boxWidth - 2) + "╗\n" +
                   "║" + new string(' ', padLeft) + message + new string(' ', padRight) + "║\n" +
                   "╚" + new string('═', boxWidth - 2) + "╝";
        }
    }
}
