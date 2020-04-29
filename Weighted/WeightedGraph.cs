using System.Collections.Generic;

namespace GRAPHics.Weighted
{
    /// <summary>
    /// Weighted undirected graph.
    /// </summary>
    /// <typeparam name="TVertex"></typeparam>
    class WeightedGraph<TVertex>
    {
        private readonly Dictionary<TVertex, List<VertexConnection<TVertex>>> adjacencyTable =
            new Dictionary<TVertex, List<VertexConnection<TVertex>>>();

        public TVertex[] Vertices { get; private set; }

        public List<VertexConnection<TVertex>> Connections { get; private set; }

        /// <summary>
        /// Constructs a new weighted graph
        /// </summary>
        /// <param name="vertices">All the graph's vertices.</param>
        /// <param name="connections">All edges of the graph</param>
        public WeightedGraph(TVertex[] vertices, List<VertexConnection<TVertex>> connections)
        {
            Vertices = vertices;

            foreach (TVertex item in vertices)
                adjacencyTable.Add(item, new List<VertexConnection<TVertex>>());

            for (int i = 0; i < connections.Count; i++)
                AddNode(connections[i]);
        }

        public void AddNode(VertexConnection<TVertex> connection)
        {
            adjacencyTable[connection.Origin].Add(connection);
            adjacencyTable[connection.Destination]
                .Add(new VertexConnection<TVertex>(connection.Destination, connection.Origin, connection.Weight));
        }

        public override string ToString()
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();

            foreach (KeyValuePair<TVertex, List<VertexConnection<TVertex>>> connection in adjacencyTable)
            {
                if (connection.Value.Count > 0)
                    builder.Append($"[ ");
                else 
                    continue;
                for (int i = 0; i < connection.Value.Count; i++)
                    if (i < connection.Value.Count - 1)
                        builder.Append(connection.Value[i] + ", ");
                    else
                        builder.Append($"{connection.Value[i]} ]\n");
            }

            return builder.ToString();
        }

        public bool DFS(TVertex origin, TVertex destination, List<TVertex> visited = null)
        {
            if (origin.Equals(destination) || 
                adjacencyTable[origin].BinarySearch(new VertexConnection<TVertex>(origin, destination)) >= 0)
                return true;

            if (visited == null)
                visited = new List<TVertex>();
            visited.Add(origin);

            System.Console.Write($"{origin} => ");
            foreach (VertexConnection<TVertex> connection in adjacencyTable[origin])
                if (visited.BinarySearch(connection.Destination) < 0)
                    if (connection.Destination.Equals(destination))
                    {
                        System.Console.WriteLine(destination + " found!");
                        return true;
                    }
                    else
                        return DFS(connection.Destination, destination, visited);
            return false;
        }
    }

}
