using Commons;
using Kayllian.Algorithms.Graphs;
using System;
using System.IO;
using System.Linq;

namespace VisualizingStronglyConnectedClients
{
    class Program
    {
        private static string _currentAlgorithm;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please type in the name of the text file (type Q to quit): ");
                var fileName = Console.ReadLine();

                if (fileName.ToLower() == "q")
                    break;

                DomainEvents.Register<EdgeTraversed>(PrintTraversal);

                try
                {
                    Process(DirectedGraphBuilder.BuildFromFile(fileName));
                }
                catch(DirectoryNotFoundException)
                {
                    Console.WriteLine($"The file '{fileName}' doesn't exist. Please select another.");
                }
                catch(InvalidFileFormatException)
                {
                    Console.WriteLine($"The file '{fileName}' isn't in the correct format.");
                    Console.WriteLine($"The first line should contain the number of vertices");
                    Console.WriteLine($"The second line should contain the number of edges");
                    Console.WriteLine($"Each additional line should contain the from edge and to edge (i.e. to indicate an edge from vertex 0 to 10, the line would be: 0 10");
                }

                Console.WriteLine("{0}{0}Hit enter button to continue", Environment.NewLine);
                Console.ReadLine();
            }
        }

        private static void PrintTraversal(EdgeTraversed edgeTraversed)
        {
            if(edgeTraversed.Algorithm != _currentAlgorithm)
            {
                _currentAlgorithm = edgeTraversed.Algorithm;
                Console.WriteLine($"{_currentAlgorithm} path");
            }

            Console.WriteLine("\t" + edgeTraversed);
        }

        public static void Process(DirectedGraph graph)
        {
            var sort = new DepthFirstOrder(graph);
            Console.WriteLine("{0}{0}Reverse Sort", Environment.NewLine);
            foreach (var vertex in sort.ReversePost)
            {
                Console.Write(vertex + " ");
            }
        }
    }

    public static class DirectedGraphBuilder
    {
        public static DirectedGraph BuildFromFile(string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            try
            {
                var graph = new DirectedGraph(int.Parse(lines[0]));

                for (int i = 2; i < lines.Length; i++)
                {
                    var line = lines[i].Trim();

                    if (line == string.Empty)
                        continue;

                    var points = line
                        .Split(' ')
                        .Select(int.Parse)
                        .ToList();

                    graph.AddEdge(points[0], points[1]);
                }

                return graph;
            }
            catch (Exception)
            {
                throw new InvalidFileFormatException(fileName);
            }
        }
    }
}
