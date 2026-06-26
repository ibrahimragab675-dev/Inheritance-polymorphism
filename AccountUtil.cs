

using System;
using System.Collections.Generic;
using System.Security.Principal;

public static class AccountUtil
{
    // Display all accounts
    public static void Display(IEnumerable<Account> accounts)
    {
        if (accounts == null) return;
        foreach (var acc in accounts)
        {
            Console.WriteLine(acc.ToString());
        }
    }

    // Deposit an amount to each account and print result (reuse Deposit behavior)
    public static void Deposit(IEnumerable<Account> accounts, double amount)
    {
        if (accounts == null) return;

        foreach (var acc in accounts)
        {
            bool success = acc.Deposit(amount);
            Console.WriteLine(success
                ? $"Deposited {amount:F2} to {acc.name}. New balance: {acc.balance:F2}"
                : $"Failed to deposit {amount:F2} to {acc.name}. Balance unchanged: {acc.balance:F2}");
        }
    }

    // Withdraw an amount from each account and print result (respects account-specific rules)
    public static void Withdraw(IEnumerable<Account> accounts, double amount)
    {
        if (accounts == null) return;

        foreach (var acc in accounts)
        {
            bool success = acc.Withdraw(amount);
            Console.WriteLine(success
                ? $"Withdrew {amount:F2} from {acc.name}. New balance: {acc.balance:F2}"
                : $"Failed to withdraw {amount:F2} from {acc.name}. Balance unchanged: {acc.balance:F2}");
        }
    }
}
