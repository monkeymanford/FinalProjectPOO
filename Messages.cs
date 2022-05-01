using System;

namespace Projet
{
    public static class Messages
    {
        public static void MenuAdmin()
        {
            Console.Clear();
            Console.WriteLine("Veuillez choisir une des options:\r\n");
            Console.WriteLine("1) Effectuer le paiement des intérêts");
            Console.WriteLine("2) Génération des rapports sur les comptes");
            Console.WriteLine("3) Quitter");
            Console.Write("\r\nVotre Choix: ");
        }

        public static void PaiementInteretsEffectue()
        {
            Console.Clear();
            Console.WriteLine("\r\nLe paiement des intérêts a été effectué");
            Console.WriteLine("\r\n\r\nAppuyez sur enter pour retourner");
            Console.ReadLine();
        }

        public static void MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Choisissez une option,");
            Console.WriteLine("1) Dépôt");
            Console.WriteLine("2) Retrait");
            Console.WriteLine("3) Virement");
            Console.WriteLine("4) Quitter");
            Console.Write("\r\nVotre sélection: ");
        }

        public static void MenuDepot()
        {
            Console.Clear();
            Console.WriteLine("Un dépôt dans quel compte ?");
            Console.WriteLine("1) Compte chèque");
            Console.WriteLine("2) Compte épargne");
            Console.Write("\r\nSelectionnez une option: ");
        }

        public static void MenuRetrait()
        {
            Console.Clear();
            Console.WriteLine("Un retrait dans quel compte ?");
            Console.WriteLine("1) Compte chèque");
            Console.WriteLine("2) Compte épargne");
            Console.Write("\r\nSélectionnez une option: ");
        }

        public static void MenuVirement()
        {
            Console.Clear();
            Console.WriteLine("Un Virement de quel à quel compte ?\r\n");
            Console.WriteLine("1) Du compte chèque vers le compte épargne");
            Console.WriteLine("2) Du compte épargne vers le compte chèque");
            Console.Write("\r\nSelectionnez une option: ");
        }

        public static void AuRevoir()
        {
            Console.Clear();
            Console.WriteLine("\r\nMerci d'avoir utilisé le service ToutCrocheInc.");
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
        }
    }
}