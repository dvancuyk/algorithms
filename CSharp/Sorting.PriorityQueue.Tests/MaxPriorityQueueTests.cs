using System;
using FluentAssertions;
using Xunit;

namespace Sorting.PriorityQueue.Tests
{
    public class MaxPriorityQueueTests
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Insert_ShouldPrioritizeKey_GivenKeyIsOnlyKey()
        {
            // Arrange
            const int key = 1;
            var priority = new MaxPriorityQueue<int>(1);

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
            const int max = 10;
            var candidates = new[] {1, 3, 5, max, 2, 7, 9};
            var priority = new MaxPriorityQueue<int>(candidates);

            // Act
            var key = priority.DeleteMax();

            // Assert
            key.Should().Be(max);
            priority.Count.Should().Be(candidates.Length - 1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnMaxAndRemoveFromQueue()
        {
            // Arrange
            const int key = 1;
            var priority = new MaxPriorityQueue<int>(new []{ key });

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
            var priority = new MaxPriorityQueue<int>(0);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => priority.DeleteMax());

            // Assert
            ex.Should().NotBeNull();
        }
        
    }
}
