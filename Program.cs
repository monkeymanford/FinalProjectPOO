using System;
using System.Collections.Generic;

namespace Projet
{
    class Program
    {
        static double montant;
        static string choix;
        static Guichet guichet = new Guichet();
        static bool isAdmin = true;
        static List<Client> listeClients = new List<Client>();

        static void Main(string[] args)
        {
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
            Client client2 = new Client("Ezekiel", "Ciel", "ezee", "2345");
            Cheque cheque2 = new Cheque(120032, 41000);
            client2.SetCompteCheque(cheque2);

            // client 3 détient seulement un compte épargne
            Client client3 = new Client("Miriam", "Yang", "miya", "3456");
            Epargne epargne3 = new Epargne(110063, 150);
            client3.SetCompteEpargne(epargne3);

            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);

            // *************************************************************************************

            guichet.SetListGuichet(listeClients);

            bool showMenu = true;
            bool validation = true;
            int tentatives = 0;

            while (validation)
            {               // après trois tentative, le guichet rejète l'utilisateur
                if (tentatives >= 3)
                {
                    Messages.TropEssais();
                    showMenu = false;
                    break;
                }

                validation = Login();
                tentatives++;
            }

            while (!(isAdmin))
            {
                showMenu = false;
                isAdmin = !ConsoleAdministrateur();
            }

            while (showMenu) // loop de menu
            {
                showMenu = MenuTransactions();
            }

        }


        // ******************* MENU DE TRANSACTIONS *********************

        static bool MenuTransactions()
        {
            Messages.MenuPrincipal();

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
            Messages.MenuDepot();
            choix = Console.ReadLine();
            Console.Clear();

            if (choix == "1" && guichet.CheckCheque())
            {
                Console.WriteLine("Balance : " + guichet.GetChequeSolde());
                Console.Write("Veuillez saisir le montant: ");
                try
                {
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant > 0)
                    {
                        guichet.DepotCheque(montant);
                        Console.Clear();
                        Console.WriteLine("\r\nNouveau Solde : " + guichet.GetChequeSolde());
                        Console.Write("\r\nAppuyez sur enter pour retourner");
                        Console.ReadLine();
                    }
                    else Messages.MontantInvalide();
                }
                catch (Exception) { Messages.Erreur(); }
            }

            else if (choix == "2" && guichet.CheckEpargne())
            {
                Console.WriteLine("Balance : " + guichet.GetEpargneSolde());
                Console.Write("Veuillez saisir le montant: ");
                try
                {
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant > 0)
                    {
                        guichet.DepotEpargne(montant);
                        Console.Clear();
                        Console.WriteLine("\r\nNouveau Solde : " + guichet.GetEpargneSolde());
                        Console.Write("\r\nAppuyez sur enter pour retourner");
                        Console.ReadLine();
                    }
                    else Messages.MontantInvalide();
                }
                catch (Exception) { Messages.Erreur(); }
            }

            else
            {
                Messages.ChoixInvalide();
            }

        }

        // ******************* MÉTHODE POUR RETRAIT *********************

        public static void Retrait()
        {
            Messages.MenuRetrait();
            choix = Console.ReadLine();
            Console.Clear();

            if (choix == "1" && guichet.CheckCheque())
            {
                Console.WriteLine("Balance : " + guichet.GetChequeSolde());
                Console.Write("Veuillez saisir le montant: ");
                try
                {
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant > 1000) Messages.TropEleve(1000);
                    else if (montant <= 0) Messages.MontantInvalide();
                    else if (montant % 10 != 0) Messages.MauvaiseCoupure();
                    else if (montant <= guichet.GetChequeSolde())
                    {
                        guichet.RetraitCheque(montant);
                        Console.Clear();
                        Console.WriteLine("\r\nNouveau Solde : " + guichet.GetChequeSolde());
                        Console.Write("\r\nAppuyez sur enter pour retourner");
                        Console.ReadLine();
                    }
                    else Messages.FondsInsuffisants();
                }
                catch (Exception) { Messages.Erreur(); }

            }

            else if (choix == "2" && guichet.CheckEpargne())
            {
                Console.WriteLine("Balance : " + guichet.GetEpargneSolde());
                Console.Write("Veuillez saisir le montant: ");
                try
                {
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant > 1000) Messages.TropEleve(1000);
                    else if (montant <= 0) Messages.MontantInvalide();
                    else if (montant % 10 != 0) Messages.MauvaiseCoupure();
                    else if (montant <= guichet.GetEpargneSolde())
                    {
                        guichet.RetraitEpargne(montant);
                        Console.Clear();
                        Console.WriteLine("\r\nNouveau Solde : " + guichet.GetEpargneSolde());
                        Console.Write("\r\nAppuyez sur enter pour retourner");
                        Console.ReadLine();
                    }
                    else Messages.FondsInsuffisants();
                }
                catch (Exception) { Messages.Erreur(); }
            }

            else
            {
                Messages.ChoixInvalide();
            }
        }

        // ******************* MÉTHODE POUR VIREMENT *********************

        public static void Virement()
        {
            Messages.MenuVirement();
            choix = Console.ReadLine();
            Console.Clear();

            if (choix == "1")
            {
                Console.WriteLine("Balance du compte chèque :  " + guichet.GetChequeSolde());
                Console.WriteLine("   ↓   ↓   ↓   ↓   ↓   ");
                Console.WriteLine("Balance du compte épargne : " + guichet.GetEpargneSolde());
                Console.Write("\r\nVeuillez saisir le montant: ");
                try
                {
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant > 100000) Messages.TropEleve(100000);
                    else if (montant <= 0) Messages.MontantInvalide();
                    else if (montant <= guichet.GetChequeSolde())
                    {
                        guichet.RetraitCheque(montant);
                        guichet.DepotEpargne(montant);
                        Console.Clear();
                        Console.WriteLine("Le virement a été effectué avec succès\r\n");
                        Console.WriteLine("Nouveau solde du compte chèque :  " + guichet.GetChequeSolde());
                        Console.WriteLine("Nouveau solde du compte épargne : " + guichet.GetEpargneSolde());
                        Console.Write("\r\nAppuyez sur enter pour retourner");
                        Console.ReadLine();
                    }
                    else Messages.FondsInsuffisants();
                }
                catch (Exception) { Messages.Erreur(); }
            }

            else if (choix == "2")
            {
                Console.WriteLine("Balance du compte épargne : " + guichet.GetEpargneSolde());
                Console.WriteLine("   ↓   ↓   ↓   ↓   ↓   ");
                Console.WriteLine("Balance du compte chèque :  " + guichet.GetChequeSolde());
                Console.Write("\r\nVeuillez saisir le montant: ");
                try
                {
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant > 100000) Messages.TropEleve(100000);
                    else if (montant <= 0) Messages.MontantInvalide();
                    else if (montant <= guichet.GetEpargneSolde())
                    {
                        guichet.RetraitEpargne(montant);
                        guichet.DepotCheque(montant);
                        Console.Clear();
                        Console.WriteLine("Le virement a été effectué avec succès\r\n");
                        Console.WriteLine("Nouveau solde du compte épargne : " + guichet.GetEpargneSolde());
                        Console.WriteLine("Nouveau solde du compte chèque :  " + guichet.GetChequeSolde());
                        Console.Write("\r\nAppuyez sur enter pour retourner");
                        Console.ReadLine();
                    }
                    else Messages.FondsInsuffisants();
                }
                catch (Exception) { Messages.Erreur(); }
            }

            else
            {
                Messages.ChoixInvalide();
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

            if (string.Equals("admin", saisieUser) && string.Equals("9999", saisieNIP))
                return isAdmin = false;

            else return guichet.ValiderUtilisateur(saisieUser, saisieNIP);

        }

        // ******************* MENU POUR ADMINISTRATEUR ET MÉTHODES *********************

        public static bool ConsoleAdministrateur()
        {
            Messages.MenuAdmin();

            switch (Console.ReadLine())
            {
                case "1":
                    PaiementInterets();
                    return true;
                case "2":
                    GenerationRapports();
                    return true;
                case "3":
                    Messages.AuRevoir();
                    return false;
                default:
                    Messages.ChoixInvalide();
                    return true;
            }
        }

        public static void PaiementInterets()
        {
            foreach (Client x in listeClients)
                if (x.GetCompteEpargne() != null) x.GetCompteEpargne().PaiementInterets();
            Messages.PaiementInteretsEffectue();
        }

        public static void GenerationRapports()
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.WriteLine("{0,-12}{1,-15}{2,-15}{3,-15}{4,16}{5,4}", "| No.:", "Type:", "User:", "Nom:", "Solde:", "|");
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach (Client x in listeClients)
            {
                if (x.GetCompteEpargne() != null)
                {
                    Console.WriteLine("{0,-12}{1,-15}{2,-15}{3,-15}{4,15}{5,5}",
                        "| " + x.GetCompteEpargne().getNumCompte(), "Epargne", x.getUser(),
                        x.getNom() + ", " + x.getPrenom(), x.GetCompteEpargne().getSolde(), "|");
                }
                if (x.GetCompteCheque() != null)
                {
                    Console.WriteLine("{0,-12}{1,-15}{2,-15}{3,-15}{4,15}{5,5}",
                        "| " + x.GetCompteCheque().getNumCompte(), "Cheque", x.getUser(),
                        x.getNom() + ", " + x.getPrenom(), x.GetCompteCheque().getSolde(), "|");
                }
            }
            Console.Write("-----------------------------------------------------------------------------");
            Console.ReadLine();
        }









    }
}
