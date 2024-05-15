using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Client : Personne
    {
        public string clientId { get; set; }
        public double montantAchatsCumules { get; set; }
        public string ville { get; set; }

        public Client(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone, string clientId, string ville)
            : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.clientId = clientId;
            this.ville = ville;
            montantAchatsCumules = 0.0;
        }
    }
}