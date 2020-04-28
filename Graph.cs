using System;
using System.Collections.Generic;
using System.Text;

namespace GRAPHics
{
    /// <summary>
    /// A simple, undirected graph presented through <see cref="Dictionary{TKey, TValue}"/> of adjacency.
    /// </summary>
    /// <typeparam name="TVertex">The type of every vertex.</typeparam>
    class Graph<TVertex>
    {
        private readonly Dictionary<TVertex, List<TVertex>> adjacencyTable
            = new Dictionary<TVertex, List<TVertex>>();

        public Graph(TVertex[] vertices, List<TVertex[]> connections)
        {
            foreach (TVertex vertex in vertices)
                adjacencyTable.Add(vertex, new List<TVertex>());

            for (int i = 0; i < connections.Count; i++)
                if (connections[i].Length == 2)
                    AddNode(connections[i][0], connections[i][1]);
        }

        public void AddNode(TVertex origin, TVertex destination)
        {
            adjacencyTable[origin].Add(destination);
            adjacencyTable[destination].Add(origin);
        }

        public bool DFS(TVertex origin, TVertex destination, List<TVertex> visited = null)
        {
            if (origin.Equals(destination) && adjacencyTable[origin].BinarySearch(destination) >= 0)
                return true;

            if (visited == null)
                visited = new List<TVertex>();
            visited.Add(origin);

            foreach (TVertex connection in adjacencyTable[origin])
                if (visited.BinarySearch(connection) < 0)
                    if (connection.Equals(destination))
                        return true;
                    else
                        return DFS(connection, destination, visited);

            return false;
        }

        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (KeyValuePair<TVertex, List<TVertex>> connnection in adjacencyTable)
            {
                builder.Append($"{connnection.Key} => [ ");

                for (int i = 0; i < connnection.Value.Count; i++)
                    if (i < connnection.Value.Count - 1)
                        builder.Append($"{connnection.Value[i]}, ");
                    else builder.Append($"{connnection.Value[i]} ]\n");
            }

            return builder.ToString();
        }
    }
}
