namespace Projet
{
    public class Client
    {
        private string nom;
        private string prenom;
        private string username;
        private string numeroNIP;

        public Client(string prenom, string nom, string username, string numeroNIP)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.username = username;
            this.numeroNIP = numeroNIP;
        }

        public string getUser() => username;
        public string getNIP() => numeroNIP;

    }
}