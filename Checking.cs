using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    public class CheckingAccount : Account
    {
        private const double WITHDRAWAL_FEE = 1.50;

        public CheckingAccount(string name = "Unnamed Checking", double balance = 0.0)
            : base(name, balance)
        {
        }

        public override bool Withdraw(double amount)
        {
            if (amount < 0) return false;

            double total = amount + WITHDRAWAL_FEE;
            // reuse base Withdraw logic for balance check and decrement
            return base.Withdraw(total);
        }

        public override string ToString()
        {
            return $"[CheckingAccount: {name}: {balance:F2}, Fee: {WITHDRAWAL_FEE:F2} per withdrawal]";
        }
    }
}

