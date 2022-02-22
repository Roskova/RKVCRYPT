namespace RKVCRYPT
{
    /*
     * Ce fichier contient des fonctions indispensable à l'éxécution du module d'interface.
     * 
     * 
     */
    class Interface_Utils
    {
        private string line = "";
        //Prends en charge les balise | | pour l'affichage de fonction.
        public static string CodeAssembler(string chaine)
        {
            string[] tp = chaine.Split("|");
            if (tp.Length == 3)
            {
                switch (tp[1])
                {
                    case "v": tp[1] = Config.Search("PROGRAM-VERSION="); break;
                }
                chaine = tp[0] + tp[1] + tp[2];
            }
            return chaine;
        }
        //Génère les lignes des entêtes.
        public static string LineGenerator()
        {
            if(line.Length > 0)
            {
                return line;
            }
            else
            {
                string op = "";
                string logo = "           ";
                string symbol = Search("INTERFACE-LINE-SYMBOL=");
                for (int i = 0; i < LargeurDeLEntete() + Convert.ToInt32(Search("INTERFACE-MARGIN=")) * 2 + 2 + logo.Length; i++)
                {
                    op += symbol;
                }
                if (op.Length > LargeurDeLEntete())
                {
                    op = op.Remove(LargeurDeLEntete() + Convert.ToInt32(Search("INTERFACE-MARGIN=")) * 2 + 2 + logo.Length);
                }
                line = op;
                return line;
            }
        }
        //Vérifie si le fichier interface.txt correspond à la dernière version publier.
        public static bool VerificationMiseAJour()
        {
            int nombreLigneValider = 0;
            string[] lines = { "##########################################################################", "# FICHIER DE CONFIGURATION DES INTERFACES DE RKV-CRYPT	     Version 1.1 #", "# Ce fichier permet de configurer les différents interfaces de RKV-CRYPT #", "##########################################################################", "INTERFACE-CONFIG-ENABLE=true", "##########################################################################", "# Personnalisation des interfaces de RKV-CRYPT                           #", "# CODE COULEUR: 0=Noire 1=Blanc 2=Bleu 3=Green 4=Rouge 5=Jaune           #", "# FORMAT: 01 (0 Backgroundcolor, 1 foregroundcolor)			 #", "##########################################################################", "INTERFACE-BACKGROUND-COLOR=", "INTERFACE-LINE-SYMBOL=", "INTERFACE-ROSKOVA-CYRILIC=true", "INTERFACE-LIST=ACCUEIL,CRYPTAGE, DECRYPTAGE", "##########################################################################", "# Configuration du menu d'accueil de RKV-CRYPT                           #", "##########################################################################", "INTERFACE-ALIGNEMENT=CENTRE", "INTERFACE-NAME=ACCUEIL", "ACCUEIL-L1=", "ACCUEIL-L2=RKV-CRYPT", "ACCUEIL-L3=Cryptage Modulaire par Roskova", "ACCUEIL-L4=", "ACCUEIL-L5=", "ACCUEIL-L6=", "ACCUEIL-L7=|v|", "##########################################################################", "# Configuration du menu de cryptage de RKV-CRYPT                         #", "##########################################################################", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "CRYPTAGE-L1=Interface du module de cryptage", "CRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "CRYPTAGE-L3=", "CRYPTAGE-L4=", "CRYPTAGE-L5=", "CRYPTAGE-L6=", "CRYPTAGE-L7=|v|", "##########################################################################", "# Configuration du menu de cryptage de RKV-CRYPT                         #", "##########################################################################", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "DECRYPTAGE-L1=Interface du module de Décryptage", "DECRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "DECRYPTAGE-L3=", "DECRYPTAGE-L4=", "DECRYPTAGE-L5=", "DECRYPTAGE-L6=", "DECRYPTAGE-L7=|v|", "##########################################################################", "# Configuration du menu d'information de RKV-CRYPT                       #", "##########################################################################", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "DECRYPTAGE-L1=Interface d'information de RKV-CRYPT", "DECRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "DECRYPTAGE-L3=Début du projet: 06-12-2021 16h40", "DECRYPTAGE-L4=Dernière version publié: 01-01-2022 01h49", "DECRYPTAGE-L5=Version du logiciel: |v|", "DECRYPTAGE-L6=Github: http://github.com/Roskova/RKV-CRYPT/", "DECRYPTAGE-L7=|v|" };
            string op = "";
            string[] config = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"RKVCRYPT\Config\interface.txt"));
            for (int i = 0; i < config.Length; i++)
            {
                string ip = Interface_Utils.Verification(lines[i]);
                string[] LO = ip.Split('=');
                ip = LO[0];
                op = Interface_Utils.Verification(config[i]);
                string[] LV = op.Split('=');
                op = LV[0];
                if (ip == op)
                {
                    nombreLigneValider++;
                    //Console.WriteLine($"({i+1}/{config.Length}) valide");
                }
                /*else
                {
                    Console.WriteLine($"Ligne {i + 1}: {op} Invalide");
                }*/
            }
            if (nombreLigneValider == config.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Permet de vérifier la présence d'une ligne dans le fichier Interface.txt
        public static bool VerificationPresence(string chaine)
        {
            bool rep = false;
            string[] config = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"RKVCRYPT\Config\interface.txt"));
            for (int i = 0; i < config.Length; i++)
            {
                if (config[i].StartsWith(chaine))
                {
                    rep = true;
                }
            }
            return rep;
        }
        //Permet de généré la marge avant et arrière de l'entête.
        public static string Marge(bool sens)
        {
            string op = "";
            string symbol = Search("INTERFACE-LINE-SYMBOL=");
            int wide = Convert.ToInt32(Search("INTERFACE-MARGIN="));
            for (int i = 0; i < wide; i++)
            {
                op += " ";
            }
            if (sens)
            {
                op += symbol[0];
            }
            else
            {
                op = symbol[0] + op;
            }
            return op;

        }
        //Permet d'aligner le texte à gauche
        public static string AlignementGauche(string chaine)
        {
            int total = LargeurDeLEntete();
            if (chaine.Length % 2 == 1)
            {
                chaine += " ";
            }
            int op = total - chaine.Length;
            string marge = "";
            for (int i = 0; i < op; i++)
            {
                marge += " ";
            }
            chaine += marge;
            return chaine;
        }
        //Permet d'aligner le texte à gauche avec le Copyright à droite.
        public static string AlignementGaucheDroite(string chaine1, string chaine2)
        {
            if (Search("INTERFACE-ROSKOVA-CYRILIC=").EndsWith("true"))
            {

                chaine2 = "Роскова © 2022";
            }
            else
            {
                chaine2 = "Roskova © 2022";
            }
            int total = LargeurDeLEntete();
            if ((chaine1.Length + chaine2.Length) % 2 == 1)
            {
                chaine1 += " ";
            }
            int op = total - (chaine1.Length + chaine2.Length);
            string marge = "";
            for (int i = 0; i < op; i++)
            {
                marge += " ";
            }
            chaine1 = chaine1 + marge + chaine2;
            return chaine1;
        }
        //Permet d'aligner le texte à droite
        public static string AlignementDroite(string chaine)
        {
            int total = LargeurDeLEntete();
            if (chaine.Length % 2 == 1)
            {
                chaine += " ";
            }
            int op = total - chaine.Length;
            string marge = "";
            for (int i = 0; i < op; i++)
            {
                marge += " ";
            }
            chaine = marge + chaine;
            return chaine;
        }
        //Permet d'aligner le texte au centre
        public static string AlignementCentrage(string chaine)
        {
            int total = LargeurDeLEntete();
            if (chaine.Length % 2 == 1)
            {
                chaine += " ";
            }
            int op = (total - chaine.Length) / 2;
            string marge = "";
            for (int i = 0; i < op; i++)
            {
                marge += " ";
            }
            chaine = marge + chaine + marge;
            return chaine;
        }
        //Calcule la largeur de l'interface en fonction du contenu du fichier de interface.txt
        public static int LargeurDeLEntete()
        {
            int MaxLine = 0;
            string[] config = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"RKVCRYPT\Config\interface.txt"));
            for (int i = 0; i < config.Length; i++)
            {
                if (config[i].StartsWith("#"))
                {
                    config[i] = "";
                }
                if (Search(config[i]).Length > MaxLine)
                {
                    MaxLine = Search(config[i]).Length;
                }
            }
            MaxLine += Convert.ToInt32(Search("INTERFACE-OVER-LENGTH="));
            return MaxLine;
        }
        //Permet de rechercher une chaine dans le fichier interface.txt
        public static string Search(string chaine)
        {
            chaine = Verification(chaine);
            string[] LV = chaine.Split('=');
            if (LV.Length > 1)
            {
                chaine = LV[1];
            }
            else
            {
                chaine = "";
            }
            return chaine;
        }
        //Vérifie et renvoie une ligne donnée
        public static string Verification(string op)
        {
            bool enable = false;
            string[] config = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"RKVCRYPT\Config\interface.txt"));
            if (!enable)
            {
                for (int i = 0; i < config.Length; i++)
                {
                    if (config[i].StartsWith("INTERFACE-CONFIG-ENABLE=") && config[i].EndsWith("true"))
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
                string[] p = { "INTERFACE-CONFIG-ENABLE=false", "INTERFACE-BACKGROUND-COLOR=", "INTERFACE-LINE-SYMBOL=", "INTERFACE-ROSKOVA-CYRILIC=true", "INTERFACE-ALIGNEMENT=CENTRE", "INTERFACE-NAME=ACCUEIL", "ACCUEIL-L1=", "ACCUEIL-L2=RKV-CRYPT", "ACCUEIL-L3=Cryptage Modulaire par Roskova", "ACCUEIL-L4=", "ACCUEIL-L5=", "ACCUEIL-L6=", "ACCUEIL-L7=|v|", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "CRYPTAGE-L1=Interface du module de cryptage", "CRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "CRYPTAGE-L3=", "CRYPTAGE-L4=", "CRYPTAGE-L5=", "CRYPTAGE-L6=", "CRYPTAGE-L7=|v|", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "DECRYPTAGE-L1=Interface du module de Décryptage", "DECRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "DECRYPTAGE-L3=", "DECRYPTAGE-L4=", "DECRYPTAGE-L5=", "DECRYPTAGE-L6=", "DECRYPTAGE-L7=|v|", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "DECRYPTAGE-L1=Interface d'information de RKV-CRYPT", "DECRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "DECRYPTAGE-L3=Début du projet: 06-12-2021 16h40", "DECRYPTAGE-L4=Dernière version publié: 01-01-2022 01h49", "DECRYPTAGE-L5=Version du logiciel: |v|", "DECRYPTAGE-L6=Github: http://github.com/Roskova/RKV-CRYPT/", "DECRYPTAGE-L7=|v|" };
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
    }
}