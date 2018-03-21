using Commons;

namespace Kayllian.Algorithms.Graphs
{
    /// <summary>
    /// Event which marks that an edge was traversed, indicating the origin and destination
    /// </summary>
    public class EdgeTraversed : IDomainEvent
    {
        public EdgeTraversed(int from, int to, string algorithm)
        {
            Origin = from;
            Destination = to;
            Algorithm = algorithm;
        }

        public int Origin { get; }
        public int Destination { get; }
        public string Algorithm { get; }

        public override string ToString()
        {
            return $"{Origin} -> {Destination}";
        }
    }
}
