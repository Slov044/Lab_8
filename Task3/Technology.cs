namespace Task3;

public class Technology
{
    public readonly IScreenElement Screen;
    public readonly ICpuElement Cpu;
    public readonly ICameraElement Camera;

    public Technology(IScreenElement screen, ICpuElement cpu, ICameraElement camera)
    {
        Screen = screen;
        Cpu = cpu;
        Camera = camera;
    }
}