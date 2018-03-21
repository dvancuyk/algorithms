using FluentAssertions;
using Kayllian.Algorithms.Graphs;
using System.Collections.Generic;
using Xunit;

namespace Graphs.Tests
{
    /// <summary>
    /// This is an algorithm that searchs for 
    /// </summary>
    public class DepthFirstPathsTests
    {
        [Theory]
        [InlineData(0, 3)]
        [InlineData(7, 8)]
        [InlineData(11, 12)]
        public void PathTo_ShouldReturnPath_GivenPathExists(int originalVertex, int connectedVertex)
        {
            // Arrange
            var graph = GraphBuilder.Basic();
            var search = new DepthFirstPaths(graph, originalVertex);

            // Act
            var path = search.PathTo(connectedVertex);

            // Assert
            path.Should()
                .NotBeNullOrEmpty()
                .And
                .Contain(originalVertex);
        }

        [Theory]
        [InlineData(0, 7)]
        [InlineData(7, 10)]
        [InlineData(11, 1)]
        public void PathTo_ShouldReturnEmptyPath_GivenNoPathExists(int originalVertex, int connectedVertex)
        {
            // Arrange
            var graph = GraphBuilder.Basic();
            var search = new DepthFirstPaths(graph, originalVertex);

            // Act
            var path = search.PathTo(connectedVertex);

            // Assert
            path.Should().BeNullOrEmpty();
        }
    }
}
