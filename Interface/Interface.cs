namespace Interface
{
    public class Interface
    {
        private string entete;
        public Interface()
        {
            this.entete = "";
        }
        public string Entete
        {
            get { return this.entete; }
            set { this.entete = value; }
        }
    }
}