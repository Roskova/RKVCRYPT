using System.Text;
namespace RKVCRYPT
{
    internal class Config
    {
        //Permet de récupéré le fichier de configuration des tables de chiffrements
        public static string Table(string op)
        {
            if (File.Exists(@"table.txt"))
            {
                string path = Path.Combine(Environment.CurrentDirectory, @"table.txt");
                string[] config = System.IO.File.ReadAllLines(path);
                for (int i = 0; i < config.Length; i++)
                {
                    if (config[i].StartsWith(op))
                    {
                        return config[i];
                    }
                }
            }
            else
            {
                string[] config = { "nu1¬ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.'", "nu2¬ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%²³~{}_±|ÉÈÊÇÙÛÀÂÎÔ`^¸€‚©°¶÷", "nu3¬abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%²³~{}_±|ÉÈÊÇÙÛÀÂÎéèêçûùàâîôÔ`^¸€‚ƒ„…†‡ˆ‰Š‹Œ Ž  ‘’“”•–—˜™š›œžŸ¡£¤¥¦§¨©ª®¯°´µ¶·¸¹º¼½¾¿ÅÆÐ×ØÞå÷", "nu4¬abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%²³~{}_±|ôÔÉÈÊÇÙÛÀÂÎéèêçûùàâî`^¸€‚ƒ„…†‡ˆ‰Š‹Œ Ž  ‘’“”•–—˜™š›œžŸ¡£¤¥¦§¨©ª®¯°´µ¶·¸¹º¼½¾¿ÅÆÐ×ØÞå÷АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя", "bin=1000-0100-0010-0001-1100-0011-1011-1101-1001-0110", "hex=0000-0001-0010-0011-0100-0101-0110-0111-1000-1001-1010-1011-1100-1101-1110-1111", "hev=0-1-2-3-4-5-6-7-8-9-A-B-C-D-E-F" };
                for (int i = 0; i < config.Length; i++)
                {
                    if (config[i].StartsWith(op))
                    {
                        return config[i];
                    }
                }
            }
            return op;
        }
        //Permet de vérifier la présense d'une ligne dans le fichier de configuration et renvoie la ligne
        public static string Verification(string op)
        {
            bool enable = false;
            string path = Path.Combine(Environment.CurrentDirectory, @"C:\Users\Utilisateur\Documents\Github (Hors-ligne)\RKVCRYPT\RKVCRYPT\config.txt");
            if (File.Exists(path))
            {
                string[] config = System.IO.File.ReadAllLines(path);
                for (int i = 0; i < config.Length; i++)
                {
                    if (config[i].StartsWith("PROGRAM-CONFIG-ENABLE=") && config[i].EndsWith("true"))
                    {
                        enable = true;
                        i = config.Length;
                    }
                }
                if (enable)
                {
                    for (int i = 0; i < config.Length; i++)
                    {
                        if (config[i].StartsWith(op))
                        {
                            return config[i];
                        }
                    }
                }
                else
                {
                    string[] p = { "PROGRAM-CONFIG-ENABLE=true", "PROGRAM-VERSION=Release 1.0.2.1", "PROGRAM-CONSOLE-TITLE=RKV-CRYPT", "MK-DEFAULT=N", "NUM-FORMAT=nu3", "LOGO-ENABLE=true", "LOGO-CUSTOM=true", "L1=           ", "L2=@....@     ", "L3=(------)   ", "L4=(> ___ <)  ", "L5=^^ ~~~ ^^  ", "L6=RKV-CRYPT", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide", "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter", "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement", "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter", "MESSAGE-MK-INPUT=Veuillez entrer le format de MK", "MESSAGE-MK-FORMAT-INVALIDE=Méthode de chiffrement invalide", "MESSAGE-MK-FORMAT=", "MESSAGE-KEY-INPUT=Veuillez entrer la |NOMBRE|e clé de chiffrement:", "MESSAGE-CRYPT=Veuillez entrer votre message à crypter", "MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter", "MESSAGE-AFFICHAGE-INPUT=Message d'origine: ", "MESSAGE-AFFICHAGE-RESULTAT=Résultat: ", "MESSAGE-OPTION-INVALIDE=L'option que vous avez sélectionnée n'existe pas" };
                    config = p;
                    for (int i = 0; i < config.Length; i++)
                    {
                        if (config[i].StartsWith(op))
                        {
                            return config[i];
                        }
                    }
                }
            }
            else
            {
                string[] p = { "PROGRAM-CONFIG-ENABLE=true", "PROGRAM-VERSION=Release 1.0.2.1", "PROGRAM-CONSOLE-TITLE=RKV-CRYPT", "MK-DEFAULT=N", "NUM-FORMAT=nu3", "LOGO-ENABLE=true", "LOGO-CUSTOM=true", "L1=           ", "L2=@....@     ", "L3=(------)   ", "L4=(> ___ <)  ", "L5=^^ ~~~ ^^  ", "L6=RKV-CRYPT  ", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide", "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter", "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement", "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter", "MESSAGE-MK-INPUT=Veuillez entrer le format de MK", "MESSAGE-MK-FORMAT-INVALIDE=Méthode de chiffrement invalide", "MESSAGE-MK-FORMAT=", "MESSAGE-KEY-INPUT=Veuillez entrer la |NOMBRE|e clé de chiffrement:", "MESSAGE-CRYPT=Veuillez entrer votre message à crypter", "MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter", "MESSAGE-AFFICHAGE-INPUT=Message d'origine: ", "MESSAGE-AFFICHAGE-RESULTAT=Résultat: ", "MESSAGE-OPTION-INVALIDE=L'option que vous avez sélectionnée n'existe pas" };
                string[] config = p;
                for (int i = 0; i < config.Length; i++)
                {
                    if (config[i].StartsWith(op))
                    {
                        return config[i];
                    }
                }
            }
            return op;
        }

        public static void CreateConfigFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(docPath, @".\RKVCRYPT\Config\config.txt");
            if (File.Exists(path))
            {
                if (Interface_Utils.VerificationMiseAJour())
                {
                    Console.WriteLine("Fichier config.txt déjà créer.\nFichier Interface.txt à jour");
                    Console.Clear();
                }
                else
                {
                /*    Console.WriteLine("Fichier config.txt déjà créer. \nFichier Corrumpu\nVeuillez corriger le fichier et/ou Mettre à jour celui-ci.\nAppuyez sur n'importe quelle touche pour continuer");
                    Console.ReadKey();*/
                    Console.Clear();
                }
            }
            else
            {
                string[] lines = { "##########################################################################", "# FICHIER DE CONFIGURATION DE RKV-CRYPT PAR ROSKOVA 1.0.2.3 2022-01-05   #", "# Ce fichier permet de configurer les différents composants de RKV-CRYPT #", "# This file is used to configure the different components of RKV-CRYPT   #", "##########################################################################", "# Configuration lier aux informations logicielles de RKV-CRYPT           #", "# Active la prise en charge du fichier de configuration                  #", "# Lorsque désactivées, les configurations par défaut seront utilisées    #", "##########################################################################", "PROGRAM-CONFIG-ENABLE=true", "PROGRAM-VERSION=EnDéveloppement", "PROGRAM-CONSOLE-TITLE=RKV-CRYPT", "PROGRAM-LOCK-MESSAGE=Programme verrouiller, Veuillez entrez le mot de passes:", "##########################################################################", "# Active la prise en charge du cryptage par décalage CESAR3              #", "# rendant le code plus difficile à lire https://roskova.ca/CESAR3        #", "# LORSQU’ACTIVÉ, LE LOGICIEL RKV-CRYPT DISTANT DOIT AVOIR LA MÊME CLÉ    #", "##########################################################################", "CESAR3-ENABLE=false", "CESAR3-KEY=CFL", "##########################################################################", "# Configuration du système de gestion de chiffrement MK (MasterKey)      #", "# REGEX CORRESPONDANT: /^[RBLNPKCH](-[RBLNPKCH])*$/                      #", "# FORMAT DE NUMÉRISATION, CHAQUE NIVEAU INCLUT LE PRÉCÉDENT              #", "# L'utilisation de nu1 prend uniquement en charge lettres et chiffre.    #", "# L'utilisation de nu2 permet la prise en charge des spéciaux et accent. #", "# L'utilisation de nu3 permet la prise en charge des majuscules.         #", "# L'utilisation de nu4 permet la prise en charge du cyrillique.          #", "##########################################################################", "MK-CONFIG-OVERPASS=false", "MK-DEFAULT=N", "NUM-FORMAT=nu3", "##########################################################################", "# Personnalisation du logo RKV-CRYPT 6x11                                #", "##########################################################################", "LOGO-ENABLE=true", "LOGO-CUSTOM=true", "L1=", "L2=@....@", "L3=(------)", "L4=(> ___ <)", "L5=^^ ~~~ ^^", "L6=RKV-CRYPT", "##########################################################################", "# MESSAGE D'ERREUR ET MESSAGE GÉNÉRAL                                    #", "##########################################################################", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide", "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter", "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement", "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter", "MESSAGE-MK-INPUT=Veuillez entrer le format de MK", "MESSAGE-MK-FORMAT-INVALIDE=Méthode de chiffrement invalide", "MESSAGE-MK-FORMAT=", "MESSAGE-KEY-INPUT=Veuillez entrer la |NOMBRE|e clé de chiffrement:", "MESSAGE-CRYPT=Veuillez entrer votre message à crypter", "MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter", "MESSAGE-AFFICHAGE-INPUT=Message d'origine: ", "MESSAGE-AFFICHAGE-RESULTAT=Résultat: ", "MESSAGE-OPTION-INVALIDE=L'option que vous avez sélectionnée n'existe pas", };
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @".\RKVCRYPT\Config\config.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
                Console.WriteLine("Fichier config.txt créer et à jour");
            }

        }
        //Recherche et renvoie le contenu d'un paramètre présent dans le fichier de configuration.
        public static string Search(string chaine)
        {
            chaine = Verification(chaine);
            string[] LV = chaine.Split('=');
            chaine = LV[1];
            return chaine;
        }
        //Configure les paramètres par défault de la console
        public static void ParamConsole()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.CursorVisible = true;
            System.Console.Title = Config.Search("PROGRAM-CONSOLE-TITLE=") + " " + Config.Search("PROGRAM-VERSION=");
            System.Console.OutputEncoding = Encoding.UTF8;
        }
    }
}