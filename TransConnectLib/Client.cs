using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Client : Personne
    {
        public string clientId;

        public Client(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone, string clientId)
            : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.clientId = clientId;
        }
    }
}