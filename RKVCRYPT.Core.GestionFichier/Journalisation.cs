namespace RKVCRYPT.Core.GestionFichier
{
    public class Journalisation : Fichier
    {
        private string date;
        private bool active;
        private string tempString;
        public Journalisation(string path, string journalisationFileHeader, bool active, bool reset) : base(path, $"{journalisationFileHeader}{DateTime.Today.Year}-{DateTime.Today.Month}-{DateTime.Today.Day}.txt")
        {
            this.tempString = "";
            this.active = active;
            this.date = $"{DateTime.Today}";
            if (active)
            {
                base.Create(reset);
            }
            if (reset)
            {
                base.Delete();
            }
        }
        public void Log(string message)
        {
            if (active)
            {
                base.Write($"[{DateTime.Now}] {message}");
            }
        }
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
            if (active)
            {
                message = message.Replace("\n", "; ").Replace("#", "").Replace("       ", "");
                Log(message);
            }
        }
        public string ReadLine()
        {
            tempString = Console.ReadLine();
            if (active)
            {
                Log(tempString);
            }
            return tempString;
        }
        public string Date
        {
            get { return date; }
        }
    }
}