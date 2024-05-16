using System;
using System.Collections.Generic;
using System.Linq;
using TransConnectLib;

namespace TransConnectLib
{
    public static class GestionCommande 
    {
        private static List<Commande> commandes = new List<Commande>();

        public static void AfficherDetails(string numeroCommande)
        {
            Commande commande = RechercherCommande(numeroCommande);
            if (commande != null)
            {
                Console.WriteLine(commande);
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
        }

        public static void CreerCommande()
        {
            Console.WriteLine("Création d'une nouvelle commande...");

            Console.Write("Entrez l'ID du client : ");
            string clientId = Console.ReadLine();
            Client client = GestionClients.RechercherClient(clientId);
            if (client == null)
            {
                Console.WriteLine("Client non trouvé, veuillez créer un nouveau client.");
                client = CreerClient();
            }

            Console.Write("Entrez la ville de départ : ");
            string villeDepart = Console.ReadLine();

            Console.Write("Entrez la ville d'arrivée : ");
            string villeArrivee = Console.ReadLine();

            Vehicule vehicule = CreerVehicule();

            Console.Write("Entrez la date de livraison (yyyy-MM-dd) : ");
            DateTime dateLivraison = DateTime.Parse(Console.ReadLine());

            List<Chauffeur> chauffeursDisponibles = ObtenirChauffeursDisponibles(dateLivraison);
            if (chauffeursDisponibles.Count == 0)
            {
                Console.WriteLine("Aucun chauffeur disponible à cette date.");
                return;
            }

            Console.WriteLine("Chauffeurs disponibles :");
            for (int i = 0; i < chauffeursDisponibles.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {chauffeursDisponibles[i].Nom} {chauffeursDisponibles[i].Prenom}");
            }

            Console.Write("Choisissez un chauffeur : ");
            int choixChauffeur = int.Parse(Console.ReadLine()) - 1;
            if (choixChauffeur < 0 || choixChauffeur >= chauffeursDisponibles.Count)
            {
                Console.WriteLine("Choix invalide.");
                return;
            }

            Chauffeur chauffeur = chauffeursDisponibles[choixChauffeur];
            chauffeur.AjouterJourNonDisponible(dateLivraison);  // Marquer le chauffeur comme non disponible pour ce jour

            string numeroCommande = Guid.NewGuid().ToString();
            Commande nouvelleCommande = new Commande(numeroCommande, client, villeDepart, villeArrivee, vehicule, chauffeur, dateLivraison);
            commandes.Add(nouvelleCommande);
            Console.WriteLine("Nouvelle commande créée avec succès.");
        }

        private static List<Chauffeur> ObtenirChauffeursDisponibles(DateTime dateLivraison)
        {
            List<Chauffeur> chauffeursDisponibles = new List<Chauffeur>();
            AjouterChauffeursDisponibles(Salarie.Organigramme, chauffeursDisponibles, dateLivraison);
            return chauffeursDisponibles;
        }

        private static void AjouterChauffeursDisponibles(NoeudEmploye noeud, List<Chauffeur> chauffeursDisponibles, DateTime dateLivraison)
        {
            if (noeud.Salarie is Chauffeur chauffeur && chauffeur.EstDisponible(dateLivraison))
            {
                chauffeursDisponibles.Add(chauffeur);
            }

            foreach (var sub in noeud.Subordonnes)
            {
                AjouterChauffeursDisponibles(sub, chauffeursDisponibles, dateLivraison);
            }
        }

        private static Client CreerClient()
        {
            Console.WriteLine("Création d'un nouveau client...");
            Console.Write("Entrez le numéro de sécurité sociale : ");
            string numSecu = Console.ReadLine();
            Console.Write("Entrez le nom : ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Entrez la date de naissance (yyyy-MM-dd) : ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
            Console.Write("Entrez l'adresse postale : ");
            string adressePostale = Console.ReadLine();
            Console.Write("Entrez l'adresse mail : ");
            string adresseMail = Console.ReadLine();
            Console.Write("Entrez le téléphone : ");
            string telephone = Console.ReadLine();
            Console.Write("Entrez l'ID client : ");
            string clientId = Console.ReadLine();
            Console.Write("Entrez la ville : ");
            string ville = Console.ReadLine();

            Client client = new Client(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone, clientId, ville);
            GestionClients.AjouterClient(client);
            return client;
        }

        private static Vehicule CreerVehicule()
        {
            Console.WriteLine("Choisissez un type de véhicule :");
            Console.WriteLine("1. Voiture");
            Console.WriteLine("2. Camionnette");
            Console.WriteLine("3. Camion Frigorifique");
            Console.WriteLine("4. Camion Benne");
            Console.WriteLine("5. Camion Citerne");
            Console.Write("Entrez votre choix : ");
            int choix = int.Parse(Console.ReadLine());

            Console.Write("Entrez la plaque d'immatriculation : ");
            string plaqueImmatriculation = Console.ReadLine();
            Console.Write("Entrez la marque : ");
            string marque = Console.ReadLine();
            Console.Write("Entrez le modèle : ");
            string modele = Console.ReadLine();
            Console.Write("Entrez la capacité du réservoir : ");
            double capaciteReservoir = double.Parse(Console.ReadLine());
            Console.Write("Entrez la couleur : ");
            string couleur = Console.ReadLine();

            switch (choix)
            {
                case 1:
                    Console.Write("Entrez le nombre de passagers : ");
                    int nombrePassagers = int.Parse(Console.ReadLine());
                    return new Voiture(null, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur, nombrePassagers);
                case 2:
                    Console.Write("Entrez l'usage : ");
                    string usage = Console.ReadLine();
                    return new Camionnette(null, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur, usage);
                case 3:
                    Console.Write("Entrez la température : ");
                    double temperature = double.Parse(Console.ReadLine());
                    Console.Write("Entrez le nombre de groupes électrogènes : ");
                    int nombreGroupesElectrogenes = int.Parse(Console.ReadLine());
                    Console.Write("Entrez la date de péremption (yyyy-MM-dd) : ");
                    DateTime datePeremption = DateTime.Parse(Console.ReadLine());
                    return new CamionFrigorifique(null, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur, temperature, new List<string>(), nombreGroupesElectrogenes, datePeremption);
                case 4:
                    Console.Write("Entrez le nombre de bennes : ");
                    int nombreBennes = int.Parse(Console.ReadLine());
                    Console.Write("Y a-t-il une grue (true/false) ? ");
                    bool grue = bool.Parse(Console.ReadLine());
                    Console.Write("Entrez le type de benne : ");
                    string typeBenne = Console.ReadLine();
                    Console.Write("Entrez le volume de la benne : ");
                    double volumeBenne = double.Parse(Console.ReadLine());
                    return new CamionBenne(null, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur, nombreBennes, grue, new List<string>(), typeBenne, volumeBenne);
                case 5:
                    Console.Write("Entrez le type de liquide transporté : ");
                    string typeLiquideTransporte = Console.ReadLine();
                    Console.Write("Entrez la capacité de la cuve : ");
                    double capaciteCuve = double.Parse(Console.ReadLine());
                    Console.Write("Entrez le type de cuve : ");
                    string typeCuve = Console.ReadLine();
                    return new CamionCiterne(null, plaqueImmatriculation, marque, modele, capaciteReservoir, couleur, typeLiquideTransporte, capaciteCuve, typeCuve);
                default:
                    Console.WriteLine("Choix non valide.");
                    return null;
            }
        }

        public static void ModifierCommande()
        {
            Console.Write("Entrez le numéro de la commande à modifier : ");
            string numeroCommande = Console.ReadLine();

            Commande commande = RechercherCommande(numeroCommande);
            if (commande != null)
            {
                Console.Write("Entrez la nouvelle ville de départ : ");
                string villeDepart = Console.ReadLine();

                Console.Write("Entrez la nouvelle ville d'arrivée : ");
                string villeArrivee = Console.ReadLine();

                Console.Write("Entrez la nouvelle date de livraison (yyyy-MM-dd) : ");
                DateTime dateLivraison = DateTime.Parse(Console.ReadLine());

                Console.Write("Entrez le nouveau prix : ");
                float prix = float.Parse(Console.ReadLine());

                Console.WriteLine("Modification du véhicule...");
                Vehicule vehicule = CreerVehicule();

                Console.WriteLine("Modification du chauffeur...");
                List<Chauffeur> chauffeursDisponibles = ObtenirChauffeursDisponibles(dateLivraison);
                if (chauffeursDisponibles.Count == 0)
                {
                    Console.WriteLine("Aucun chauffeur disponible à cette date.");
                    return;
                }

                Console.WriteLine("Chauffeurs disponibles :");
                for (int i = 0; i < chauffeursDisponibles.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {chauffeursDisponibles[i].Nom} {chauffeursDisponibles[i].Prenom}");
                }

                Console.Write("Choisissez un chauffeur : ");
                int choixChauffeur = int.Parse(Console.ReadLine()) - 1;
                if (choixChauffeur < 0 || choixChauffeur >= chauffeursDisponibles.Count)
                {
                    Console.WriteLine("Choix invalide.");
                    return;
                }

                Chauffeur chauffeur = chauffeursDisponibles[choixChauffeur];
                chauffeur.AjouterJourNonDisponible(dateLivraison);  // Marquer le chauffeur comme non disponible pour ce jour

                commande.ModifierCommande(vehicule, chauffeur, villeDepart, villeArrivee, dateLivraison, prix);
                Console.WriteLine("Commande modifiée avec succès.");
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
        }

        public static void AnnulerCommande()
        {
            Console.Write("Entrez le numéro de la commande à annuler : ");
            string numeroCommande = Console.ReadLine();

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
                Console.WriteLine(commande);
                Console.WriteLine();
            }
        }

        public static Commande RechercherCommande(string numeroCommande)
        {
            return commandes.Find(c => c.NumeroCommande == numeroCommande);
        }

        public static List<Commande> RechercherCommandes(string villeDepart = null, string villeArrivee = null, DateTime? dateLivraison = null, string clientNom = null)
        {
            return commandes.FindAll(c =>
                (villeDepart == null || c.VilleDepart == villeDepart) &&
                (villeArrivee == null || c.VilleArrivee == villeArrivee) &&
                (dateLivraison == null || c.DateLivraison.Date == dateLivraison.Value.Date) &&
                (clientNom == null || c.Client.Nom == clientNom));
        }

        private static Chauffeur TrouverChauffeur(string numSecu)
        {
            return Salarie.Organigramme?.TrouverNoeud(numSecu)?.Salarie as Chauffeur;
        }
    }
}
