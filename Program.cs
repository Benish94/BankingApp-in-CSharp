using Bankautomat.Services;
using Bankautomat.Storage;
using Bankautomat.Models;
using Bankautomat.Data;

var bank = new BankService(new JsonStorage());
var interest = new InterestService();

Console.WriteLine("Willkommen beim Münzautomaten\n");

while (true)
{
    Console.WriteLine("Kontonummer (8 Ziffern):");

    var accNumber = Console.ReadLine();

    if (accNumber == null || accNumber.Length != 8)
        continue;

    var account = bank.Login(accNumber);

    if (account.CustomerType == CustomerType.External)
    {
        Console.WriteLine("Fremdkunde erkannt.");

        Console.WriteLine("Betrag zum Abheben:");

        if (decimal.TryParse(Console.ReadLine()?.Replace(",", "."), out decimal amount))
        {
            if (!bank.Withdraw(account, amount))
                Console.WriteLine("Nicht genug Guthaben.");
        }

        continue;
    }

    Console.WriteLine($"Willkommen {account.Name}");

    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("1 Kontostand");
        Console.WriteLine("2 Auszahlung");
        Console.WriteLine("3 Zinsen gutschreiben");
        Console.WriteLine("4 Logout");

        var input = Console.ReadLine();

        if (input == "1")
        {
            var total = bank.GetTotalCents(account);

            Console.WriteLine($"Kontostand: {total/100m:0.00} €");
        }

        if (input == "2")
        {
            Console.WriteLine("Betrag:");

            if (decimal.TryParse(Console.ReadLine()?.Replace(",", "."), out decimal amount))
            {
                if (!bank.Withdraw(account, amount))
                    Console.WriteLine("Nicht genug Guthaben");
            }
        }

        if (input == "3")
        {
            var interestAmount = interest.CalculateInterest(account);

            bank.Redistribute(account,
                bank.GetTotalCents(account) + interestAmount);

            Console.WriteLine($"Zinsen gutgeschrieben: {interestAmount/100m:0.00} €");
        }

        if (input == "4")
            break;
    }
}