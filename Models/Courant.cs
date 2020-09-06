using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Courant : Compte
    {
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

        public override void Retrait(double montant)
        {
            Retrait(montant, LigneDeCredit);
        }
    }
}
