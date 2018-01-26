using Kayllian.Algorithms.Graphs;
using System;
using System.IO;

namespace DegreesOf_Separation
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = args[0];
            var delimiter = args[1];
            var symbol = args[2];

            var graph = new SymbolGraph(File.ReadAllLines(fileName), delimiter);

            if (!graph.Contains(symbol))
            {
                Console.WriteLine($"'{symbol}' cannot be found in the file '{fileName}'.");
                return;
            }

            var symbolIndex = graph.Index(symbol);
            var search = new BreadthFirstSearch(graph.Graph, symbolIndex);

            string value = null;

            do
            {
                value = Console.ReadLine();

                if (!graph.Contains(value))
                {
                    Console.WriteLine($"'{value}' cannot be found in the file '{fileName}'.");
                    continue;
                }

                var valueIndex = graph.Index(value);
                if (!search.HasPathTo(valueIndex))
                {
                    Console.WriteLine($"There is no path from '{symbol}' to '{value}'.");
                    continue;
                }

                foreach (var vertex in search.PathTo(valueIndex))
                {
                    Console.WriteLine($"\t{graph.Name(vertex)}");
                }


            } while (!string.IsNullOrEmpty(value));
        }
    }
}
