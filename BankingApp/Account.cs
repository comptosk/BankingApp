using System;
using System.Collections.Generic;
using System.Text;

namespace BankingApp {
    class Account {

        // get is when someone is reading the data. get is left side.
        //set is when someone is making the data. set is right side. 

        public int AccountNumber { get; set; }
        public double Balance { get; set; } = 0;
        
        public string Description { get; set; }

        public void Deposit(double Amount) {
            if (Amount <= 0) {
                Console.WriteLine("Amount must be positive.");
                Balance += Amount;
            }
        }
        public void Withdraw(double Amount) {
            
            if (Amount > Balance) {
                Console.WriteLine("INSUFFICIENT FUNDS");
                return;
            }

            Balance -= Amount;
        }
        public double GetBalance() {
            return Balance;
        }
        public Account() {
            this.AccountNumber = 0;
            this.Description = "New Account";
            this.AccountNumber = 0;
        }

    }
}
