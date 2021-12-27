namespace RKVCRYPT
{
    internal class Interface
    {
        private readonly string v = Config.Search("PROGRAM-VERSION=");
        public struct logo
        {
            public string L1; public string L2; public string L3; public string L4; public string L5; public string L6;
        }
        public static void Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6)
        {
            logo log = new logo();
            string custom = Config.Search("LOGO-CUSTOM=");
            string logo = Config.Search("LOGO-ENABLE=");
            if (logo == "true")
            {
                if (custom == "true")
                {
                    log.L1 = Config.Search("L1="); log.L2 = Config.Search("L2="); log.L3 = Config.Search("L3="); log.L4 = Config.Search("L4="); log.L5 = Config.Search("L5="); log.L6 = Config.Search("L6=");
                }
                else
                {
                    log.L1 = "          #"; log.L2 = "@....@    #"; log.L3 = "(------)  #"; log.L4 = "(> ___ <) #"; log.L5 = "^^ ~~~ ^^ #"; log.L6 = "RKV-CRYPT #";
                }
                L1 = log.L1; L2 = log.L2; L3 = log.L3; L4 = log.L4; L5 = log.L5; L6 = log.L6;
            }
            else
            {
                L1 = "           "; L2 = L1; L3 = L1; L4 = L1; L5 = L1; L6 = L1;
            }
        }
        public struct affichage
        {
            public string ligne0; public string ligne1; public string ligne2; public string ligne3; public string ligne4; public string ligne5; public string ligne6; public string ligne7; public string ligne8;
        }
        public static string print(affichage chaine)
        {
            return chaine.ligne0 + "\n" + chaine.ligne1 + "\n" + chaine.ligne2 + "\n" + chaine.ligne3 + "\n" + chaine.ligne4 + "\n" + chaine.ligne5 + "\n" + chaine.ligne6 + "\n" + chaine.ligne7 + "\n" + chaine.ligne8;
        }
        public static void accueil()
        {
            string v = Config.Search("PROGRAM-VERSION=");
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage accueil = new affichage
            {
                ligne0 = "########################################################################",
                ligne1 = "# " + L1 + "                                                          #",
                ligne2 = "# " + L2 + "                     RKV-CRYPT                            #",
                ligne3 = "# " + L3 + "            Cryptage Modulaire par Roskova                #",
                ligne4 = "# " + L4 + "                                                          #",
                ligne5 = "# " + L5 + "                                                          #",
                ligne6 = "# " + L6 + "                                                          #",
                ligne7 = "# " + L1 + " " + v + "                          Роскова © 2021  #",
                ligne8 = "########################################################################"
            };
            Console.WriteLine(print(accueil));
        }
        public static void information()
        {
            string v = Config.Search("PROGRAM-VERSION=");
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage info = new affichage
            {
                ligne0 = "##########################################################################",
                ligne1 = "# " + L1 + " Interface d'information de RKV-CRYPT                       #",
                ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                  #",
                ligne3 = "# " + L3 + " Début du projet: 06-12-2021 16h40                          #",
                ligne4 = "# " + L4 + " Dernière version publié: 28-12-2021 04h 9                  #",
                ligne5 = "# " + L5 + " Version du logiciel: " + v + "                       #",
                ligne6 = "# " + L6 + " Github: http://github.com/Roskova/RKV-CRYPT/               #",
                ligne7 = "# " + L1 + " Email: roskova@protonmail.com              Роскова © 2021  #",
                ligne8 = "##########################################################################"
            };
            Console.WriteLine(print(info));
        }
        public static void cryptage()
        {
            string v = Config.Search("PROGRAM-VERSION=");
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage cryptage = new affichage
            {
                ligne0 = "##########################################################################",
                ligne1 = "# " + L1 + " Interface du module de cryptage                            #",
                ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                  #",
                ligne3 = "# " + L3 + "                                                            #",
                ligne4 = "# " + L4 + "                                                            #",
                ligne5 = "# " + L5 + "                                                            #",
                ligne6 = "# " + L6 + "                                                            #",
                ligne7 = "# " + L1 + " " + v + "                            Роскова © 2021  #",
                ligne8 = "##########################################################################"
            };
            Console.WriteLine(print(cryptage));
        }
        public static void decryptage()
        {
            string v = Config.Search("PROGRAM-VERSION=");
            Console.Clear();
            Logo(out string L1, out string L2, out string L3, out string L4, out string L5, out string L6);
            affichage cryptage = new affichage
            {
                ligne0 = "##########################################################################",
                ligne1 = "# " + L1 + " Interface du module de décryptage                          #",
                ligne2 = "# " + L2 + " RKV-CRYPT: Cryptage Modulaire par Roskova                  #",
                ligne3 = "# " + L3 + "                                                            #",
                ligne4 = "# " + L4 + "                                                            #",
                ligne5 = "# " + L5 + "                                                            #",
                ligne6 = "# " + L6 + "                                                            #",
                ligne7 = "# " + L1 + " " + v + "                            Роскова © 2021  #",
                ligne8 = "##########################################################################"
            };
            Console.WriteLine(print(cryptage));
        }
        public static void InterfaceDaccueil()
        {
            bool k = false;
            Console.Clear();
            accueil();
            Console.WriteLine(Config.Search("MESSAGE-SELECTEUR-OPTION="));
            while (!k)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D1)
                {
                    Cryptage.main();
                }
                else if (key == ConsoleKey.D2)
                {
                    Decryptage.main();
                }
                else if (key == ConsoleKey.D3)
                {
                    information();
                }
                else if (key == ConsoleKey.Q)
                {
                    int exit = Convert.ToInt32("");
                }
                else
                {
                    Console.Clear();
                    accueil();
                    Console.WriteLine(Config.Search("MESSAGE-SELECTEUR-INVALIDE=") + "\n" + Config.Search("MESSAGE-SELECTEUR-OPTION="));
                }
            }
        }
        public static void main()
        {
            InterfaceDaccueil();
        }
    }
}