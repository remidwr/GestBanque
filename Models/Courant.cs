using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant
    {
        #region Surcharge
        public static double operator +(double Solde, Courant courant)
        {
            return Solde + ((courant.Solde < 0.0) ? 0.0 : courant.Solde);
        }
        #endregion

        public string Numero { get; set; }
        public double Solde { get; private set; }

        #region LigneDeCredit
        private double _LigneDeCredit;
        
        public double LigneDeCredit
        {
            get 
            {
                return _LigneDeCredit;
            }
            set
            {
                if (value >= 0)
                    _LigneDeCredit = value;
                else
                    throw new InvalidOperationException("La ligne de crédit doit être supérieure à zéro !");
            } 
        }
        #endregion

        public Personne Titulaire { get; set; }

        public void Retrait(double montant)
        {
            if (montant <= 0)
                throw new Exception("Montant négatif !");
            else if (Solde - montant < -LigneDeCredit)
                throw new InvalidOperationException("Retrait impossible !");

            Solde -= montant;
        }

        public void Depot(double montant)
        {
            if(montant <= 0)
            {
                throw new Exception("Le montant doit être supérieur à zéro");
            }

            Solde += montant;
        }
    }
}
