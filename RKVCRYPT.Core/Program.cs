using RKVCRYPT.Core.GestionFichier;
using RKVCRYPT.Core.Interface;
namespace RKVCRYPT.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "../../.././";
            List<Display_Interface> DI = new List<Display_Interface>();
            List<Fichier> LF = new List<Fichier>();
            Fichier Fconfig = new Fichier(x, "configuration.txt");
            Fichier Finterface = new Fichier(x, "interface.txt");
            Journalisation log = new Journalisation(x + Fconfig.Search("DOSSIER-JOURNALISATION="), Fconfig.Search("JOURNALISATION-FILE-HEADER="), Convert.ToBoolean(Fconfig.Search("JOURNALISATION=")), Convert.ToBoolean(Fconfig.Search("REINITIALISER=")));
            //Séparation et activation des différentes interface active dans le fichier de configuration
            string Linterface = Fconfig.Search("INTERFACE-ACTIF=");
            string[] LinterfaceSplit = Linterface.Split(',');
            foreach (string i in LinterfaceSplit) LF.Add(new Fichier(x + Fconfig.Search("DOSSIER-INTERFACE="), i + ".txt"));
            for (int i = 0; i < LF.Count; i++) DI.Add(new Display_Interface(LinterfaceSplit[i], Fconfig, SelectF(LinterfaceSplit[i], LF), Finterface));
            foreach (Display_Interface i in DI)
            {
                log.WriteLine(i.Entete);
                log.WriteLine(i.Description);
            }

        }
        private static Fichier SelectF(string NomInterface, List<Fichier> LF)
        {
            foreach (Fichier i in LF) { if (i.Nom == NomInterface + ".txt") { return i; } }
            return LF[0];
        }
    }
}