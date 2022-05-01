using System;

namespace Projet
{
    public static class Messages
    {
            public static void AuRevoir()
            {
                Console.Clear();

                Console.WriteLine("\r\n\r\nAppuyez sur enter pour terminer");
                Console.ReadLine();
            }

            public static void ChoixInvalide()
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\nCe choix n'est pas disponible, veuillez recommencer");
                Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                Console.ReadLine();
            }

            public static void FondsInsuffisants()
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\nFonds insuffisants !!");
                Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                Console.ReadLine();
            }

            public static void TropEleve(int limite)
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\nVous ne pouvez dépasser la limite de " + limite + "$ pour cette transaction");
                Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                Console.ReadLine();
            }

            public static void MauvaiseCoupure()
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\nLe montant du retrait doit être multiple de 10");
                Console.WriteLine("\r\nAppuyez sur enter pour retourner");
                Console.ReadLine();
            }

            public static void CompteManquant()
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\nVous devez détenir plus d'un compte pour effectuer un virement");
                Console.WriteLine("\r\nAppuyez sur <<enter>> pour retourner");
                Console.ReadLine();
            }

            public static void TropEssais()
            {
                Console.Clear();
                Console.WriteLine("\r\n\r\nNous ne pouvons valider vos informations");
                Console.WriteLine("\r\nVeuillez réessayer plus tard");
                Console.WriteLine("\r\n\r\nAu revoir");
            }
    }
}