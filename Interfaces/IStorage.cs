using Bankautomat.Models;

namespace Bankautomat.Interfaces;

public interface IStorage
{
    Dictionary<string, Account> Load();
    void Save(Dictionary<string, Account> accounts);
}