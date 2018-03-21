using FluentAssertions;
using Graphs.Weighted;
using Xunit;

namespace Graph.Weighted.Tests
{
    public class EdgeWeightedGraphTests
    {
        [Fact]
        public void Edges_ShouldOnlyReturnOneEdge_GivenOneEdgeWasAdded()
        {
            // Arrange
            var graph = new EdgeWeightedGraph(3);
        }
    }
}
