namespace Projet
{
    public class Compte
    {
        private int numeroCompte;
        private double soldeCompte;

        public Compte()
        {
            
        }

        public Compte(int numeroCompte, double soldeCompte)
        {
            this.numeroCompte = numeroCompte;
            this.soldeCompte = soldeCompte;
        }

        // getters & setters

        public double getNumCompte() => numeroCompte;
        public double getSolde() => soldeCompte;

        public void Depot(double montant)
        {
            soldeCompte += montant;
        }

        public void Retrait(double montant)
        {
            soldeCompte -= montant;
        }


    }
}