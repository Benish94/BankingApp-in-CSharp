using Bankautomat.Interfaces;
using Bankautomat.Models;
using Bankautomat.Utils;
using Bankautomat.UI;

namespace Bankautomat.Controllers;

public class BankController
{
    private readonly IBankService bank;
    private readonly IInterestService interest;

    public BankController(IBankService bank, IInterestService interest)
    {
        this.bank = bank;
        this.interest = interest;
    }

    public void Run()
    {
        while (true)
        {
            AsciiATM.ShowWelcome();

            int choice = ConsoleMenu.ShowMainMenu();

            switch (choice)
            {
                case 1:
                    LoginCustomer();
                    break;

                case 2:
                    WithdrawExternal();
                    break;

                case 3:
                    Console.WriteLine("👋 Vielen Dank für Ihren Besuch.");
                    return;

                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }
        }
    }

    private void LoginCustomer()
    {
        AsciiATM.ShowScreen("Login");

        var accNumber = InputValidator.AskAccountNumber();

        var account = bank.Login(accNumber);

        if (account.CustomerType == CustomerType.External)
        {
            AsciiATM.ShowError("Konto nicht gefunden.");
            return;
        }

        var pin = InputValidator.AskPin();

        if (account.Pin != pin)
        {
            AsciiATM.ShowError("Falsche PIN.");
            return;
        }

        HandleExistingCustomer(account);
    }

    private void WithdrawExternal()
    {
        AsciiATM.ShowScreen("Auszahlung ohne Konto");

        var amount = InputValidator.AskAmount();

        var tempAccount = new Account
        {
            Name = "Fremdkunde",
            CustomerType = CustomerType.External,
            AccCoins = new()
        };

        if (!bank.Withdraw(tempAccount, amount))
            AsciiATM.ShowError("Auszahlung nicht möglich.");
        else
            AsciiATM.ShowSuccess("Auszahlung erfolgreich.");
    }

    private void HandleExistingCustomer(Account account)
    {
        Console.WriteLine($"\n👋 Willkommen {account.Name}");

        while (true)
        {
            int choice = ConsoleMenu.ShowCustomerMenu();

            switch (choice)
            {
                case 1:
                    ShowBalance(account);
                    break;

                case 2:
                    Withdraw(account);
                    break;

                case 3:
                    AddInterest(account);
                    break;

                case 4:
                    AsciiATM.EjectCard();
                    return;

                default:
                    Console.WriteLine("Ungültige Auswahl.");
                    break;
            }
        }
    }

    private void ShowBalance(Account account)
    {
        var total = bank.GetTotalCents(account);

        Console.WriteLine($"💰 Kontostand: {total / 100m:0.00} €");
    }

    private void Withdraw(Account account)
    {
        var amount = InputValidator.AskAmount();

        if (!bank.Withdraw(account, amount))
            AsciiATM.ShowError("Nicht genug Guthaben.");
        else
            AsciiATM.ShowSuccess("Auszahlung erfolgreich.");
    }

    private void AddInterest(Account account)
    {
        var interestAmount = interest.CalculateInterest(account);

        bank.Redistribute(account,
            bank.GetTotalCents(account) + interestAmount);

        Console.WriteLine($"📈 Zinsen gutgeschrieben: {interestAmount / 100m:0.00} €");
    }
}