namespace Task3.Factories;

public class TechnologyFactory<TCamera, TCpu, TScreen> : ITechnologyFactory
    where TCamera: ICameraElement, new()
    where TCpu: ICpuElement, new()
    where TScreen: IScreenElement, new()
{
    public ICameraElement CreateCamera()
    {
        return new TCamera();
    }

    public ICpuElement CreateCpu()
    {
        return new TCpu();

    }

    public IScreenElement CreateScreen()
    {
        return new TScreen();
    }
}