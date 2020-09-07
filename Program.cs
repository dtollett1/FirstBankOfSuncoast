using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public String Account { get; set; }

        public int Amount { get; set; }
        public String Type { get; set; }
    }


    class Program
    {

        static void DisplayTransactions(List<Transaction> transactions, string accountType)
        {
            var specificTransactions = transactions.Where(transaction => transaction.Account == accountType);

            foreach (var transaction in specificTransactions)
            {
                Console.WriteLine($"A {transaction.Type} of {transaction.Amount}");
            }
        }

        static int Balance(List<Transaction> transactions, string accountType)
        {
            var withdrawTransactions = transactions.Where(transaction => transaction.Account == accountType && transaction.Type == "Withdraw");
            var depositTransactions = transactions.Where(transaction => transaction.Account == accountType && transaction.Type == "Deposit");
            var sumOfWithdrawAmounts = withdrawTransactions.Sum(transaction => transaction.Amount);
            var sumOfDepositAmounts = depositTransactions.Sum(transaction => transaction.Amount);

            return sumOfDepositAmounts - sumOfWithdrawAmounts;
        }
        static void SaveTransactions(List<Transaction> transactions)
        {
            var fileWriter = new StreamWriter("transactions.csv");

            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

            csvWriter.WriteRecords(transactions);

            fileWriter.Close();

        }
        static void Main(string[] args)
        {

            var transactions = new List<Transaction>();

            if (File.Exists("transactions.csv"))
            {
                var fileReader = new StreamReader("transactions.csv");

                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

                transactions = csvReader.GetRecords<Transaction>().ToList();

                fileReader.Close();
            }

            var hasQuitTheApplication = true;
            while (hasQuitTheApplication is true)
            {


                Console.WriteLine("What would you Like to do?");
                Console.WriteLine("DEPOSIT SAVINGS - Make a Deposit into savings");
                Console.WriteLine("DEPOSIT CHECKING - Make a Deposit into checking");
                Console.WriteLine("WITHDRAW SAVINGS - Make a Withdrawal from savings");
                Console.WriteLine("WITHDRAW CHECKING - Make a Withdrawal from checking");
                Console.WriteLine("TRANSFER - Transfer");
                Console.WriteLine("BALANCE - Check Balance");
                Console.WriteLine("HISTORY SAVINGS - Show Savings History");
                Console.WriteLine("HISTORY CHECKING - Show Checking History");
                Console.WriteLine("QUIT - This will exit the System");
                Console.WriteLine();
                Console.WriteLine("CHOICE:");
                var choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "Quit":
                        hasQuitTheApplication = false;
                        break;

                    case "DEPOSIT SAVINGS":
                        var depositSavingsAmount = int.Parse(Console.ReadLine());
                        var newsavingsdepositTransaction = new Transaction()
                        {
                            Type = "Withdraw",
                            Account = "Savings",
                            Amount = depositSavingsAmount
                        };
                        transactions.Add(newsavingsdepositTransaction);
                        SaveTransactions(transactions);

                        break;

                    case "DEPOSIT CHECKING":
                        var depositCheckingAmount = int.Parse(Console.ReadLine());
                        var newCheckingdepositTransaction = new Transaction()
                        {
                            Type = "Withdraw",
                            Account = "Savings",
                            Amount = depositCheckingAmount
                        };
                        transactions.Add(newCheckingdepositTransaction);
                        SaveTransactions(transactions);
                        break;

                    case "WITHDRAW SAVINGS":
                        Console.Write("How much do you want to withdraw: ");
                        var withdrawSavingsAmount = int.Parse(Console.ReadLine());
                        if (withdrawSavingsAmount < 0)
                        {
                            Console.WriteLine("Sorry your balance is less than zero");
                        }
                        else
                        {
                            var balanceInSavings = Balance(transactions, "Savings");
                            if (withdrawSavingsAmount > balanceInSavings)
                            {
                                Console.WriteLine("Insufficient funds");
                            }
                            else
                            {
                                var newTransaction = new Transaction()
                                {
                                    Type = "Withdraw",
                                    Account = "Savings",
                                    Amount = withdrawSavingsAmount
                                };
                                transactions.Add(newTransaction);
                                SaveTransactions(transactions);
                            }

                        }
                        break;

                    case "WITHDRAW CHECKING":
                        Console.Write("How much do you want to withdraw: ");
                        var withdrawCheckingAmount = int.Parse(Console.ReadLine());
                        if (withdrawCheckingAmount < 0)
                        {
                            Console.WriteLine("Sorry your balance is less than zero");
                        }
                        else
                        {
                            var balanceInSavings = Balance(transactions, "Savings");
                            if (withdrawCheckingAmount > balanceInSavings)
                            {
                                Console.WriteLine("Insufficient funds");
                            }
                            else
                            {
                                var newTransaction = new Transaction()
                                {
                                    Type = "Withdraw",
                                    Account = "Savings",
                                    Amount = withdrawCheckingAmount
                                };
                                transactions.Add(newTransaction);
                                SaveTransactions(transactions);
                            }

                        }
                        break;

                    case "TRANSFER":
                        break;

                    case "BALANCE":

                        var checkingBalance = Balance(transactions, "Checking");
                        var savingsBalance = Balance(transactions, "Savings");
                        Console.WriteLine($"The balance in your savings is {savingsBalance}");
                        Console.WriteLine($"The balance in your checking is {checkingBalance}");
                        break;

                    case "HISTORY SAVINGS":
                        DisplayTransactions(transactions, "Savings");
                        break;

                    case "HISTORY CHECKING":
                        DisplayTransactions(transactions, "Checking");
                        break;

                    default:
                        Console.WriteLine($"{choice} - is not a valid option");
                        break;
                }


            }


        }
    }
}

