using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransConnectLib;

namespace TransConnectLib
{
  public class Statistiques
  {
    private List<Commande> commandes;

    public Statistiques(List<Commande> commandes)
    {
        this.commandes = commandes;
    }

    public void AfficherMenuStatistiques()
    {
        while (true)
        {
            Console.WriteLine("Menu des statistiques :");
            Console.WriteLine("1. Afficher les statistiques des commandes");
            Console.WriteLine("2. Afficher les statistiques des chauffeurs");
            Console.WriteLine("3. Afficher les statistiques des véhicules");
            Console.WriteLine("4. Retour au menu principal");
            Console.Write("Entrez votre choix : ");

            int choix = int.Parse(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    AfficherStatistiquesCommandes();
                    break;
                case 2:
                    AfficherStatistiquesChauffeurs();
                    break;
                case 3:
                    AfficherStatistiquesVehicules();
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Choix non valide, veuillez réessayer.");
                    break;
            }
        }
    }

    private void AfficherStatistiquesCommandes()
    {
        Console.WriteLine("Statistiques des commandes :");
        Console.WriteLine($"Total des commandes : {commandes.Count}");
        Console.WriteLine($"Total des commandes réalisées : {commandes.Count(c => c.EtatLivraison)}");
        Console.WriteLine($"Total des commandes annulées : {commandes.Count(c => !c.EtatLivraison)}");

        var commandesTriees = commandes.OrderBy(c => c).ToList();
        Console.WriteLine("Commandes triées par prix :");
        foreach (var commande in commandesTriees)
        {
            Console.WriteLine(commande);
        }
    }

    private void AfficherStatistiquesChauffeurs()
    {
        var chauffeurs = commandes.GroupBy(c => c.Chauffeur).Select(g => g.Key).OrderBy(c => c).ToList();
        foreach (var chauffeur in chauffeurs)
        {
            Console.WriteLine($"Chauffeur : {chauffeur.Nom}");
            Console.WriteLine($"  Nombre de livraisons : {chauffeur.GetNombreLivraisons()}");
            Console.WriteLine($"  Moyenne des notes : {chauffeur.GetMoyenneNotes():0.00}");
        }
    }

    private void AfficherStatistiquesVehicules()
    {
        var typesVehicules = commandes.GroupBy(c => c.Vehicule.GetType().Name);
        foreach (var typeGroup in typesVehicules)
        {
            var type = typeGroup.Key;
            Console.WriteLine($"Type de véhicule : {type}");
            Console.WriteLine($"  Utilisation : {typeGroup.Count()}");
            Console.WriteLine($"  Moyenne des distances parcourues : {typeGroup.Average(c => c.Vehicule.DistanceParcourue):0.00} km");
        }
    }
}
}
