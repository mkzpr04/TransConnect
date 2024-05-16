using System;
using System.Collections.Generic;


namespace TransConnectLib
{
    public static class GestionClients
    {
        private static List<Client> clients = new List<Client>();

        public static void AjouterClient(Client client)
        {
            clients.Add(client);
            Console.WriteLine("Client ajouté avec succès !");
        }

        public static void SupprimerClient(string clientId)
        {
            var client = clients.FirstOrDefault(c => c.clientId == clientId);
            if (client != null)
            {
                clients.Remove(client);
                Console.WriteLine("Client supprimé avec succès !");
            }
            else
            {
                Console.WriteLine("Client non trouvé !");
            }
        }

        public static void ModifierClient(string clientId, string adressePostale, string adresseMail, string telephone)
        {
            var client = clients.FirstOrDefault(c => c.clientId == clientId);
            if (client != null)
            {
                client.AdressePostale = adressePostale;
                client.AdresseMail = adresseMail;
                client.Telephone = telephone;
                Console.WriteLine("Client modifié avec succès !");
            }
            else
            {
                Console.WriteLine("Client non trouvé !");
            }
        }

        public static void AfficherClients(string critere)
        {
            IEnumerable<Client> sortedClients = clients;
            switch (critere)
            {
                case "alphabetique":
                    sortedClients = sortedClients.OrderBy(c => c.Nom).ThenBy(c => c.Prenom);
                    break;
                case "ville":
                    sortedClients = sortedClients.OrderBy(c => c.ville);
                    break;
                case "montant":
                    sortedClients = sortedClients.OrderByDescending(c => c.montantAchatsCumules);
                    break;
                default:
                    Console.WriteLine("Tri non pris en charge.");
                    return;
            }

            foreach (var client in sortedClients)
            {
                Console.WriteLine($"ID: {client.clientId}, Nom: {client.Nom}, Prénom: {client.Prenom}, Ville: {client.ville}, Montant Achats: {client.montantAchatsCumules}");
            }
        }
        
        public static Client RechercherClient(string clientId)
        {
            return clients.FirstOrDefault(c => c.clientId == clientId);
        }
    }
}
