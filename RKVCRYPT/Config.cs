using System.Text;

namespace RKVCRYPT
{
    class Config
    {
        //Permet de récupéré le fichier de configuration des tables de chiffrements
        public static string table(string op)
        {
            string path = Path.Combine(Environment.CurrentDirectory, @"ref\table.txt");
            string[] config = System.IO.File.ReadAllLines(path);
            for (int i = 0; i < config.Length; i++)
            {
                if (config[i].StartsWith(op))
                {
                    return config[i];
                }
            }
            return op;
        }
        //Permet de vérifier la présence d'une ligne dans le fichier config.txt
        public static string verification(string op)
        {
            bool enable = false;
            string path = Path.Combine(Environment.CurrentDirectory, @"ref\config.txt");
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
                string[] p = { "PROGRAM-CONSOLE-TITLE=RKV-CRYPT", "MESSAGE-AFFICHAGE-QUITTER=Appuyez sur Q pour quitter", "MESSAGE-AFFICHAGE-INPUT=Message d'origine:", "MESSAGE-AFFICHAGE-RESULTAT=Résultat:", "PROGRAM-CONFIG-ENABLE=true", "PROGRAM-VERSION=Release 1.0.1.7", "MK-CONFIG-OVERPASS=false", "MK-DEFAULT=N-R-K-R-H-K-R-L", "NUM-FORMAT=nu3", "CESAR3-ENABLE=false", "CESAR3-KEY=CFL", "LOGO-ENABLE=true", "LOGO-CUSTOM=true", "L1=          #", "L2=@....@    #", "L3=(------)  #", "L4=(> ___ <) #", "L5=^^ ~~~ ^^ #", "L6=RKV-CRYPT #", "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide", "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter", "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement", "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter", "MESSAGE-MK-INPUT=Veuillez entrer le format de MK", "MESSAGE-MK-FORMAT=", "MESSAGE-KEY-INPUT=Veuillez entrer la | NOMBRE |e clé de chiffrement:", "MESSAGE-CRYPT=Veuillez entrer votre message à crypter", "INVALIDE-MK-FORMAT=Méthode de chiffrement invalide", "INVMESSAGE-OPTION=L'option que vous avez sélectionnée n'existe pas" };
                config = p;
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
            chaine = verification(chaine);
            string[] LV = chaine.Split('=');
            chaine = LV[1];
            return chaine;
        }
        //Configure les paramètres par défault de la Console
        public static void console()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
            Console.Title = Config.Search("PROGRAM-CONSOLE-TITLE=") + " " + Config.Search("PROGRAM-VERSION=");
            Console.SetWindowSize(75, 25);
            Console.SetBufferSize(10000, 250);
            Console.OutputEncoding = Encoding.UTF8;
        }
    }
}