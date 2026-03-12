namespace Bankautomat.Models;

public class Account
{
    public string Name { get; set; } = "";

    public CustomerType CustomerType { get; set; }

    public Dictionary<string,int> AccCoins { get; set; } = new();
}