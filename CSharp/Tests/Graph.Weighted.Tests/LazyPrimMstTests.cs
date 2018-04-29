using FluentAssertions;
using Graphs.Weighted;
using Xunit;

namespace Graph.Weighted.Tests
{
    public class LazyPrimMstTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Weight_ShouldReturnWeight_GivenMstCanBeFound()
        {
            // Arrange
            const double expectedWeight = 1.81;
            var graph = WeightedGraphBuilder.Basic();
            
            // Act
            var mst = new LazyPrimMst(graph);

            // Assert
            mst.Weight.Should().Be(expectedWeight);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Edges_ShouldReturnCorrectEdges_GivenMstCanBeFOund()
        {
            // Arrange
            var graph = WeightedGraphBuilder.Basic();
            var expected = new[]
            {
                new Edge(4, 5, 0.35),
                new Edge(5, 7, 0.28),
                new Edge(0, 7, 0.16),
                new Edge(2, 3, 0.17),
                new Edge(1, 7, 0.19),
                new Edge(0, 2, 0.26),
                new Edge(6, 2, 0.40),
            };

            // Act
            var mst = new LazyPrimMst(graph);

            // Assert
            mst.Edges.Should().Contain(expected);
        }
    }
}