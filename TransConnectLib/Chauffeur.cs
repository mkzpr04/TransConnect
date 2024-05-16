using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Chauffeur : Salarie
    {
        public List<DateTime> joursNonDisponibles { get; private set; }

        public Chauffeur(string numSecu, string nom, string prenom, DateTime dateNaissance, 
                        string adressePostale, string adresseMail, string telephone, 
                        DateTime dateEntree, string poste, double salaire, List<DateTime> joursNonDisponibles)
                        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone, 
                        dateEntree, poste, salaire)
        {
            this.joursNonDisponibles = joursNonDisponibles;
        }
        public Chauffeur(string numSecu, string nom, string prenom, DateTime dateNaissance, 
                        string adressePostale, string adresseMail, string telephone, 
                        DateTime dateEntree, string poste, double salaire)
                        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone, 
                        dateEntree, poste, salaire)
        {
            joursNonDisponibles = new List<DateTime>();
        }
        
         // Méthodes

         // Vérifie si le chauffeur est libre pour une livraison à dateLivraison
        public List<DateTime> JoursNonDisponibles { get; set; }

        public bool EstDisponible(DateTime date)
        {
            return !JoursNonDisponibles.Contains(date.Date);
        }

        public void AjouterJourNonDisponible(DateTime date)
        {
            JoursNonDisponibles.Add(date.Date);
        }
        

    }
}