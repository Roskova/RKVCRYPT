using System.Text.RegularExpressions;

namespace RKVCRYPT
{
    internal class Cryptage
    {
        //Permet de récupéré le nom de la table de chiffrement à utilisé dans le config.txt
        public static string Format()
        {
            string nu = Config.Search("NUM-FORMAT=");
            return nu;
        }
        //Divise une chaine de caractère en sous-chaine d'une longueur donnée
        public static string Substring(int nb, string chaine)
        {
            for (int i = 0; i < chaine.Length - nb; i++)
            {
                i = i + nb;
                chaine = chaine.Insert(i, "¬");
            }
            return chaine;
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
        //Lecture du binaire 11100 --> 3120
        public static string Lecture(string chaine)
        {
            chaine = chaine.Replace('0', 'A').Replace('1', 'B');
            chaine = chaine.Replace("AAAAAA", "60").Replace("AAAAA", "50").Replace("AAAA", "40").Replace("AAA", "30").Replace("AA", "20").Replace("A", "10");
            chaine = chaine.Replace("BBBBBB", "61").Replace("BBBBB", "51").Replace("BBBB", "41").Replace("BBB", "31").Replace("BB", "21").Replace("B", "11");
            return chaine;
        }
        // Permet de récupéré la table de chiffrement
        public static string Cutter(char sym, string op)
        {
            string nu = Config.Table(op);
            string[] lv = nu.Split(sym);
            nu = lv[1];
            return nu;
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
        //Converti la table de chiffrement en tableau de string[]
        public static void ConvTable(out string[] tab, out string[] tab2)
        {
            string nu = Format();
            string table = Cutter('¬', nu);
            string tabC = Espacement(table);
            tab = tabC.Split('¬');
            tab2 = new string[tabC.Length];
            if (table.Length >= 100 && table.Length < 1000)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (i < 100)
                    {
                        if (i < 10)
                        {
                            tab2[i] = "00" + (i + 1);
                        }
                        else
                        {
                            tab2[i] = "0" + (i + 1);
                        }
                    }
                    else
                    {
                        tab2[i] = "" + i;
                    }
                }
            }
            else if (tab.Length >= 1000)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (i < 100)
                    {
                        if (i < 10)
                        {
                            tab2[i] = "000" + (i + 1);
                        }
                        else if (i < 100)
                        {
                            tab2[i] = "00" + (i + 1);
                        }
                        else
                        {
                            tab2[i] = "0" + (i + 1);
                        }
                    }
                    else
                    {
                        tab2[i] = "" + i;
                    }
                }
            }
            else
            {
                for (int i = 0; i < tab.Length; i++)
                {

                    if (i < 10)
                    {
                        tab2[i] = "0" + (i + 1);
                    }
                    else
                    {
                        tab2[i] = "" + (i + 1);
                    }
                }
            }
        }
        //Convertie un chaine binaraire en Hexadécimal
        public static string Hex(string chaine)
        {
            chaine = Substring(4, chaine);
            string tabRef = Cutter('=', "hev=");
            string[] tab = tabRef.Split('-');
            string[] bin = chaine.Split('¬');
            for (int i = 0; i < bin.Length; i++)
            {
                switch (bin[i])
                {
                    case "0000": bin[i] = tab[0]; break;
                    case "0001": bin[i] = tab[1]; break;
                    case "0010": bin[i] = tab[2]; break;
                    case "0011": bin[i] = tab[3]; break;
                    case "0100": bin[i] = tab[4]; break;
                    case "0101": bin[i] = tab[5]; break;
                    case "0110": bin[i] = tab[6]; break;
                    case "0111": bin[i] = tab[7]; break;
                    case "1000": bin[i] = tab[8]; break;
                    case "1001": bin[i] = tab[9]; break;
                    case "1010": bin[i] = tab[10]; break;
                    case "1011": bin[i] = tab[11]; break;
                    case "1100": bin[i] = tab[12]; break;
                    case "1101": bin[i] = tab[13]; break;
                    case "1110": bin[i] = tab[14]; break;
                    case "1111": bin[i] = tab[15]; break;
                }
            }
            string output = "";
            for (int i = 0; i < bin.Length; i++)
            {
                output += bin[i];
            }
            return output;
        }
        public static string Binarosk(string chaine)
        {
            string tabRef = Cutter('=', "bin=");
            string[] tab = tabRef.Split('-');
            chaine = Espacement(chaine);
            string[] bin = chaine.Split('¬');
            for (int i = 0; i < bin.Length; i++)
            {
                switch (bin[i])
                {
                    case "1": bin[i] = tab[0]; break;
                    case "2": bin[i] = tab[1]; break;
                    case "3": bin[i] = tab[2]; break;
                    case "4": bin[i] = tab[3]; break;
                    case "5": bin[i] = tab[4]; break;
                    case "6": bin[i] = tab[5]; break;
                    case "7": bin[i] = tab[6]; break;
                    case "8": bin[i] = tab[7]; break;
                    case "9": bin[i] = tab[8]; break;
                    case "0": bin[i] = tab[9]; break;
                }
            }
            string output = "";
            for (int i = 0; i < bin.Length; i++)
            {
                output += bin[i];
            }
            return output;
        }
        public static string Num(string chaine)
        {
            ConvTable(out string[] tab, out string[] tab2);
            string ch = Espacement(chaine);
            string[] numC = ch.Split('¬');
            for (int j = 0; j < numC.Length; j++)
            {
                for (int i = 0; i < tab.Length; i++)
                {
                    if (numC[j] == tab[i])
                    {
                        numC[j] = tab2[i];
                    }
                }
            }
            //Recompose la chaine
            string output = "";
            for (int i = 0; i < numC.Length; i++)
            {
                output += numC[i];
            }
            return output;
        }
        public static string Lettre(string chaine)
        {
            //Tab = Table Lettre tab2 = Table chiffre
            ConvTable(out string[] tab, out string[] tab2);
            if (Contain('a', Cutter('¬', Format())) && Contain('A', Cutter('¬', Format())))
            {
                chaine = Substring(3, chaine);
            }
            else
            {
                chaine = Substring(2, chaine);
            }
            //Module de lettrage
            string[] numC = chaine.Split('¬');
            for (int j = 0; j < numC.Length; j++)
            {
                for (int i = 0; i < tab2.Length; i++)
                {
                    if (numC[j] == tab2[i])
                    {
                        numC[j] = tab[i];
                    }
                }
            }
            //Recompose la chaine
            string output = "";
            for (int i = 0; i < numC.Length; i++)
            {
                output += numC[i];
            }
            return output;
        }
        public static string Key(string chaine, int nb)
        {
            Affichage();
            string messageKeyInput = Config.Search("MESSAGE-KEY-INPUT=");
            string[] y = messageKeyInput.Split('|');
            messageKeyInput = y[0] + nb + y[2];
            Console.WriteLine(messageKeyInput);
            string key = Binarosk(Num(Console.ReadLine()));
            chaine = Binarosk(Num(chaine));
            if (key.Length < chaine.Length)
            {
                while (key.Length < chaine.Length)
                {
                    key += key;
                }
            }
            key = key.Insert(chaine.Length, "¬");
            string[] keyS = key.Split('¬');
            key = keyS[0];
            string[] k = Espacement(key).Split('¬');
            string[] e = Espacement(chaine).Split('¬');
            for (int i = 0; i < chaine.Length; i++)
            {
                if (e[i] == "0" && k[i] == "0")
                {
                    e[i] = "0";
                }
                else if (e[i] == "1" && k[i] == "0")
                {
                    e[i] = "1";
                }
                if (e[i] == "0" && k[i] == "1")
                {
                    e[i] = "1";
                }
                if (e[i] == "1" && k[i] == "1")
                {
                    e[i] = "2";
                }
            }
            //Recombine la chaine
            string output = "";
            for (int i = 0; i < chaine.Length; i++)
            {
                output += e[i];
            }
            return output;
        }
        public static string GestionMK(string message)
        {
            string pattern = @"^[RBLNPKCH](-[RBLNPKCH])*$";
            string input = Config.Search("MK-DEFAULT=");
            Match mk = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (mk.Success)
            {
                string[] mkformat = input.Split('-');
                for (int i = 0; i < mkformat.Length; i++)
                {
                    switch (mkformat[i])
                    {
                        //case "R": message = binarosk(message); break;
                        case "N": message = Num(message); break;
                            // case "H": message = hex(message); break;
                            //case "K": keynb++; message = key(message, keynb); break;
                            //case "P": message = Lettre(message); break;
                            //case "L": message = Lecture(message); break;
                    }
                }
            }
            return message;
        }
        public static string Message()
        {
            Affichage();
            Console.WriteLine(Config.Search("MESSAGE-CRYPT="));
            string message = Console.ReadLine();
            if (message.Length >= 0)
            {
                if (Contain('a', Cutter('¬', Format())) && Contain('A', Cutter('¬', Format())))
                {
                    return message;
                }
                else
                {
                    return message.ToUpper();
                }
            }
            return "";
        }
        public static void AffichageOutput(string input, string chaine)
        {
            Affichage();
            Console.WriteLine(Config.Search("MESSAGE-AFFICHAGE-INPUT=") + input + "\n" + Config.Search("MESSAGE-AFFICHAGE-RESULTAT=") + chaine);
            Console.WriteLine(Config.Search("MESSAGE-AFFICHAGE-QUITTER="));
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                Interface.InterfaceAccueil();
            }
            else
            {
                Cryptage.Fonction();
            }
        }
        public static void Affichage()
        {
            Console.Clear();
            Interface.InterfaceCryptage();
        }
        public static void Fonction()
        {
            string input = Message();
            string chaine = GestionMK(input);
            AffichageOutput(input, chaine);
        }
    }
}