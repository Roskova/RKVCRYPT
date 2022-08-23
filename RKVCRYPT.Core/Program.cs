using RKVCRYPT.Core.GestionFichier;
using RKVCRYPT.Module.Chiffrement;
namespace RKVCRYPT.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            // string x = "../../.././"
            string x = "./";
            //  Section de chargements des fichiers et interfaces par défault
            //  List<Display_Interface> DI = new List<Display_Interface>();
            //  List<Fichier> LF = new List<Fichier>();
            //  Fichier Finterface = new Fichier(x, "interface.txt");
            Fichier Fconfig = new Fichier(x, "configuration.txt");
            Journalisation log = new Journalisation(x + Fconfig.Search("DOSSIER-JOURNALISATION="), Fconfig.Search("JOURNALISATION-FILE-HEADER="), Convert.ToBoolean(Fconfig.Search("JOURNALISATION=")), Convert.ToBoolean(Fconfig.Search("REINITIALISER=")));
            Chiffrement chiffrement = new Chiffrement("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%\\²³~{}_±|ôÔÉÈÊÇÙÛÀÂÎéèêçûùàâî`^¸€‚ƒ„…†‡ˆ‰Š‹Œ Ž  ‘’“”•–—˜™š›œžŸ¡£¤¥¦§¨©ª®¯°´µ¶·¸¹º¼½¾¿ÅÆÐ×ØÞå÷\"#&");
            //  Séparation et activation des différentes interface active dans le fichier de configuration
            //  string Linterface = Fconfig.Search("MODULE-ACTIF=");
            //  string[] LinterfaceSplit = Linterface.Split(',');
            //  foreach (string i in LinterfaceSplit) LF.Add(new Fichier(x + Fconfig.Search("DOSSIER-INTERFACE="), i + ".txt"));
            //  for (int i = 0; i < LF.Count; i++) DI.Add(new Display_Interface(LinterfaceSplit[i], Fconfig, SelectF(LinterfaceSplit[i], LF), Finterface));
            /*  foreach (Display_Interface i in DI)
              {
                  log.WriteLine(i.Entete);
                  log.WriteLine(i.Description);
              }
            */
            Console.Clear();
            string message = " ";
            string key = " ";
            while (true)
            {
                Console.Clear();
                log.WriteLine("Message: " + message);
                log.WriteLine("Clé de chiffrement: " + key);
                log.WriteLine("1: Chiffrage\n2: Déchiffrage\n3: Encryptage avec la clé\n4: Décryptage avec la clé\n5: Application du Binarosk\n6: Retrait du Binarosk\n7: Nouvelle clé\n8: Nouveau message");
                string select = log.ReadLine();
                switch (select)
                {
                    case "1": message = chiffrement.Chiffrage(message); break;
                    case "2": message = chiffrement.Dechiffrage(message); break;
                    case "3": message = chiffrement.AddKey(key, message); break;
                    case "4": message = chiffrement.RemoveKey(key, message); break;
                    case "5": message = chiffrement.Binarosk(message, true, true); break;
                    case "6": message = chiffrement.Binarosk(message, false, true); break;
                    case "7": Console.WriteLine("Entrez la nouvelle clé de chiffrement"); key = Console.ReadLine(); break;
                    case "8": Console.WriteLine("Veuillez entrez le nouveau message"); message = Console.ReadLine(); break;
                }
            }

        }/*
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
        }*/
    }
}