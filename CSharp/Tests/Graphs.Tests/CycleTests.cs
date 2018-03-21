using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class CycleTests
    {
        [Fact]
        public void HasCycleShould_ReturnTrue_GivenGraphIsNotAcyclic()
        {
            // Arrange
            var graph = GraphBuilder.Basic();
            var cycle = new Cycle(graph);

            // Act
            var hasCycle = cycle.HasCycle;

            // Assert
            hasCycle.Should().BeTrue();
        }

        [Fact]
        public void HasCycleShould_ReturnFalse_GivenGraphIsAcyclic()
        {
            // Arrange
            var graph = GraphBuilder.Acyclic();
            var cycle = new Cycle(graph);

            // Act
            var hasCycle = cycle.HasCycle;

            // Assert
            hasCycle.Should().BeTrue();
        }
    }
}
