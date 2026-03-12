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

    public static int ShowWithdrawMenu()
    {
        Console.WriteLine();
        Console.WriteLine("┌──────────────────────────────┐");
        Console.WriteLine("│ 💸 Auszahlung wählen         │");
        Console.WriteLine("│                              │");
        Console.WriteLine("│ 1 5 €                        │");
        Console.WriteLine("│ 2 10 €                       │");
        Console.WriteLine("│ 3 20 €                       │");
        Console.WriteLine("│ 4 50 €                       │");
        Console.WriteLine("│ 5 100 €                      │");
        Console.WriteLine("│ 6 Anderer Betrag             │");
        Console.WriteLine("└──────────────────────────────┘");

        Console.Write("Auswahl: ");

        int.TryParse(Console.ReadLine(), out int result);

        return result;
    }
}