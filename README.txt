README Projet C#:

Etape 1: Création des classes Personne et Véhicule ainsi que les classes qui en héritent Client.cs, Salarie.cs, Chauffeur.cs
Tests unitaires des classes Personne, Salarie avec Xunit + (Extension .NET Core Test Explorer.) (ou ligne de commande avec dotnet test) sur le TransConnectTests.
A FAIRE :
Tests unitaire de la classe Véhicule et des classes qui en héritent.
Documentation de la classe Véhicule et des classes qui en héritent.

- Création d'une interface utilisateur [avec la console] et alimentation au fil des étapes suivantes.

Étape 2 : Gestion des Salariés
Gérer les informations des salariés grâce à une classe EmployeeService, incluant l'embauche (AjoutSalarie), le licenciement (SupprimerSalarie), les mises à jour (ModifieSalarie) de leurs profils et enfin (ListerSalarie)
Implémentation de l'organigramme dynamique qui change en fonction de si l'on ajoute des salariés etc. L'organigramme initial contient les membres de la société décrit dans le document pdf. 


A FAIRE: 
S'assurer que toutes les fonctionnalités du module de gestion des salariés fonctionnent comme prévu sans erreurs ni bugs.
-> Tests unitaires sur la gestion des salariés
-> Documentation

Etape 3: Gestion des Clients 

"Implémenter les fonctionnalités permettant de gérer les informations des clients, similaires à celles des salariés, incluant l'ajout, la suppression, et la mise à jour des clients, ainsi que des fonctions de recherche."
Tâches :

Développer le modèle ClientService : Ce service gérera les données des clients, offrant des méthodes pour ajouter, supprimer, et mettre à jour les informations des clients.
Créer l'interface utilisateur pour la gestion des clients dans TransConnectApp : Permettre aux utilisateurs d'interagir avec le système pour gérer les informations des clients.
Écrire des tests unitaires pour vérifier la fiabilité et l'efficacité des fonctionnalités implémentées.

Etape 4: Gestion des Commandes 

Objectif : Développer le système de gestion des commandes qui inclut la création, la modification, et le suivi des commandes de livraison.

Tâches :

Créer le modèle CommandService : Ce service s'occupera de toutes les opérations liées aux commandes, y compris l'enregistrement des nouveaux ordres, la mise à jour des commandes existantes, et leur suivi.
Interface utilisateur pour les commandes : Développer des interfaces dans TransConnectApp pour permettre la gestion des commandes.
Implémenter l'algorithme de Dijkstra pour le calcul de l'itinéraire le plus court pour les livraisons.
Tests unitaires et d'intégration pour s'assurer que le module des commandes fonctionne correctement.

Etpae 5: Module Statistiques


Objectif : Fournir des statistiques et des rapports sur les performances des employés, les commandes, et d'autres métriques commerciales.

Tâches :

Développer StatisticsService : Ce service recueillera et analysera les données pour fournir des insights utiles, tels que le nombre de livraisons par chauffeur, les performances des clients, etc.
Interface utilisateur pour les statistiques : Créer des interfaces pour afficher les statistiques et les rapports dans TransConnectApp.
Tests pour valider les calculs et les rapports générés par le service.


Étape 6 : Consolidation et Tests d'Intégration


Objectif : Assurer que tous les modules fonctionnent ensemble de manière fluide et conforme aux exigences du projet.


S'assurer que les modules de salariés, clients, commandes, et statistiques interagissent sans problèmes.
Exécuter des scénarios de tests qui couvrent plusieurs modules à la fois pour identifier et corriger les problèmes d'intégration.

Étape 7 : Documentation et Finalisation

A la fin de chaque étape.


Interface dans TRANSCONNECTAPP:

Sous-Menus Détaillés :
Gestion des Salariés : Ajouter, supprimer, mettre à jour, et lister les salariés.
Gestion des Clients : Ajouter, supprimer, mettre à jour, et afficher les clients par divers critères.
Gestion des Commandes : Créer, modifier, et afficher les détails des commandes, incluant le calcul d'itinéraire.
Affichage des Statistiques : Visualiser les performances, le volume des commandes, etc.
Implémentation Fonctionnelle :

Interaction avec les Services : Connecté aux services métier pour effectuer des opérations de données réelles (par exemple, créer un nouveau client, afficher les informations d'un salarié).




notes Program TransConnectApp:
using System;
using System.ComponentModel.DataAnnotations.Schema;
using TransConnectLib;

namespace TransConnectApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool enFonctionnement = true;
            while (enFonctionnement)
            {
                Console.Clear();
                Console.WriteLine("Bienvenue dans le Système de Gestion TransConnect");
                Console.WriteLine("1. Gérer les Salariés");
                Console.WriteLine("2. Gérer les Clients");
                Console.WriteLine("3. Gérer les Commandes");
                Console.WriteLine("4. Voir les Statistiques");
                Console.WriteLine("5. Quitter");

                Console.Write("Veuillez entrer votre choix : ");
                var choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        GestionDesSalaries();
                        break;
                    case "2":
                        GestionDesClients();
                        break;
                    case "3":
                        GestionDesCommandes();
                        break;
                    case "4":
                        AfficherStatistiques();
                        break;
                    case "5":
                        enFonctionnement = false;
                        break;
                    default:
                        Console.WriteLine("Choix invalide. Veuillez réessayer.");
                        break;
                }
            }
        }

        
        static void GestionDesClients()
        {
            // TODO: Implémenter la gestion des clients
            Console.WriteLine("Gestion des clients en cours...");
            Console.ReadKey();
        }

        static void GestionDesCommandes()
        {
            // TODO: Implémenter la gestion des commandes
            Console.WriteLine("Gestion des commandes en cours...");
            Console.ReadKey();
        }

        static void AfficherStatistiques()
        {
            // TODO: Implémenter l'affichage des statistiques
            Console.WriteLine("Affichage des statistiques...");
            Console.ReadKey();
        }
    }
}
