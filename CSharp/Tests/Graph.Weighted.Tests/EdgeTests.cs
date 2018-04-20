using Graphs.Weighted;

using FluentAssertions;
using Xunit;

namespace Graph.Weighted.Tests
{
    public class EdgeTests
    {
        private static readonly Edge LesserEdge = new Edge(1, 2, .5);
        private static readonly Edge GreaterEdge = new Edge(1, 2, 1.5);

        [Fact]
        [Trait("Category", "Unit")]
        public void CompareTo_ShouldReturnNegativeOne_GivenTheOtherEdgeWeightIsGreater()
        {
            // Act
            var result = LesserEdge.CompareTo(GreaterEdge);

            // Assert
            result.Should().Be(-1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CompareTo_Should0_GivenTheOtherEdgeWeightIsEqual()
        {
            // Act
            var result = LesserEdge.CompareTo(LesserEdge);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void CompareTo_ShouldReturnNegative1_GivenTheOtherEdgeWeightIsLesser()
        {
            // Act
            var result = LesserEdge.CompareTo(GreaterEdge);

            // Assert
            result.Should().Be(-1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equals_ShouldReturnTrue_GivenEdgeRepresentsSameEdge()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.3);
            var second = new Edge(0, 1, 1.3);

            // Act
            var equals = edge.Equals(second);

            // Assert
            equals.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equals_ShouldReturnFalse_GivenVertexIsDifferent()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.3);
            var second = new Edge(2, 1, 1.3);

            // Act
            var equals = edge.Equals(second);

            // Assert
            equals.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equals_ShouldReturnFalse_GivenSecondVertexIsDifferent()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.3);
            var second = new Edge(0, 2, 1.3);

            // Act
            var equals = edge.Equals(second);

            // Assert
            equals.Should().BeFalse();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Equals_ShouldReturnFalse_GivenWeightIsDifferent()
        {
            // Arrange
            var edge = new Edge(0, 1, 1.3);
            var second = new Edge(0, 1, 1.4);

            // Act
            var equals = edge.Equals(second);

            // Assert
            equals.Should().BeFalse();
        }
    }
}
