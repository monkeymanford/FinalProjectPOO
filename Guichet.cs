using System;
using System.Collections.Generic;

namespace Projet
{
    public class Guichet
    {
        private Client client;
        private Cheque compteCheque;
        private Epargne compteEpargne;
        private List<Client> listeClients;

        public Guichet()
        {

        }

        // GETTERS POUR SOLDES :

        public double GetEpargneSolde()
        {
            return compteEpargne.getSolde();
        }

        public double GetChequeSolde()
        {
            return compteCheque.getSolde();
        }

        // SETTER POUR LA LISTE DE CLIENTS :

        public void SetListGuichet(List<Client> listeClients)
        {
            this.listeClients = listeClients;
        }

        public bool ValiderUtilisateur(string user, string nip)
        {
            foreach (Client x in listeClients)
            {
                if (string.Equals(x.getUser(), user) && string.Equals(x.getNIP(), nip))
                {
                    this.compteCheque = x.GetCompteCheque();
                    this.compteEpargne = x.GetCompteEpargne();
                    this.client = x;
                    return false;
                }
            }
            return true;
        }

        // BOOL CHECK POUR TYPE DE COMPTE DISPONIBLE POUR LE CLIENT

        public bool CheckCheque()
        {
            if (compteCheque != null) return true;
            else return false;
        }

        public bool CheckEpargne()
        {
            if (compteEpargne != null) return true;
            else return false;
        }

        // MÉTHODES POUR DÉPÔTS ET RETRAITS :

        public void RetraitCheque(double montant)
        {
            compteCheque.Retrait(montant);
        }

        public void RetraitEpargne(double montant)
        {
            compteEpargne.Retrait(montant);
        }

        public void DepotCheque(double montant)
        {
            compteCheque.Depot(montant);
        }

        public void DepotEpargne(double montant)
        {
            compteEpargne.Depot(montant);
        }

    }
}