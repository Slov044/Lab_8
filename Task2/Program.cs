using System.Text;
using Task2.Factories;

internal static class Program
{
    public static void Main(string[] args)
    {
        Console.InputEncoding = Console.OutputEncoding = Encoding.Unicode;

        var factory = GetFactory();
        var chart = factory.Create();

        chart.Draw(new int[] { 1, 2, 3, 5, 2 });
    }

    public static IChartFactory GetFactory()
    {
        while (true)
        {
            var text = Input.String("Введіть тип пристрою (h, v)");

            switch (text.ToLowerInvariant())
            {
                case "h":
                    return new HorizontalChartFactory();
                case "v":
                    return new VerticalChartFactory();
            }
        }
    }
}