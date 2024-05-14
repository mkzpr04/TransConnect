using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransConnectLib;

namespace FlotteVéhicule
{
    public static class GestionCommande
    {
        private static List<Commande> commandes = new List<Commande>();

        public static void CreerCommande(Client client, Vehicule vehicule, Chauffeur chauffeur,
                                         string villeDepart, string villeArrivee, DateTime dateLivraison)
        {
            string numeroCommande = Guid.NewGuid().ToString();
            Commande nouvelleCommande = new Commande(numeroCommande, client, villeDepart, villeArrivee, vehicule, chauffeur, dateLivraison);
            commandes.Add(nouvelleCommande);
            Console.WriteLine("Nouvelle commande créée avec succès.");
        }

        public static void ModifierCommande(string numeroCommande, Vehicule vehicule, Chauffeur chauffeur, string villeDepart, string villeArrivee, DateTime dateLivraison, float prix)
        {
            Commande commande = RechercherCommande(numeroCommande);
            if (commande != null)
            {
                commande.ModifierCommande(vehicule, chauffeur, villeDepart, villeArrivee, dateLivraison, prix);
                Console.WriteLine("Commande modifiée avec succès.");
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
        }

        public static void AnnulerCommande(string numeroCommande)
        {
            Commande commande = RechercherCommande(numeroCommande);
            if (commande != null)
            {
                commande.AnnulerCommande();
                Console.WriteLine("Commande annulée avec succès.");
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
        }

        public static void ListerCommandes()
        {
            foreach (var commande in commandes)
            {
                commande.AfficherDetails();
                Console.WriteLine();
            }
        }

        public static Commande RechercherCommande(string numeroCommande)
        {
            return commandes.Find(c => c.NumeroCommande == numeroCommande);
        }

    }
}
