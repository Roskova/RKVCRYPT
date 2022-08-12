using RKVCRYPT.Core.GestionFichier;
using RKVCRYPT.Core.Interface;
namespace RKVCRYPT.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "../../.././";
            Fichier Fconfig = new Fichier(x, "config.txt");
            Fichier Ftable = new Fichier(x, "table.txt");
            Fichier Finterface = new Fichier(x, "interface.txt");
            List<Fichier> LF = new List<Fichier>();
            List<Display_Interface> DI = new List<Display_Interface>();
            Finterface.Load(); Ftable.Load(); Fconfig.Load();
            //Séparation et activation des différentes interface active dans le fichier de configuration
            string Linterface = Finterface.Search("INTERFACE-ACTIVE=");
            string[] LinterfaceSplit = Linterface.Split(',');
            foreach (string i in LinterfaceSplit) LF.Add(new Fichier(x + Finterface.Search("DOSSIER-INTERFACE="), i + ".txt"));
            foreach (Fichier i in LF) i.Load();
            for (int i = 0; i < LF.Count; i++) DI.Add(new Display_Interface(LinterfaceSplit[i], SelectF(LinterfaceSplit[i], LF), Finterface));
            foreach (Display_Interface i in DI)
            {
                Console.WriteLine(i.Entete);
                Console.WriteLine(i.Description);
            }
        }
        private static Fichier SelectF(string NomInterface, List<Fichier> LF)
        {
            foreach (Fichier i in LF) { if (i.Nom == NomInterface + ".txt") { return i; } }
            return LF[0];
        }
    }
}