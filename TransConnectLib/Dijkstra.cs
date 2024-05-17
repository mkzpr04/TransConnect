using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TransConnectLib
{
    public class Dijkstra
    {
        private Dictionary<string, List<(string destination, int distance)>> graph;
        public string VilleDepart { get; set; }
        public string VilleArrivee { get; set; }
        public int DistanceTotale { get; set; }
        public List<string> Chemin { get; set; }

        public Dijkstra(string filePath)
        {
            graph = new Dictionary<string, List<(string destination, int distance)>>();
            LoadGraphFromCSV(filePath);
            Chemin = new List<string>(); // Initialiser Chemin
        }

        private void LoadGraphFromCSV(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');
                string start = values[0].Trim();
                string end = values[1].Trim();
                int distance = int.Parse(values[2].Trim());

                if (!graph.ContainsKey(start))
                {
                    graph[start] = new List<(string destination, int distance)>();
                }
                if (!graph.ContainsKey(end))
                {
                    graph[end] = new List<(string destination, int distance)>();
                }

                graph[start].Add((end, distance));
                graph[end].Add((start, distance)); // Assuming undirected graph
            }
        }

        public int CalculerPlusCourtChemin(string start, string end)
        {
            var distances = new Dictionary<string, int>();
            var previous = new Dictionary<string, string>();
            var nodes = new List<string>();

            foreach (var vertex in graph)
            {
                if (vertex.Key == start)
                {
                    distances[vertex.Key] = 0;
                }
                else
                {
                    distances[vertex.Key] = int.MaxValue;
                }
                nodes.Add(vertex.Key);
            }

            while (nodes.Count != 0)
            {
                nodes.Sort((x, y) => distances[x] - distances[y]);
                var smallest = nodes[0];
                nodes.Remove(smallest);

                if (smallest == end)
                {
                    while (previous.ContainsKey(smallest))
                    {
                        Chemin.Insert(0, smallest);
                        smallest = previous[smallest];
                    }
                    Chemin.Insert(0, start);
                    DistanceTotale = distances[end];
                    return distances[end];
                }

                if (distances[smallest] == int.MaxValue)
                {
                    break;
                }

                foreach (var neighbor in graph[smallest])
                {
                    var alt = distances[smallest] + neighbor.distance;
                    if (alt < distances[neighbor.destination])
                    {
                        distances[neighbor.destination] = alt;
                        previous[neighbor.destination] = smallest;
                    }
                }
            }

            return int.MaxValue;
        }
    }
}
