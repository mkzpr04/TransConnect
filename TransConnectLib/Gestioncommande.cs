using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransConnectLib;
using System.IO;

namespace TransConnectLib
{
    public class GestionCommande 
    {
        private List<Commande> commandes;

        public GestionCommande()
        {
            commandes = new List<Commande>();
        }

        public void AfficherDetails(string numeroCommande)
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

        public void CreerCommande()
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

            Console.Write("Entrez la ville de départ : ");
            string villeDepart = Console.ReadLine();

            Console.Write("Entrez la ville d'arrivée : ");
            string villeArrivee = Console.ReadLine();

            Vehicule vehicule = CreerVehicule();

            Console.Write("Entrez le numéro de sécurité sociale du chauffeur : ");
            string chauffeurNumSecu = Console.ReadLine();
            Chauffeur chauffeur = (Chauffeur)Salarie.Organigramme.Salarie.Subordonnes.SelectMany(n => n.Subordonnes).Select(n => n.Salarie).FirstOrDefault(c => c.NumSecu == chauffeurNumSecu);

            if (chauffeur == null)
            {
                Console.WriteLine("Chauffeur non trouvé.");
                return;
            }

            Console.Write("Entrez la date de livraison (yyyy-MM-dd) : ");
            DateTime dateLivraison = DateTime.Parse(Console.ReadLine());

            string numeroCommande = Guid.NewGuid().ToString();
            Commande nouvelleCommande = new Commande(numeroCommande, client, villeDepart, villeArrivee, vehicule, chauffeur, dateLivraison);
            commandes.Add(nouvelleCommande);
            Console.WriteLine("Nouvelle commande créée avec succès.");
            MettreAJourFichierExcel();
        }

        private Vehicule CreerVehicule()
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

        public void ModifierCommande()
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
                Console.Write("Entrez le nouveau numéro de sécurité sociale du chauffeur : ");
                string chauffeurNumSecu = Console.ReadLine();
                Chauffeur chauffeur = (Chauffeur)Salarie.Organigramme.Salarie.Subordonnes
                    .SelectMany(n => n.Subordonnes)
                    .Select(n => n.Salarie)
                    .FirstOrDefault(c => c.NumSecu == chauffeurNumSecu);
                
                if (chauffeur == null)
                {
                    Console.WriteLine("Chauffeur non trouvé.");
                    return;
                }

                commande.ModifierCommande(vehicule, chauffeur, villeDepart, villeArrivee, dateLivraison, prix);
                Console.WriteLine("Commande modifiée avec succès.");
                MettreAJourFichierExcel();
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
        }

        public void AnnulerCommande()
        {
            Console.Write("Entrez le numéro de la commande à annuler : ");
            string numeroCommande = Console.ReadLine();

            Commande commande = RechercherCommande(numeroCommande);
            if (commande != null)
            {
                commande.AnnulerCommande();
                Console.WriteLine("Commande annulée avec succès.");
                MettreAJourFichierExcel();
            }
            else
            {
                Console.WriteLine("Commande non trouvée.");
            }
        }

        public void ListerCommandes()
        {
            foreach (var commande in commandes)
            {
                Console.WriteLine(commande);
                Console.WriteLine();
            }
        }

        public Commande RechercherCommande(string numeroCommande)
        {
            return commandes.Find(c => c.NumeroCommande == numeroCommande);
        }

        public List<Commande> RechercherCommandes(string villeDepart = null, string villeArrivee = null, DateTime? dateLivraison = null, string clientNom = null)
        {
            return commandes.FindAll(c =>
                (villeDepart == null || c.VilleDepart == villeDepart) &&
                (villeArrivee == null || c.VilleArrivee == villeArrivee) &&
                (dateLivraison == null || c.DateLivraison.Date == dateLivraison.Value.Date) &&
                (clientNom == null || c.Client.Nom == clientNom));
        }

        private void MettreAJourFichierExcel()
        {
            string filePath = "commandes.xlsx";
            FileInfo fileInfo = new FileInfo(filePath);

            using (ExcelPackage package = new ExcelPackage(fileInfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Count > 0 ? package.Workbook.Worksheets[0] : package.Workbook.Worksheets.Add("Commandes");

                worksheet.Cells.Clear();

                worksheet.Cells[1, 1].Value = "Numéro Commande";
                worksheet.Cells[1, 2].Value = "Client";
                worksheet.Cells[1, 3].Value = "Ville Départ";
                worksheet.Cells[1, 4].Value = "Ville Arrivée";
                worksheet.Cells[1, 5].Value = "Véhicule";
                worksheet.Cells[1, 6].Value = "Chauffeur";
                worksheet.Cells[1, 7].Value = "Date Livraison";
                worksheet.Cells[1, 8].Value = "Prix";
                worksheet.Cells[1, 9].Value = "Statut";
                worksheet.Cells[1, 10].Value = "Note";

                int row = 2;
                foreach (var commande in commandes)
                {
                    worksheet.Cells[row, 1].Value = commande.NumeroCommande;
                    worksheet.Cells[row, 2].Value = commande.Client.Nom;
                    worksheet.Cells[row, 3].Value = commande.VilleDepart;
                    worksheet.Cells[row, 4].Value = commande.VilleArrivee;
                    worksheet.Cells[row, 5].Value = commande.Vehicule.Marque;
                    worksheet.Cells[row, 6].Value = commande.Chauffeur.Nom;
                    worksheet.Cells[row, 7].Value = commande.DateLivraison.ToString("yyyy-MM-dd");
                    worksheet.Cells[row, 8].Value = commande.Prix;
                    worksheet.Cells[row, 9].Value = commande.EtatLivraison ? "Effectuée" : "Non effectuée";
                    worksheet.Cells[row, 10].Value = commande.NoteLivraison;
                    row++;
                }

                package.Save();
            }
        }

        public void AfficherMenu()
        {
            while (true)
            {
                Console.WriteLine("Menu de gestion des commandes :");
                Console.WriteLine("1. Créer une nouvelle commande");
                Console.WriteLine("2. Afficher les détails d'une commande");
                Console.WriteLine("3. Modifier une commande existante");
                Console.WriteLine("4. Annuler une commande");
                Console.WriteLine("5. Lister toutes les commandes");
                Console.WriteLine("6. Rechercher des commandes");
                Console.WriteLine("7. Quitter");
                Console.Write("Entrez votre choix : ");

                int choix = int.Parse(Console.ReadLine());

                switch (choix)
                {
                    case 1:
                        CreerCommande();
                        break;
                    case 2:
                        Console.Write("Entrez le numéro de la commande : ");
                        string numeroCommande = Console.ReadLine();
                        AfficherDetails(numeroCommande);
                        break;
                    case 3:
                        ModifierCommande();
                        break;
                    case 4:
                        AnnulerCommande();
                        break;
                    case 5:
                        ListerCommandes();
                        break;
                    case 6:
                        Console.WriteLine("Entrez les critères de recherche (laissez vide pour ignorer un critère) :");
                        Console.Write("Ville de départ : ");
                        string villeDepart = Console.ReadLine();
                        Console.Write("Ville d'arrivée : ");
                        string villeArrivee = Console.ReadLine();
                        Console.Write("Date de livraison (yyyy-MM-dd) : ");
                        string dateLivraisonStr = Console.ReadLine();
                        DateTime? dateLivraison = string.IsNullOrEmpty(dateLivraisonStr) ? (DateTime?)null : DateTime.Parse(dateLivraisonStr);
                        Console.Write("Nom du client : ");
                        string clientNom = Console.ReadLine();

                        var resultats = RechercherCommandes(
                            string.IsNullOrEmpty(villeDepart) ? null : villeDepart,
                            string.IsNullOrEmpty(villeArrivee) ? null : villeArrivee,
                            dateLivraison,
                            string.IsNullOrEmpty(clientNom) ? null : clientNom
                        );

                        foreach (var commande in resultats)
                        {
                            Console.WriteLine(commande);
                            Console.WriteLine();
                        }
                        break;
                    case 7:
                        return;
                    default:
                        Console.WriteLine("Choix non valide, veuillez réessayer.");
                        break;
                }
            }
        }
    }
}
