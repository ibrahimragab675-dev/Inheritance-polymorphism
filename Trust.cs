using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_polymorphism
{
    public class TrustAccount : SavingsAccount
    {
        private const double BONUS_THRESHOLD = 5000.0;
        private const double BONUS_AMOUNT = 50.0;
        private const int MAX_WITHDRAWALS = 3;
        private const double MAX_WITHDRAWAL_PERCENT = 0.20; // strictly less than 20%

        public int WithdrawalsThisYear { get; private set; } = 0;

        public TrustAccount(string name = "Unnamed Trust", double balance = 0.0, double interestRate = 0.0)
            : base(name, balance, interestRate)
        {
        }

        public override bool Deposit(double amount)
        {
            if (amount < 0) return false;

            double bonus = amount >= BONUS_THRESHOLD ? BONUS_AMOUNT : 0.0;
            double amountWithBonus = amount + bonus;

            // reuse SavingsAccount deposit behavior (adds interest on amountWithBonus)
            return base.Deposit(amountWithBonus);
        }

        public override bool Withdraw(double amount)
        {
            if (amount < 0) return false;

            // Enforce max withdrawals per year
            if (WithdrawalsThisYear >= MAX_WITHDRAWALS)
                return false;

            // Must be strictly less than 20% of current balance
            if (amount >= (balance * MAX_WITHDRAWAL_PERCENT))
                return false;

            // Use base withdraw (Account.Withdraw) to check funds and subtract
            bool ok = base.Withdraw(amount);
            if (ok)
            {
                WithdrawalsThisYear++;
            }
            return ok;
        }

        public override string ToString()
        {
            return $"[TrustAccount: {name}: {balance:F2}, Interest: {interestRate:F2}%, WithdrawalsThisYear: {WithdrawalsThisYear}]";
        }
    }
}

