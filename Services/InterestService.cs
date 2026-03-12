using Bankautomat.Models;
using Bankautomat.Data;

namespace Bankautomat.Services;

public class InterestService
{
    private const decimal INTEREST_RATE = 0.01m; // 1 %

    public int CalculateInterest(Account account)
    {
        int total = 0;

        foreach (var coin in account.AccCoins)
        {
            total += coin.Value * CoinDefinitions.Values[coin.Key];
        }

        var interest = total * INTEREST_RATE;

        return (int)Math.Round(interest);
    }
}