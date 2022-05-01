using System;
using System.Collections.Generic;

namespace Projet
{
    // utiliser liste clients, liste comptes
    // utiliser polymorphisme ?pour génération des rapports?, tous les comptes ch et ep sont des comptes.

    class Program
    {
        static void Main(string[] args)
        {
            List<Client> listeClients = new List<Client>();

            // client 1 avec un compte de chaque type
            Client client1 = new Client("Ghandi", "Lee", "glee", "1234");
            Cheque cheque1 = new Cheque(1600, 110061);
            Epargne epargne1 = new Epargne(3200, 110062);
            client1.SetCompteCheque(cheque1);
            client1.SetCompteEpargne(epargne1);

            // client 2 détient seulement un compte chèque
            Client client2 = new Client("Ezekiel", "Ciel", "ezeciel", "2345");
            Cheque cheque2 = new Cheque(41000, 120032);
            client2.SetCompteCheque(cheque2);

            // client 3 détient seulement un compte épargne
            Client client3 = new Client("Miriam", "Yang", "miyang", "3456");
            Epargne epargne3 = new Epargne(150, 110063);
            client3.SetCompteEpargne(epargne3);

            listeClients.Add(client1);
            //listeClients.Add(client2);
            //listeClients.Add(client3);

            Guichet guichet = new Guichet(listeClients);

            bool showMenu = true;
            bool validation = true;
            string saisieUser;
            string saisieNIP;
            int tentatives = 0;

            while (validation)
            {
                if (tentatives >= 3) // après trois tentative, le guichet rejète l'utilisateur
                {
                    Console.Clear();
                    Console.WriteLine("Nous ne pouvons valider vos informations, réessayez plus tard");
                    showMenu = false;
                    break;
                }
                Console.Clear();
                Console.Write("Veuillez entrer votre nom d'utilisateur: ");
                saisieUser = Console.ReadLine();
                Console.Write("\r\nVeuillez entrer votre NIP: ");
                saisieNIP = Console.ReadLine();
                validation = guichet.ValiderUtilisateur(saisieUser, saisieNIP);
                tentatives++;
            }

            while (showMenu) // menu principal
            {
                showMenu = Menu();

            }

            static bool Menu()
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
                        Console.Clear();
                        Console.WriteLine("Un dépôt dans quel compte ?");
                        Console.WriteLine("1) Compte chèque");
                        Console.WriteLine("2) Compte épargne");
                        Console.Write("\r\nSelectionner une option: ");


                        /* if (Console.ReadLine() == 1)
                        {
                            Console.Clear();
                            Console.Write("Veuillez saisir le montant: ");


                        } */


                        return true;
                    case "2":
                        Console.Clear();
                        Console.WriteLine("Un retrait dans quel compte ?");
                        Console.WriteLine("1) Compte chèque");
                        Console.WriteLine("2) Compte épargne");
                        Console.Write("\r\nSelectionner une option: ");
                        Console.ReadLine();
                        return true;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("Un Virement de quel à quel compte ?");
                        Console.WriteLine("1) De compte chèque vers compte épargne");
                        Console.WriteLine("2) de compte épargne vers compte chèque");
                        Console.Write("\r\nSelectionner une option: ");
                        Console.ReadLine();
                        return true;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("Merci d'avoir utilisé le service ToutCrocheInc.");
                        Console.ReadLine();
                        return false;
                    default:
                        return true;
                }
            }
        }



    }
}
