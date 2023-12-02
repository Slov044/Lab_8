// See https://aka.ms/new-console-template for more information


using Task4;

internal class Program
{
    private static readonly JsonFileSerializer JsonFileSerializer = new();
    private static readonly XmlFileSerializer XmlFileSerializer = new();

    private static readonly DataSet DataSet = new();
    
    public static void Main(string[] args)
    {
        var serizlizer = GetSerializer();

        var name = Input.String("Введіть назву файла");
        var fileName = Path.ChangeExtension(name, serizlizer.Extension);

        using (var stream = File.Open(fileName, FileMode.Create, FileAccess.Write))
        {
            serizlizer.Save(DataSet, stream);
        }

        DataSet loadedDataSet;
        using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
        {
            loadedDataSet = serizlizer.Load(stream)!;
        }

        foreach (var number in loadedDataSet.Numbers)
        {
            Console.WriteLine(number);
        }
        
        
    }

    private static IFileSerializer GetSerializer()
    {
        while (true)
        {
            Console.WriteLine("Введіть номер серіалізатора (1 - xml, 2 - json): ");
            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.D1:
                    return XmlFileSerializer.Clone();
                case ConsoleKey.D2:
                    return JsonFileSerializer.Clone();
            }
        }
    }
}