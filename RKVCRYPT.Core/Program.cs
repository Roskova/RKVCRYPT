using RKVCRYPT.Core.GestionFichier;
using RKVCRYPT.Core.Interface;
using RKVCRYPT.Module.Chiffrement;
namespace RKVCRYPT.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            string x = "../../.././";
            //Section de chargements des fichiers et interfaces par défault
            List<Display_Interface> DI = new List<Display_Interface>();
            List<Fichier> LF = new List<Fichier>();
            Fichier Fconfig = new Fichier(x, "configuration.txt");
            Fichier Finterface = new Fichier(x, "interface.txt");
            Journalisation log = new Journalisation(x + Fconfig.Search("DOSSIER-JOURNALISATION="), Fconfig.Search("JOURNALISATION-FILE-HEADER="), Convert.ToBoolean(Fconfig.Search("JOURNALISATION=")), Convert.ToBoolean(Fconfig.Search("REINITIALISER=")));
            Chiffrement chiffrement = new Chiffrement("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%\\²³~{}_±|ôÔÉÈÊÇÙÛÀÂÎéèêçûùàâî`^¸€‚ƒ„…†‡ˆ‰Š‹Œ Ž  ‘’“”•–—˜™š›œžŸ¡£¤¥¦§¨©ª®¯°´µ¶·¸¹º¼½¾¿ÅÆÐ×ØÞå÷\"АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя");
            //Séparation et activation des différentes interface active dans le fichier de configuration
            string Linterface = Fconfig.Search("MODULE-ACTIF=");
            string[] LinterfaceSplit = Linterface.Split(',');
            foreach (string i in LinterfaceSplit) LF.Add(new Fichier(x + Fconfig.Search("DOSSIER-INTERFACE="), i + ".txt"));
            for (int i = 0; i < LF.Count; i++) DI.Add(new Display_Interface(LinterfaceSplit[i], Fconfig, SelectF(LinterfaceSplit[i], LF), Finterface));
            foreach (Display_Interface i in DI)
            {
                log.WriteLine(i.Entete);
                log.WriteLine(i.Description);
            }
            Console.Clear();
            while (true) {
                log.WriteLine("Entrez le message:");
                string input = Console.ReadLine();
                log.Write($"Message entrée: {input}");
                log.WriteLine(chiffrement.Chiffrage(input));
                log.WriteLine(chiffrement.Dechiffrage(chiffrement.Chiffrage(input)));
            }

        }
        private static Fichier SelectF(string NomInterface, List<Fichier> LF)
        {
            foreach (Fichier i in LF) 
            { 
                if (i.Nom == NomInterface + ".txt") 
                { 
                    return i;
                }
            }
            return LF[0];
        }
    }
}