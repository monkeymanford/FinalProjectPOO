using System;

namespace Projet
{
    public class Guichet
    {
        private Client client;
        private Cheque comptecheque;
        private Epargne compteEpargne;
        private static string saisieUser;
        private static string saisieNIP;


        public bool ValiderUtilisateur(string nom, int nip)
        {
            Console.Clear();
            Console.Write("Veuillez entrer votre nom d'utilisateur: ");
            saisieUser = Console.ReadLine();
            Console.Write("\r\nVeuillez entrer votre NIP: ");
            saisieNIP = Console.ReadLine();

            return true;
        }

        public double RetraitCheque(double montant, int nip)
        {
            return 0;
        }

        public double RetraitEpargne(double montant, int nip)
        {
            return 0;
        }

        public double DepotCheque(double montant, int nip)
        {
            return 0;
        }

        public double DepotEpargne(double montant, int nip)
        {
            return 0;
        }

    }
}