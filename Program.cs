using System;
using System.IO;
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
                if (config[i].StartsWith("ENABLE-CONFIG="))
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
                    "LOGO-ENABLE=true",
                    "LOGO-CUSTOM=false",
                    "NUM-FORMAT=nu2",
                    "CESAR3-ENABLE=false",
                    "CESAR3-KEY=CFL",
                    "MK-OVERPASS-CONFIG=false",
                    "MK-DEFAULT=N-R-K-R-H-K-R-L",
                    "MESSAGE-INPUT-MK=Veuillez entrer le Format MK",
                    "INVALIDE-FORMAT-MK=Méthode de chiffrement invalide",
                    "TXT-MESSAGE=Veuillez entrer votre message à crypter"
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
        static void Decryptage()
        {
            RKVCRYPTDeCryptage.main();
        }
        static void Cryptage()
        {
            RKVCRYPTCryptage.main();
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            RKVCRYPTInterface.main();
        }
    }
}
