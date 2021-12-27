using System.Text;


namespace RKVCRYPT
{
    internal class Config
    {
        //Permet de récupéré le fichier de configuration des tables de chiffrements
        public static string table(string op)
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
                string[] p = { "nu1¬ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.'",
                    "nu2¬ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%²³~{}_±|ÉÈÊÇÙÛÀÂÎÔ`^¸€‚©°¶÷",
                    "nu3¬abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%²³~{}_±|ÉÈÊÇÙÛÀÂÎéèêçûùàâîôÔ`^¸€‚ƒ„…†‡ˆ‰Š‹Œ Ž  ‘’“”•–—˜™š›œžŸ¡£¤¥¦§¨©ª®¯°´µ¶·¸¹º¼½¾¿ÅÆÐ×ØÞå÷",
                    "nu4¬abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 ,.';:()«»+-/#*[]=<>?!$¢@%²³~{}_±|ôÔÉÈÊÇÙÛÀÂÎéèêçûùàâî`^¸€‚ƒ„…†‡ˆ‰Š‹Œ Ž  ‘’“”•–—˜™š›œžŸ¡£¤¥¦§¨©ª®¯°´µ¶·¸¹º¼½¾¿ÅÆÐ×ØÞå÷АаБбВвГгДдЕеЁёЖжЗзИиЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщЪъЫыЬьЭэЮюЯя
",
                    "NUM-FORMAT=nu3",
                    "LOGO-ENABLE=true",
                    "LOGO-CUSTOM=true", "L1=           ", "L2=@....@     ", "L3=(------)   ", "L4=(> ___ <)  ", "L5=^^ ~~~ ^^  ", "L6=RKV-CRYPT  ", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide", "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter", "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement", "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter", "MESSAGE-MK-INPUT=Veuillez entrer le format de MK", "MESSAGE-MK-FORMAT-INVALIDE=Méthode de chiffrement invalide", "MESSAGE-MK-FORMAT=", "MESSAGE-KEY-INPUT=Veuillez entrer la |NOMBRE|e clé de chiffrement:", "MESSAGE-CRYPT=Veuillez entrer votre message à crypter", "MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter", "MESSAGE-AFFICHAGE-INPUT=Message d'origine: ", "MESSAGE-AFFICHAGE-RESULTAT=Résultat: ", "MESSAGE-OPTION-INVALIDE=L'option que vous avez sélectionnée n'existe pas" };
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
        public static void ConfigCreate()
        {
            StreamWriter log;
            if (File.Exists(@"config.txt"))
            {
            }
            else
            {
                string path = @"config.txt";
                using FileStream fs = File.Create(@"config.txt");
                log = File.AppendText(@"config.txt");
                string configuration = "RKV-CRYPT";
                log.Write(configuration);
            }
        }
        //Permet de vérifier la présence d'une ligne dans le fichier config.txt
        public static string Verification(string op)
        {
            //ConfigCreate();
            bool enable = false;
            string path = Path.Combine(Environment.CurrentDirectory, @"config.txt");
            if (File.Exists(path))
            {
                string[] config = System.IO.File.ReadAllLines(path);
                for (int i = 0; i < config.Length; i++)
                {
                    if (config[i].StartsWith("PROGRAM-CONFIG-ENABLE="))
                    {
                        if (config[i].EndsWith("true"))
                        {
                            enable = true;
                            i = config.Length;
                        }
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
                    string[] p = { "PROGRAM-CONFIG-ENABLE=true", "PROGRAM-VERSION=Release 1.0.2  ", "PROGRAM-CONSOLE-TITLE=RKV-CRYPT", "MK-DEFAULT=N", "NUM-FORMAT=nu3", "LOGO-ENABLE=true", "LOGO-CUSTOM=true", "L1=           ", "L2=@....@     ", "L3=(------)   ", "L4=(> ___ <)  ", "L5=^^ ~~~ ^^  ", "L6=RKV-CRYPT", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide", "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter", "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement", "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter", "MESSAGE-MK-INPUT=Veuillez entrer le format de MK", "MESSAGE-MK-FORMAT-INVALIDE=Méthode de chiffrement invalide", "MESSAGE-MK-FORMAT=", "MESSAGE-KEY-INPUT=Veuillez entrer la |NOMBRE|e clé de chiffrement:", "MESSAGE-CRYPT=Veuillez entrer votre message à crypter", "MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter", "MESSAGE-AFFICHAGE-INPUT=Message d'origine: ", "MESSAGE-AFFICHAGE-RESULTAT=Résultat: ", "MESSAGE-OPTION-INVALIDE=L'option que vous avez sélectionnée n'existe pas" };
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
                string[] p = {"PROGRAM-CONFIG-ENABLE=true","PROGRAM-VERSION=Release 1.0.2  ","PROGRAM-CONSOLE-TITLE=RKV-CRYPT","MK-DEFAULT=N","NUM-FORMAT=nu3","LOGO-ENABLE=true","LOGO-CUSTOM=true","L1=           ","L2=@....@     ","L3=(------)   ","L4=(> ___ <)  ","L5=^^ ~~~ ^^  ", "L6=RKV-CRYPT  ", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide","MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter","MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement","MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter","MESSAGE-MK-INPUT=Veuillez entrer le format de MK","MESSAGE-MK-FORMAT-INVALIDE=Méthode de chiffrement invalide","MESSAGE-MK-FORMAT=","MESSAGE-KEY-INPUT=Veuillez entrer la |NOMBRE|e clé de chiffrement:",                "MESSAGE-CRYPT=Veuillez entrer votre message à crypter","MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter","MESSAGE-AFFICHAGE-INPUT=Message d'origine: ","MESSAGE-AFFICHAGE-RESULTAT=Résultat: ","MESSAGE-OPTION-INVALIDE=L'option que vous avez sélectionnée n'existe pas" };
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
        //Recherche et renvoie le contenu d'un paramètre présent dans le fichier de configuration.
        public static string Search(string chaine)
        {
            chaine = Verification(chaine);
            string[] LV = chaine.Split('=');
            chaine = LV[1];
            return chaine;
        }
        //Configure les paramètres par défault de la Console
        public static void Console()
        {
            System.Console.BackgroundColor = ConsoleColor.Black;
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.CursorVisible = true;
            System.Console.Title = Config.Search("PROGRAM-CONSOLE-TITLE=") + " " + Config.Search("PROGRAM-VERSION=");

            System.Console.OutputEncoding = Encoding.UTF8;
        }
    }
}