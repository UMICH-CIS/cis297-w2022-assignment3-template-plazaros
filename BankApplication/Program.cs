using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    /// <summary>
    /// This class determines account balance
    /// </summary>
    /// <Student>Paul Lazaros</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    class Account
    {
        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            set
            {
                if (value < 0.0m)
                    Console.WriteLine("Starting balance must be positive");
                else balance = value;
            }
        }
        public Account(decimal initialBalance)
        {
            Balance = initialBalance;
            Console.WriteLine($"Initial balance is ${Balance}");
        }
    /// <summary>
    /// This method adds amount to balance
    /// </summary>
    /// <Student>Paul Lazaros</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    /// <param name="amount"></param>
        public void Credit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"New account balance is ${Balance}");
        }
    /// <summary>
    /// This method substracts amount from balance
    /// </summary>
    ///  <Student>Paul Lazaros</Student>
    /// <Class>CIS297</Class>
    /// <Semester>Winter 2022</Semester>
    /// <param name="amount"></param>
    /// <returns></returns>
        public bool Debit(decimal amount)
        {
            if (balance < amount)
            {
                Console.WriteLine("Debit amount exceeded account balance");
                return false;
            }
            else balance -= amount;
            Console.WriteLine($"New account balance is ${Balance}");
            return true;
        }
    }
/// <summary>
/// This class calculates interest rate
/// </summary>
/// <Student>Paul Lazaros</Student>
/// <Class>CIS297</Class>
/// <Semester>Winter 2022</Semester>
    class SavingsAccount : Account
    {
        private decimal interestRate;
        public SavingsAccount(decimal initialBalance, decimal intRate) : base(initialBalance)
        {
            interestRate = intRate;
            Console.WriteLine($"The interest rate is {interestRate}%");
        }
        /// <summary>
        /// This method calculates interest
        /// </summary>
        /// <Student>Paul Lazaros</Student>
        /// <Class>CIS297</Class>
        /// <Semester>Winter 2022</Semester>
        /// <returns></returns>
        public decimal CalculateInterest()
        {
            Console.WriteLine($"The interest is ${Balance * (interestRate / 100)}");
            return Balance * (interestRate / 100);
        }
    }
/// <summary>
/// This class completes transactions
/// </summary>
/// <Student>Paul Lazaros</Student>
/// <Class>CIS297</Class>
/// <Semester>Winter 2022</Semester>
    class CheckingAccount : Account
    {
        private decimal transactionFee;
        public CheckingAccount(decimal inititalBalance, decimal fee) : base(inititalBalance)
        {
            transactionFee = fee;
            Console.WriteLine($"Transaction fee of ${transactionFee}");
        }
        /// <summary>
        /// This method redefines Credit to subtract transcation fee
        /// </summary>
        /// <Student>Paul Lazaros</Student>
        /// <Class>CIS297</Class>
        /// <Semester>Winter 2022</Semester>
        /// <param name="amount"></param>
        public void Credit(decimal amount)
        {
            Balance = Balance + amount;
            Balance = Balance - transactionFee;
            Console.WriteLine($"New account balance is ${Balance}");
        }
        /// <summary>
        /// This method redefines Debit to subtract transaction fee
        /// </summary>
        /// <Student>Paul Lazaros</Student>
        /// <Class>CIS297</Class>
        /// <Semester>Winter 2022</Semester>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Debit(decimal amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Debit amount exceeds account balance");
                return false;
            }
            else
            {
                Balance = Balance - amount;
                Balance = Balance - transactionFee;
                Console.WriteLine($"New account balance is ${Balance}");
                return true;
            }    
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(5000);
            acc.Credit(500);
            acc.Debit(200);
            SavingsAccount sacc = new SavingsAccount(5000, 5m);
            sacc.CalculateInterest();
            CheckingAccount cacc = new CheckingAccount(5000, 20);
            cacc.Credit(500);
            cacc.Debit(200);
            Console.ReadKey();
        }
    }
}
