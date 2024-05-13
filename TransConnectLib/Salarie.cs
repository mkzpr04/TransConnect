using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransConnectLib
{
    public class Salarie : Personne
    {
        // Attributs de la classe Salarie.
        private DateTime dateEntree;
        private string poste;
        private double salaire;
        public static NoeudEmploye Organigramme;
        public static List<Salarie> EmployeTC = new List<Salarie>();

        // Constructeurs pour la classe Salarie.
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

        // Propriétés de la classe Salarie.
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
        
        // Méthodes de la classe Salarie.
        public static int NbSalaries
        {
            get { return EmployeTC.Count; }
        }
        public static void AjouterSalarie(Salarie salarie)
        {
            Console.WriteLine("Ajout d'un nouveau salarié...");
            EmployeTC.Add(salarie);
            Console.WriteLine("Salarié ajouté avec succès !");
        }

        public static void SupprimerSalarie()
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
    
        public static void SupprimerSalarie(Salarie salarie)
        {
            Salarie salarieASupprimer = EmployeTC.FirstOrDefault(s => s.NumSecu == salarie.NumSecu);
            if (salarieASupprimer != null)
            {
                EmployeTC.Remove(salarieASupprimer);
                Console.WriteLine("Salarié supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Salarié non trouvé !");
            }
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


    }


    
}