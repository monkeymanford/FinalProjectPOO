namespace Projet
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string username;
        private string numeroNIP;

        public Client(string nom, string prenom, string username, string numeroNIP)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.numeroNIP = numeroNIP;
        }
    }
}