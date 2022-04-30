namespace Projet
{
    public class Compte
    {
        private int numeroCompte;
        private double soldeCompte;

        public Compte(int numeroCompte, double soldeCompte)
        {
            this.numeroCompte = numeroCompte;
            this.soldeCompte = soldeCompte;
        }

        // getter

        public int getNumCompte() => numeroCompte;

        public void Retrait(double montant)
        {

        }

        public void Depot(double montant)
        {

        }


    }
}