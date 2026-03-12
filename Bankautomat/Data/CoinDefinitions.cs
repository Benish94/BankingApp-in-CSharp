namespace Bankautomat.Data;

public static class CoinDefinitions
{
    public static readonly List<(string Key, int Value, string Label)> Coins =
        new()
        {
            ("100", 10000, "100 €"),
            ("50", 5000, "50 €"),
            ("20", 2000, "20 €"),
            ("10", 1000, "10 €"),
            ("5", 500, "5 €"),

            ("2", 200, "2 €"),
            ("1", 100, "1 €"),
            ("0.5", 50, "0.50 €"),
            ("0.2", 20, "0.20 €"),
            ("0.1", 10, "0.10 €"),
            ("0.05", 5, "0.05 €"),
            ("0.02", 2, "0.02 €"),
            ("0.01", 1, "0.01 €")
        };

    public static readonly Dictionary<string, int> Values =
        Coins.ToDictionary(c => c.Key, c => c.Value);

    public static Dictionary<string, int> CreateEmptyCoins()
    {
        return Coins.ToDictionary(c => c.Key, c => 0);
    }
}