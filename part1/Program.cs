using System;
using System.Media;
using System.Threading;

namespace CyberSecurityChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Bot";

            DisplayAsciiLogo();

            PlayVoiceGreeting();

            string userName = AskUserName();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nWelcome {userName}! I'm your Cybersecurity Awareness Bot.");
            Console.WriteLine("You can ask me about passwords, phishing, or safe browsing.");
            Console.WriteLine("Type 'exit' anytime to quit.");
            Console.ResetColor();

            ChatBot(userName);
        }

        // ASCII Logo
        static void DisplayAsciiLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("===================================================");
            Console.WriteLine("           CYBERSECURITY AWARENESS BOT");
            Console.WriteLine("===================================================");
            Console.WriteLine("        .----.");
            Console.WriteLine("       / .--. \\");
            Console.WriteLine("      | |    | |");
            Console.WriteLine("      | |.-\"\"-.|");
            Console.WriteLine("     ///`.::::.`\\");
            Console.WriteLine("    ||| ::/  \\:: ;");
            Console.WriteLine("    ||; ::\\__/:: ;");
            Console.WriteLine("     \\\\\\ '::::' /");
            Console.WriteLine("      `=':-..-'`");
            Console.WriteLine("        CYBER SECURITY");
            Console.WriteLine("===================================================");

            Console.ResetColor();
        }

        // Voice Greeting
        static void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("welcome.wav");
                player.PlaySync();
            }
            catch
            {
                Console.WriteLine("Voice greeting could not be played.");
            }
        }

        // Ask User Name
        static string AskUserName()
        {
            Console.Write("\nPlease enter your name: ");
            string name = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Name cannot be empty. Please enter your name: ");
                name = Console.ReadLine();
            }

            return name;
        }

        // Typing Effect
        static void TypingEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30);
            }
            Console.WriteLine();
        }

        // Chatbot Response System
        static void ChatBot(string userName)
        {
            string input;

            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nYou: ");
                Console.ResetColor();

                input = Console.ReadLine().ToLower();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Bot: I didn’t quite understand that. Could you rephrase?");
                }

                else if (input.Contains("how are you"))
                {
                    TypingEffect($"Bot: I'm doing great, {userName}! Thanks for asking.");
                }

                else if (input.Contains("your purpose") || input.Contains("what do you do"))
                {
                    TypingEffect("Bot: My purpose is to help users understand cybersecurity and stay safe online.");
                }

                else if (input.Contains("password"))
                {
                    TypingEffect("Bot: Use strong passwords with uppercase, lowercase, numbers, and symbols.");
                    TypingEffect("Bot: Never share your password with anyone.");
                }

                else if (input.Contains("phishing"))
                {
                    TypingEffect("Bot: Phishing is when attackers trick you into revealing sensitive information using fake emails or websites.");
                    TypingEffect("Bot: Always check the sender's email and suspicious links.");
                }

                else if (input.Contains("safe browsing"))
                {
                    TypingEffect("Bot: Safe browsing means avoiding suspicious websites, keeping software updated, and not downloading unknown files.");
                }

                else if (input.Contains("what can i ask"))
                {
                    TypingEffect("Bot: You can ask me about:");
                    Console.WriteLine("- Password safety");
                    Console.WriteLine("- Phishing attacks");
                    Console.WriteLine("- Safe browsing");
                    Console.WriteLine("- My purpose");
                }

                else if (input != "exit")
                {
                    TypingEffect("Bot: I didn’t quite understand that. Could you rephrase?");
                }

            } while (input != "exit");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nBot: Goodbye! Stay safe online.");
            Console.ResetColor();
        }
    }
}