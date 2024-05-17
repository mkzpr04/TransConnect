RAPPORT Projet C#

## Introduction
Ce rapport documente les différentes étapes de développement et de réalisation de notre projet. Nous l'avons divisé en plusieurs phases, chacune ayant des objectifs spécifiques. Ce rapport détaille ces étapes, les fonctionnalités implémentées, les tests réalisés, et les perspectives d'améliorations.

## Étape 1: Création des Classes de Base
### Nous avons créé les 2 classes à la base de tout le projet :
- **Personne** : Classe de base représentant une personne.
- **Véhicule** : Classe de base représentant un véhicule.
Puis nous avons créé toutes les autres classes qui en héritent, nous retrouvons les salariés (dont les chauffeurs),les clients et tous les différents types de véhicules.

## Étape 2: Gestion des Salariés, des Clients et des Commandes
### Nous avons ensuite implémenté la gestion des salariés 
- AjoutSalarie : Embauche d'un salarié.
- SupprimerSalarie : Licenciement d'un salarié.
- ModifierSalarie : Mise à jour des informations d'un salarié.
- ListerSalarie : Affichage de l'organigramme.

L'organigramme est dynamique et se met à jour lors de l'ajout d'un salarié lorsque l'on spécifie son poste et son chef pour savoir où on doit le placer.
Pour cet organigramme, nous avons utilisé les arbres n-aire.
Chaque nœud de l'arbre représente un salarié et contient une liste de subordonnés. Cette structure permet de modéliser les relations hiérarchiques de manière efficace. Les opérations courantes incluent l'ajout, la suppression, et la recherche de nœuds (salariés), ce qui permet de maintenir l'organigramme à jour en fonction des changements dans l'entreprise.

La gestion des Clients et des Commandes suit la même logique que la gestion des Salariés 

Pour la gestion des commandes, nous avons utilisé l'algorithme de Djikstra afin de trouver le plus court chemin entre la ville d'arrivée et la ville de départ lors de la création d'une commande.
L'algorithme de Dijkstra est utilisé pour trouver le chemin le plus court entre deux villes dans un graphe. Le graphe est représenté par un dictionnaire où chaque clé est une ville et la valeur est une liste de tuples contenant les villes voisines et les distances associées. L'algorithme suit les étapes suivantes :

Initialisation des distances de toutes les villes à l'infini, sauf la ville de départ.
Utilisation d'une "file de priorité" pour traiter les villes, en commençant par la ville de départ.
Pour chaque ville, mise à jour des distances de ses voisins si un chemin plus court est trouvé.
Répétition jusqu'à ce que la destination soit atteinte ou que toutes les villes aient été traitées.
Reconstitution du chemin le plus court en utilisant un dictionnaire.

## Étape 3: Module Statistiques
### L'objectif est de fournir des statistiques sur les performances des employés ou sur les commandes

Nous avons implémenté différentes statistiques pour afficher notamment le nombre de livraisons par chauffeur, ou la moyenne des notes des clients en utilisant les délégations.

## Étape 4: Affichage du menu 
Nous avons tout concentré dans la classe Program de notre projet pour laisser l'utilisateur choisir ce qu'il veut gérer et avec quelle partie il souhaite intéragir. Selon ce qu'il veut, cela renvoie aux différentes classes de gestion de client, salariés, commandes ou statistiques. 

Nous avons ensuite rajouté une interface : IComparable, qui est utilisé dans différentes classes notammenent pour comparer le prix de 2 commandes entre eux, ou pour comparer les différentes notes des clients dans l'optique de savoir quels sont les clients qu'il faudrait favoriser dans un programme de fidélité. 

Nous avons ensuite procédé aux tests unitaires pour certaines méthodes.

## Points d'améliorations 
Nous avons déjà implémenté le système de notation des clients, nous aurons donc pu mettre en place un système de bons d'achat afin de récompenser les clients ayant le plus de commande à leur actif et ayant une bonne note. 
Nous aurions aussi pu ajouter un système de maintenance des véhicules, une fois qu'ils ont effectué un certain nombre de commandes, ou de kilomètres par exemple. 
