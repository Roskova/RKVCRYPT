using RKVCRYPT.Core;
namespace RKVCRYPT.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Fichier Fconfig = new Fichier("./", "config.txt");
            Fichier Ftable = new Fichier("./", "table.txt");
            Fichier Finterface = new Fichier("./", "interface.txt");
            Finterface.Load();
            Ftable.Load();
            Fconfig.Load();
            Display display = new Display("RKVCRYPT", Finterface);
        }
    }
}

