using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    abstract class Vehicule
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

        public void ChangerChauffeur(Chauffeur nouveauChauffeur)
        {
            if (this.chauffeur != null && this.chauffeur.Equals(nouveauChauffeur))
            {
                Console.WriteLine("Pas de changement de chauffeur nécessaire.");
                return;
            }

            if (nouveauChauffeur.IsAvailable())
            {
                this.chauffeur = nouveauChauffeur;
                Console.WriteLine($"Changement de chauffeur effectué. Nouveau chauffeur: {nouveauChauffeur.Nom}");
            }
            else
            {
                Console.WriteLine("Changement de chauffeur impossible.");
            }
        }

    }
}
