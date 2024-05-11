using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Salarie : Personne
    {
        private DateTime dateEntree;
        private string poste;
        private double salaire;
        public static NoeudEmploye Organigramme;
        public static List<Salarie> EmployeTC = new List<Salarie>();
        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone, DateTime dateEntree, string poste, double salaire) 
        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = dateEntree;
            this.poste = poste;
            this.salaire = salaire;
        }
        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone) 
        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = DateTime.Now;
        }
        public Salarie(string numSecu, string nom, string prenom, DateTime dateNaissance, string adressePostale, string adresseMail, string telephone, DateTime dateEntree) 
        : base(numSecu, nom, prenom, dateNaissance, adressePostale, adresseMail, telephone)
        {
            this.dateEntree = dateEntree;
        }
        public string Poste
        {
            get { return poste ; }
            set{ poste = value ; }
        }

        public double Salaire
        {
            get { return salaire ; }
            set{ salaire = value ; }
        }

        static void AjouterSalarie(List<Salarie> EmployeTC, Salarie salarie)
        {
            Console.WriteLine("Ajout d'un nouveau salarié...");
            EmployeTC.Add(salarie);
            Console.WriteLine("Salarié ajouté avec succès !");
            Console.ReadKey();
        }

        static void SupprimerSalarie(List<Salarie> EmployeTC, Salarie salarie)
        {
            Console.WriteLine("Suppression d'un salarié...");
            Console.WriteLine("Saisissez le numéro de sécurité sociale du salarié à supprimer : ");
            string numSecu = Console.ReadLine();
            Salarie salarieASupprimer = EmployeTC.FirstOrDefault(s => s.NumSecu == numSecu);
            if (salarieASupprimer != null)
            {
                EmployeTC.Remove(salarieASupprimer);
                Console.WriteLine("Salarié supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Salarié non trouvé !");
            }
            Console.ReadKey();
        }

        static void ListerSalaries(List<Salarie> EmployeTC)
        {
            Console.WriteLine("Liste des salariés : ");
            foreach (Salarie salarie in EmployeTC)
            {
                Console.WriteLine(salarie);
            }
            Console.ReadKey();
        }
        public static void InitialiserOrganigramme(Salarie directeurGeneral)
        {
            Organigramme = new NoeudEmploye(directeurGeneral);
        }
        public static void AjouterSalarie(Salarie salarie, string numSecuManager = null)
        {
            Console.WriteLine("Ajout d'un nouveau salarié...");
            EmployeTC.Add(salarie);
            var nouveauNoeud = new NoeudEmploye(salarie);

            if (numSecuManager == null)
            {
                Organigramme.AjouterChef(nouveauNoeud);
            }
            else
            {
                var noeudManager = TrouverNoeudEmploye(Organigramme, numSecuManager);
                if (noeudManager != null)
                {
                    noeudManager.AjouterChef(nouveauNoeud);
                }
                else
                {
                    Console.WriteLine("Manager non trouvé !");
                }
            }

            Console.WriteLine("Salarié ajouté avec succès !");
            Console.ReadKey();
        }

        public static void SupprimerSalarie(string numSecu)
        {
            Console.WriteLine("Suppression d'un salarié...");
            var salarieASupprimer = EmployeTC.FirstOrDefault(s => s.NumSecu == numSecu);
            if (salarieASupprimer != null)
            {
                EmployeTC.Remove(salarieASupprimer);
                var noeudASupprimer = TrouverNoeudEmploye(Organigramme, numSecu);
                if (noeudASupprimer != null)
                {
                    SupprimerNoeudEmploye(Organigramme, noeudASupprimer);
                }
                Console.WriteLine("Salarié supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Salarié non trouvé !");
            }
            Console.ReadKey();
        }

        public static void ListerSalaries()
        {
            Console.WriteLine("Liste des salariés : ");
            foreach (Salarie salarie in EmployeTC)
            {
                Console.WriteLine(salarie);
            }
            Console.ReadKey();
        }

        private static NoeudEmploye TrouverNoeudEmploye(NoeudEmploye racine, string numSecu)
        {
            if (racine.salarie.NumSecu == numSecu)
                return racine;

            foreach (var chef in racine.chefs)
            {
                var resultat = TrouverNoeudEmploye(chef, numSecu);
                if (resultat != null)
                    return resultat;
            }

            return null;
        }

        private static void SupprimerNoeudEmploye(NoeudEmploye racine, NoeudEmploye noeudASupprimer)
        {
            foreach (var chef in racine.chefs)
            {
                if (chef == noeudASupprimer)
                {
                    racine.chefs.Remove(noeudASupprimer);
                    return;
                }
                SupprimerNoeudEmploye(chef, noeudASupprimer);
            }
        }

        public static void AfficherOrganigramme(NoeudEmploye noeud, int niveau = 0)
        {
            Console.WriteLine(new string('-', niveau) + noeud.salarie.Nom + " " + noeud.salarie.Prenom + " (" + noeud.salarie.Poste + ")");
            foreach (var chef in noeud.chefs)
            {
                AfficherOrganigramme(chef, niveau + 1);
            }
        }

        public static void AfficherOrganigramme()
        {
            AfficherOrganigramme(Organigramme);
            Console.ReadKey();
        }
    }


    
}