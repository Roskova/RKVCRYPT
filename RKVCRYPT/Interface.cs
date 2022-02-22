namespace RKVCRYPT
{
    class Interface
    {
        public static void InterfaceBackgroundColor()
        {
            string param = Interface_Utils.Search("INTERFACE-BACKGROUND-COLOR=");
            switch (param[0])
            {
                case '0': Console.BackgroundColor = ConsoleColor.Black; break;
                case '1': Console.BackgroundColor = ConsoleColor.DarkBlue; break;
                case '2': Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                case '3': Console.BackgroundColor = ConsoleColor.DarkCyan; break;
                case '4': Console.BackgroundColor = ConsoleColor.DarkRed; break;
                case '5': Console.BackgroundColor = ConsoleColor.DarkMagenta; break;
                case '6': Console.BackgroundColor = ConsoleColor.DarkYellow; break;
                case '7': Console.BackgroundColor = ConsoleColor.Gray; break;
                case '8': Console.BackgroundColor = ConsoleColor.DarkGray; break;
                case '9': Console.BackgroundColor = ConsoleColor.Blue; break;
                case 'a': Console.BackgroundColor = ConsoleColor.Green; break;
                case 'b': Console.BackgroundColor = ConsoleColor.Cyan; break;
                case 'c': Console.BackgroundColor = ConsoleColor.Red; break;
                case 'd': Console.BackgroundColor = ConsoleColor.Magenta; break;
                case 'e': Console.BackgroundColor = ConsoleColor.Yellow; break;
                case 'f': Console.BackgroundColor = ConsoleColor.White; break;
                default: Console.BackgroundColor = ConsoleColor.Black; break;
            }
            switch (param[1])
            {
                case '0': Console.ForegroundColor = ConsoleColor.Black; break;
                case '1': Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                case '2': Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                case '3': Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                case '4': Console.ForegroundColor = ConsoleColor.DarkRed; break;
                case '5': Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                case '6': Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                case '7': Console.ForegroundColor = ConsoleColor.Gray; break;
                case '8': Console.ForegroundColor = ConsoleColor.DarkGray; break;
                case '9': Console.ForegroundColor = ConsoleColor.Blue; break;
                case 'a': Console.ForegroundColor = ConsoleColor.Green; break;
                case 'b': Console.ForegroundColor = ConsoleColor.Cyan; break;
                case 'c': Console.ForegroundColor = ConsoleColor.Red; break;
                case 'd': Console.ForegroundColor = ConsoleColor.Magenta; break;
                case 'e': Console.ForegroundColor = ConsoleColor.Yellow; break;
                case 'f': Console.ForegroundColor = ConsoleColor.White; break;
                default: Console.ForegroundColor = ConsoleColor.White; break;
            }
        }
        public static void InterfaceRegister(out string[] InList, out int[] InListLength)
        {

            string[] config = System.IO.File.ReadAllLines(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), @"RKVCRYPT\Config\interface.txt"));
            string list = Interface_Utils.Search("INTERFACE-LIST=");
            InList = list.Split(",");
            InListLength = new int[InList.Length];
            int t = 1;

            for (int i = 0; i < InList.Length; i++)
            {
                t = 1;
                int count = 0;
                for (int j = 0; j < config.Length; j++)
                {
                    list = InList[i] + t + "=";
                    if (Interface_Utils.VerificationPresence(list) == true)
                    {
                        count++;
                    }
                    t++;
                }
                InListLength[i] = count;
            }
            //Console.WriteLine($"Interface{InList[0]}:{InListLength[0]}\nInterface{InList[1]}:{InListLength[1]}\nInterface{InList[2]}:{InListLength[2]}\n");
        }

        public static string EnTete(string chaine, int number, string[] marge)
        {
            string[] logo = { "           ", "@....@     ", "(------)   ", "(> ___ <)  ", "^^ ~~~ ^^  ", "RKV-CRYPT  ", "           ", "           ", "           " };
            string op = "";
            string alignement = Interface_Utils.Search($"{chaine}-ALIGNEMENT=");
            Console.WriteLine(marge[0]);
            for (int i = 1; i < number + 1; i++)
            {

                if (alignement.Length == number)
                {
                    switch (alignement[i - 1])
                    {
                        case 'D': op += marge[1] + logo[i - 1] + Interface_Utils.AlignementDroite(Interface_Utils.CodeAssembler(Interface_Utils.Search($"{chaine}{i}="))) + marge[2] + "\n"; break;
                        case 'C': op += marge[1] + logo[i - 1] + Interface_Utils.AlignementCentrage(Interface_Utils.CodeAssembler(Interface_Utils.Search($"{chaine}{i}="))) + marge[2] + "\n"; break;
                        case 'G': op += marge[1] + logo[i - 1] + Interface_Utils.AlignementGauche(Interface_Utils.CodeAssembler(Interface_Utils.Search($"{chaine}{i}="))) + marge[2] + "\n"; break;
                        case 'S': op += marge[1] + logo[i - 1] + Interface_Utils.AlignementGaucheDroite(Interface_Utils.CodeAssembler(Interface_Utils.Search($"{chaine}{i}=")), "") + marge[2] + "\n"; break;
                    }
                    Interface_Utils.CodeAssembler(Interface_Utils.Search($"{chaine}{i}="));
                }
            }

            return op + marge[0];
        }
        public static void InterfaceAccueil()
        {
            bool k = false;
            Console.Clear();
            Interface.SelecteurInterface(0);
            Console.WriteLine(Config.Search("MESSAGE-SELECTEUR-OPTION="));
            while (!k)
            {
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.D1)
                {
                    k = true;
                    RKVCRYPT.Cryptage.Fonction();
                }
                else if (key == ConsoleKey.D2)
                {
                    k = true;
                    RKVCRYPT.Decryptage.Fonction();
                }
                else if (key == ConsoleKey.D3)
                {
                    Interface.SelecteurInterface(2);
                }
                else if (key == ConsoleKey.Q)
                {
                    k = true;
                }
                else
                {
                    Interface.SelecteurInterface(0);
                    Console.WriteLine(Config.Search("MESSAGE-SELECTEUR-INVALIDE=") + "\n" + Config.Search("MESSAGE-SELECTEUR-OPTION="));
                }
            }
        }
        public static void CreateInterfaceFile()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string path = Path.Combine(docPath, @".\RKVCRYPT\Config\interface.txt");
            if (File.Exists(path))
            {
                if (Interface_Utils.VerificationMiseAJour())
                {
                    Console.WriteLine("Fichier Interface.txt déjà créer.\nFichier Interface.txt à jour");
                    Console.Clear();
                }
                else
                {
                   /* Console.WriteLine("Fichier Interface.txt déjà créer. \nFichier Corrumpu\nVeuillez corriger le fichier et/ou Mettre à jour celui-ci.\nAppuyez sur n'importe quelle touche pour continuer");
                    Console.ReadKey();*/
                    Console.Clear();
                }
            }
            else
            {
                string[] lines = { "##########################################################################", "# FICHIER DE CONFIGURATION DES INTERFACES DE RKV-CRYPT	     Version 1.1 #", "# Ce fichier permet de configurer les différents interfaces de RKV-CRYPT #", "##########################################################################", "INTERFACE-CONFIG-ENABLE=true", "##########################################################################", "# Personnalisation des interfaces de RKV-CRYPT                           #", "# CODE COULEUR: 0=Noire 1=Blanc 2=Bleu 3=Green 4=Rouge 5=Jaune           #", "# FORMAT: 01 (0 Backgroundcolor, 1 foregroundcolor)			 #", "##########################################################################", "INTERFACE-BACKGROUND-COLOR=", "INTERFACE-LINE-SYMBOL=", "INTERFACE-ROSKOVA-CYRILIC=true", "##########################################################################", "# Configuration du menu d'accueil de RKV-CRYPT                           #", "##########################################################################", "INTERFACE-ALIGNEMENT=CENTRE", "INTERFACE-NAME=ACCUEIL", "ACCUEIL-L1=", "ACCUEIL-L2=RKV-CRYPT", "ACCUEIL-L3=Cryptage Modulaire par Roskova", "ACCUEIL-L4=", "ACCUEIL-L5=", "ACCUEIL-L6=", "ACCUEIL-L7=|v|", "##########################################################################", "# Configuration du menu de cryptage de RKV-CRYPT                         #", "##########################################################################", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "CRYPTAGE-L1=Interface du module de cryptage", "CRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "CRYPTAGE-L3=", "CRYPTAGE-L4=", "CRYPTAGE-L5=", "CRYPTAGE-L6=", "CRYPTAGE-L7=|v|", "##########################################################################", "# Configuration du menu de cryptage de RKV-CRYPT                         #", "##########################################################################", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "DECRYPTAGE-L1=Interface du module de Décryptage", "DECRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "DECRYPTAGE-L3=", "DECRYPTAGE-L4=", "DECRYPTAGE-L5=", "DECRYPTAGE-L6=", "DECRYPTAGE-L7=|v|", "##########################################################################", "# Configuration du menu d'information de RKV-CRYPT                       #", "##########################################################################", "INTERFACE-ALIGNEMENT=DROITE", "INTERFACE-NAME=CRYPTAGE", "DECRYPTAGE-L1=Interface d'information de RKV-CRYPT", "DECRYPTAGE-L2=RKV-CRYPT: Cryptage Modulaire par Roskova", "DECRYPTAGE-L3=Début du projet: 06-12-2021 16h40", "DECRYPTAGE-L4=Dernière version publié: 01-01-2022 01h49", "DECRYPTAGE-L5=Version du logiciel: |v|", "DECRYPTAGE-L6=Github: http://github.com/Roskova/RKV-CRYPT/", "DECRYPTAGE-L7=|v|" };
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, @".\RKVCRYPT\Config\interface.txt")))
                {
                    foreach (string line in lines)
                        outputFile.WriteLine(line);
                }
                Console.WriteLine("Fichier interface.txt créer et à jour");
            }

        }
        public static void SelecteurInterface(int nombre)
        {
            Console.Clear();
           
                string[] marge = { LineGenerator(), Interface_Utils.Marge(false), Interface_Utils.Marge(true) };
                InterfaceRegister(out string[] InList, out int[] InListLength);
                Console.WriteLine(EnTete(InList[nombre], InListLength[nombre], marge));
        }

        public static void Fonction()
        {
            InterfaceAccueil();
        }
    }
}