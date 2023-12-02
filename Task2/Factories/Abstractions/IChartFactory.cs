using Task2.Charts.Abstractions;

namespace Task2.Factories;

public interface IChartFactory
{
    IChart Create();
}