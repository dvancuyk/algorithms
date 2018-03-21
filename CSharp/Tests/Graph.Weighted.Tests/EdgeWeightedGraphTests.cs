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
            var edge = new Edge(0, 1, 1.2);
            var graph = new EdgeWeightedGraph(3);
            graph.AddEdge(edge);
            
            // Act
            var edges = graph.Edges;

            // Assert
            edges.Should()
                .HaveCount(1)
                .And
                .Contain(edge);
        }

        [Fact]
        public void EdgeCount_ShouldReturnOne_GivenOneEdgeWasAdded()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.2);
            var graph = new EdgeWeightedGraph(3);
            graph.AddEdge(edge);
            
            // Act
            var edges = graph.EdgesCount;

            // Assert
            edges.Should()
                .Be(1);
        }

        [Fact]
        public void Adjacent_ShouldReturnEdge_GivenEdgeWasAddedToVertex()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.2);
            var graph = new EdgeWeightedGraph(3);
            graph.AddEdge(edge);
            
            // Act
            var edges = graph.Adjacent(edge.Either());

            // Assert
            edges.Should()
                .HaveCount(1)
                .And
                .Contain(edge);
        }

        [Fact]
        public void Adjacent_ShouldReturnEdges_GivenOtherAdjacentIsCalled()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.2);
            var graph = new EdgeWeightedGraph(3);
            graph.AddEdge(edge);
            
            // Act
            var edges = graph.Adjacent(edge.Other(0));

            // Assert
            edges.Should()
                .HaveCount(1)
                .And
                .Contain(edge);
        }

        [Fact]
        public void Adjacent_ShouldReturnEmptyCollection_GivenNoEdgesAdded()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.2);
            var graph = new EdgeWeightedGraph(3);
            graph.AddEdge(edge);
            
            // Act
            var edges = graph.Adjacent(2);

            // Assert
            edges.Should()
                .BeEmpty();
        }
    }
}
