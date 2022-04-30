using System;
using System.Collections.Generic;

namespace Projet
{
    public class Guichet
    {
        private Client client;
        private Cheque comptecheque;
        private Epargne compteEpargne;
        private List<Client> listeClients;

        public Guichet(List<Client> listeClients)
        {
            this.listeClients = listeClients;
        }

        public bool ValiderUtilisateur(string user, string nip)
        {
            foreach (Client x in listeClients)
            {
                if (string.Equals(x.getUser(), user) && string.Equals(x.getNIP(), nip)) return false;
            }
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