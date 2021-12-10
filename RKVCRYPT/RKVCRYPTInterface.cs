using System;
namespace RKVCRYPT
{
    internal class RKVCRYPTInterface
    {
        public struct logoLoad
        {
            public string L1;
            public string L2;
            public string L3;
            public string L4;
            public string L5;
            public string L6;
        }       
        public static void Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6)
        {
            logoLoad log = new logoLoad();
            string custom = Program.Search("LOGO-CUSTOM=");
            string logo = Program.Search("LOGO-ENABLE=");
            if (logo == "true")
            {
                if (custom == "true")
                {
                    log.L1 = Program.Search("L1=");
                    log.L2 = Program.Search("L2=");
                    log.L3 = Program.Search("L3=");
                    log.L4 = Program.Search("L4=");
                    log.L5 = Program.Search("L5=");
                    log.L6 = Program.Search("L6=");
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

        public static void accueil()
        {
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage accueil = new affichage();
            accueil.ligne0 = "########################################################################";
            accueil.ligne1 = "# " + L1 + " Interface d'accueil                                      #";
            accueil.ligne2 = "# " + L2 + "                                                          #";
            accueil.ligne3 = "# " + L3 + "                                                          #";
            accueil.ligne4 = "# " + L4 + "                                                          #";
            accueil.ligne5 = "# " + L5 + "                                                          #";
            accueil.ligne6 = "# " + L6 + "                                                          #";
            accueil.ligne7 = "# " + L1 + " ROSKOVA@PROTONMAIL.COM                   Роскова © 2021  #";
            accueil.ligne8 = "########################################################################";
            Console.WriteLine(print(accueil));
        }
        public static void information()
        {
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage info = new affichage();
            info.ligne0 = "########################################################################";
            info.ligne1 = "# " + L1 + " Interface d'information de RKV-CRYPT                     #";
            info.ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                #";
            info.ligne3 = "# " + L3 + " Début du projet: 06-12-2021 16h40                        #";
            info.ligne4 = "# " + L4 + " Dernière version publié: 09-12-2021 22h30                #";
            info.ligne5 = "# " + L5 + " Version du logiciel: 1.0.1.3                             #";
            info.ligne6 = "# " + L6 + " Github: http://github.com/Roskova/RKV-CRYPT/             #";
            info.ligne7 = "# " + L1 + " ROSKOVA@PROTONMAIL.COM                   Роскова © 2021  #";
            info.ligne8 = "########################################################################";
            Console.WriteLine(print(info));
        }
        public static void cryptage()
        {
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage cryptage = new affichage();
            cryptage.ligne0 = "########################################################################";
            cryptage.ligne1 = "# " + L1 + " Interface du module de cryptage                          #";
            cryptage.ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                #";
            cryptage.ligne3 = "# " + L3 + " FONCTION MK ACTIVÉ: N = numération du message            #";
            cryptage.ligne4 = "# " + L4 + "    N-R-H-L-K        L = Lecture du Binarosky             #";
            cryptage.ligne5 = "# " + L5 + " K = Applique un clé H = Transforme en Hexadécimal        #";
            cryptage.ligne6 = "# " + L6 + " R = Transforme en binarosk le message chiffré            #";
            cryptage.ligne7 = "# " + L1 + " ROSKOVA@PROTONMAIL.COM                   Роскова © 2021  #";
            cryptage.ligne8 = "########################################################################";
            Console.WriteLine(print(cryptage));
        }
        public static void decryptage()
        {
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage cryptage = new affichage();
            cryptage.ligne0 = "########################################################################";
            cryptage.ligne1 = "# " + L1 + " Interface du module de décryptage                        #";
            cryptage.ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                #";
            cryptage.ligne3 = "# " + L3 + " FONCTION MK ACTIVÉ: N = Inverse la numération            #";
            cryptage.ligne4 = "# " + L4 + "                     L = Inverse la lecture du Binarosk   #";
            cryptage.ligne5 = "# " + L5 + "                                                          #";
            cryptage.ligne6 = "# " + L6 + "                                                          #";
            cryptage.ligne7 = "# " + L1 + " ROSKOVA@PROTONMAIL.COM                   Роскова © 2021  #";
            cryptage.ligne8 = "########################################################################";
            Console.WriteLine(print(cryptage));
        }
        public static void InterfaceDaccueil()
        {
            bool k = false;
            Console.Clear();
            accueil();
            Console.WriteLine(Program.Search("MESSAGE-SELECTEUR-OPTION="));
            while(!k)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D1)
                {
                    RKVCRYPTCryptage.main();
                }
                else if (key == ConsoleKey.D2)
                {
                    RKVCRYPTDeCryptage.main();
                }
                else if (key == ConsoleKey.D3)
                {
                    information();
                }
                else if (key == ConsoleKey.Q)
                {
                    int exit = Convert.ToInt32("banane");
                }
                else
                {
                    Console.Clear();
                    accueil();
                    Console.WriteLine(Program.Search("MESSAGE-SELECTEUR-INVALIDE="));
                    Console.WriteLine(Program.Search("MESSAGE-SELECTEUR-OPTION="));
                }
            }
            
        }
        public static void main()
        {
            InterfaceDaccueil();
        }
    }
}