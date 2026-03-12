namespace Bankautomat.UI;

public static class ConsoleMenu
{
    public static int ShowMainMenu()
    {
        Console.WriteLine("┌──────────────────────────────────────┐");
        Console.WriteLine("│ 1️⃣  Konto verwenden                  │");
        Console.WriteLine("│ 2️⃣  Auszahlung ohne Konto            │");
        Console.WriteLine("│ 3️⃣  Beenden                          │");
        Console.WriteLine("└──────────────────────────────────────┘");
        Console.Write("Auswahl: ");

        if (int.TryParse(Console.ReadLine(), out int result))
            return result;

        return 0;
    }

    public static int ShowCustomerMenu()
    {
        Console.WriteLine("┌──────────────────────────────────────┐");
        Console.WriteLine("│ 1️⃣  Kontostand anzeigen              │");
        Console.WriteLine("│ 2️⃣  Geld abheben                     │");
        Console.WriteLine("│ 3️⃣  Zinsen gutschreiben              │");
        Console.WriteLine("│ 4️⃣  Karte auswerfen (Logout)         │");
        Console.WriteLine("└──────────────────────────────────────┘");
        Console.Write("Auswahl: ");

        if (int.TryParse(Console.ReadLine(), out int result))
            return result;

        return 0;
    }
}