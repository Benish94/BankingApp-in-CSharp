using Bankautomat.Models;

namespace Bankautomat.Interfaces;

public interface IInterestService
{
    int CalculateInterest(Account account);
}