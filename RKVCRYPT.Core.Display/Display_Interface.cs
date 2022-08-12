using RKVCRYPT.Core.GestionFichier;

namespace RKVCRYPT.Core.Interface
{
    public class Display_Interface : Display
    {
        private Fichier Lf;
        private string nom;
        private int nbLigneEntete;
        private string alignement;
        private string description;
        private string entete;
        private List<string> Lentete; //Contient l'entête extraite du contenu du fichier
        private List<string> Lcontenu; //Contient le contenu du fichier
        public Display_Interface(string nom, Fichier Lf, Fichier LInterface) : base(nom, LInterface)
        {
            this.nom = nom;
            this.Lf = Lf;
            this.nbLigneEntete = 0;
            this.description = "Nom de l'interface: " + Lf.Search("NAME=") + "\n" + "Auteur du fichier: " + Lf.Search("AUTHOR=") + "\n" + "Version: " + Lf.Search("VERSION=") + "\n" + "Module parent: " + Lf.Search("ASSOCIATE-MODULE=") + "\n" + "Description: " + Lf.Search("DESCRIPTION=") + "\n";
            this.alignement = Lf.Search("ALIGNEMENT=");
            this.Lentete = new List<string>();
            this.Lcontenu = new List<string>();
            Lcontenu = Lf.Print;
            entete = ExtractEntete();
        }
        public string ExtractEntete()
        {
            int debut = Convert.ToInt32(Lf.Search("LIGNE-DEBUT-ENTETE=")) - 1;
            int fin = Convert.ToInt32(Lf.Search("LIGNE-FIN-ENTETE="));
            nbLigneEntete = fin - debut;
            for (int i = debut; i < fin; i++)
            {
                Lentete.Add(Lcontenu[i]);
            }
            return base.EnTete(Lentete, alignement, nbLigneEntete);
        }
        public string Nom
        {
            get { return nom; }
        }
        public string Description
        {
            get { return description; }
        }
        public string Entete
        {
            get { return entete; }
        }

    }
}
