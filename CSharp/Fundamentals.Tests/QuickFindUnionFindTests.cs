using System;
using FluentAssertions;
using Xunit;

namespace Fundamentals.Tests
{
    public class QuickFindUnionFindTests
    {
        [Fact]
        public void Connected_ShouldReturnTrue_GivenTwoPointsAreUnioned()
        {
            // Arrange
            const int p = 1,
                q = 9;
            var uf = new QuickFindUnionFind(10);

            // Act
            uf.Union(p, q);
            var isConnected = uf.Connected(p, q);

            // Assert
            isConnected.Should().BeTrue();
        }

        [Fact]
        public void Connected_ShouldReturnTrue_GivenPointsAreUnionedAndTransitive()
        {
            // Arrange
            const int p = 1,
                q = 9,
                x = 5;
            var uf = new QuickFindUnionFind(10);

            // Act
            uf.Union(p, q);
            uf.Union(q, x);
            var isConnected = uf.Connected(p, x);

            // Assert
            isConnected.Should().BeTrue();
        }

        [Fact]
        public void Connected_ShouldReturnFalse_GivenTwoPointsAreNotUnioned()
        {
            // Arrange
            const int p = 1,
                q = 9,
                x = 5;
            var uf = new QuickFindUnionFind(10);

            // Act
            uf.Union(p, q);
            var isConnected = uf.Connected(p, x);

            // Assert
            isConnected.Should().BeFalse();
        }

        [Fact]
        public void Count_ShouldReturnN_GivenNoUnionsAndInitializedWithN()
        {
            // Arrange
            const int count = 10;

            // Act
            var uf = new QuickFindUnionFind(count);

            // Assert
            uf.Count.Should().Be(count);
        }

        [Fact]
        public void Count_ShouldReturn5_GivenInitializedWith10And5UnionOccurs()
        {
            // Arrange
            const int count = 10;
            var uf = new QuickFindUnionFind(count);

            // Act
            for (int index = 1; index <= count; index+=2)
            {
                uf.Union(index - 1, index);
            }

            // Assert
            uf.Count.Should().Be(count / 2);
        }

        [Fact]
        public void Count_ShouldReturn1_GivenAllPointsAreUnioned()
        {
            // Arrange
            const int count = 10;
            var uf = new QuickFindUnionFind(count);

            // Act
            for (int index = 0; index < count; index++)
            {
                uf.Union(1, index);
            }

            // Assert
            uf.Count.Should().Be(1);
        }
    }
}
