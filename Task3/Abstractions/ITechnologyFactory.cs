public interface ITechnologyFactory
{
    ICameraElement CreateCamera();
    ICpuElement CreateCpu();
    IScreenElement CreateScreen();
}