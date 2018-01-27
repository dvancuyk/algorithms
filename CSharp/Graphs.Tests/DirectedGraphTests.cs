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
        public void ReverseShould_CreateReverseGraph()
        {
            // Arrange
            var graph = new DirectedGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);

            // Act
            var reverse = graph.Reverse();

            // Assert
            reverse.Adjacent(0)
                .Should()
                .HaveCount(0, "the vertex 0 should have no edges coming from it");

            reverse.Adjacent(1)
                .Should()
                .HaveCount(1, "the vertex 1 should have 1 edge coming from it")
                .And
                .Contain(0, "the edge from 1 -> 0 should've been reversed");

            reverse.Adjacent(2)
                .Should()
                .HaveCount(1, "the vertex 1 should have 1 edge coming from it")
                .And
                .Contain(1, "the edge from 1 -> 2 should've been reversed");

            reverse.Adjacent(3)
                .Should()
                .HaveCount(1, "the vertex 1 should have 1 edge coming from it")
                .And
                .Contain(2, "the edge from 2 -> 3 should've been reversed");
        }
    }
}
