using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class DepthFirstSearchTests
    {
        private static readonly Graph _graph;

        static DepthFirstSearchTests()
        {
            _graph = GraphBuilder.Basic();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        public void MarkedShould_ReturnTrue_GivenVertexIsConnected(int vertex)
        {
            // Arrange
            var search = new DepthFirstSearch(_graph, 0);

            // Act
            var marked = search.Marked(vertex);

            // Assert
            marked.Should().BeTrue($"the vertex '{vertex}' should be connected");
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(11)]
        [InlineData(12)]
        public void MarkedShould_ReturnFalse_GivenVertexIsNotConnected(int vertex)
        {
            // Arrange
            var search = new DepthFirstSearch(_graph, 0);

            // Act
            var marked = search.Marked(vertex);

            // Assert
            marked.Should().BeFalse($"the vertex '{vertex}' should be connected");
        }
        
        [Theory]
        [InlineData(0, 6)]
        [InlineData(7, 1)]
        [InlineData(9, 3)]
        public void CountShould_ReturnNumberOfConnectedNodes(int vertex, int count)
        {
            // Arrange
            var search = new DepthFirstSearch(_graph, vertex);

            // Act
            var connectedCount = search.Count;

            // Assert
            connectedCount.Should().Be(count);
        }
    }
}
