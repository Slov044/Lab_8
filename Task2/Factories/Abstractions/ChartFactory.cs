using Task2.Charts.Abstractions;

namespace Task2.Factories;

public class ChartFactory<TChart>: IChartFactory where TChart: IChart, new()
{
    public IChart Create()
    {
        return new TChart();
    }
}