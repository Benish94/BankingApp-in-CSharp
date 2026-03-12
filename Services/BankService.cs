using Bankautomat.Models;
using Bankautomat.Storage;
using Bankautomat.Data;

namespace Bankautomat.Services;

public class BankService
{
    private readonly JsonStorage storage;

    public Dictionary<string,Account> Accounts { get; private set; }

    public BankService(JsonStorage storage)
    {
        this.storage = storage;
        Accounts = storage.Load();
    }

    public Account RegisterAccount(string accNumber, string name)
    {
        var account = new Account
        {
            Name = name,
            CustomerType = CustomerType.Existing,
            AccCoins = CoinDefinitions.CreateEmptyCoins()
        };

        Accounts[accNumber] = account;

        Save();

        return account;
    }

    public Account Login(string accNumber)
    {
        if (Accounts.ContainsKey(accNumber))
            return Accounts[accNumber];

        return new Account
        {
            Name = "Fremdkunde",
            CustomerType = CustomerType.External,
            AccCoins = CoinDefinitions.CreateEmptyCoins()
        };
    }

    public int GetTotalCents(Account account)
    {
        int sum = 0;

        foreach (var c in account.AccCoins)
            sum += c.Value * CoinDefinitions.Values[c.Key];

        return sum;
    }

    public void Redistribute(Account account, int cents)
    {
        foreach (var k in account.AccCoins.Keys.ToList())
            account.AccCoins[k] = 0;

        int remaining = cents;

        foreach (var coin in CoinDefinitions.Values)
        {
            int use = remaining / coin.Value;

            if (use > 0)
            {
                account.AccCoins[coin.Key] = use;
                remaining -= use * coin.Value;
            }
        }
    }

    public bool Withdraw(Account account, decimal amount)
    {
        int cents = (int)Math.Round(amount * 100);

        int total = GetTotalCents(account);

        if (cents > total)
            return false;

        Redistribute(account, total - cents);

        Save();

        return true;
    }

    public void Save()
    {
        storage.Save(Accounts);
    }
}