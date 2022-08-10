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
    }
}