using System;
using FluentAssertions;
using Xunit;

namespace Sorting.PriorityQueue.Tests
{
    public class MinPriorityQueueTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Insert_ShouldPrioritizeKey_GivenKeyIsOnlyKey()
        {
            // Arrange
            const double key = 1.7;
            var priority = new MinPriorityQueue<double>(1);

            // Act
            priority.Insert(key);

            // Assert
            priority.Max.Should().Be(key);
            priority.Count.Should().Be(1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnMaxKey_GivenMultipleKeys()
        {
            // Arrange
            const double min = .04;
            var candidates = new[] { 1.1, 300.1, 5.5, min, .2, 7.9, 900.2 };
            var priority = new MinPriorityQueue<double>(candidates);

            // Act
            var key = priority.DeleteMax();

            // Assert
            key.Should().Be(min);
            priority.Count.Should().Be(candidates.Length - 1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnMaxAndRemoveFromQueue()
        {
            // Arrange
            const double key = 1.00;
            var priority = new MinPriorityQueue<double>(new[] { key });

            // Act
            var max = priority.DeleteMax();

            // Assert
            max.Should().Be(key);
            priority.Count.Should().Be(0);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnNull_GivenQueueIsEmpty()
        {
            // Arrange
            var priority = new MinPriorityQueue<double>(0);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => priority.DeleteMax());

            // Assert
            ex.Should().NotBeNull();
        }
    }
}