using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    class Account {

        private bool IsAmountNegative(double Amount) {
            if (Amount <= 0) {
                Console.WriteLine("Amount must be positive.");
                return true;
            }
            return false;
        }

        // get is when someone is reading the data. get is left side.
        //set is when someone is making the data. set is right side. 

        private static int NextAccountNumber = 1;
        public int AccountNumber { get; private set; }
        private double Balance { get; set; } = 0;
        public string Description { get; set; }

        private static Account[] Accounts = new Account[5];
        private static int NextIndex = 0;

        public static void AddAccount(Account account) {
            Accounts[NextIndex] = account;
            NextIndex++;
        }

        public static void ListAccounts() {
            for (var idx = 0; idx < NextIndex; idx++) {
                var account = Accounts[idx];
                Console.WriteLine($"Id:{account.AccountNumber}; Desc:{account.Description};            Bal:{account.Balance}");
            }
        }

        public bool Transfer(Account ToAccount, double Amount) {
            var success = Withdraw(Amount);
           if(!success) {
                Console.WriteLine("Transfer failed - See log file");
                return false;
            }
            success = ToAccount.Deposit(Amount);
            if(!success) {
                Console.WriteLine("Transfer failed -See log file");
                Deposit(Amount);
                return false;
            }
            return false;
        }

        public bool Deposit(double Amount) {
            if(IsAmountNegative(Amount)) {
                return false;
            }

            Balance += Amount;
            return true;
        }
        public bool Withdraw(double Amount) {
            if (IsAmountNegative(Amount)) {
                return false;
            }

            if (Amount > Balance) {
                Console.WriteLine("INSUFFICIENT FUNDS");
                return false;
            }
            
            Balance -= Amount;
            return true;
        }

        public static string GetRoutingNumber() {
            return "123 456 789";
        }

        public double GetBalance() {
            return Balance;
        }
        public Account() {
            this.AccountNumber = NextAccountNumber++;
            this.Description = "New Account";
        }

    }
}
