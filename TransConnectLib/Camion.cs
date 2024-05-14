using FlotteVéhicule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Camion : Vehicule
    {
        public Camion(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                      double capaciteReservoir, string couleur)
                      : base(chauffeur, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur)
        {
            
        }
    }

    
}
