using RKVCRYPT.Core;
namespace RKVCRYPT.Core
{
    public class Display
    {
        private string nom;
        private Fichier Finterface;
        public Display(string nom, Fichier Finterface)
        {
            this.nom = nom;
            this.Finterface = Finterface;
        }
        private void BackGroundColor()
        {
            string param = Finterface.Search("INTERFACE-BACKGROUND-COLOR=");
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
        public void Generate()
        {

        }
        private string LineGenerator()
        {
            string op = "";
            string logo = "           ";
            string symbol = Finterface.Search("INTERFACE-LINE-SYMBOL=");
            for (int i = 0; i < LargeurDeLEntete() + Convert.ToInt32(Finterface.Search("INTERFACE-MARGIN=")) * 2 + 2 + logo.Length; i++)
            {
                op += symbol;
            }
            if (op.Length > LargeurDeLEntete())
            {
                op = op.Remove(LargeurDeLEntete() + Convert.ToInt32(Finterface.Search("INTERFACE-MARGIN=")) * 2 + 2 + logo.Length);
            }
            return op;
        }
        public string Marge(bool sens)
        {
            string op = "";
            string symbol = Finterface.Search("INTERFACE-LINE-SYMBOL=");
            int wide = Convert.ToInt32(Finterface.Search("INTERFACE-MARGIN="));
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
        public string AlignementGauche(string chaine)
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
        public string AlignementGaucheDroite(string chaine1, string chaine2)
        {
            if (Finterface.Search("INTERFACE-ROSKOVA-CYRILIC=").EndsWith("true"))
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
        public string AlignementDroite(string chaine)
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
        public string AlignementCentrage(string chaine)
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
        private string EnTete(string chaine, int number, string[] marge)
        {
            string[] logo = { "           ", "@....@     ", "(------)   ", "(> ___ <)  ", "^^ ~~~ ^^  ", "RKV-CRYPT  ", "           ", "           ", "           " };
            string op = "";
            string alignement = Finterface.Search($"{chaine}-ALIGNEMENT=");
            Console.WriteLine(marge[0]);
            for (int i = 1; i < number + 1; i++)
            {

                if (alignement.Length == number)
                {
                    switch (alignement[i - 1])
                    {
                        case 'D': op += marge[1] + logo[i - 1] + AlignementDroite(CodeAssembler(Finterface.Search($"{chaine}{i}="))) + marge[2] + "\n"; break;
                        case 'C': op += marge[1] + logo[i - 1] + AlignementCentrage(CodeAssembler(Finterface.Search($"{chaine}{i}="))) + marge[2] + "\n"; break;
                        case 'G': op += marge[1] + logo[i - 1] + AlignementGauche(CodeAssembler(Finterface.Search($"{chaine}{i}="))) + marge[2] + "\n"; break;
                        case 'S': op += marge[1] + logo[i - 1] + AlignementGaucheDroite(CodeAssembler(Finterface.Search($"{chaine}{i}=")), "") + marge[2] + "\n"; break;
                    }
                    CodeAssembler(Finterface.Search($"{chaine}{i}="));
                }
            }

            return op + marge[0];
        }
        private string CodeAssembler(string chaine)
        {
            string[] tp = chaine.Split("|");
            if (tp.Length == 3)
            {
                switch (tp[1])
                {
                    case "v": tp[1] = Finterface.Search("PROGRAM-VERSION="); break;
                }
                chaine = tp[0] + tp[1] + tp[2];
            }
            return chaine;
        }
        //Calcule la largeur de l'interface en fonction du contenu du fichier de interface.txt
        private int LargeurDeLEntete()
        {
            int MaxLine = 0;
            List<string> x = Finterface.Print();
            for (int i = 0; i < x.Count; i++)
            {
                if (x[i].StartsWith("#"))
                {
                    x[i] = "";
                }
                if (Finterface.Search(x[i]).Length > MaxLine)
                {
                    MaxLine = Finterface.Search(x[i]).Length;
                }
            }
            MaxLine += Convert.ToInt32(Finterface.Search("INTERFACE-OVER-LENGTH="));
            return MaxLine;
        }
    }
}