using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class CamionCiterne : Camion
    {
        public string TypeLiquideTransporte { get; private set; }
        public double CapaciteCuve { get; private set; }
        public string TypeCuve { get; private set; }

        public CamionCiterne(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                             double capaciteReservoir, string couleur,
                             string typeLiquideTransporte, double capaciteCuve, string typeCuve)
                             : base(chauffeur, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur)
        {
            this.TypeLiquideTransporte = typeLiquideTransporte;
            this.CapaciteCuve = capaciteCuve;
            this.TypeCuve = typeCuve;
        }

        public void ModifierTypeLiquideTransporte(string nouveauType)
        {
            if (!string.IsNullOrEmpty(nouveauType))
            {
                TypeLiquideTransporte = nouveauType;
                Console.WriteLine($"Le type de liquide transporté a été modifié. Nouveau type: {TypeLiquideTransporte}.");
            }
            else
            {
                Console.WriteLine("Le type de liquide transporté ne peut pas être vide.");
            }
        }

        public void ModifierCapaciteCuve(double nouvelleCapacite)
        {
            if (nouvelleCapacite >= 0)
            {
                this.CapaciteCuve = nouvelleCapacite;
                Console.WriteLine($"La capacité de la cuve a été modifiée. Nouvelle capacité: {CapaciteCuve}.");
            }
            else
            {
                Console.WriteLine("La capacité de la cuve doit être supérieure ou égale à zéro.");
            }
        }

        public void ModifierTypeCuve(string nouveauType)
        {
            if (!string.IsNullOrEmpty(nouveauType))
            {
                this.TypeCuve = nouveauType;
                Console.WriteLine($"Le type de cuve a été modifié. Nouveau type: {TypeCuve}.");
            }
            else
            {
                Console.WriteLine("Le type de cuve ne peut pas être vide.");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", Type de Liquide Transporté: {TypeLiquideTransporte}, Capacité de la Cuve: {CapaciteCuve}L, Type de Cuve: {TypeCuve}";
        }
    }

    
}
