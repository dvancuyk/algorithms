using FluentAssertions;
using Xunit;
using Kayllian.Algorithms.Graphs;

namespace Graphs.Tests.GraphsTests
{
    public class AddEdgeShould
    {
        [Fact]
        public void AddEdge_GivenEdgeDoesNotExist()
        {
            // Arrange
            var graph = new Graph(3);
            const int first = 0,
                second = 1;

            // Act
            graph.AddEdge(first, second);

            // Assert
            graph.Edges.Should().Be(1);
            graph.Adjacent(first)
                .Should()
                .Contain(second)
                .And
                .HaveCount(1);
            graph.Adjacent(second)
                .Should()
                .Contain(first)
                .And
                .HaveCount(1);
        }

        [Fact]
        public void AddEdge_GivenEdgeIsParallelToExistingEdge()
        {
            // Arrange
            var graph = new Graph(3);
            const int first = 0,
                second = 2;
            graph.AddEdge(first, second);

            // Act
            graph.AddEdge(first, second);

            // Assert
            graph
                .Adjacent(second)
                .Should()
                .HaveCount(2)
                .And
                .OnlyContain(v => v == first);

        }
    }
}
