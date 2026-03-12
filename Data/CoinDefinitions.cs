namespace Bankautomat.Data;

public static class CoinDefinitions
{
    public static readonly Dictionary<string, int> Values = new()
    {
        {"2",200},
        {"1",100},
        {"0.5",50},
        {"0.2",20},
        {"0.1",10},
        {"0.05",5},
        {"0.02",2},
        {"0.01",1}
    };

    public static readonly Dictionary<string,string> Labels = new()
    {
        {"2","2.00 €"},
        {"1","1.00 €"},
        {"0.5","0.50 €"},
        {"0.2","0.20 €"},
        {"0.1","0.10 €"},
        {"0.05","0.05 €"},
        {"0.02","0.02 €"},
        {"0.01","0.01 €"}
    };

    public static Dictionary<string,int> CreateEmptyCoins()
    {
        return Values.Keys.ToDictionary(k => k, k => 0);
    }
}