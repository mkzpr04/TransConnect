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

}
