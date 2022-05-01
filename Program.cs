using System;
using System.Security;
using System.Collections.Generic;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Client> listeClients = new List<Client>();

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

            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);

            Guichet guichet = new Guichet(listeClients);

            bool showMenu = true;
            bool validation = true;
            string saisieUser;
            string saisieNIP = "";
            int tentatives = 0;
            double montant;

            while (validation)
            {
                if (tentatives >= 3) // après trois tentative, le guichet rejète l'utilisateur
                {
                    Console.Clear();
                    Console.WriteLine("Nous ne pouvons valider vos informations, veuillez réessayez plus tard");
                    showMenu = false;
                    break;
                }
                Console.Clear();
                Console.Write("Veuillez entrer votre nom d'utilisateur: ");
                saisieUser = Console.ReadLine();
                Console.Write("\r\nVeuillez entrer votre NIP: ");
                saisieNIP = CachePasse();
                validation = guichet.ValiderUtilisateur(saisieUser, saisieNIP);
                tentatives++;
            }

            while (showMenu) // menu loop
            {
                showMenu = Menu();
            }

            bool Menu()
            {
                Console.Clear();
                Console.WriteLine("Choisir une option:");
                Console.WriteLine("1) Dépôt");
                Console.WriteLine("2) Retrait");
                Console.WriteLine("3) Virement");
                Console.WriteLine("4) Quitter");
                Console.Write("\r\nSelectionner une option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        Depot();
                        return true;

                    case "2":
                        Retrait();
                        return true;

                    case "3":
                        if (guichet.CheckCheque() && guichet.CheckEpargne()) Virement();
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Vous devez détenir plus d'un compte pour effectuer un virement");
                            Console.WriteLine("Appuyez sur <<enter>> pour retourner");
                            Console.ReadLine();
                        }
                        return true;

                    case "4":
                        AuRevoir();
                        return false;

                    default:
                        ChoixInvalide();
                        return true;
                }
            }


            // ******************************** méthodes ************************************


            void Depot() // MÉTHODE POUR LES DÉPOTS
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
                    Console.WriteLine("Nouveau Solde : " + guichet.GetChequeSolde());
                    Console.WriteLine("\r\nAppuyez sur une touche pour retourner");
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
                    Console.WriteLine("Nouveau Solde : " + guichet.GetEpargneSolde());
                    Console.WriteLine("\r\nAppuyez sur une touche pour retourner");
                    Console.ReadLine();
                }

                else
                {
                    ChoixInvalide();
                }

            }

            void Retrait() // MÉTHODE POUR LES RETRAITS
            {
                string choix;

                Console.Clear();
                Console.WriteLine("Un retrait dans quel compte ?");
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
                    if (montant <= guichet.GetChequeSolde())
                    {
                        guichet.RetraitCheque(montant);
                        Console.Clear();
                        Console.WriteLine("Nouveau Solde : " + guichet.GetChequeSolde());
                        Console.WriteLine("\r\nAppuyez sur une touche pour retourner");
                        Console.ReadLine();
                    }
                    else FondsInsuffisants();

                }

                else if (choix == "2" && guichet.CheckEpargne())
                {
                    Console.Clear();
                    Console.WriteLine("Balance : " + guichet.GetEpargneSolde());
                    Console.Write("Veuillez saisir le montant: ");
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant <= guichet.GetEpargneSolde())
                    {
                        guichet.RetraitEpargne(montant);
                        Console.Clear();
                        Console.WriteLine("Nouveau Solde : " + guichet.GetEpargneSolde());
                        Console.WriteLine("\r\nAppuyez sur une touche pour retourner");
                        Console.ReadLine();
                    }
                    else FondsInsuffisants();
                }

                else
                {
                    ChoixInvalide();
                }
            }

            void Virement() // MÉTHODE POUR LES VIREMENTS
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
                    if (montant <= guichet.GetChequeSolde())
                    {
                        guichet.RetraitCheque(montant);
                        guichet.DepotEpargne(montant);
                        Console.Clear();
                        Console.WriteLine("Le virement a été effectué");
                        Console.WriteLine("Nouveau solde du compte chèque :  " + guichet.GetChequeSolde());
                        Console.WriteLine("Nouveau solde du compte épargne : " + guichet.GetEpargneSolde());
                        Console.WriteLine("\r\nAppuyez sur une touche pour retourner");
                        Console.ReadLine();
                    }
                    else FondsInsuffisants();
                }

                if (choix == "2")
                {
                    Console.Clear();
                    Console.WriteLine("Balance du compte épargne : " + guichet.GetEpargneSolde());

                    Console.WriteLine("Balance du compte chèque :  " + guichet.GetChequeSolde());
                    Console.Write("\r\nVeuillez saisir le montant: ");
                    montant = Convert.ToDouble(Console.ReadLine());
                    if (montant <= guichet.GetEpargneSolde())
                    {
                        guichet.RetraitEpargne(montant);
                        guichet.DepotCheque(montant);
                        Console.Clear();
                        Console.WriteLine("Le virement a été effectué\r\n");
                        Console.WriteLine("Nouveau solde du compte épargne : " + guichet.GetEpargneSolde());
                        Console.WriteLine("Nouveau solde du compte chèque :  " + guichet.GetChequeSolde());
                        Console.WriteLine("\r\nAppuyez sur une touche pour retourner");
                        Console.ReadLine();
                    }
                    else FondsInsuffisants();
                }
            }

            void AuRevoir()
            {
                Console.Clear();

                Console.WriteLine("Appuyez sur une touche pour terminer");
                Console.ReadLine();
            }

            void ChoixInvalide()
            {
                Console.Clear();
                Console.WriteLine("Ce choix n'est pas disponible, veuillez recommencer");
                Console.WriteLine("Appuyez sur <<enter>> pour retourner");
                Console.ReadLine();
            }

            void FondsInsuffisants()
            {
                Console.Clear();
                Console.WriteLine("Fonds insuffisants !!");
                Console.WriteLine("Appuyez sur <<enter>> pour retourner");
                Console.ReadLine();
            }

        }

        public static string CachePasse()
        {
            ConsoleKeyInfo key;
            string code = "";
            while (true)
            {
                key = Console.ReadKey(true);
                if (Char.IsNumber(key.KeyChar))
                {
                    Console.Write("*");
                    code += key.KeyChar;
                }
                else if (key.Key == ConsoleKey.Enter) return code;
            }
        }



    }
}
