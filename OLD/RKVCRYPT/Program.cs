namespace RKVCRYPT
{
    class Program
    {
        public static void Verrouillage()
        {
            Console.WriteLine(Config.Search("PROGRAM-LOCK-MESSAGE="));
        }
        //Appelle le fichier de Configuration et l'interface de démarrage
        static void Main(string[] args)
        {
            Config.ParamConsole();
            Config.CreateConfigFile();
            Interface.CreateInterfaceFile();
            Interface.InterfaceBackgroundColor();
            Interface.Fonction();
        }
    }
}