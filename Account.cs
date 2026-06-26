using System;

public class Account
{
   public string name { get; set; } 
    public double balance { get; set; }

    public Account(string name = "Unnamed Account", double balance = 0.0)
        
    {
        this.name = name;
        this.balance = balance;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount < 0)
            return false;
        else
        {
            balance += amount;
            return true;
        }
    }

    public virtual bool Withdraw(double amount)
    {
        if (balance - amount >= 0)
        {
            balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }

    public double GetBalance()
    {
        return balance;
    }

    public override string ToString()
    {
        return $"[Account: {name}: {balance}]";
    }
}