namespace Bankautomat.UI;

public static class AsciiATM
{
    public static void ShowWelcome()
    {
        Console.WriteLine();
        Console.WriteLine("╔════════════════════════════════╗");
        Console.WriteLine("║                                ║");
        Console.WriteLine("║          🏧 BANKAUTOMAT         ║");
        Console.WriteLine("║                                ║");
        Console.WriteLine("║   Willkommen bei Ihrer Bank    ║");
        Console.WriteLine("║                                ║");
        Console.WriteLine("╚════════════════════════════════╝");
        Console.WriteLine();
    }

    public static void ShowScreen(string title)
    {
        Console.WriteLine();
        Console.WriteLine("=================================");
        Console.WriteLine($" {title}");
        Console.WriteLine("=================================");
        Console.WriteLine();
    }

    public static void ShowError(string message)
    {
        Console.WriteLine();
        Console.WriteLine($"❌ {message}");
        Console.WriteLine();
    }

    public static void ShowSuccess(string message)
    {
        Console.WriteLine();
        Console.WriteLine($"✅ {message}");
        Console.WriteLine();
    }

    public static void EjectCard()
    {
        Console.WriteLine();
        Console.WriteLine("💳 Karte wird ausgegeben...");
        Console.WriteLine("Vielen Dank für Ihren Besuch!");
        Console.WriteLine();
    }
}