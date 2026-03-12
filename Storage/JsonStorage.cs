using System.Text.Json;
using Bankautomat.Models;
using Bankautomat.Interfaces;

namespace Bankautomat.Storage;

public class JsonStorage : IStorage
{
    private const string FILE = "accounts.json";

    public Dictionary<string, Account> Load()
    {
        if (!File.Exists(FILE))
            return new();

        try
        {
            var json = File.ReadAllText(FILE);

            return JsonSerializer.Deserialize<Dictionary<string,Account>>(json)
                   ?? new();
        }
        catch
        {
            Console.WriteLine("Fehlerhafte JSON Datei.");
            return new();
        }
    }

    public void Save(Dictionary<string, Account> accounts)
    {
        var json = JsonSerializer.Serialize(
            accounts,
            new JsonSerializerOptions { WriteIndented = true }
        );

        File.WriteAllText(FILE, json);
    }
}