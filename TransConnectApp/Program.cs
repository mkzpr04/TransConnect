using System;
using TransConnectLib;

namespace TransConnectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialiser l'employé racine
            var directeurGeneral = new Salarie("123456789", "Dupont", "Jean", new DateTime(1970, 1, 1), "123 rue Principale", "dupont.jean@example.com", "0123456789", new DateTime(2000, 1, 1), "Directeur", 50000);
            Salarie.InitialiserOrganigramme(directeurGeneral);

            bool enFonctionnement = true;
            while (enFonctionnement)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans le Système de Gestion TransConnect");
                Console.WriteLine("1. Gérer les Salariés");
                Console.WriteLine("2. Voir l'Organigramme");
                Console.WriteLine("3. Quitter");

                Console.Write("Veuillez entrer votre choix : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        GererLesSalaries();
                        break;
                    case "2":
                        Salarie.AfficherOrganigramme();
                        break;
                    case "3":
                        enFonctionnement = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void GererLesSalaries()
        {
            bool retour = true;
            while (retour)
            {
                Console.Clear();
                Console.WriteLine("Gestion des Salariés");
                Console.WriteLine("1. Ajouter un salarié");
                Console.WriteLine("2. Modifier un salarié");
                Console.WriteLine("3. Supprimer un salarié");
                Console.WriteLine("4. Lister tous les salariés");
                Console.WriteLine("5. Retour");

                Console.Write("Veuillez choisir une option : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        AjouterSalarie();
                        break;
                    case "2":
                        ModifierSalarie();
                        break;
                    case "3":
                        SupprimerSalarie();
                        break;
                    case "4":
                        Salarie.ListerSalaries();
                        break;
                    case "5":
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
            Console.Write("Entrez l'email: ");
            string email = Console.ReadLine();
            Console.Write("Entrez le téléphone: ");
            string telephone = Console.ReadLine();
            Console.Write("Entrez la date d'entrée (yyyy-mm-dd): ");
            DateTime dateEntree = DateTime.Parse(Console.ReadLine());

            Console.Write("Voulez-vous entrer le poste et le salaire maintenant? (oui/non): ");
            string choixOptionnel = Console.ReadLine().ToLower();

            if (choixOptionnel == "oui")
            {
                Console.Write("Entrez le poste: ");
                string poste = Console.ReadLine();
                Console.Write("Entrez le salaire: ");
                double salaire = double.Parse(Console.ReadLine());

                Salarie nouveauSalarie = new Salarie(numSecu, nom, prenom, dateNaissance, adresse, email, telephone, dateEntree, poste, salaire);
                Console.Write("Entrez le numéro de sécurité sociale du manager: ");
                string numSecuManager = Console.ReadLine();
                Salarie.AjouterSalarie(nouveauSalarie, numSecuManager);
            }
            else
            {
                Salarie nouveauSalarie = new Salarie(numSecu, nom, prenom, dateNaissance, adresse, email, telephone, dateEntree);
                Console.Write("Entrez le numéro de sécurité sociale du manager: ");
                string numSecuManager = Console.ReadLine();
                Salarie.AjouterSalarie(nouveauSalarie, numSecuManager);
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

            var employe = Salarie.EmployeTC.FirstOrDefault(e => e.NumSecu == numSecu);
            if (employe != null)
            {
                employe.Poste = poste;
                employe.Salaire = salaire;
                Console.WriteLine("Salarié modifié avec succès !");
            }
            else
            {
                Console.WriteLine("Salarié non trouvé !");
            }
            Console.ReadKey();
        }

        static void SupprimerSalarie()
        {
            Console.WriteLine("Suppression d'un salarié...");
            Console.Write("Entrez le numéro de sécurité sociale du salarié à supprimer: ");
            string numSecu = Console.ReadLine();

            Salarie.SupprimerSalarie(numSecu);
        }
    }
}
