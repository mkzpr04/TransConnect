using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransConnectLib;

namespace TransConnectLib
{
    public class Commande : IComparable<Commande>
{
    // attributs de la classe Commande
    public string NumeroCommande { get;  set; }
    public Client Client { get;  set; }
    public string VilleDepart { get;  set; }
    public string VilleArrivee { get;  set; }
    public float Prix { get;  set; }
    public Vehicule Vehicule { get;  set; }
    public Chauffeur Chauffeur { get;  set; }
    public DateTime DateLivraison { get;  set; }
    public bool EtatLivraison { get;  set; }
    public float NoteLivraison { get;  set; }
    public int DistanceTotale { get; set; }
    public List<string> Chemin { get; set; }
    private Dijkstra dijkstra;

    // Constructeur pour la classe Commande
    public Commande(string numeroCommande, Client client, string villeDepart, string villeArrivee, Vehicule vehicule, Chauffeur chauffeur, DateTime dateLivraison, Dijkstra dijkstra)
    {
        NumeroCommande = numeroCommande;
        Client = client;
        VilleDepart = villeDepart;
        VilleArrivee = villeArrivee;
        Vehicule = vehicule;
        Chauffeur = chauffeur;
        DateLivraison = dateLivraison;
        this.dijkstra = dijkstra;
        Chemin = new List<string>();

        // Initialisation de la distance et du chemin
        DistanceTotale = this.dijkstra.CalculerPlusCourtChemin(VilleDepart, VilleArrivee);
        Chemin = this.dijkstra.Chemin;

        // Calculer le prix de la commande
        Prix = CalculerPrix();
    }
    public bool LivraisonEffectuee(string numerocommande)
    { 
        return EtatLivraison;
    }
    public float CalculerPrix()
    {
        float tarifParKm = 1.0F;

        if (Vehicule is Camionnette)
        {
            tarifParKm = 1.5F; // Tarif pour les camionnettes
        }
        if (Vehicule is Camion)
        {
            tarifParKm = 2.0F; // Tarif pour les camions 
        }

        return DistanceTotale * tarifParKm;
    }

    public void EvaluationLivraison(float note)
    {
        if (note >= 0 && note <= 5)
        {
            NoteLivraison = note;
            Console.WriteLine($"La livraison a été évaluée avec une note de: {NoteLivraison}");
        }
        else
        {
            Console.WriteLine("La note doit être comprise entre 0 et 5.");
        }
    }

    public void ModifierCommande(Vehicule vehicule, Chauffeur chauffeur, string villeDepart, string villeArrivee, DateTime dateLivraison, float prix)
    {
        Vehicule = vehicule;
        Chauffeur = chauffeur;
        VilleDepart = villeDepart;
        VilleArrivee = villeArrivee;
        DateLivraison = dateLivraison;
        Prix = prix;
        Console.WriteLine("Les détails de la commande ont été modifiés.");
    }

    public void AnnulerCommande()
    {
        EtatLivraison = false;
        Console.WriteLine("La commande a été annulée.");
    }

    public void AfficherPlanDeRoute()
    {
        Console.WriteLine($"Plan de route pour la commande {NumeroCommande}:");
        foreach (var ville in Chemin)
        {
            Console.WriteLine(ville);
        }
    }
    public int CompareTo(Commande commande)
    {
        if (commande == null) return 1;
        return Prix.CompareTo(commande.Prix);
    }

}
}
