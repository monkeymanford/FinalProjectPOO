namespace Projet
{
    public class Guichet
    {
        private Client client;
        private CompteCheque comptecheque;
        private CompteEpargne compteEpargne;


        public bool ValiderUtilisateur(string nom, int nip)
        {
            return true;
        }

        public double RetraitCheque(double montant, int nip)
        {

        }

        public double RetraitEpargne(double montant, int nip)
        {

        }

        public double DepotCheque(double montant, int nip)
        {

        }

        public double DepotEpargne(double montant, int nip)
        {
            
        }

    }
}