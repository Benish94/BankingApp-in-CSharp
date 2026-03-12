namespace Bankautomat.Models;

public class Account
{
    public string Name { get; set; } = "";

    public string Pin { get; set; } = "";

    public CustomerType CustomerType { get; set; }

    public Dictionary<string,int> AccCoins { get; set; } = new();

    public int FailedPinAttempts { get; set; } = 0;

    public bool IsLocked { get; set; } = false;
}