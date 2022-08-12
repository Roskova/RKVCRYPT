using System.Text;
namespace RKVCRYPT.Core.GestionFichier
{
    public class Fichier
    {
        private string nom;
        private string path;
        private char sym;
        private List<string> contenu;
        public Fichier(string path, string nom)
        {
            this.nom = nom;
            this.path = path;
            this.sym = '=';
            this.contenu = new List<string>();
        }
        public void Create()
        {
            StreamWriter sw = new StreamWriter(path + nom);
            sw.Close();
        }
        public void Write(string message)
        {
            StreamWriter sw = new StreamWriter(path + nom, true, Encoding.UTF8);
            sw.WriteLine(message);
            sw.Close();
        }
        public void Load()
        {
            string line;
            StreamReader sr = new StreamReader(path + nom);
            line = sr.ReadLine();
            while (line != null)
            {
                contenu.Add(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        public string Search(string cible)
        {
            string w = Locate(cible);
            string[] x = w.Split(sym);
            return x[1];
        }
        private string Locate(string cible)
        {
            foreach (string item in contenu)
            {
                if (item.StartsWith(cible))
                {
                    return item;
                }
            }
            return cible;
        }
        public string Nom
        {
            get { return nom; }
        }
        public string Path
        {
            get { return path; }
        }
        public List<string> Print
        {
            get { return contenu; }
        }
    }
}