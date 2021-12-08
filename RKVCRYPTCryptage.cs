using System;
namespace RKVCRYPT
{
    class RKVCRYPTCryptage
    {
        /* 
             * MÉTHODE DE CHIFFREMENT 
             *                  # #   #     # 
             * FORMAT VOULU IP> N-R-K-R-H-K-R-L
             * EXÉCUTE Key B K D INPUT--> A DEVIENT 01 DEVIENT 01101000 DEVIENT 03121202
             * DEVIENT 01100010100001001000010001100100 DEVIENT 62848464 DEVIENT 00110100110100011101000100110001
             * DEVIENT 11221211221211122212111211221112
             # R BINAROSK 1 = 1000 2 = 0100 3 = 0010 4 = 0001 5 = 1100 6 = 0011 7 = 1011 8 = 1101 9 = 1001 0 = 0110
             * B CONVERSION EN BINAIRE
             * L LECTURE DU BINARY 01101000 = 1021101130
             # N CONVERSION EN CHIFFRE
             * P CONVERSION EN LETTRE
             * K Key de chiffrement en numérique.
             * C KEY DE CESAR3 DE 3-5 CARACTÈRE DE LONG RESPECTANT LE FORMAT DE TEST CFL. 
             * H CONVERSION EN HEXADÉCIMAL
        */
        public static string espacement(string chaine)
        {
            for (int i = 0; i < chaine.Length - 1; i++)
            {
                i++;
                chaine = chaine.Insert(i, "¬");

            }
            return chaine;
        }
        public static string binarosk(string chaine)
        {
            string tabRef = table("bin¬");
            tabRef = tabRef.Remove(0, 4);
            string[] tab = tabRef.Split('¬');
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
            Console.ReadKey();
            string output = "";
            for (int i = 0; i < bin.Length; i++)
            {
                output += bin[i];
            }
            return output;
        }
        public static string table(string op)
        {
            string[] config = System.IO.File.ReadAllLines(@"C:\Users\Utilisateur\Documents\Github (Hors-ligne)\RKVCRYPT\table.txt");
            for (int i = 0; i < config.Length; i++)
            {
                if (config[i].StartsWith(op))
                {
                    return config[i];
                }
            }
            return op;
        }
        public static string Num(string chaine)
        {
            if(Program.Search("NUM-FORMAT=") == "nu3" || Program.Search("NUM-FORMAT=") == "nu4")
            {
                string nu = "nu3";
                if(Program.Search("NUM-FORMAT=")== "nu4")
                {
                    nu = "nu4";
                }
                string tabRef = table(nu);
                tabRef = tabRef.Remove(0, 3);
                string[] tab = tabRef.Split('¬');
                string[] tab2 = new string[tabRef.Length];
                for (int i = 1; i < tab.Length + 1; i++)
                {
                    if (i < 100)
                    {

                        if (i < 10)
                        {
                            tab2[i] = "00" + (i);
                        }
                        else
                        {
                            tab2[i] = "0" + i;
                        }
                    }
                    else
                    {
                        {

                            if (i < 110 && i >= 100)
                            {
                                tab2[i] = "" + (i);
                            }
                            else
                            {
                                tab2[i] = "" + i;
                            }
                        }
                    }
                }
                for (int i = 0; i < tab.Length; i++)
                {
                    Console.Write("\t" + tab[i] + " " + tab2[i]);
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
                string output = "";
                for (int i = 0; i < numC.Length; i++)
                {
                    output += numC[i];
                }
                return output;
            }
            else if (Program.Search("NUM-FORMAT=") == "nu1")
            {
                string tabRef = table("nu1¬");
                tabRef = tabRef.Remove(0, 3);
                string[] tab = tabRef.Split('¬'); //Tableau de caractères
                string[] tab2 = new string[tabRef.Length];
                for (int i = 1; i < tab.Length + 1; i++)
                {
                    if (i < 100)
                    {

                        if (i < 10)
                        {
                            tab2[i] = "0" + (i);
                        }
                        else
                        {
                            tab2[i] = "" + i;
                        }
                    }
                    else
                    {
                        {

                            if (i < 110 && i >= 100)
                            {
                                tab2[i] = "" + (i);
                            }
                            else
                            {
                                tab2[i] = "" + i;
                            }
                        }
                    }
                }
                for (int i = 0; i < tab.Length; i++)
                {
                    Console.Write("\t" + tab[i] + " " + tab2[i]);
                }
                string ch = espacement(chaine);
                string[] numC = ch.Split('¬');
                for (int i = 0; i < numC.Length; i++)
                {
                    bool correspond = false;
                    for (int j = 0; j < tab.Length; j++)
                    {
                        
                        if (numC[i] == tab[j])
                        {
                            correspond = true;
                        }
                    }
                    if (!correspond)
                    {
                        numC[i] = "";
                    }
                }

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
                string output = "";
                for (int i = 0; i < numC.Length; i++)
                {
                    output += numC[i];
                }
                return output;
            }
            else
            {
                string tabRef = table("nu2¬");
                tabRef = tabRef.Remove(0, 3);
                string[] tab = tabRef.Split('¬');
                string[] tab2 = new string[tabRef.Length];
                for (int i = 1; i < tab.Length + 1; i++)
                {
                    if (i < 10)
                    {
                        tab2[i] = "0" + (i);
                    }
                    else
                    {
                        tab2[i] = "" + i;
                    }
                }
                /*for (int i = 0; i < tab.Length; i++)
                {
                    Console.Write("\t"+tab[i]+" " + tab2[i]);
                }*/
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
                string output = "";
                for (int i = 0; i < numC.Length; i++)
                {
                    output += numC[i];
                }
                return output;
            }
        }
        public static string Message()
        {
            Console.WriteLine(Program.Search("TXT-MESSAGE="));
            string message = Console.ReadLine();
            if (message.Length >= 0)
            {
                if(Program.Search("NUM-FORMAT=") == "nu3" || Program.Search("NUM-FORMAT=") == "nu4") {
                    return message;
                }
                else
                {
                    return message.ToUpper();
                }
            }
            return "Erreur";
        }
        public static void gestionMK()
        {
            string invmessageMK = Program.Search("INVALIDE-FORMAT-MK=");
            Console.WriteLine(Program.Search("MESSAGE-INPUT-MK="));
            string mk = Console.ReadLine().ToUpper();
            if (mk.Length != 0)
            {
                mk = Num(mk);
                Console.WriteLine(mk);
            }
            else
            {
                Console.WriteLine(invmessageMK);
            }
        }
        public static void affichage(string chaine, string num, string input)
        {
            Console.Clear();
            RKVCRYPTInterface.information();
            Console.WriteLine("Message d'origine: "+input+"\n" + "Chiffrage: " + num+"\n"+"Résultat: " + chaine);
        }
        public static void main()
        {
            //gestionMK();
            string input = Message();
            string num = Num(input);
            string bin = binarosk(num);
            affichage(bin, num, input);
        }
    }
}