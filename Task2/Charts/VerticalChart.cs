using Task2.Charts.Abstractions;

namespace Task2.Charts;

public class VerticalChart : IChart
{
    public void Draw(int[] data)
    {
        if (data == null || data.Length == 0)
        {
            Console.WriteLine("No data to display.");
            return;
        }

        for (int i = 0; i < data.Length; i++)
        {
            Console.Write($"{i + 1}| ");
            for (int j = 0; j < data[i]; j++)
            {
                Console.Write("# ");
            }
            Console.WriteLine(data[i]);
        }

        Console.WriteLine();
    }
}