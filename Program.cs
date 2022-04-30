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
            IList<Client> listeClients = new List<Client>();

            Client client1 = new Client("Ghandi", "Lee", "glee", "1234");
            Client client2 = new Client("Ezekiel", "Ciel", "ezewu", "2345");
            Client client3 = new Client("Miriam", "Yang", "miyang", "3456");

            listeClients.Add(client1);
            listeClients.Add(client2);
            listeClients.Add(client3);

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Guichet.MenuPrincipal();
            }

            static bool MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Choisir une option:");
            Console.WriteLine("1) Option #1");
            Console.WriteLine("2) Option #2");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelectionner une option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Option #1 selectionnée ");
                    Console.ReadLine();
                    return true;
                case "2":
                    Console.WriteLine("Option #2 selectionnée ");
                    Console.ReadLine();
                    return true;
                case "3":
                    Console.WriteLine("Option #3 selectionnée ");
                    Console.ReadLine();
                    return false;
                default:
                    return true;
            }
        }
        }



    }
}
