using System;
using System.Collections.Generic;

namespace TransConnectLib
{
    public class NoeudEmploye
    {
        public Salarie Salarie { get; set; }
        public List<NoeudEmploye> Subordonnes;

        public NoeudEmploye(Salarie salarie)
        {
            Salarie = salarie;
            Subordonnes = new List<NoeudEmploye>();
        }

        public void AjouterSubordonne(NoeudEmploye subordonne)
        {
            Subordonnes.Add(subordonne);
        }

        public void SupprimerSubordonne(NoeudEmploye subordonne)
        {
            Subordonnes.Remove(subordonne);
        }
        public NoeudEmploye TrouverNoeud(string numSecu)
        {
            if (Salarie.NumSecu == numSecu) return this;
            foreach (var sub in Subordonnes)
            {
                var result = sub.TrouverNoeud(numSecu);
                if (result != null) return result;
            }
            return null;
        }

        public static void AfficherOrganigramme(NoeudEmploye noeud, string indentation = "", bool estDernier = true)
        {
            // Déterminer le préfixe en fonction de la position du noeud (dernier ou non)
            string prefixe;
            if (estDernier)
            {
                prefixe = "└─ ";
            }
            else
            {
                prefixe = "├─ ";
            }

            // Afficher le nom et le poste du salarié avec le préfixe approprié
            Console.WriteLine(indentation + prefixe + noeud.Salarie.Nom + " / " + noeud.Salarie.Poste);

            // Mettre à jour l'indentation pour les enfants
            if (estDernier)
            {
                indentation += "   ";
            }
            else
            {
                indentation += "|  ";
            }

            // Parcourir tous les subordonnés pour afficher leur information
            for (int i = 0; i < noeud.Subordonnes.Count; i++)
            {
                bool estDernierSubordonne = (i == noeud.Subordonnes.Count - 1);
                AfficherOrganigramme(noeud.Subordonnes[i], indentation, estDernierSubordonne);
            }
        }


    }
}
