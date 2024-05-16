using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class CamionFrigorifique : Camion
    {
        public double Temperature { get; private set; } 
        public List<string> ProduitsTransportes { get; private set; }
        public int NombreGroupesElectrogenes { get; private set; }
        public DateTime DatePeremption { get; private set; }

        public CamionFrigorifique(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                           double capaciteReservoir, string couleur,
                           double temperature, List<string> produitsTransportes,
                           int nombreGroupesElectrogenes, DateTime datePeremption)
                           : base(chauffeur, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur)
        {
            this.Temperature = temperature;
            this.ProduitsTransportes = produitsTransportes;
            this.NombreGroupesElectrogenes = nombreGroupesElectrogenes;
            this.DatePeremption = datePeremption;
        }
        public void ModifierNombreGroupesElectrogenes(int nouveauNombre)
        {
            if (nouveauNombre >= 0)
            {
                this.NombreGroupesElectrogenes = nouveauNombre;
                Console.WriteLine($"Le nombre de groupes électrogènes a été modifié. Nouveau nombre: {NombreGroupesElectrogenes}.");
            }
            else
            {
                Console.WriteLine("Le nombre de groupes électrogènes doit être supérieur ou égal à zéro.");
            }
        }
        public void ModifierDatePeremption(DateTime nouvelleDate)
        {
            if (nouvelleDate > DateTime.Now)
            {
                this.DatePeremption = nouvelleDate;
                Console.WriteLine($"La date de péremption a été modifiée. Nouvelle date: {DatePeremption.ToShortDateString()}.");
            }
            else
            {
                Console.WriteLine("La date de péremption doit être dans le futur.");
            }
        }

        // Ajoute un produit à la liste des produits transportés.
        public void AjouterProduit(string produit)
        {
            ProduitsTransportes.Add(produit);
        }
        // Supprime un produit de la liste des produits transportés.
        public void SupprimerProduit(string produit)
        {
            ProduitsTransportes.Remove(produit);
        }
        public override string ToString()
        {
            return base.ToString() + $", Temperature: {Temperature}, Nombre de Groupes Electrogenes: {NombreGroupesElectrogenes}, Date de Peremption: {DatePeremption.ToShortDateString()}, Produits Transportes: {string.Join(", ", ProduitsTransportes)}";
        }

    }
}
