using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface ICustomer
    {
        double Solde { get; }
        void Retrait(double montant);
        void Depot(double montant);
    }
}
