using System;
using System.Collections.Generic;

namespace Projet
{
    class Program
    {
        static double montant;
        static Guichet guichet = new Guichet();

        static void Main(string[] args)
        {
            List<Client> listeClients = new List<Client>();

            // ************************ HARD CODED INFOS ******************************************

            // J'ai hardcodé trois clients pour chaque variation possible, 
            // c'est-à-dire un client avec les deux comptes ainsi que
            // deux clients avec chacun un des types de compte.

            // client 1 avec un compte de chaque type
            Client client1 = new Client("Ghandi", "Lee", "glee", "1234");
            Cheque cheque1 = new Cheque(110061, 1600);
            Epargne epargne1 = new Epargne(110062, 3200);
            client1.SetCompteCheque(cheque1);
            client1.SetCompteEpargne(epargne1);

            // client 2 détient seulement un compte chèque
            Client client2 = new Client("Ezekiel", "Ciel", "ezeciel", "2345");
            Cheque cheque2 = new Cheque(120032, 41000);
            client2.SetCompteCheque(cheque2);

            // client 3 détient seulement un compte épargne
            Client client3 = new Client("Miriam", "Yang", "miyang", "3456");
            Epargne epargne3 = new Epargne(110063, 150);
            client3.SetCompteEpargne(epargne3);

            // *************************************************************************************

            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);

            guichet.SetListGuichet(listeClients);

            bool showMenu = true;
            bool validation = true;
            int tentatives = 0;

            while (validation)
            {
                if (tentatives >= 3) // après trois tentative, le guichet rejète l'utilisateur
                {
                    Messages.TropEssais();
                    showMenu = false;
                    break;
                }

                validation = Login();
                tentatives++;
            }

            while (showMenu) // menu loop
            {
                showMenu = MenuTransactions();
            }

        }

        // ******************* MENU DE TRANSACTIONS *********************

        static bool MenuTransactions()
        {
            Console.Clear();
            Console.WriteLine("Choisissez une option,");
            Console.WriteLine("1) Dépôt");
            Console.WriteLine("2) Retrait");
            Console.WriteLine("3) Virement");
            Console.WriteLine("4) Quitter");
            Console.Write("\r\nVotre sélection: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Depot();
                    return true;

                case "2":
                    Retrait();
                    return true;

                case "3":
                    if (guichet.CheckCheque() && guichet.CheckEpargne())
                        Virement();
                    else Messages.CompteManquant();
                    return true;

                case "4":
                    Messages.AuRevoir();
                    return false;

                default:
                    Messages.ChoixInvalide();
                    return true;
            }
        }

        // ******************* MÉTHODE POUR DÉPOT *********************

        static void Depot()
        {
            string choix;

            Console.Clear();
            Console.WriteLine("Un dépôt dans quel compte ?");
            Console.WriteLine("1) Compte chèque");
            Console.WriteLine("2) Compte épargne");
            Console.Write("\r\nSelectionnez une option: ");
            choix = Console.ReadLine();

            if (choix == "1" && guichet.CheckCheque())
            {
                Console.Clear();
                Console.WriteLine("Balance : " + guichet.GetChequeSolde());
                Console.Write("Veuillez saisir le montant: ");
                montant = Convert.ToDouble(Console.ReadLine());
                guichet.DepotCheque(montant);
                Console.Clear();
                Console.WriteLine("\r\nNouveau Solde : " + guichet.GetChequeSolde());
                Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                Console.ReadLine();
            }

            else if (choix == "2" && guichet.CheckEpargne())
            {
                Console.Clear();
                Console.WriteLine("Balance : " + guichet.GetEpargneSolde());
                Console.Write("Veuillez saisir le montant: ");
                montant = Convert.ToDouble(Console.ReadLine());
                guichet.DepotEpargne(montant);
                Console.Clear();
                Console.WriteLine("\r\nNouveau Solde : " + guichet.GetEpargneSolde());
                Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                Console.ReadLine();
            }

            else
            {
                Messages.ChoixInvalide();
            }

        }

        // ******************* MÉTHODE POUR RETRAIT *********************

        public static void Retrait()
        {
            string choix;

            Console.Clear();
            Console.WriteLine("Un retrait dans quel compte ?");
            Console.WriteLine("1) Compte chèque");
            Console.WriteLine("2) Compte épargne");
            Console.Write("\r\nSélectionnez une option: ");
            choix = Console.ReadLine();

            if (choix == "1" && guichet.CheckCheque())
            {
                Console.Clear();
                Console.WriteLine("Balance : " + guichet.GetChequeSolde());
                Console.Write("Veuillez saisir le montant: ");
                montant = Convert.ToDouble(Console.ReadLine());

                if (montant > 1000) Messages.TropEleve(1000);
                else if (montant % 10 != 0) Messages.MauvaiseCoupure();
                else if (montant <= guichet.GetChequeSolde())
                {
                    guichet.RetraitCheque(montant);
                    Console.Clear();
                    Console.WriteLine("\r\nNouveau Solde : " + guichet.GetChequeSolde());
                    Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                    Console.ReadLine();
                }
                else Messages.FondsInsuffisants();

            }

            else if (choix == "2" && guichet.CheckEpargne())
            {
                Console.Clear();
                Console.WriteLine("Balance : " + guichet.GetEpargneSolde());
                Console.Write("Veuillez saisir le montant: ");
                montant = Convert.ToDouble(Console.ReadLine());

                if (montant > 1000) Messages.TropEleve(1000);
                else if (montant % 10 != 0) Messages.MauvaiseCoupure();
                else if (montant <= guichet.GetEpargneSolde())
                {
                    guichet.RetraitEpargne(montant);
                    Console.Clear();
                    Console.WriteLine("\r\nNouveau Solde : " + guichet.GetEpargneSolde());
                    Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                    Console.ReadLine();
                }
                else Messages.FondsInsuffisants();
            }

            else
            {
                Messages.ChoixInvalide();
            }
        }

        // ******************* MÉTHODE POUR VIREMENT *********************

        public static void Virement()
        {
            string choix;

            Console.Clear();
            Console.WriteLine("Un Virement de quel à quel compte ?\r\n");
            Console.WriteLine("1) Du compte chèque vers le compte épargne");
            Console.WriteLine("2) Du compte épargne vers le compte chèque");
            Console.Write("\r\nSelectionnez une option: ");
            choix = Console.ReadLine();

            if (choix == "1")
            {
                Console.Clear();
                Console.WriteLine("Balance du compte chèque :  " + guichet.GetChequeSolde());

                Console.WriteLine("Balance du compte épargne : " + guichet.GetEpargneSolde());
                Console.Write("\r\nVeuillez saisir le montant: ");
                montant = Convert.ToDouble(Console.ReadLine());
                if (montant > 100000) Messages.TropEleve(100000);
                else if (montant <= guichet.GetChequeSolde())
                {
                    guichet.RetraitCheque(montant);
                    guichet.DepotEpargne(montant);
                    Console.Clear();
                    Console.WriteLine("Le virement a été effectué\r\n");
                    Console.WriteLine("Nouveau solde du compte chèque :  " + guichet.GetChequeSolde());
                    Console.WriteLine("Nouveau solde du compte épargne : " + guichet.GetEpargneSolde());
                    Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                    Console.ReadLine();
                }
                else Messages.FondsInsuffisants();
            }

            if (choix == "2")
            {
                Console.Clear();
                Console.WriteLine("Balance du compte épargne : " + guichet.GetEpargneSolde());

                Console.WriteLine("Balance du compte chèque :  " + guichet.GetChequeSolde());
                Console.Write("\r\nVeuillez saisir le montant: ");
                montant = Convert.ToDouble(Console.ReadLine());
                if (montant > 100000) Messages.TropEleve(100000);
                if (montant <= guichet.GetEpargneSolde())
                {
                    guichet.RetraitEpargne(montant);
                    guichet.DepotCheque(montant);
                    Console.Clear();
                    Console.WriteLine("Le virement a été effectué\r\n");
                    Console.WriteLine("Nouveau solde du compte épargne : " + guichet.GetEpargneSolde());
                    Console.WriteLine("Nouveau solde du compte chèque :  " + guichet.GetChequeSolde());
                    Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                    Console.ReadLine();
                }
                else Messages.FondsInsuffisants();
            }
        }

        // ******************* MÉTHODE POUR LOGIN *********************

        public static bool Login()
        {
            string saisieUser;
            string saisieNIP = "";

            Console.Clear();
            Console.Write("Veuillez entrer votre nom d'utilisateur: ");
            saisieUser = Console.ReadLine();

            Console.Write("\r\nVeuillez entrer votre NIP: ");
            saisieNIP = Security.CachePasse();
            return guichet.ValiderUtilisateur(saisieUser, saisieNIP);
        }

    }
}
