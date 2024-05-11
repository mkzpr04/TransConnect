using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class NoeudEmploye
    {
        public Salarie salarie;
        public List<NoeudEmploye> chefs;

        public NoeudEmploye(Salarie salarie)
        {
            this.salarie = salarie;
            this.chefs = new List<NoeudEmploye>();
        }

        public void AjouterChef(NoeudEmploye chef)
        {
            this.chefs.Add(chef);
        }

        public void SupprimerChef(NoeudEmploye chef)
        {
            this.chefs.Remove(chef);
        }
    }
}
