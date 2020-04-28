using System;

namespace GRAPHics
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] vertices = "KH,PK,NY,SF,LM,BGT,PAR,LON,VARNA".Split(',');

            var connections = new System.Collections.Generic.List<string[]>
            {
                new string[2] {"KH", "PAR" },
                new string[2] {"KH", "PK" },
                new string[2] {"SF", "PAR" },
                new string[2] {"LON", "PAR" },
                new string[2] {"LON", "NY" },
                new string[2] {"KH", "LON" },
                new string[2] {"SF", "LON" },
                new string[2] {"PK", "LON" },
                new string[2] {"NY", "BGT"},
                new string[2] {"BGT", "LM" }
            };

            Graph<string> graph = new Graph<string>(vertices, connections);

            graph.AddNode("SF", "SF");
            graph.AddNode("VARNA", "VARNA");

            Console.WriteLine(graph.DFS("VARNA", "VARNA"));
        }
    }
}
