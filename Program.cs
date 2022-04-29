using System;

namespace Projet
{
    // utiliser liste clients, liste comptes
    // utiliser polymorphisme ?pour génération des rapports?, tous les comptes ch et ep sont des comptes.



    class Program
    {
        static void Main(string[] args)
       {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MenuPrincipal();
            }
        }

        private static bool MenuPrincipal()
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
