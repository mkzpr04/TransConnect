using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public abstract class Vehicule
{
    // Propriétés du véhicule
    public Chauffeur Chauffeur { get; private set; }  // Le chauffeur attribué au véhicule
    public string PlaqueImmatriculation { get; private set; }  // La plaque d'immatriculation du véhicule
    public string Marque { get; private set; }  // La marque du véhicule
    public string Modele { get; private set; }  // Le modèle du véhicule
    public double CapaciteReservoir { get; private set; }  // La capacité du réservoir du véhicule
    public string Couleur { get; private set; }  // La couleur du véhicule

    // Constructeur pour la classe Vehicule.
    public Vehicule(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                    double capaciteReservoir, string couleur)
    {
        this.Chauffeur = chauffeur;
        this.PlaqueImmatriculation = plaqueImmatriculation;
        this.Marque = marque;
        this.Modele = modele;
        this.CapaciteReservoir = capaciteReservoir;
        this.Couleur = couleur;
    }

    // Méthodes pour la classe Vehicule.
    public void AttribuerChauffeur(Chauffeur nouveauChauffeur)
    {
        this.Chauffeur = nouveauChauffeur;
    }

    public override string ToString()
    {
        return $"Plaque: {PlaqueImmatriculation}, Marque: {Marque}, Modèle: {Modele}, Couleur: {Couleur}, Capacité Réservoir: {CapaciteReservoir}L, Chauffeur: {Chauffeur?.Nom ?? "Aucun"}";
    }
}
}
