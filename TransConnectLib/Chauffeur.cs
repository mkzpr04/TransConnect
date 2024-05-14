using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Chauffeur : Salarie
    {
        public DateTime disponibilite { get; private set; }

        public Chauffeur(string numSecu, string nom, string prenom, DateTime dateNaissance, 
                        string adressePostale, string adresseMail, string telephone, 
                        DateTime dateEntree, string poste, double salaire, DateTime disponibilite)
                        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone, 
                        dateEntree, poste, salaire)
        {
            
        }
        public Chauffeur(string numSecu, string nom, string prenom, DateTime dateNaissance, 
                        string adressePostale, string adresseMail, string telephone, 
                        DateTime dateEntree, string poste, double salaire)
                        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone, 
                        dateEntree, poste, salaire)
        {
            disponibilite=DateTime.Now;
        }
        
         // Méthodes

         // Vérifie si le chauffeur est libre pour une livraison à dateLivraison
        public bool EstLibre(DateTime dateLivraison)
        {
            if (disponibilite.Date == dateLivraison.Date)
            {
                return true; // Chauffeur libre
            }
            return false; // Chauffeur non libre
        }
        

    }
}