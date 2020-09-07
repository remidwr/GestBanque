using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Interfaces
{
    public interface IBanker : ICustomer
    {
        string Numero { get; }
        Personne Titulaire { get; }
        int LigneDeCredit { get; set; }
        void AppliquerInteret();
    }
}
