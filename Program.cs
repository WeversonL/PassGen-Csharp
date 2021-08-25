using System;
using MySql.Data.MySqlClient;

namespace Conection_Database
{
    class Program
    {   
        static manipulacao con = new manipulacao();
        static gerador gen = new gerador();
        static void Main(string[] args)
        {
            while (true){
                String opcao;

                Console.Clear();
                Console.WriteLine("".PadLeft(27,'-'));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("         PassGen");
                Console.ResetColor();
                Console.WriteLine("".PadLeft(27,'-'));

                Console.Write("1 - Generate Password\n2 - Existing Password\n3 - Your Saved Passwords\n4 - Exit application\n");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("".PadLeft(27,'-'));
                Console.ResetColor();
                Console.Write("Your option: ");
                Console.ForegroundColor = ConsoleColor.Green;
                opcao = Console.ReadLine().ToString();
                Console.ResetColor();

                if (opcao == "1"){

                    char LowerOpc, UpperOpc, NumericOpc, SpecialOpc;
                    int LenghtPass;
                    string NovaSenha = null;
                    string chars = null;

                    Console.Clear();
                    Console.WriteLine("".PadLeft(27,'-'));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("  Generating new password");
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(27,'-'));

                    Console.Write("Lowercase letters? [Y/N] ");
                    LowerOpc = Convert.ToChar(Console.ReadLine());
                    if (LowerOpc == 'Y' || LowerOpc == 'y'){
                        chars += "abcdefghijklmnopqrstuvwxyz";
                    }

                    Console.Write("\nUppercase letters? [Y/N] ");
                    UpperOpc = Convert.ToChar(Console.ReadLine());
                    if(UpperOpc == 'Y' || UpperOpc == 'y'){
                        chars+="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    }

                    Console.Write("\nNumeric characters? [Y/N] ");
                    NumericOpc = Convert.ToChar(Console.ReadLine());
                    if(NumericOpc == 'Y' || NumericOpc == 'y'){
                        chars+="0123456789";
                    }

                    Console.Write("\nSpecial characters? [Y/N] ");
                    SpecialOpc = Convert.ToChar(Console.ReadLine());
                    if(SpecialOpc == 'Y' || SpecialOpc == 'y'){
                        chars+="!#@#$%$%&(@@){!@}[*&]-?°_=@#!+/|&*:;.?°®ß";
                    }

                    Console.Write("\nPassword length? [0/30] ");
                    LenghtPass = Convert.ToInt16(Console.ReadLine());
                    if(LenghtPass > 30){
                        LenghtPass = 30;
                    }

                    NovaSenha = gen.gerarSenha(chars, LenghtPass);

                    Console.Clear();
                    Console.WriteLine("\n  This is your new password");
                    Console.WriteLine("".PadLeft(30,'-'));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(NovaSenha);
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(30,'-'));

                    Console.Write("\nDo you want to save this password in the database? [Y/N] ");

                    char gravar = Convert.ToChar(Console.ReadLine());

                    if (gravar == 'Y' || gravar == 'y'){

                        Console.Clear();
                        Console.WriteLine("".PadLeft(60,'-'));
                        Console.Write("Application [Press Enter to Skip]: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string aplicacao = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(60,'-'));
                        Console.Write("User [Press Enter to Skip]: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        string usuario = Console.ReadLine();
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(60,'-'));

                        Console.Clear();
                        Console.WriteLine("".PadLeft(30,'-'));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("This is your informations.");
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(30,'-'));
                        Console.Write("\nApplication: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(aplicacao);
                        Console.ResetColor();
                        Console.Write("\nUser: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(usuario);
                        Console.ResetColor();
                        Console.Write("\nPassword: ");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(NovaSenha);
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\n\nDo you really want to save? [Y/N] ");
                        Console.ResetColor();
                        char persist = Convert.ToChar(Console.ReadLine());

                        if (persist == 'Y' || persist == 'y'){
                            con.inserirDados(usuario, NovaSenha, aplicacao);
                            Console.Clear();
                            Console.WriteLine("".PadLeft(30,'-'));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Successfully inserted!");
                            Console.ResetColor();
                            Console.WriteLine("".PadLeft(30,'-'));
                            Console.WriteLine("Press any key to continue...");
                        } else{
                            Console.Clear();
                            Console.WriteLine("".PadLeft(30,'-'));
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Press any key to continue...");
                            Console.ResetColor();
                            Console.WriteLine("".PadLeft(30,'-'));
                        }
                        Console.ReadKey();
                    }
                }

                else if (opcao == "2"){
                    Console.Clear();
                    Console.WriteLine("".PadLeft(60,'-'));
                    Console.Write("Application [Press Enter to Skip]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string aplicacao = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(60,'-'));
                    Console.Write("User [Press Enter to Skip]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string usuario = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(60,'-'));
                    Console.Write("Password [Required field]: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    string senha = Console.ReadLine();
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(60,'-'));

                    Console.Clear();
                    Console.WriteLine("".PadLeft(30,'-'));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("This is your informations.");
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(30,'-'));
                    Console.Write("\nApplication: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(aplicacao);
                    Console.ResetColor();
                    Console.Write("\nUser: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(usuario);
                    Console.ResetColor();
                    Console.Write("\nPassword: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(senha);
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\n\nDo you really want to save? [Y/N] ");
                    Console.ResetColor();
                    char persist = Convert.ToChar(Console.ReadLine());

                    if (persist == 'Y' || persist == 'y'){
                        con.inserirDados(usuario, senha, aplicacao);
                        Console.Clear();
                        Console.WriteLine("".PadLeft(30,'-'));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Successfully inserted!");
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(30,'-'));
                        Console.WriteLine("Press any key to continue...");
                    } else{
                        Console.Clear();
                        Console.WriteLine("".PadLeft(30,'-'));
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Press any key to continue...");
                        Console.ResetColor();
                        Console.WriteLine("".PadLeft(30,'-'));
                    }
                    Console.ReadKey();
                    
                }

                else if (opcao == "3"){

                    Console.Clear();
                    MySqlDataReader read = con.obterDados();
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Press any key to continue...");
                    Console.ResetColor();
                    Console.WriteLine("".PadLeft(50,'-'));
                    Console.ReadKey();

                }

                else if (opcao == "4"){
                    break;
                }

            } 
        }
    }
}