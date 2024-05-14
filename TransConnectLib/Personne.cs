using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    // Représente une personne de base avec des informations générales chez TransConnect.
    public abstract class Personne
    {
        private string numSecu;
        private string nom;
        private string prenom;
        private DateTime dateNaissance;
        private string adressePostale;
        private string adresseMail;
        private string telephone;

        // Constructeur pour la classe abstraite Personne.
        protected Personne(string numSecu,string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone)
        {
            this.numSecu = numSecu;
            this.nom = nom;
            this.prenom = prenom;
            this.dateNaissance = dateNaissance;
            this.adressePostale = adressePostale;
            if (!MailValide(adresseMail))
            {
                throw new ArgumentException("L'adresse mail n'est pas valide.");
            }
            this.adresseMail = adresseMail;
            this.telephone = telephone;
        }

        // Propriétés de la classe Personne.
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public DateTime DateNaissance { get => dateNaissance; }
        public string NumSecu { get => numSecu;}
        public string AdresseMail
        {
            get{ return adresseMail; }
            set{ adresseMail = value; }
        }

        public string Telephone
        {
            get{ return telephone; }
            set{ telephone = value; }
        }

        public string AdressePostale
        {
            get{ return adressePostale; }
            set{ adressePostale = value; }
        }

        // Méthodes de la classe Personne.

        // Vérifie si l'adresse mail est valide.
        public static bool MailValide(string adresseMail)  // Méthode statique pour la réutiliser dans d'autres classes sans instancier un objet Personne.
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(adresseMail);
                return addr.Address == adresseMail;
            }
            catch
            {
                return false;
            }
        }

        public bool MailValide()
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(adresseMail);
                return addr.Address == adresseMail;
            }
            catch
            {
                return false;
            }
        }

        // Change l'adresse postale de la personne.
        public void ChangeAddresse(string newAddress)
        {
            adressePostale = newAddress;
        }

        // Calcule l'âge de la personne.
        public int CalculAge()
        {
            int age = DateTime.Now.Year - dateNaissance.Year;
            if (DateTime.Now.DayOfYear < dateNaissance.DayOfYear)
                age = age - 1;

            return age;
        }

        // Retourne une chaine de caractères représentant la personne.
        public override string ToString()
        {
            return $"Nom: {Nom}, Adresse Mail: {AdresseMail}, Telephone: {Telephone}";
        }



    }
}

