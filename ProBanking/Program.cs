using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with Banking *****");
            Console.Write("Create a name on the account: ");
            string name = Console.ReadLine();
            Console.Write("Create a password: ");
            string password = Console.ReadLine();
            Account newaccount = new Account(name, "935-4831", password, 500, 0.04);
            
            string loopcontinue = "YES";
            while (loopcontinue == "YES")
            {
                if (newaccount.Login())
                {
                    MainMenu(newaccount);
                }
                else
                {
                    Console.WriteLine("Login Failure! You have entered an invalid password!");
                }
                Console.Write("Continue? :");
                loopcontinue = Console.ReadLine();
            }
            Console.ReadLine();
        }

        static void MainMenu(Account account)
        {
            bool loopvalue = true;
            int accountoptions = 0;
            int monetaryInput = 0;
            string charInput = "n";
            while (loopvalue == true)
            {
                Console.WriteLine("Please make a selection:\n[1] Check Balance [2] Deposit [3] Credit [4] Quit");
                try
                {
                    accountoptions = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                switch (accountoptions)
                {
                    case 1:
                        account.GetCurrentBalance();
                        break;
                    case 2:
                        Console.Write("How much do you wish to deposit? : ");
                        monetaryInput = Convert.ToInt32(Console.ReadLine());
                        account.Deposit(monetaryInput);
                        break;
                    case 3:
                        Console.Write("How much do you wish to withdraw? : ");
                        monetaryInput = Convert.ToInt32(Console.ReadLine());
                        account.Credit(monetaryInput);
                        break;
                    case 4:
                        Console.Write("Do you wish to quit? (y/n): ");
                        charInput = Console.ReadLine();
                        if (charInput.ToUpper() == "N")
                            break;
                        else
                            loopvalue = false;
                        break;
                    default:
                        Console.WriteLine("Received invalid input.");
                        break;
                }
            }
        }
    }
}
