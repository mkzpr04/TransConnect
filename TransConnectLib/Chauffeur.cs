using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Chauffeur : Salarie, IComparable<Chauffeur>
    {
        public List<DateTime> JoursNonDisponibles { get; private set; }

        public Chauffeur(string numSecu, string nom, string prenom, DateTime dateNaissance,
                        string adressePostale, string adresseMail, string telephone,
                        DateTime dateEntree, string poste, double salaire, List<DateTime> joursNonDisponibles)
                        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone,
                        dateEntree, poste, salaire)
        {
            this.JoursNonDisponibles = joursNonDisponibles ?? new List<DateTime>();
        }
        public Chauffeur(string numSecu, string nom, string prenom, DateTime dateNaissance,
                        string adressePostale, string adresseMail, string telephone,
                        DateTime dateEntree, string poste, double salaire)
                        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone,
                        dateEntree, poste, salaire)
        {
            this.JoursNonDisponibles = new List<DateTime>();
        }

        // Méthodes

        // Vérifie si le chauffeur est libre pour une livraison à dateLivraison
        public bool EstDisponible(DateTime date)
        {
            return !JoursNonDisponibles.Contains(date.Date);
        }

        public void AjouterJourNonDisponible(DateTime date)
        {
            JoursNonDisponibles.Add(date.Date);
        }
        public int GetNombreLivraisons()
        {
            return GestionCommande.RechercherCommandes(null, null, null, this.Nom).Count;
        }

        public float GetMoyenneNotes()
        {
            var commandes = GestionCommande.RechercherCommandes(null, null, null, this.Nom);
            return commandes.Count == 0 ? 0 : commandes.Average(c => c.NoteLivraison);
        }

        public int CompareTo(Chauffeur chauffeur)
        {
            if (chauffeur == null) return 1;
            return GetNombreLivraisons().CompareTo(chauffeur.GetNombreLivraisons());
        }
    }
}
