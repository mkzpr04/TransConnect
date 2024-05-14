using FlotteVéhicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class CamionBenne : Camion
    {
        public int NombreBennes { get; private set; }
        public bool Grue { get; private set; }
        public List<string> ProduitsTransportes { get; private set; }
        public string TypeBenne { get; private set; }
        public double VolumeBenne { get; private set; }

        public CamionBenne(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                           double capaciteReservoir, string couleur,
                           int nombreBennes, bool Grue, List<string> produitsTransportes,
                           string typeBenne, double volumeBenne)
                           : base(chauffeur, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur)
        {
            this.NombreBennes = nombreBennes;
            this.Grue = Grue;
            this.ProduitsTransportes = produitsTransportes;
            this.TypeBenne = typeBenne;
            this.VolumeBenne = volumeBenne;
        }
        public void ModifierNombreBennes(int nouveauNombre)
        {
            if (nouveauNombre >= 0)
            {
                this.NombreBennes = nouveauNombre;
                Console.WriteLine($"Le nombre de bennes a été modifié. Nouveau nombre: {NombreBennes}.");
            }
            else
            {
                Console.WriteLine("Le nombre de bennes doit être supérieur ou égal à zéro.");
            }
        }
        public void PresenceGrue(bool grue)
        {
            this.Grue = grue;
            Console.WriteLine($"Présence de la grue modifiée. Nouvelle valeur: {Grue}.");
        }
        public void ModifierTypeBenne(string nouveauType)
        {
            if (!string.IsNullOrEmpty(nouveauType))
            {
                this.TypeBenne = nouveauType;
                Console.WriteLine($"Le type de benne a été modifié. Nouveau type: {TypeBenne}.");
            }
            else
            {
                Console.WriteLine("Le type de benne ne peut pas être vide.");
            }
        }
        public void ModifierVolumeBenne(double nouveauVolume)
        {
            if (nouveauVolume >= 0)
            {
                this.VolumeBenne = nouveauVolume;
                Console.WriteLine($"Le volume de la benne a été modifié. Nouveau volume: {VolumeBenne}.");
            }
            else
            {
                Console.WriteLine("Le volume de la benne doit être supérieur ou égal à zéro.");
            }
        }
        public void AjouterProduit(string produit)
        {
            ProduitsTransportes.Add(produit);
        }
        public void SupprimerProduit(string produit)
        {
            ProduitsTransportes.Remove(produit);
        }
        public override string ToString()
        {
            return base.ToString() + $", Nombre de Bennes: {NombreBennes}, Grue: {Grue}, Type de Benne: {TypeBenne}, Volume de la Benne: {VolumeBenne}, Produits Transportés: {string.Join(", ", ProduitsTransportes)}";
        }

    }
}
