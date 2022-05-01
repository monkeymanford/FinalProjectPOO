namespace Projet
{
    public class Epargne : Compte
    {
        private const double tauxInteret = 1.25;

        public Epargne()
        {
            
        }

        public Epargne(int numeroCompte, double solde) : base(numeroCompte, solde)
        {

        }

        public void PaiementInterets()
        {
            setSolde(getSolde() * tauxInteret);
        }


    }
}