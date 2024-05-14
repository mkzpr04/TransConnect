using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Voiture : Vehicule
{
    public int NombrePassagers { get; private set; } // Le nombre de passagers 

    public Voiture(Chauffeur chauffeur, string plaqueImmatriculation, string marque, string modele,
                   double capaciteReservoir, string couleur, int nombrePassagers)
                   : base(chauffeur, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur)
    {
        this.NombrePassagers = nombrePassagers;
    }

    public void ChangerNombrePassagers(int nouveauNombrePassagers)
    {
        if (nouveauNombrePassagers > 0 && nouveauNombrePassagers != NombrePassagers)
        {
            this.NombrePassagers = nouveauNombrePassagers;
            Console.WriteLine($"Le nombre de passagers a été modifié. Nouveau nombre de passagers: {NombrePassagers}.");
        }
        else if (nouveauNombrePassagers <= 0)
        {
            Console.WriteLine("Le nombre de passagers doit être supérieur à zéro.");
        }
        else
        {
            Console.WriteLine("Le nouveau nombre de passagers est identique à l'ancien. Aucun changement nécessaire.");
        }
    }
    public override string ToString()
    {
        return base.ToString() + $", Nombre de Passagers: {NombrePassagers}";
    }
}

    
}
