using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Salarie : Personne
    {
        // Attributs de la classe Salarie.
        private DateTime dateEntree;
        private string poste;
        private double salaire;
        public static NoeudEmploye Organigramme;
        public List<NoeudEmploye> Subordonnes;

        // Constructeurs pour la classe Salarie.
        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance,
                      string adressePostale, string adresseMail, string telephone, DateTime dateEntree, string poste, double salaire) 
                      : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = dateEntree;
            this.poste = poste;
            this.salaire = salaire;
            Subordonnes = new List<NoeudEmploye>();
        }

        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale,
                      string adresseMail, string telephone)
                      : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = DateTime.Now;
            Subordonnes = new List<NoeudEmploye>();
        }

        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale,
                      string adresseMail, string telephone, DateTime dateEntree)
                      : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = dateEntree;
            Subordonnes = new List<NoeudEmploye>();
        }

        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale,
                      string adresseMail, string telephone, string poste, double salaire)
                      : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = DateTime.Now;
            this.poste = poste;
            this.salaire = salaire;
            Subordonnes = new List<NoeudEmploye>();
        }

        // Propriétés de la classe Salarie.
        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }

        public double Salaire
        {
            get { return salaire; }
            set { salaire = value; }
        }

        // Méthodes de la classe Salarie.
        public static int NbSalaries
        {
            get { return GestionSalaries.GetSalariesCount(); }
        }
    }
}
