﻿using System;
using TransConnectLib;

namespace TransConnectApp
{
    class Program
    {
        static NoeudEmploye racine;

        static void Main(string[] args)
        {
            InitialiserEmployes();
            bool systemeActif = true;
            while (systemeActif)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans le Système de Gestion TransConnect");
                Console.WriteLine("1. Gérer les Salariés");
                Console.WriteLine("2. Gérer les Commandes");
                Console.WriteLine("3. Voir l'Organigramme");
                Console.WriteLine("4. Quitter");

                Console.Write("Veuillez entrer votre choix : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        GérerLesSalariés();
                        break;
                    case "2":
                        GérerLesCommandes();
                        break;
                    case "3":
                        GestionSalaries.ListerSalaries();
                        Console.ReadKey();
                        break;
                    case "4":
                        systemeActif = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void InitialiserEmployes()
        {
            // Création des salariés
            var directeurGeneral = new Salarie("184127645108946", "Mr Dupond", "", new DateTime(2003, 10, 10), "", "markdupond@gmail.com", "", "Directeur Général", 10000.0);
            racine = new NoeudEmploye(directeurGeneral);
            Salarie.Organigramme = racine; //initialisation de racine et Salarie.Organigramme

            var directriceCommerciale = new Salarie("084127645108947", "Mme Fiesta", "", new DateTime(2005, 09, 05), "", "fiesta@gmail.com", "", "Directrice Commerciale", 8000.0);
            GestionSalaries.AjouterSalarie(directriceCommerciale, "184127645108946");

            var directeurOperations = new Salarie("184127645108948", "Mr Fetard", "", new DateTime(2006, 08, 06), "", "fetard@yahoo.fr", "", "Directeur des opérations", 9000.0);
            GestionSalaries.AjouterSalarie(directeurOperations, "184127645108946");

            var directriceRH = new Salarie("084127645108949", "Mme Joyeuse", "", new DateTime(2007, 07, 07), "", "joyeuse@hotmail.fr", "", "Directrice des Ressources Humaines", 8500.0);
            GestionSalaries.AjouterSalarie(directriceRH, "184127645108946");

            var directeurFinancier = new Salarie("184127645108950", "Mr GripSous", "", new DateTime(2008, 06, 08), "", "gripsous@gmail.com", "", "Directeur Financier", 9500.0);
            GestionSalaries.AjouterSalarie(directeurFinancier, "184127645108946");

            var commercial1 = new Salarie("184127645108951", "Mr Forge", "", new DateTime(2009, 05, 09), "", "forge@gmail.com", "", "Commercial", 7000.0);
            GestionSalaries.AjouterSalarie(commercial1, "084127645108947");

            var commercial2 = new Salarie("084127645108952", "Mme Fermi", "", new DateTime(2005, 10, 25), "", "fermi@hotmail.fr", "", "Commerciale", 7500.0);
            GestionSalaries.AjouterSalarie(commercial2, "084127645108947");

            var chefEquipe1 = new Salarie("084127645108953", "Mr Royal", "", new DateTime(2003, 10, 10), "", "royal@yahoo.fr", "", "Chef Equipe", 8500.0);
            GestionSalaries.AjouterSalarie(chefEquipe1, "184127645108948");

            var chauffeur1 = new Chauffeur("184127645108954", "Mr Romu", "", new DateTime(2005, 09, 05), "", "romu@yahoo.Fr", "", new DateTime(2006, 08, 06), "Chauffeur", 1000.0, DateTime.Now);
            GestionSalaries.AjouterSalarie(chauffeur1, "084127645108953");

            var chauffeur2 = new Chauffeur("084127645108955", "Mr Romi", "", new DateTime(2008, 06, 08), "", "romi@gmail.com", "", new DateTime(2009, 02, 19), "Chauffeur", 1000.0, DateTime.Now);
            GestionSalaries.AjouterSalarie(chauffeur2, "084127645108953");

            var chauffeur3 = new Chauffeur("184127645108956", "Mr Rami", "", new DateTime(2007, 07, 07), "", "rami@yahoo.fr", "", new DateTime(2008, 06, 08), "Chauffeur", 1000.0, DateTime.Now);
            GestionSalaries.AjouterSalarie(chauffeur3, "084127645108953");

            var chefEquipe2 = new Salarie("084127645108957", "Mme Prince", "", new DateTime(2005, 10, 25), "", "prince@yahoo.fr", "", "Chef d'Equipe", 8000.0);
            GestionSalaries.AjouterSalarie(chefEquipe2, "184127645108948");

            var chauffeur4 = new Chauffeur("184127645108958", "Mme Rome", "", new DateTime(2003, 10, 10), "", "rome@yahoo.fr", "", new DateTime(2005, 09, 05), "Chauffeur", 1000.0, DateTime.Now);
            GestionSalaries.AjouterSalarie(chauffeur4, "084127645108957");

            var chauffeur5 = new Chauffeur("084127645108959", "Mme Rimou", "", new DateTime(2005, 09, 05), "", "rimou@hotmail.fr", "", new DateTime(2006, 03, 15), "Chauffeur", 1000.0, DateTime.Now);
            GestionSalaries.AjouterSalarie(chauffeur5, "084127645108957");

            var formation = new Salarie("184127645108960", "Mme Couleur", "", new DateTime(2005, 10, 25), "", "couleur@yahoo.fr", "", "Formation", 5000.0);
            GestionSalaries.AjouterSalarie(formation, "084127645108949");

            var contrats = new Salarie("084127645108961", "Mme TouteLeMonde", "", new DateTime(2005, 10, 25), "", "toutelemonde@yahoo.fr", "", "Contrats", 6000.0);
            GestionSalaries.AjouterSalarie(contrats, "084127645108949");

            var directionComptable = new Salarie("184127645108962", "Mr Picsou", "", new DateTime(2005, 05, 29), "", "picsou@yahoo.fr", "", "Direction comptable", 7000.0);
            GestionSalaries.AjouterSalarie(directionComptable, "184127645108950");

            var comptable1 = new Salarie("084127645108963", "Mme Fournier", "", new DateTime(2005, 01, 10), "", "fournier@hotmail.fr", "", "Comptable", 8000.0);
            GestionSalaries.AjouterSalarie(comptable1, "184127645108962");

            var comptable2 = new Salarie("084127645108964", "Mme Gautier", "", new DateTime(2005, 07, 10), "", "gautier@gmail.com", "", "Comptable", 9000.0);
            GestionSalaries.AjouterSalarie(comptable2, "184127645108962");

            var controleurGestion = new Salarie("184127645108965", "Mr GrosSous", "", new DateTime(2005, 12, 18), "", "grossous@gmail.com", "", "Controleur de Gestion", 7000.0);
            GestionSalaries.AjouterSalarie(controleurGestion, "184127645108950");
        }

        static void GérerLesSalariés()
        {
            bool retour = true;
            while (retour)
            {
                Console.Clear();
                Console.WriteLine("Gestion des Salariés");
                Console.WriteLine("1. Ajouter un salarié");
                Console.WriteLine("2. Ajouter un chauffeur");
                Console.WriteLine("3. Modifier un salarié");
                Console.WriteLine("4. Supprimer un salarié");
                Console.WriteLine("5. Lister tous les salariés");
                Console.WriteLine("6. Retour");

                Console.Write("Veuillez choisir une option : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterSalarie();
                        break;
                    case "2":
                        AjouterChauffeur();
                        break;
                    case "3":
                        ModifierSalarie();
                        break;
                    case "4":
                        SupprimerSalarie();
                        break;
                    case "5":
                        GestionSalaries.ListerSalaries();
                        Console.ReadKey();
                        break;
                    case "6":
                        retour = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void GérerLesCommandes()
        {
            bool retour = true;
            while (retour)
            {
                Console.Clear();
                Console.WriteLine("Gestion des Commandes");
                Console.WriteLine("1. Créer une nouvelle commande");
                Console.WriteLine("2. Afficher les détails d'une commande");
                Console.WriteLine("3. Modifier une commande existante");
                Console.WriteLine("4. Annuler une commande");
                Console.WriteLine("5. Lister toutes les commandes");
                Console.WriteLine("6. Rechercher des commandes");
                Console.WriteLine("7. Retour");

                Console.Write("Veuillez choisir une option : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        GestionCommande.CreerCommande();
                        break;
                    case "2":
                        Console.Write("Entrez le numéro de la commande : ");
                        string numeroCommande = Console.ReadLine();
                        GestionCommande.AfficherDetails(numeroCommande);
                        Console.ReadKey();
                        break;
                    case "3":
                        GestionCommande.ModifierCommande();
                        break;
                    case "4":
                        GestionCommande.AnnulerCommande();
                        break;
                    case "5":
                        GestionCommande.ListerCommandes();
                        Console.ReadKey();
                        break;
                    case "6":
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

                        var resultats = GestionCommande.RechercherCommandes(
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
                        Console.ReadKey();
                        break;
                    case "7":
                        retour = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void AjouterSalarie()
        {
            Console.WriteLine("Ajout d'un nouveau salarié...");
            Console.Write("Entrez le numéro de sécurité sociale: ");
            string numSecu = Console.ReadLine();
            Console.Write("Entrez le nom: ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le prénom: ");
            string prenom = Console.ReadLine();
            Console.Write("Entrez la date de naissance (yyyy-mm-dd): ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
            Console.Write("Entrez l'adresse postale: ");
            string adresse = Console.ReadLine();

            string email = "";
            bool isValidEmail = false;
            while (!isValidEmail)
            {
                Console.Write("Entrez l'email: ");
                email = Console.ReadLine();
                if (!Personne.MailValide(email))
                {
                    Console.WriteLine("Format d'email invalide. Veuillez réessayer.");
                }
                else
                {
                    isValidEmail = true;
                }
            }

            Console.Write("Entrez le téléphone: ");
            string telephone = Console.ReadLine();

            Console.Write("Entrez la date d'entrée (yyyy-mm-dd): ");
            DateTime dateEntree = DateTime.Now;
            bool isValidDate = false;
            while (!isValidDate)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    dateEntree = DateTime.Now;  // Si l'utilisateur entre une date vide, on prend la date du jour
                    isValidDate = true;
                }
                else if (DateTime.TryParse(input, out dateEntree))
                {
                    isValidDate = true;
                }
                else
                {
                    Console.WriteLine("Date invalide. Veuillez réessayer.");
                    Console.Write("Entrez la date d'entrée (yyyy-mm-dd): ");
                }
            }

            Console.Write("Entrez le poste: ");
            string poste = Console.ReadLine();
            Console.Write("Entrez le salaire: ");
            double salaire = double.Parse(Console.ReadLine());

            Console.Write("Le salarié a-t-il un manager ? (oui/non) : ");
            string choixOptionnel = Console.ReadLine().ToLower();

            if (choixOptionnel == "oui")
            {
                Console.Write("Entrez le numéro de sécurité sociale du manager: ");
                string numSecuManager = Console.ReadLine();
                Salarie nouveauSalarie = new Salarie(numSecu, nom, prenom, dateNaissance, adresse, email, telephone, dateEntree, poste, salaire);
                GestionSalaries.AjouterSalarie(nouveauSalarie, numSecuManager);
            }
            else
            {
                Salarie nouveauSalarie = new Salarie(numSecu, nom, prenom, dateNaissance, adresse, email, telephone, dateEntree, poste, salaire);
                GestionSalaries.AjouterSalarie(nouveauSalarie);
            }
        }

        static void AjouterChauffeur()
        {
            Console.WriteLine("Ajout d'un nouveau chauffeur...");
            Console.Write("Entrez le numéro de sécurité sociale: ");
            string numSecu = Console.ReadLine();
            Console.Write("Entrez le nom: ");
            string nom = Console.ReadLine();
            Console.Write("Entrez le prénom: ");
            string prenom = Console.ReadLine();
            Console.Write("Entrez la date de naissance (yyyy-mm-dd): ");
            DateTime dateNaissance = DateTime.Parse(Console.ReadLine());
            Console.Write("Entrez l'adresse postale: ");
            string adresse = Console.ReadLine();
            Console.Write("Entrez l'email: ");
            string email = Console.ReadLine();
            Console.Write("Entrez le téléphone: ");
            string telephone = Console.ReadLine();
            Console.Write("Entrez la date d'entrée (yyyy-mm-dd): ");
            DateTime dateEntree = DateTime.Parse(Console.ReadLine());
            Console.Write("Entrez le salaire: ");
            double salaire = double.Parse(Console.ReadLine());
            Console.Write("Entrez la disponibilité (yyyy-mm-dd): ");
            DateTime disponibilite = DateTime.Parse(Console.ReadLine());

            Console.Write("Le chauffeur a-t-il un manager ? (oui/non) : ");
            string choixOptionnel = Console.ReadLine().ToLower();

            if (choixOptionnel == "oui")
            {
                Console.Write("Entrez le numéro de sécurité sociale du manager: ");
                string numSecuManager = Console.ReadLine();
                Chauffeur nouveauChauffeur = new Chauffeur(numSecu, nom, prenom, dateNaissance, adresse, email, telephone, dateEntree, "Chauffeur", salaire, disponibilite);
                GestionSalaries.AjouterSalarie(nouveauChauffeur, numSecuManager);
            }
            else
            {
                Chauffeur nouveauChauffeur = new Chauffeur(numSecu, nom, prenom, dateNaissance, adresse, email, telephone, dateEntree, "Chauffeur", salaire, disponibilite);
                GestionSalaries.AjouterSalarie(nouveauChauffeur);
            }
        }

        static void ModifierSalarie()
        {
            Console.WriteLine("Modification d'un salarié...");
            Console.Write("Entrez le numéro de sécurité sociale du salarié à modifier: ");
            string numSecu = Console.ReadLine();
            Console.Write("Entrez le nouveau poste: ");
            string poste = Console.ReadLine();
            Console.Write("Entrez le nouveau salaire: ");
            double salaire = double.Parse(Console.ReadLine());

            GestionSalaries.ModifierSalarie(numSecu, poste, salaire);
        }

        static void SupprimerSalarie()
        {
            Console.WriteLine("Suppression d'un salarié...");
            Console.WriteLine("Saisissez le numéro de sécurité sociale du salarié à supprimer : ");
            string numSecu = Console.ReadLine();
            GestionSalaries.SupprimerSalarie(numSecu);
            // Supprimer le salarie de l'organigramme.
            NoeudEmploye noeud = racine.TrouverNoeud(numSecu);
            if (noeud != null)
            {
                racine.SupprimerSubordonne(noeud);
            }
        }
    }
}
