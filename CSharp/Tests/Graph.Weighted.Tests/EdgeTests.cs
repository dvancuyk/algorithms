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
        public void CompareTo_ShouldReturnNegativeOne_GivenTheOtherEdgeWeightIsGreater()
        {
            // Act
            var result = LesserEdge.CompareTo(GreaterEdge);

            // Assert
            result.Should().Be(-1);
        }

        [Fact]
        public void CompareTo_Should0_GivenTheOtherEdgeWeightIsEqual()
        {
            // Act
            var result = LesserEdge.CompareTo(LesserEdge);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void CompareTo_ShouldReturnNegative1_GivenTheOtherEdgeWeightIsLesser()
        {
            // Act
            var result = LesserEdge.CompareTo(GreaterEdge);

            // Assert
            result.Should().Be(-1);
        }
    }
}
