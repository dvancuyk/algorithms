using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using Xunit;

namespace Graphs.Tests
{
    public class DirectedCycleTests
    {
        [Fact]
        public void HasCycleShould_ReturnTrue_GivenGraphHasCycle()
        {
            // Arrange
            var graph = GraphBuilder.DefaultDirected();
            var query = new DirectedCycle(graph);

            // Act
            var hasCycle = query.HasCycle;

            // Assert
            hasCycle.Should().BeTrue();
        }

        [Fact]
        public void HasCycleShould_ReturnFalse_GivenGraphHasAcyclic()
        {
            // Arrange
            var graph = new DirectedGraph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(2, 3);

            var query = new DirectedCycle(graph);

            // Act
            var hasCycle = query.HasCycle;

            // Assert
            hasCycle.Should().BeFalse();
        }

        [Fact]
        public void CycleShould_ReturnNonEmptyCollection_GivenGraphHasCycle()
        {
            // Arrange
            var graph = GraphBuilder.DefaultDirected();
            var query = new DirectedCycle(graph);

            // Act
            var cycle = query.Cycle();

            // Assert
            cycle.Should().NotBeNullOrEmpty();
            

        }
    }
}
