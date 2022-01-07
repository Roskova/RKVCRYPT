namespace RKVCRYPT
{
    class Utils
    {
        // Permet de récupéré la table de chiffrement
        public static string Cutter(char sym, string op)
        {
            string nu = Config.Table(op);
            string[] lv = nu.Split(sym);
            nu = lv[1];
            return nu;
        }
        //Ajoute des ¬ entre chaque caractère d'une chaine donnée
        public static string Espacement(string chaine)
        {
            for (int i = 0; i < chaine.Length - 1; i++)
            {
                i++;
                chaine = chaine.Insert(i, "¬");
            }
            return chaine;
        }
        //Vérifie si la table contient un caractère spécifier
        public static bool Contain(char op, string chaine)
        {
            bool rep = false;
            for (int i = 0; i < chaine.Length; i++)
            {
                if (chaine[i] == op)
                {
                    rep = true;
                }
            }
            return rep;
        }
        //Affiche le résultat du cryptage
        public static void AffichageOutput(string input, string chaine, int redirection)
        {
            Console.WriteLine(Config.Search("MESSAGE-AFFICHAGE-INPUT=") + input + "\n" + Config.Search("MESSAGE-AFFICHAGE-RESULTAT=") + chaine + "\n" + Config.Search("MESSAGE-AFFICHAGE-QUITTER="));
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                Interface.InterfaceAccueil();
            }
            else
            {
                if(redirection == 0)
                {
                    Cryptage.Fonction();
                }
                else
                {
                    Decryptage.Fonction();
                }
            }
        }
    }
}