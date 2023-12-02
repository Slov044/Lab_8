using System.Text.Json;

namespace Task1;

public class ConfigurationManager
{
    private static readonly Lazy<ConfigurationManager> Lazy = new(() => new ConfigurationManager());

    private const string Path = "config.json";
    
    public static ConfigurationManager Instance => Lazy.Value;

    private readonly Dictionary<string, string> _dictionary;

    static ConfigurationManager()
    {
        AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
    }

    private static void CurrentDomain_ProcessExit(object? sender, EventArgs e)
    {
        if (!Lazy.IsValueCreated)
            return;

        Instance.Save();
    }

    private ConfigurationManager()
    {
        _dictionary = Load();
    }
    
    public void Set(string key, string value)
    {
        _dictionary[key] = value;
    }

    public string? Get(string key)
    {
        if (_dictionary.TryGetValue(key, out var value))
            return value;
        return null;
    }

    public void Save()
    {
        using var stream = File.Open(Path, FileMode.Create, FileAccess.Write);
        JsonSerializer.Serialize(stream, this._dictionary);
    }
    
    private static Dictionary<string, string> Load()
    {
        if (!File.Exists(Path))
            return new Dictionary<string, string>();
        
        using var stream = File.Open(Path, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<Dictionary<string, string>>(stream)!;
    }
}