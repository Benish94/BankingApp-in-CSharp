using System.Linq;

namespace Bankautomat.Utils;

public static class InputValidator
{
    public static string AskAccountNumber()
    {
        while (true)
        {
            Console.Write("Kontonummer (8 Ziffern): ");

            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                input.Length == 8 &&
                input.All(char.IsDigit))
            {
                return input;
            }

            Console.WriteLine("❌ Ungültige Kontonummer.");
        }
    }

    public static string AskPin()
    {
        while (true)
        {
            Console.Write("PIN (4 Stellen): ");

            var input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                input.Length == 4 &&
                input.All(char.IsDigit))
            {
                return input;
            }

            Console.WriteLine("❌ Ungültige PIN.");
        }
    }

    public static decimal AskAmount()
    {
        while (true)
        {
            Console.Write("Betrag eingeben: ");

            var input = Console.ReadLine()?.Replace(",", ".");

            if (decimal.TryParse(input, out decimal amount) && amount > 0)
                return amount;

            Console.WriteLine("❌ Ungültiger Betrag.");
        }
    }
}