using System.Text;

namespace RKVCRYPT
{
    class Program
    {
        public static string configLoad(string op)
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
                string[] configFalse = {
                    "MESSAGE-SELECTEUR-INVALIDE=Veuillez sélectionnée une option valide",
                    "MESSAGE-SELECTEUR-OPTION=1: Crypter 2: Décrypter 3: Information du logiciel Q: Quitter",
                    "MESSAGE-DECRYPT-FORMAT=Veuillez entrer le nom de la table de chiffrement",
                    "MESSAGE-DECRYPT=Veuillez entrer votre message à décrypter",
                    "MESSAGE-MK-INPUT=Veuillez entrer le format de MK",
                    "MESSAGE-MK-FORMAT=",
                    "MESSAGE-KEY-INPUT=Veuillez entrer la | NOMBRE |e clé de chiffrement:",
                    "MESSAGE-CRYPT=Veuillez entrer votre message à crypter",
                    "INVALIDE-MK-FORMAT=Méthode de chiffrement invalide",
                    "INVMESSAGE-OPTION=L'option que vous avez sélectionnée n'existe pas",
                    "LOGO-ENABLE=true",
                    "LOGO-CUSTOM=true",
                    "L1=          #",
                    "L2=@....@    #",
                    "L3=(------)  #",
                    "L4=(> ___ <) #",
                    "L5=^^ ~~~ ^^ #",
                    "L6=RKV-CRYPT #",
                    "CESAR3-ENABLE=false",
                    "CESAR3-KEY=CFL",
                    "MK-CONFIG-OVERPASS=false",
                    "MK-DEFAULT=N-R-K-R-H-K-R-L",
                    "NUM-FORMAT=nu3",
                    "PROGRAM-CONFIG-ENABLE=true",
                    "PROGRAM-VERSION=Release 1.0.1.7"
                };
                for (int i = 0; i < configFalse.Length; i++)
                {
                    if (configFalse[i].StartsWith(op))
                    {
                        return configFalse[i];
                    }
                }
            }
            return op;
        }
        public static string Search(string chaine)
        {
            chaine = configLoad(chaine);
            string[] LV = chaine.Split('=');
            chaine = LV[1];
            return chaine;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RKVCRYPTInterface.main();
        }
    }
}
