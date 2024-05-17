using System;
using System.Collections.Generic;
using System.IO;

namespace TransConnectLib
{
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