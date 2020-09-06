using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Banque
    {
        public string Nom { get; set; }

        private Dictionary<string, Courant> _Comptes;
        public Dictionary<string, Courant> Comptes
        {
            get
            {
                return _Comptes = _Comptes ?? new Dictionary<string, Courant>();
            }
        }

        public Courant this[string numero]
        {
            get
            {
                Comptes.TryGetValue(numero, out Courant compte);
                return compte;
            }
        }

        public void Ajouter(Courant compte)
        {
            if(compte is null || Comptes.ContainsKey(compte.Numero))
            {
                throw new InvalidOperationException("Pas de compte !");
            }

            Comptes.Add(compte.Numero, compte);
        }

        public void Supprimer(string numero)
        {
            Comptes.Remove(numero);
        }

        public double AvoirDesComptes(Personne personne)
        {
            double Avoir = 0.0;

            foreach (Courant courant in _Comptes.Values)
            {
                if (courant.Titulaire == personne)
                    Avoir += courant;
            }

            return Avoir;
        }
    }
}
