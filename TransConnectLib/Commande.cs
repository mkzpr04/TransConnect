using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransConnectLib;

namespace FlotteVéhicule
{
    public class Commande
    {
        // Propriétés de la classe Commande
        public string NumeroCommande { get; private set; }
        public Client Client { get; private set; }
        public string VilleDepart { get; private set; }
        public string VilleArrivee { get; private set; }
        public float Prix { get; private set; }
        public Vehicule Vehicule { get; private set; }
        public Chauffeur Chauffeur { get; private set; }
        public DateTime DateLivraison { get; private set; }
        public bool EtatLivraison { get; private set; }
        public float NoteLivraison { get; private set; }


        // Constructeur pour la classe Commande
        public Commande(string numeroCommande, Client client, string villeDepart, string villeArrivee, Vehicule vehicule, Chauffeur chauffeur, DateTime dateLivraison)
        {
            this.NumeroCommande = numeroCommande;
            this.Client = client;
            this.VilleDepart = villeDepart;
            this.VilleArrivee = villeArrivee;
            this.Vehicule = vehicule;
            this.Chauffeur = chauffeur;
            this.DateLivraison = dateLivraison;
            this.EtatLivraison = false; // Par défaut, la livraison n'est pas encore effectuée
            this.NoteLivraison = 0;
            this.Prix = CalculerPrix(); // Calcule le prix initial lors de la création de la commande
        }
        public bool LivraisonEffectuee()
        {
            // A modifier en regardant sur le excel si le client a payé 
            return EtatLivraison;
        }
        public float CalculerPrix()
        {
            // A changer selon les valeurs qu'on voudra mettre 
            float distance = CalculerDistance(VilleDepart, VilleArrivee);
            float tarifParKm = 1.0F;

            if (Vehicule is Camionnette)
            {
                tarifParKm = 2.0F; // Tarif pour les camionnettes
            }
            if (Vehicule is Camion)
            {
                tarifParKm = 3.0F; // Tarif pour les camions 
            }

            return distance * tarifParKm;
        }
        private float CalculerDistance(string villeDepart, string villeArrivee)
        {
            //Récuperer les valeurs dans le excel (utiliser aussi Dijkstra ?)
            return 1.0f; //valeur juste pour pas avoir d'erreur
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
            this.Vehicule = vehicule;
            this.Chauffeur = chauffeur;
            this.VilleDepart = villeDepart;
            this.VilleArrivee = villeArrivee;
            this.DateLivraison = dateLivraison;
            this.Prix = prix;
            Console.WriteLine("Les détails de la commande ont été modifiés.");
        }
        public void AnnulerCommande()
        {
            EtatLivraison = false;
            Console.WriteLine("La commande a été annulée.");
        }
        public void AfficherDetails()
        {
            Console.WriteLine($"Commande N°: {NumeroCommande}");
            Console.WriteLine($"Client: {Client}");
            Console.WriteLine($"Véhicule: {Vehicule}");
            Console.WriteLine($"Chauffeur: {Chauffeur}");
            Console.WriteLine($"Départ: {VilleDepart}");
            Console.WriteLine($"Arrivée: {VilleArrivee}");
            Console.WriteLine($"Date de livraison: {DateLivraison}");
            Console.WriteLine($"Prix: {Prix}");
            Console.WriteLine($"Statut: {(EtatLivraison ? "Effectuée" : "Non effectuée")}");
            Console.WriteLine($"Note: {NoteLivraison}");
        }

        // créer des méthodes pour exporter les données vers un fichier excel

    }
}
