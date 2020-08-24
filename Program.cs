using System;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class transaction
    {
        // name = datetime of transaction
        public DateTime Name { get; set; } = DateTime.Now;
        // account = checking or savings
        public String Account { get; set; }
        // amount = deposit/withdrawal amount
        public int Amount { get; set; }
        public String Type { get; set; }
    }
    class Checking
    {
        public int CheckDeposit { get; set; }
        public int CheckWithdrawal { get; set; }
    }
    class Savings
    {
        public int SavDeposit { get; set; }
        public int SavWithdrawal { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {

            var transactions = new List<transaction>();

            var hasQuitTheApplication = false;
            while (hasQuitTheApplication is false)
            {

                // Show them a menu of options they can do

                // Deposit Savings -  As a user I should have a menu option to make a deposit transaction for savings
                // Deposit Checking -  As a user I should have a menu option to make a deposit transaction for checking
                // Withdraw Savings -  As a user I should have a menu option to make a withdraw transaction for savings 
                // Withdraw Checking - As a user I should have a menu option to make a withdraw transaction for Checking
                // Balance -  As a user I should have a menu option to see the balance of checking/savings
                // Quit - Exit the application

                Console.WriteLine("What would you Like to do?");
                Console.WriteLine("DEPOSIT - Make a Deposit");
                Console.WriteLine("WITHDRAW - Make a Withdrawal");
                Console.WriteLine("BALANCE - Check Balance");
                Console.WriteLine("QUIT - This will exit the System");
                Console.WriteLine();
                Console.WriteLine("CHOICE:");
                var choice = Console.ReadLine().ToUpper();

                if (choice == "DEPOSIT")
                {
                    Console.WriteLine("What would you Like to do?");
                    Console.WriteLine("SAVINGS - Deposit savings");
                    Console.WriteLine("CHECKING - Deposit Checking");
                    Console.WriteLine();
                    Console.WriteLine("CHOICE:");
                    var depositChoice = Console.ReadLine().ToUpper();
                    if (depositChoice == "SAVINGS")
                    {
                        Console.WriteLine($"Savings Balance is {Amount}")
                    }
                    if (depositChoice == "CHECKING")
                    {
                        // deposit checking
                    }


                }

                if (choice == "WITHDRAW")
                {
                    Console.WriteLine("What would you Like to do?");
                    Console.WriteLine("SAVINGS - Withdraw savings");
                    Console.WriteLine("CHECKING - Withdraw Checking");
                    Console.WriteLine();
                    Console.WriteLine("CHOICE:");
                    var withdrawChoice = Console.ReadLine().ToUpper();
                    if (withdrawChoice == "SAVINGS")
                    {
                        // withdraw from savings
                    }
                    if (withdrawChoice == "CHECKING")
                    {
                        // withdraw from checking
                    }

                }

                if (choice == "BALANCE")
                {
                    Console.WriteLine("What would you Like to do?");
                    Console.WriteLine("SAVINGS - Balance savings");
                    Console.WriteLine("CHECKING - Balance Checking");
                    Console.WriteLine();
                    Console.WriteLine("CHOICE:");
                    var balanceChoice = Console.ReadLine().ToUpper();
                    if (balanceChoice == "SAVINGS")
                    {
                        // check savings balance
                    }
                    if (balanceChoice == "CHECKING")
                    {
                        //check checking balance
                    }
                }

                if (choice == "QUIT")
                {
                    hasQuitTheApplication = true;
                }

                Console.WriteLine("---GOODBYE---");

            }
        }
    }
}

