using System;
using System.Collections.Generic;
using System.Linq;

namespace TransConnectLib
{
    public static class GestionSalaries
    {
        private static List<Salarie> salaries = new List<Salarie>();

        public static void AjouterSalarie(Salarie salarie, string numSecuManager = null)
        {
            salaries.Add(salarie);
            if (numSecuManager != null && Salarie.Organigramme != null)
            {
                var managerNoeud = Salarie.Organigramme.TrouverNoeud(numSecuManager);
                if (managerNoeud != null)
                {
                    var nouveauNoeud = new NoeudEmploye(salarie);
                    managerNoeud.AjouterSubordonne(nouveauNoeud);
                }
                else
                {
                    Console.WriteLine("Manager non trouvé.");
                }
            }
            else
            {
                if (Salarie.Organigramme == null)
                {
                    Salarie.Organigramme = new NoeudEmploye(salarie); // Si aucun manager, c'est la racine
                }
                else
                {
                    var nouveauNoeud = new NoeudEmploye(salarie);
                    Salarie.Organigramme.AjouterSubordonne(nouveauNoeud);
                }
            }
            Console.WriteLine("Salarié ajouté avec succès !");
        }

        public static void SupprimerSalarie(string numSecu)
        {
            var salarieASupprimer = salaries.FirstOrDefault(s => s.NumSecu == numSecu);
            if (salarieASupprimer != null)
            {
                salaries.Remove(salarieASupprimer);
                Console.WriteLine("Salarié supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Salarié non trouvé !");
            }
        }

        public static void ModifierSalarie(string numSecu, string poste, double salaire)
        {
            var employe = salaries.FirstOrDefault(e => e.NumSecu == numSecu);
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
        }

        public static void ListerSalaries()
        {
            if (Salarie.Organigramme != null)
            {
                NoeudEmploye.AfficherOrganigramme(Salarie.Organigramme);
            }
            else
            {
                Console.WriteLine("Aucun salarié dans l'organigramme.");
            }
        }
        public static int GetSalariesCount()
        {
            return salaries.Count;
        }
    }
}
