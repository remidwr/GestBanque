using Models;
using System;

namespace GestBanque
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne personne1 = new Personne();
            personne1.Nom = "Nolan";
            personne1.Prenom = "Christopher";
            personne1.DateNaiss = new DateTime(1967, 10, 10);

            Courant courant1 = new Courant();
            courant1.Numero = "US000000000001";
            courant1.Titulaire = personne1;
            courant1.LigneDeCredit = 500;
            courant1.Depot(2500);
            Afficher(courant1);

            courant1.Retrait(500);
            Afficher(courant1);

            courant1.Retrait(1000);
            Afficher(courant1);

            //courant1.Retrait(2000);
            Afficher(courant1);

            Epargne epargne1 = new Epargne();
            epargne1.Numero = "US000000000002";
            epargne1.Titulaire = personne1;
            epargne1.Depot(20000);
            Afficher(epargne1);

            Banque banque = new Banque();
            banque.Nom = "Inception Bank";
            banque.Ajouter(courant1);
            banque.Ajouter(epargne1);
        }

        private static void Afficher(Compte compte)
        {
            Console.WriteLine($"{compte.Numero} {compte.Solde} - {compte.Titulaire.Nom} {compte.Titulaire.Prenom}");
        }
    }
}
