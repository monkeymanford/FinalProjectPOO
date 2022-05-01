namespace Projet
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string username;
        private string numeroNIP;
        private Cheque compteCheque;
        private Epargne compteEpargne;

        // l'objet client contient de données pour les numéros de comptes si ces comptes sont disponibles
        // si le client ne détient pas ce type de compte, la valeur demeure null

        //private int numeroCompteEpargne;
        //private int numeroCompteCheque;

        public Client(string prenom, string nom, string username, string numeroNIP)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.numeroNIP = numeroNIP;
        }

        // getters and setters

        public string getUser() => username;
        public string getNIP() => numeroNIP;

        public void SetCompteEpargne(Epargne compteEpargne)
        {
            this.compteEpargne = compteEpargne;
        }

        public void SetCompteCheque(Cheque compteCheque)
        {
            this.compteCheque = compteCheque;
        }

        public Epargne GetCompteEpargne()
        {
            return compteEpargne;
        }

        public Cheque GetCompteCheque()
        {
            return compteCheque;
        }

    }
}