// See https://aka.ms/new-console-template for more information


using System.Text;
using Task1;

Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

Console.WriteLine("Json config");
if (File.Exists("config.json"))
{
    Console.WriteLine(File.ReadAllText("config.json"));
}

var configManager = ConfigurationManager.Instance;

configManager.Set("LoggingMode", "Verbose");
configManager.Set("DatabaseConnection", "Server=myserver;Database=mydatabase;User=myuser;Password=mypassword;");
Console.WriteLine(configManager.Get("LoggingMode"));

bool isActive = true;
while (isActive)
{
    string key = Input.String("Введіть назву поля");

    if (key == "")
    {
        configManager.Save();
        Console.WriteLine("Saved!");
        continue;
    }
    
    var value = configManager.Get(key);
    
    if (value is not null)
        Console.WriteLine("Last value: " + value);

    string newValue = Input.String("New value");
    configManager.Set(key, newValue);
}
