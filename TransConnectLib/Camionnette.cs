using FlotteVéhicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Camionnette : Vehicule
    {
        public string Usage { get; private set; } // L'usage de la camionnette 

        public Camionnette(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                           double capaciteReservoir, string couleur, string usage)
                           : base(chauffeur, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur)
        {
            this.Usage = usage;
        }
        public void ChangerUsage(string nouvelUsage)
        {
            if (!string.IsNullOrEmpty(nouvelUsage) && !nouvelUsage.Equals(Usage, StringComparison.OrdinalIgnoreCase))
            {
                this.Usage = nouvelUsage;
                Console.WriteLine($"L'usage de la camionnette a été modifié. Nouvel usage: {Usage}.");
            }
            else if (string.IsNullOrEmpty(nouvelUsage))
            {
                Console.WriteLine("Le nouvel usage ne peut pas être vide.");
            }
            else
            {
                Console.WriteLine("Le nouvel usage est identique à l'ancien. Aucun changement nécessaire.");
            }
        }
        public override string ToString()
        {
            return base.ToString() + $", Usage: {Usage}";
        }
    }
}
