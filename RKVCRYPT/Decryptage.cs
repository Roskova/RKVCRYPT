using System.Text.RegularExpressions;

namespace RKVCRYPT
{
    class RKVCRYPTDeCryptage
    {
        //Permet de récupéré le nom de la table de chiffrement à utilisé dans le config.txt
        public static string format()
        {
            affichage();
            Console.WriteLine(Program.Search("MESSAGE-DECRYPT-FORMAT="));
            string nu = Console.ReadLine();
            if (nu == "")
            {
                nu = "nu3";
            }
            return nu;
        }
        public static string Lecture(string chaine)
        {
            chaine = chaine.Replace("60", "AAAAAA").Replace("50", "AAAAA").Replace("40", "AAAA").Replace("30", "AAA").Replace("20", "AA").Replace("10", "A");
            chaine = chaine.Replace("61", "BBBBBB").Replace("51", "BBBBB").Replace("41", "BBBB").Replace("31", "BBB").Replace("21", "BB").Replace("11", "B");
            chaine = chaine.Replace('A', '0').Replace('B', '1');
            return chaine;
        }
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
        //Converti la table de chiffrement en tableau de string[]
        public static void ConvTable(string format, out string[] tab, out string[] tab2)
        {
            string nu = format;
            string tabC = Cryptage.espacement(Cryptage.cutter('¬', nu));
            tab = tabC.Split('¬');
            tab2 = new string[tabC.Length];
            if (tab.Length >= 100 && tab.Length < 1000)
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
        public static string hex(string chaine)
        {
            chaine = Cryptage.substring(4, chaine);
            string tabRef = Cryptage.cutter('=', "hev=");
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
        public static string binarosk(string chaine)
        {
            string tabRef = Cryptage.cutter('¬', "bin=");
            string[] tab = tabRef.Split('-');
            chaine = Cryptage.espacement(chaine);
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
        public static string Num(string format, string chaine)
        {
            ConvTable(format, out string[] tab, out string[] tab2);
            string ch = Cryptage.espacement(chaine);
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
        public static string Lettre(string format, string chaine)
        {
            //Tab = Table Lettre tab2 = Table chiffre
            ConvTable(format, out string[] tab, out string[] tab2);
            if (Cryptage.contain('a', Cryptage.cutter('¬', format)) && Cryptage.contain('A', Cryptage.cutter('¬', format)))
            {
                chaine = Cryptage.substring(3, chaine);
            }
            else
            {
                chaine = Cryptage.substring(2, chaine);
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
        public static string key(string format, string chaine, int nb)
        {
            string messagekeyinput = Program.Search("MESSAGE-KEY-INPUT=");
            string[] Y = messagekeyinput.Split('|');
            messagekeyinput = Y[0] + nb + Y[2];
            Console.WriteLine(messagekeyinput);
            string key = binarosk(Num(format, Console.ReadLine()));
            chaine = binarosk(Num(format, chaine));
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
            string[] k = Cryptage.espacement(key).Split('¬');
            string[] e = Cryptage.espacement(chaine).Split('¬');
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
            Console.WriteLine(output);
            Console.ReadLine();
            return output;
        }
        public static string gestionMK(string format, string message)
        {
            affichage();
            int keynb = 0;
            string invmessageMK = Program.Search("MESSAGE-MK-FORMAT-INVALIDE=");
            Console.WriteLine(Program.Search("MESSAGE-MK-INPUT="));
            Console.Write(Program.Search("MESSAGE-MK-FORMAT="));
            string pattern = @"^[RBLNPKCH](-[RBLNPKCH])*$";
            string input = Console.ReadLine();
            Match mk = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (mk.Success)
            {
                //input = espacement(input);
                string[] mkformat = input.Split('-');
                for (int i = 0; i < mkformat.Length; i++)
                {
                    switch (mkformat[i])
                    {
                        //case "R": message = binarosk(message); break;
                        //case "N": message = Num(format, message); break;
                        //case "H": message = hex(message); break;
                        //case "K": keynb++; message = key(format, message, keynb); break;
                        case "N": message = Lettre(format, message); break;
                        case "L": message = Lecture(message); break;
                    }
                }
            }
            else
            {
                Console.WriteLine(invmessageMK);
            }
            return message;
        }
        public static string Message(string format)
        {
            affichage();
            Console.WriteLine(Program.Search("MESSAGE-DECRYPT="));
            string message = Console.ReadLine();
            if (message.Length >= 0)
            {
                if (Cryptage.contain('a', Cryptage.cutter('¬', format)) && Cryptage.contain('A', Cryptage.cutter('¬', format)))
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
        public static void affichageOutput(string input, string chaine)
        {
            affichage();
            Console.WriteLine(Program.Search("MESSAGE-AFFICHAGE-INPUT=") + input + "\n" + Program.Search("MESSAGE-AFFICHAGE-RESULTAT=") + chaine);
            Console.WriteLine(Program.Search("MESSAGE-AFFICHAGE-QUITTER="));
            if (Console.ReadKey().Key == ConsoleKey.Q)
            {
                RKVCRYPTInterface.InterfaceDaccueil();
            }
            else
            {
                main();
            }
        }
        public static void affichage()
        {
            Console.Clear();
            RKVCRYPTInterface.decryptage();
        }
        public static void main()
        {
            string num = format();
            string input = Message(num);
            string chaine = gestionMK(num, input);
            affichageOutput(input, chaine);
        }
    }
}