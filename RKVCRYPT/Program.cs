namespace RKVCRYPT
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatingSystem.IsWindows();
            Config.Console();
            Interface.main();
        }
    }


}