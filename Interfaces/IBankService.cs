using Bankautomat.Models;

namespace Bankautomat.Interfaces;

public interface IBankService
{
    Dictionary<string,Account> Accounts { get; }

    Account RegisterAccount(string accNumber,string name,string pin);

    int GetTotalCents(Account account);

    void Deposit(Account account,decimal amount);

    bool Withdraw(Account account,decimal amount);

    void Redistribute(Account account,int cents);

    void Save();
}