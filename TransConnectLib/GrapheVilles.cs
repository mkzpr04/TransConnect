using System;
using System.Collections.Generic;
using System.IO;

namespace TransConnectLib
{
    public class GrapheVilles
    {
        private Dictionary<string, Dictionary<string, int>> adjList;

        public GrapheVilles()
        {
            adjList = new Dictionary<string, Dictionary<string, int>>();
        }

        public void AjouterRoute(string ville1, string ville2, int distance)
        {
            if (!adjList.ContainsKey(ville1))
                adjList[ville1] = new Dictionary<string, int>();

            if (!adjList.ContainsKey(ville2))
                adjList[ville2] = new Dictionary<string, int>();

            adjList[ville1][ville2] = distance;
            adjList[ville2][ville1] = distance;
        }

        public Dictionary<string, int> GetVoisins(string ville)
        {
            return adjList.ContainsKey(ville) ? adjList[ville] : new Dictionary<string, int>();
        }

        public List<string> GetVilles()
        {
            return new List<string>(adjList.Keys);
        }
    }

    public static class GestionGraphe
    {
        public static GrapheVilles ChargerGrapheDepuisCSV(string filePath)
        {
            var graphe = new GrapheVilles();

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1)) // Skip header line
            {
                var values = line.Split(',');

                string ville1 = values[0];
                string ville2 = values[1];
                int distance = int.Parse(values[2]);

                graphe.AjouterRoute(ville1, ville2, distance);
            }

            return graphe;
        }
    }
}
