using System;
using System.Web.Security;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace PasswordGen
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Password Manager Project 2021.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("Do you want to generate a password, or find an existing one? Type FIND or GEN");
            Console.WriteLine("");
            string userInput = Console.ReadLine();
            userInput = userInput.ToUpper();

            Console.WriteLine("");

            switch (userInput)
            {
                case "GEN":
                    GeneratePass();
                    break;
                case "FIND":
                    FindExistingPass();
                    break;
                default:
                    Console.WriteLine("Please check your input and try again. Press any key to exit the program now.");
                    break;
            }
            Console.ReadKey(true);
        }

        static void FindExistingPass()
        {
            Console.WriteLine("What program/purpose was the password for?");
            Console.WriteLine("");
            string stringToFind = Console.ReadLine();
            stringToFind = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(stringToFind.ToLower());
            Console.WriteLine("");
            int passFound = 0;
            foreach(string line in File.ReadAllLines(Globals.myFile))
            {
                if (line.Contains(stringToFind))
                {
                    passFound++;
                    Console.WriteLine(line);
                    Console.WriteLine("");
                    string[] justPass = line.Split(':');
                    Console.WriteLine(justPass[1]);
                    Console.WriteLine("");
                    Console.WriteLine("Password has been copied to clipboard.");
                    Clipboard.SetText(justPass[1]);
                }
            }
            if(passFound == 0)
            {
                Console.WriteLine("Sorry, there was no matching password found.");
                Console.WriteLine("Press any key to leaves.");
            }
            Console.ReadKey(true);
        }
        static void GeneratePass()
        {
            Console.WriteLine("How many passwords would you like to generate today?");
            Console.WriteLine("");
            string userGreet = "What would this password be for?";
            int passAmount = Int32.Parse(Console.ReadLine());
            Console.WriteLine("");
            for (int i = 0; i < passAmount; i++)
            {
                Console.WriteLine(userGreet);
                Console.WriteLine("");
                String purpose = Console.ReadLine();
                purpose = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(purpose.ToLower());
                Console.WriteLine("");
                Console.WriteLine("");
                String generatedPassword = Membership.GeneratePassword(18, 4);

                Console.WriteLine("");
                Console.WriteLine($"The password generated is {generatedPassword}. It has been copied to clipboard, feel free to paste.");
                Clipboard.SetText(generatedPassword);
                Console.WriteLine("");
                userGreet = "What would the next password be for?";
                Console.WriteLine("");

                Console.WriteLine("Security Check: Did the password work? yes or no");
                Console.WriteLine("");
                string works = Console.ReadLine();
                Console.WriteLine("");
                if (works.Equals("no", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Would you like to modify the generated password yourself so it can work and paste here? yes or no");
                    Console.WriteLine("");
                    string response = Console.ReadLine();
                    if(response.Equals("yes", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Awesome, input the modified version here and we'll store it.");
                        string modifiedPass = Console.ReadLine();
                        generatedPassword = modifiedPass;
                    } else if(response.Equals("no", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Alright! Restarting program.");
                            continue;
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("Cool, adding it to file.");
                Console.WriteLine("");
                String finalPass = purpose + ":" + generatedPassword;

                using (StreamWriter sw = File.AppendText(Globals.myFile))
                {
                    sw.WriteLine(finalPass);
                }
                using (StreamReader sr = File.OpenText(Globals.myFile))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            Console.ReadKey(true);
        }
    }
    public static class Globals
    {
        public const string myFile = @"D:\Documents\111 sensitive\passwordsLocal.txt";
    }
}
