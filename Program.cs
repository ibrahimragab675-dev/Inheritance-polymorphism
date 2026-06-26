using Inheritance_polymorphism;
using System;
using System.Collections.Generic;
using System.Security.Principal;

class Program
{
    static void Main()
    {
        var accounts = new List<Account>
            {
                new Account("Base Joe", 1000.0),
                new SavingsAccount("Savings Sally", 2000.0, interestRate: 5.0),
                new CheckingAccount("Checking Charlie", 1500.0),
                new TrustAccount("Trust Tina", 10000.0, interestRate: 3.0)
            };

        Console.WriteLine("--- Initial Accounts ---");
        AccountUtil.Display(accounts);

        Console.WriteLine("\n--- Deposit 1000 to all ---");
        AccountUtil.Deposit(accounts, 1000.0);

        Console.WriteLine("\n--- Withdraw 200 from all ---");
        AccountUtil.Withdraw(accounts, 200.0);

        Console.WriteLine("\n--- Trust special cases ---");
        var trust = accounts[3] as TrustAccount;
        if (trust != null)
        {
            Console.WriteLine("Deposit 6000 to trust (should get $50 bonus + interest):");
            trust.Deposit(6000.0);
            Console.WriteLine(trust.ToString());

            Console.WriteLine("Attempt 1st trust withdrawal of 1000 (allowed if <20%): " +
                              (trust.Withdraw(1000.0) ? "succeeded" : "failed"));
            Console.WriteLine("Attempt 2nd trust withdrawal of 3000 (may fail if >=20%): " +
                              (trust.Withdraw(3000.0) ? "succeeded" : "failed"));
            Console.WriteLine("Attempt 3rd trust withdrawal of 500 (succeeded?) " +
                              (trust.Withdraw(500.0) ? "succeeded" : "failed"));
            Console.WriteLine("Attempt 4th trust withdrawal of 100 (should fail - exceed 3 withdrawals): " +
                              (trust.Withdraw(100.0) ? "succeeded" : "failed"));
            Console.WriteLine(trust.ToString());
        }

        Console.WriteLine("\n--- Final Accounts ---");
        AccountUtil.Display(accounts);
    }
}
