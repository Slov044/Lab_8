using Task2.Charts.Abstractions;

namespace Task2.Charts;

public class HorizontalChart: IChart
{
    public void Draw(int[] data)
    {
        if (data == null || data.Length == 0)
        {
            Console.WriteLine("No data to display.");
            return;
        }

        int maxValue = data.Max();

        for (int i = maxValue; i > 0; i--)
        {
            foreach (int value in data)
            {
                char symbol = value >= i ? '#' : ' ';
                Console.Write(symbol + " ");
            }
            Console.WriteLine();
        }

        for (int j = 0; j < data.Length; j++)
        {
            Console.Write("--");
        }
        Console.WriteLine();

        for (int k = 0; k < data.Length; k++)
        {
            Console.Write($"{k + 1} ");
        }
        Console.WriteLine();
    }
}