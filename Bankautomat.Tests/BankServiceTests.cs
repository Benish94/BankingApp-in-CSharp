using Xunit;
using Bankautomat.Services;
using Bankautomat.Models;
using Bankautomat.Data;
using Bankautomat.Interfaces;

namespace Bankautomat.Tests;

public class BankServiceTests
{
    // FakeStorage verhindert Dateizugriffe auf accounts.json
    private class FakeStorage : IStorage
    {
        public Dictionary<string, Account> Load() => new();
        public void Save(Dictionary<string, Account> accounts) { }
    }

    private BankService CreateService()
    {
        var storage = new FakeStorage();
        return new BankService(storage);
    }

    private Account CreateAccount()
    {
        return new Account
        {
            Name = "Test",
            Pin = "1234",
            CustomerType = CustomerType.Existing,
            AccCoins = CoinDefinitions.CreateEmptyCoins()
        };
    }

    [Fact]
    public void Deposit_ShouldIncreaseBalance()
    {
        var service = CreateService();
        var account = CreateAccount();

        service.Deposit(account, 10);

        int total = service.GetTotalCents(account);

        Assert.Equal(1000, total);
    }

    [Fact]
    public void Withdraw_ShouldReduceBalance()
    {
        var service = CreateService();
        var account = CreateAccount();

        service.Deposit(account, 20);

        bool result = service.Withdraw(account, 10);

        int total = service.GetTotalCents(account);

        Assert.True(result);
        Assert.Equal(1000, total);
    }

    [Fact]
    public void Withdraw_ShouldFail_WhenBalanceTooLow()
    {
        var service = CreateService();
        var account = CreateAccount();

        bool result = service.Withdraw(account, 10);

        Assert.False(result);
    }

    [Fact]
    public void Redistribute_ShouldUseLargestDenominations()
    {
        var service = CreateService();
        var account = CreateAccount();

        service.Deposit(account, 187.76m);

        Assert.Equal(1, account.AccCoins["100"]);
        Assert.Equal(1, account.AccCoins["50"]);
        Assert.Equal(1, account.AccCoins["20"]);
        Assert.Equal(1, account.AccCoins["10"]);
        Assert.Equal(1, account.AccCoins["5"]);
        Assert.Equal(1, account.AccCoins["2"]);
    }

    [Fact]
    public void Interest_ShouldIncreaseBalance()
    {
        var service = CreateService();
        var interest = new InterestService();

        var account = CreateAccount();

        service.Deposit(account, 100);

        int interestValue = interest.CalculateInterest(account);

        Assert.Equal(100, interestValue);
    }

    [Fact]
    public void RegisterAccount_ShouldCreateAccount()
    {
        var service = CreateService();

        var account = service.RegisterAccount("12345678", "Max", "1234");

        Assert.NotNull(account);
        Assert.Equal("Max", account.Name);
        Assert.Equal("1234", account.Pin);
    }
}