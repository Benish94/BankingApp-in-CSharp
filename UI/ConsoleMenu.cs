namespace Bankautomat.UI;

public static class ConsoleMenu
{
    public static int ShowMainMenu()
    {
        Console.WriteLine("┌──────────────────────────────┐");
        Console.WriteLine("│ 🏧 BANKAUTOMAT               │");
        Console.WriteLine("│                              │");
        Console.WriteLine("│ 1 Konto verwenden            │");
        Console.WriteLine("│ 2 Auszahlung ohne Konto      │");
        Console.WriteLine("│ 3 Beenden                    │");
        Console.WriteLine("└──────────────────────────────┘");

        Console.Write("Auswahl: ");

        int.TryParse(Console.ReadLine(),out int result);

        return result;
    }

    public static int ShowCustomerMenu()
    {
        Console.WriteLine("┌──────────────────────────────┐");
        Console.WriteLine("│ 💳 Kundenmenü                │");
        Console.WriteLine("│                              │");
        Console.WriteLine("│ 1 Kontostand anzeigen        │");
        Console.WriteLine("│ 2 Einzahlung                 │");
        Console.WriteLine("│ 3 Auszahlung                 │");
        Console.WriteLine("│ 4 Zinsen                    │");
        Console.WriteLine("│ 5 Logout                    │");
        Console.WriteLine("└──────────────────────────────┘");

        Console.Write("Auswahl: ");

        int.TryParse(Console.ReadLine(),out int result);

        return result;
    }
}