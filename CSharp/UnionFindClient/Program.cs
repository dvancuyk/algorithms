using System;
using System.Diagnostics;
using System.IO;
using Fundamentals;

namespace UnionFindClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            var process = Process.GetCurrentProcess();
            var iterations = new[] {"tiny", "medium", "large"};

            foreach (var testType in iterations)
            {
                var connections = LoadFile(testType);
                Console.WriteLine($"Testing size: {testType}, Count: {connections.Length}");
                var initializeSize = process.PrivateMemorySize64;
                stopwatch.Restart();

                var uf = new WeightedQuickUnionFind(int.Parse(connections[0]));
                for (int i = 1; i < connections.Length; i++)
                {
                    var index = connections[i].IndexOf(' ');
                    int p = int.Parse(connections[i].Substring(0, index)),
                        q = int.Parse(connections[i].Substring(index + 1));

                    uf.Union(p, q);
                }
                
                var elapsedTime = stopwatch.Elapsed;
                process.Refresh();

                Console.WriteLine($"\tMemory Size = {(process.PrivateMemorySize64 - initializeSize) / 1024}kb");
                Console.WriteLine($"\tElapsed Time = {elapsedTime}");
            }

            Console.ReadLine();
        }

        static string[] LoadFile(string size)
        {
            var fileName = $"Data/{size}UF.txt";
            return File.ReadAllLines(fileName);
        }
    }
}
