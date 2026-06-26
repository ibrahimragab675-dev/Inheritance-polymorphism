using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    public class SavingsAccount : Account
    {
        public double interestRate { get; set; } // percent, e.g., 5.0 means 5%

        public SavingsAccount(string name = "Unnamed Savings", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance)
        {
            this.interestRate = interestRate;
        }

        // Deposit receives interest on the deposited amount
        public override bool Deposit(double amount)
        {
            if (amount < 0) return false;

            double interest = amount * (interestRate / 100.0);
            double total = amount + interest;
            return base.Deposit(total);
        }

        public override string ToString()
        {
            return $"[SavingsAccount: {name}: {balance:F2}, Interest: {interestRate:F2}%]";
        }
    }


}
