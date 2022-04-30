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

            // hard coded clients :

            Client client1 = new Client("Ghandi", "Lee", "glee", "1234");
            Client client2 = new Client("Ezekiel", "Ciel", "ezeciel", "2345");
            Client client3 = new Client("Miriam", "Yang", "miyang", "3456");

            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);

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
                        Console.WriteLine("Un dépôt dans quel compte ?");
                        Console.WriteLine("1) Compte chèque");
                        Console.WriteLine("2) Compte épargne");
                        Console.Write("\r\nSelectionner une option: ");
                        Console.ReadLine();
                        return true;
                    case "2":
                        Console.WriteLine("Un retrait dans quel compte ?");
                        Console.WriteLine("1) Compte chèque");
                        Console.WriteLine("2) Compte épargne");
                        Console.Write("\r\nSelectionner une option: ");
                        Console.ReadLine();
                        return true;
                    case "3":
                        Console.WriteLine("Un Virement de quel à quel compte ?");
                        Console.WriteLine("1) De compte chèque vers compte épargne");
                        Console.WriteLine("2) de compte épargne vers compte chèque");
                        Console.Write("\r\nSelectionner une option: ");
                        Console.ReadLine();
                        return true;
                    case "4":
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
