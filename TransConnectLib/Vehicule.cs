using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public abstract class Vehicule
    {
        public Chauffeur chauffeur;
        public string PlaqueImmatriculation;
        public string Marque;
        public string Modele;
        public double CapaciteReservoir;
        public string Couleur;

        public Vehicule(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                        double capaciteReservoir, string couleur)
        {
            this.chauffeur = chauffeur;
            this.PlaqueImmatriculation = plaqueImmatriculation;
            this.Marque = marque;
            this.Modele = modele;
            this.CapaciteReservoir = capaciteReservoir;
            this.Couleur = couleur;
        }
        public void AttribuerChauffeur(Chauffeur nouveauChauffeur)
        {
            this.chauffeur = nouveauChauffeur;
        }

        

    }
}
