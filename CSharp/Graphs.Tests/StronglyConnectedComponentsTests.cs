using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class t
    {
        [Fact]
        public void CountShould_Return5_GivenOnly5ConnectedComponentsExist()
        {
            // Arrange
            var graph = GraphBuilder.DefaultDirected();

            // Act
            var scc = new StronglyConnectedComponents(graph);

            // Assert
            scc.Count.Should().Be(5);
        }

        [Theory]
        [InlineData(2, 3)]
        [InlineData(10, 11)]
        [InlineData(7, 8)]
        public void IsStrongConnectedShould_ReturnTrue_GivenVerticesAreStronglyConnected(int v, int w)
        {
            // Arrange
            var graph = GraphBuilder.DefaultDirected();
            var scc = new StronglyConnectedComponents(graph);

            // Act
            var isConnected = scc.StronglyConnected(v, w);

            // Assert
            isConnected.Should().BeTrue();
        }

        [Theory]
        [InlineData(1, 3)]
        [InlineData(2, 10)]
        [InlineData(2, 6)]
        [InlineData(8, 10)]
        public void IsStrongConnectedShould_ReturnFalse_GivenVerticesAreNotStronglyConnected(int v, int w)
        {
            // Arrange
            var graph = GraphBuilder.DefaultDirected();
            var scc = new StronglyConnectedComponents(graph);

            // Act
            var isConnected = scc.StronglyConnected(v, w);

            // Assert
            isConnected.Should().BeFalse();
        }
    }
}
