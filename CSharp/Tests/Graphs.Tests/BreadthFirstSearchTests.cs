using Kayllian.Algorithms.Graphs;
using FluentAssertions;
using Xunit;

namespace Graphs.Tests
{
    public class BreadthFirstSearchTests
    {
        [Fact]
        public void PathToShould_MapCorrectPath_GivenPathExists()
        {
            // Act
            const int origin = 0,
                destination = 3;
            var graph = GraphBuilder.Basic();
            var search = new BreadthFirstSearch(graph, origin);
            var expected = new[] { origin, 5, destination };

            // Act
            var paths = search.PathTo(destination);

            // Assert
            paths.Should().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(0, 4, 3)]
        [InlineData(7, 8, 2)]
        [InlineData(9, 12, 2)]
        public void PathToShould_HaveShortestPath_GivenPathExists(int origin, int destination, int length)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new BreadthFirstSearch(graph, origin);

            // Act
            var paths = search.PathTo(destination);

            // Assert
            paths.Should().NotBeNull()
                .And
                .HaveCount(length);
        }

        [Theory]
        [InlineData(0, 8)]
        [InlineData(0, 9)]
        [InlineData(7, 1)]
        [InlineData(7, 12)]
        [InlineData(9, 6)]
        [InlineData(9, 8)]
        public void PathToShould_ReturnNull_GivenNoPathExists(int origin, int destination)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new BreadthFirstSearch(graph, origin);

            // Act
            var paths = search.PathTo(destination);

            // Assert
            paths.Should().BeEmpty();
        }

        [Theory]
        [InlineData(0, 4)]
        [InlineData(7, 8)]
        [InlineData(9, 12)]
        public void HasShould_ReturnTrue_GivenPathExists(int origin, int destination)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new BreadthFirstSearch(graph, origin);

            // Act
            var paths = search.HasPathTo(destination);

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
        public void HasShould_ReturnFalse_GivenNoPathExists(int origin, int destination)
        {
            // Act
            var graph = GraphBuilder.Basic();
            var search = new BreadthFirstSearch(graph, origin);

            // Act
            var paths = search.HasPathTo(destination);

            // Assert
            paths.Should().BeFalse();
        }
    }
}
