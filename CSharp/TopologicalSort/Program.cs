using System;
using System.IO;
using Kayllian.Algorithms.Graphs;

namespace TopologicalSort
{
    class Program
    {
        /// <summary>
        /// This client shows how a graph can be sorted topologically.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var file = args[0];
            var delimiter = args[1];

            var graph = new SymbolGraph(File.ReadAllLines(file), delimiter, count => new DirectedGraph(count));
            
            var cycleDetector = new DirectedCycle(graph.Graph);
            if (cycleDetector.HasCycle)
            {
                Console.WriteLine("A cycle has been detected.");
                foreach (var node in cycleDetector.Cycle())
                {
                    Console.WriteLine($"\t{graph.Name(node)}");
                }
            }
            else
            {
                var sort = new DepthFirstOrder(graph.Graph);
                foreach (var vertex in sort.ReversePost)
                {
                    Console.WriteLine(graph.Name(vertex));
                }
            }

            Console.ReadLine();
        }
    }
}
