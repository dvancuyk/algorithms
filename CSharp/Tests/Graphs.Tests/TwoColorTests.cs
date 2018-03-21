using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class TwoColorTests
    {
        [Fact]
        public void IsBipartiteShould_ReturnFalse_GivenGraphIsNotBipartite()
        {
            // Arrange
            var graph = GraphBuilder.Basic();
            var test = new TwoColor(graph);

            // Act
            var isBipartite = test.IsBipartite;

            // Assert
            isBipartite.Should().BeFalse();
        }

        [Fact]
        public void IsBipartiteShould_ReturnTrue_GivenGraphIsBipartite()
        {
            // Arrange
            var graph = GraphBuilder.Bipartite();
            var test = new TwoColor(graph);

            // Act
            var isBipartite = test.IsBipartite;

            // Assert
            isBipartite.Should().BeTrue();
        }
    }
}
