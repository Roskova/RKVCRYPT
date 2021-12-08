using System;
using System.IO;
using System.Text.RegularExpressions;

namespace RKVCRYPT
{
    class RKVCRYPTCryptage
    {
        /* 
             * MÉTHODE DE CHIFFREMENT 
             *                  # #   # #   # 
             * FORMAT VOULU IP> N-R-K-R-H-K-R-L
             * EXÉCUTE Key B K D INPUT--> A DEVIENT 01 DEVIENT 01101000 DEVIENT 03121202
             * DEVIENT 01100010100001001000010001100100 DEVIENT 62848464 DEVIENT 00110100110100011101000100110001
             * DEVIENT 11221211221211122212111211221112
             # R BINAROSK 1 = 1000 2 = 0100 3 = 0010 4 = 0001 5 = 1100 6 = 0011 7 = 1011 8 = 1101 9 = 1001 0 = 0110
             * B CONVERSION EN BINAIRE
             * L LECTURE DU BINAROSK 01101000 = 1021101130
             # N CONVERSION EN CHIFFRE
             * P CONVERSION EN LETTRE
             # K Key de chiffrement en numérique.
             # H CONVERSION EN HEXADÉCIMAL
             * C KEY DE CESAR3 DE 3-5 CARACTÈRE DE LONG RESPECTANT LE FORMAT DE TEST CFL.
        */
        //Permet de récupéré le nom de la table de chiffrement à utilisé dans le config.txt
        public static string format()
        {
            string nu = Program.Search("NUM-FORMAT=");
            return nu;
        }
        public static string substringByFour(string chaine)
        {
            for (int i = 0; i < chaine.Length - 4; i++)
            {
                i++;
                i++;
                i++;
                i++;
                chaine = chaine.Insert(i, "¬");

            }
            return chaine;
        }
        public static string substringByThree(string chaine)
        {
            for (int i = 0; i < chaine.Length - 3; i++)
            {
                i++;
                i++;
                i++;
                chaine = chaine.Insert(i, "¬");

            }
            return chaine;
        }
        //Ajoute des ¬ entre chaque caractère d'une chaine donnée
        public static string espacement(string chaine)
        {
            for (int i = 0; i < chaine.Length - 1; i++)
            {
                i++;
                chaine = chaine.Insert(i, "¬");

            }
            return chaine;
        }
        //Permet de récupéré la table de chiffrement indiquer
        public static string cutter(string op)
        {
            string nu = table(op);
            string[] LV = nu.Split('¬');
            nu = LV[1];
            return nu;
        }
        public static string bincutter(string op)
        {
            string nu = table(op);
            string[] LV = nu.Split('=');
            nu = LV[1];
            return nu;
        }
        //Vérifie si la table contient un caractère spécifier
        public static bool contain(char op, string chaine)
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
        public static string Message()
        {
            Console.WriteLine(Program.Search("TXT-MESSAGE="));
            string message = Console.ReadLine();
            if (message.Length >= 0)
            {
                if (contain('a', cutter(format())) && contain('A', cutter(format())))
                {
                    return message;
                }
                else
                {
                    return message.ToUpper();
                }
            }
            return "Erreur";
        }
        public static string hex(string chaine)
        {
            chaine = substringByFour(chaine);
            string tabRef = bincutter("hev=");
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
            string tabRef = bincutter("bin=");
            string[] tab = tabRef.Split('-');
            chaine = espacement(chaine);
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
            string nu = format();
            string tabC = espacement(cutter(nu));
            string[] tab = tabC.Split('¬');
            string[] tab2 = new string[tabC.Length];
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
            string ch = espacement(chaine);
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
        public static string key(string chaine, int nb)
        {
            string messageinputkey = Program.Search("MESSAGE-INPUT-KEY=");
            string[] Y = messageinputkey.Split('|');
            messageinputkey = Y[0] + nb + Y[2];
            Console.WriteLine(messageinputkey);
            string key = binarosk(Num(Console.ReadLine()));
            chaine = binarosk(Num(chaine));
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
            string[] k = espacement(key).Split('¬');
            string[] e = espacement(chaine).Split('¬');
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
        public static string gestionMK(string message)
        {
            int keynb = 0;
            string invmessageMK = Program.Search("INVALIDE-FORMAT-MK=");
            Console.WriteLine(Program.Search("MESSAGE-INPUT-MK="));
            Console.Write(Program.Search("MESSAGE-FORMAT-MK="));
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
                        case "R": message = binarosk(message); break;
                        case "N": message = Num(message); break;
                        case "H": message = hex(message); break;
                        case "K": keynb++; message = key(message, keynb); break;
                    }
                }
            }
            else
            {
                Console.WriteLine(invmessageMK);
            }
            return message;
        }
        public static void affichageOutput(string input, string chaine)
        {
            Console.Clear();
            RKVCRYPTInterface.information();
            Console.WriteLine("Message d'origine: " + input + "\n" + "Résultat: " + chaine);
        }
        public static void main()
        {
            string input = Message();
            string chaine = gestionMK(input);
            affichageOutput(input, chaine);
        }
    }
}