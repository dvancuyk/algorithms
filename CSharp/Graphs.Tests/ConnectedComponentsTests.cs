using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class ConnectedComponentsTests
    {
        [Fact]
        public void CountShould_ReturnThree_GivenThereAreThreeConnectedComponents()
        {
            // Arrange
            var graph = GraphBuilder.Basic();
            var connectedComponentsSearch = new ConnectedComponent(graph);

            // Act
            var count = connectedComponentsSearch.Count;

            // Assert
            count.Should().Be(3);
        }

        [Fact]
        public void CountShould_ReturnOne_GivenGraphIsAllConnected()
        {
            // Arrange
            var graph = GraphBuilder.Bipartite();
            var connectedComponentsSearch = new ConnectedComponent(graph);

            // Act
            var count = connectedComponentsSearch.Count;

            // Assert
            count.Should().Be(1);
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(7, 8)]
        [InlineData(9, 12)]
        public void IsConnectedShould_ReturnTrue_GivenPathExists(int origin, int destination)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new ConnectedComponent(graph);

            // Act
            var paths = search.IsConnected(origin, destination);

            // Assert
            paths.Should().BeTrue();
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(0, 9)]
        [InlineData(7, 1)]
        [InlineData(7, 12)]
        [InlineData(9, 6)]
        [InlineData(9, 8)]
        public void IsConnectedShould_ReturnFalse_GivenNoPathExists(int origin, int destination)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new ConnectedComponent(graph);

            // Act
            var paths = search.IsConnected(origin, destination);

            // Assert
            paths.Should().BeFalse();
        }

        [Theory]
        [InlineData(2, 8)]
        [InlineData(7, 10)]
        [InlineData(4, 12)]
        public void IdShould_BeUniqueForVertices_GivenVerticesInDifferentComponents(int v, int w)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new ConnectedComponent(graph);

            // Act
            var vId = search.Id(v);
            var wId = search.Id(w);

            // Assert
            vId.Should().NotBe(wId);
        }

        [Theory]
        [InlineData(5, 2)]
        [InlineData(7, 8)]
        [InlineData(10, 11)]
        public void IdShould_BeSameForVertices_GivenVerticesInSameComponents(int v, int w)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new ConnectedComponent(graph);

            // Act
            var vId = search.Id(v);
            var wId = search.Id(w);

            // Assert
            vId.Should().Be(wId);
        }
    }
}
