using Bankautomat.Models;

namespace Bankautomat.Interfaces;

public interface IBankService
{
    Dictionary<string, Account> Accounts { get; }

    Account RegisterAccount(string accNumber, string name, string pin);

    Account Login(string accNumber);

    int GetTotalCents(Account account);

    void Redistribute(Account account, int cents);

    bool Withdraw(Account account, decimal amount);

    void Save();
}