using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public abstract class Compte : IBanker, ICustomer
    {
        public string Numero { get; set; }
        public double Solde { get; private set; }
        public Personne Titulaire { get; set; }
        public int LigneDeCredit { get; set; }

        public void Retrait(double montant, double LigneDeCredit)
        {
            if (montant <= 0)
                throw new Exception("Montant négatif !");
            else if (Solde - montant < -LigneDeCredit)
                throw new InvalidOperationException("Retrait impossible !");

            Solde -= montant;
        }

        public virtual void Retrait(double montant)
        {
            Retrait(montant, 0.0);
        }

        public void Depot(double montant)
        {
            if (montant <= 0)
                throw new Exception("Le montant doit être supérieur à zéro");

            Solde += montant;
        }

        protected abstract double CalculInteret();

        public void AppliquerInteret()
        {
            Solde += CalculInteret();
        }

        #region Surcharge
        public static double operator +(double Solde, Compte compte)
        {
            return Solde + ((compte.Solde < 0.0) ? 0.0 : compte.Solde);
        }
        #endregion
    }
}
