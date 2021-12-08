using System;
namespace RKVCRYPT
{

    internal class RKVCRYPTInterface
    {

        /* Logo Entête*/
        public struct logoLoad
        {
            public string L1;
            public string L2;
            public string L3;
            public string L4;
            public string L5;
            public string L6;
        }
        public static string Search(string chaine)
        {
            chaine = Program.configLoad(chaine);
            string[] LV = chaine.Split('=');
            chaine = LV[1];
            return chaine;
        }
        public static void Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6)
        {
            logoLoad log = new logoLoad();
            string custom = Search("LOGO-CUSTOM=");
            string logo = Search("LOGO-ENABLE=");
            if (logo == "true")
            {
                if (custom == "true")
                {
                    log.L1 = Search("L1=");
                    log.L2 = Search("L2=");
                    log.L3 = Search("L3=");
                    log.L4 = Search("L4=");
                    log.L5 = Search("L5=");
                    log.L6 = Search("L6=");
                }
                else
                {
                    log.L1 = "          #";
                    log.L2 = "@....@    #";
                    log.L3 = "(------)  #";
                    log.L4 = "(> ___ <) #";
                    log.L5 = "^^ ~~~ ^^ #";
                    log.L6 = "RKV-CRYPT #";
                }
                L1 = log.L1;
                L2 = log.L2;
                L3 = log.L3;
                L4 = log.L4;
                L5 = log.L5;
                L6 = log.L6;
            }
            else
            {
                L1 = "           ";
                L2 = L1;
                L3 = L1;
                L4 = L1;
                L5 = L1;
                L6 = L1;
            }

        }

        public struct affichage
        {
            public string ligne0;
            public string ligne1;
            public string ligne2;
            public string ligne3;
            public string ligne4;
            public string ligne5;
            public string ligne6;
            public string ligne7;
            public string ligne8;
        }
        public static string print(affichage chaine)
        {
            return chaine.ligne0 + "\n" + chaine.ligne1 + "\n" + chaine.ligne2 + "\n" + chaine.ligne3 + "\n" + chaine.ligne4 + "\n" + chaine.ligne5 + "\n" + chaine.ligne6 + "\n" + chaine.ligne7 + "\n" + chaine.ligne8;
        }

        public static string headAccueil(string L1, string L2, string L3, string L4, string L5, string L6)
        {
            affichage accueil = new affichage();
            accueil.ligne0 = "########################################################################";
            accueil.ligne1 = "# " + L1 + " Interface d'accueil                                      #";
            accueil.ligne2 = "# " + L2 + "                                                          #";
            accueil.ligne3 = "# " + L3 + "                                                          #";
            accueil.ligne4 = "# " + L4 + "                                                          #";
            accueil.ligne5 = "# " + L5 + "                                                          #";
            accueil.ligne6 = "# " + L6 + "                                                          #";
            accueil.ligne7 = "# " + L1 + " ROSKOVA@PROTONMAIL.COM                   ROSKOVA © 2021  #";
            accueil.ligne8 = "########################################################################";
            return print(accueil);
        }
        public static string headInformation(string L1, string L2, string L3, string L4, string L5, string L6)
        {
            affichage info = new affichage();
            info.ligne0 = "########################################################################";
            info.ligne1 = "# " + L1 + " Interface d'information                                  #";
            info.ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                #";
            info.ligne3 = "# " + L4 + " Début du projet: 06-12-2021 16h40                        #";
            info.ligne4 = "# " + L3 + " Dernière version publié: 08-12-2021 01h06                #";
            info.ligne5 = "# " + L5 + " Version du logiciel: 1.0.0                               #";
            info.ligne6 = "# " + L6 + " Github: http://github.com/Roskova/RKV-CRYPT/             #";
            info.ligne7 = "# " + L1 + " ROSKOVA@PROTONMAIL.COM                   ROSKOVA © 2021  #";
            info.ligne8 = "########################################################################";
            return print(info);
        }
        public static void accueil()
        {
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            Console.WriteLine(headAccueil(L1, L2, L3, L4, L5, L6));
        }
        public static void information()
        {
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            Console.WriteLine(headInformation(L1, L2, L3, L4, L5, L6));
        }
        public static void main()
        {
            accueil();
        }
    }
}