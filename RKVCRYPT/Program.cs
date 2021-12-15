using System.Text;

namespace RKVCRYPT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Config.main();
            Interface.main();
        }
    }
}
