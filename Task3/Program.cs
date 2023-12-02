// See https://aka.ms/new-console-template for more information

using System.Text;
using Task3;
using Task3.Factories;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

        var factory = GetFactory();

        var phone = new Technology(
            factory.CreateScreen(),
            factory.CreateCpu(),
            factory.CreateCamera()
        );
        
        phone.Cpu.Run();
        phone.Screen.Show();
        phone.Camera.MakePicture();
    }

    public static ITechnologyFactory GetFactory()
    {
        while (true)
        {
            var text = Input.String("Введіть тип пристрою (телефон, планшет, ноутбук)");

            switch (text.ToLowerInvariant())
            {
                case "телефон":
                    return new PhoneTechnologyFactory();
                case "планшет":
                    return new LaptopTechnologyFactory();
                case "ноутбук":
                    return new LaptopTechnologyFactory();
            }
        }
    }
}