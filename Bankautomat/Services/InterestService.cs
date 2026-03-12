using Bankautomat.Models;
using Bankautomat.Interfaces;
using Bankautomat.Data;

namespace Bankautomat.Services;

public class InterestService : IInterestService
{
    private const decimal RATE = 0.01m;

    public int CalculateInterest(Account account)
    {
        int total=0;

        foreach(var coin in account.AccCoins)
            total += coin.Value * CoinDefinitions.Values[coin.Key];

        return (int)Math.Round(total * RATE);
    }
}