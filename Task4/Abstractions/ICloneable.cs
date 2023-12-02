namespace Task4;

public interface ICloneable<out T> : ICloneable
{
    new T Clone();
}