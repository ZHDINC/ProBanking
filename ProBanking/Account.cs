using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProBanking
{
    class Account
    {
        public Account(string NameOnAccount, string AccountNumber, string hashtopass, double Balance, double InterestRate)
        {
            this.Balance = Balance;
            this.InterestRate = InterestRate;
            this.NameOnAccount = NameOnAccount;
            this.AccountNumber = AccountNumber;
            Password = hashtopass.GetHashCode();
        }

        public Account() { }

        public double Balance { get; set; }
        public double InterestRate { get; set; }
        public string NameOnAccount { get; set; }
        public string AccountNumber { get; set; }
        private int Password { get; set; }

        public double Deposit(double deposit)
        {
            double AfterDeposit = Balance + deposit;
            Console.WriteLine("After depositing ${0}, your account value is now ${1}", deposit, AfterDeposit);
            return Balance += deposit;
        }

        public double Credit(double credit)
        {
            double AfterCredit = Balance - credit;
            if(AfterCredit < 0)
            {
                Console.WriteLine("You are overdrawn. Transaction declined.");
                OverdraftFee(15);
                return Balance;
            }
            else
            {
                Console.WriteLine("After crediting ${0}, your account value is now ${1}.", credit, AfterCredit);
                return Balance -= credit;
            }
        }

        private double OverdraftFee(double fee)
        {
            return Balance -= fee;
        }

        public void GetCurrentBalance()
        {
            Console.WriteLine("Your current balance is ${0}.", Balance);
        }

        public bool Login()
        {
            string username = "";
            string password = "";
            Console.WriteLine("Please login to access banking services.");
            Console.Write("Username: ");
            username = Console.ReadLine();
            Console.Write("Password: ");
            password = Console.ReadLine();
            int hashedpass = password.GetHashCode();
            if (Password == hashedpass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
