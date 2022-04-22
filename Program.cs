using System;

namespace Conection_Database
{
    internal class Program
    {
        private static readonly Repository connection = new();
        private static readonly Generator generator = new();

        private static void Main(string[] args)
        {
            while (true)
            {
                string option;

                Console.Clear();
                Console.WriteLine("".PadLeft(27, '-'));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("         PassGen");
                Console.ResetColor();
                Console.WriteLine("".PadLeft(27, '-'));

                Console.Write(
                    "1 - Generate Password\n2 - Existing Password\n3 - Your Saved Passwords\n4 - Exit application\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("".PadLeft(27, '-'));
                Console.ResetColor();
                Console.Write("Your option: ");
                Console.ForegroundColor = ConsoleColor.Green;
                option = Console.ReadLine();
                Console.ResetColor();

                if (option == "1")
                {
                    string lowerOpc;
                    string upperOpc;
                    string numericOpc;
                    string specialOpc;
                    int lengthPass;
                    string newPassword;
                    string chars = null;

                    Console.Clear();
                    Console.WriteLine("".PadLeft(27, '-'));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  Generating new password");
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(27, '-'));

                    Console.Write("Lowercase letters? [Y/n] ");
                    lowerOpc = Console.ReadLine();
                    if (lowerOpc == "" || lowerOpc.ToUpper() == "Y") chars += "abcdefghijklmnopqrstuvwxyz";

                    Console.Write("\nUppercase letters? [Y/n] ");
                    upperOpc = Console.ReadLine();
                    if (upperOpc == "" || upperOpc.ToUpper() == "Y") chars += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

                    Console.Write("\nNumeric characters? [Y/n] ");
                    numericOpc = Console.ReadLine();
                    if (numericOpc == "" || numericOpc.ToUpper() == "Y") chars += "0123456789";

                    Console.Write("\nSpecial characters? [Y/n] ");
                    specialOpc = Console.ReadLine();
                    if (specialOpc == "" || specialOpc.ToUpper() == "Y") chars += "!#@#$%$%&(@@){!@}[*&]-?°_=@#!+/|&*:;.?°®ß";

                    Console.Write("\nPassword length? [0/30] ");
                    lengthPass = Convert.ToInt16(Console.ReadLine());
                    if (lengthPass > 30) lengthPass = 30;

                    newPassword = generator.generatePassword(chars, lengthPass);

                    Console.Clear();
                    Console.WriteLine("\n  This is your new password");
                    Console.WriteLine("".PadLeft(30, '-'));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(newPassword);
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(30, '-'));

                    Console.Write("\nDo you want to save this password in the database? [Y/n] ");

                    var write = Console.ReadLine();

                    if (write == "" || write.ToUpper() == "Y")
                    {
                        Console.Clear();
                        Console.WriteLine("".PadLeft(60, '-'));
                        Console.Write("Application [Press Enter to Skip]: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        var application = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(60, '-'));
                        Console.Write("User [Press Enter to Skip]: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        var user = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(60, '-'));

                        Console.Clear();
                        Console.WriteLine("".PadLeft(30, '-'));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This is your informations.");
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(30, '-'));
                        Console.Write("\nApplication: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(application);
                        Console.ResetColor();
                        Console.Write("\nUser: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(user);
                        Console.ResetColor();
                        Console.Write("\nPassword: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(newPassword);
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n\nDo you really want to save? [Y/n] ");
                        Console.ResetColor();
                        var persist = Console.ReadLine();

                        persisteToWrite(persist, user, newPassword, application);
                        
                    }
                }

                else if (option == "2")
                {
                    Console.Clear();
                    Console.WriteLine("".PadLeft(60, '-'));
                    Console.Write("Application [Press Enter to Skip]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    var application = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(60, '-'));
                    Console.Write("User [Press Enter to Skip]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    var user = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(60, '-'));
                    Console.Write("Password [Required field]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    var password = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(60, '-'));

                    Console.Clear();
                    Console.WriteLine("".PadLeft(30, '-'));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("This is your informations.");
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(30, '-'));
                    Console.Write("\nApplication: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(application);
                    Console.ResetColor();
                    Console.Write("\nUser: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(user);
                    Console.ResetColor();
                    Console.Write("\nPassword: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(password);
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nDo you really want to save? [Y/n] ");
                    Console.ResetColor();
                    var persist = Console.ReadLine();

                    persisteToWrite(persist, user, password, application);

                }

                else if (option == "3")
                {
                    Console.Clear();
                    var read = connection.getData();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to continue...");
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(50, '-'));
                    Console.ReadKey();
                }

                else if (option == "4")
                {
                    break;
                }
            }
        }

        static void persisteToWrite(string persist, string user, string password, string application)
        {
            if (persist == "" || persist.ToUpper() == "Y")
            {
                connection.insertData(user, password, application);
                Console.Clear();
                Console.WriteLine("".PadLeft(30, '-'));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Successfully inserted!");
                Console.ResetColor();
                Console.WriteLine("".PadLeft(30, '-'));
                Console.WriteLine("Press any key to continue...");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("".PadLeft(30, '-'));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Press any key to continue...");
                Console.ResetColor();
                Console.WriteLine("".PadLeft(30, '-'));
            }

            Console.ReadKey();
        }
        
    }
}