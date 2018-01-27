using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class DirectedGraphTests
    {
        [Fact]
        public void AddEdge_AddDirectionFromFirstToSecond_GivenEdgeDoesNotExist()
        {
            // Arrange
            var graph = new DirectedGraph(3);
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
        }

        [Fact]
        public void AddEdge_NotAddDirectionFromSecondFirst_GivenEdgeIsDirectedFromFirstToSecond()
        {
            // Arrange
            var graph = new DirectedGraph(3);
            const int first = 0,
                second = 1;

            // Act
            graph.AddEdge(first, second);

            // Assert
            graph.Edges.Should().Be(1);
            graph.Adjacent(second)
                .Should()
                .NotContain(first)
                .And
                .HaveCount(0);
        }

        [Fact]
        public void AddEdge_NotAddDirectionFromSecondFirst_GivenEdgeIsDirectedFromFirstToSecond()
        {
            // Arrange
            var graph = new DirectedGraph(3);
            const int first = 0,
                second = 1;

            // Act
            graph.AddEdge(first, second);

            // Assert
            graph.Edges.Should().Be(1);
            graph.Adjacent(second)
                .Should()
                .NotContain(first)
                .And
                .HaveCount(0);
        }
    }
}
