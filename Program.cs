using System;

namespace GRAPHics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vertices = "KH,PK,NY,SF,LM,BGT,PAR,LON,VARNA".Split(',');

            var connections = new System.Collections.Generic.List<Weighted.VertexConnection<string>>
            {
                new Weighted.VertexConnection<string>("KH",  "PAR", 1 ),
                new Weighted.VertexConnection<string>("KH",  "PK" , 2 ),
                new Weighted.VertexConnection<string>("SF",  "PAR", 3 ),
                new Weighted.VertexConnection<string>("LON", "PAR", 9 ),
                new Weighted.VertexConnection<string>("LON", "NY" , 10 ),
                new Weighted.VertexConnection<string>("KH",  "LON", 4 ),
                new Weighted.VertexConnection<string>("SF",  "LON", 3 ),
                new Weighted.VertexConnection<string>("PK",  "LON", 9 ),
                new Weighted.VertexConnection<string>("NY",  "BGT", 4 ),
                new Weighted.VertexConnection<string>("BGT", "LM" , 3)
            };

            //Graph<string> graph = new Graph<string>(vertices, connections);

            //graph.AddNode("SF", "SF");
            //graph.AddNode("VARNA", "VARNA");

            //Console.WriteLine(graph.DFS("VARNA", "VARNA"));

            Weighted.WeightedGraph<string> weightedGraph = new Weighted.WeightedGraph<string>(vertices, connections);
            weightedGraph.AddNode(new Weighted.VertexConnection<string>("VARNA", "VARNA", 1));
            Console.WriteLine(weightedGraph.DFS("KH", "PK"));

        }
    }
}
