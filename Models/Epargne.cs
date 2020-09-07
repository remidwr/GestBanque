using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Epargne : Compte
    {
        public DateTime DateDernierRetrait { get; set; }

        public override void Retrait(double montant)
        {
            double AncienSolde = Solde;
            base.Retrait(montant);

            if (Solde != AncienSolde)
                DateDernierRetrait = DateTime.Now;
        }

        protected override double CalculInteret()
        {
            return Solde * 0.045;
        }
    }
}
