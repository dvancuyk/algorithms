using System;
using FluentAssertions;
using Xunit;

namespace Sorting.PriorityQueue.Tests
{
    public class IndexMinPriorityQueueTests
    {

        private static IndexMinPriorityQueue<T> CreatePriorityQueue<T>(params T[] items)
            where T : IComparable<T>
        {
            var queue = new IndexMinPriorityQueue<T>(items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                queue.Insert(i, items[i]);
            }

            return queue;
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Insert_ShouldPrioritizeKey_GivenKeyIsOnlyKey()
        {
            // Arrange
            const double key = 1.7;
            var priority = CreatePriorityQueue<double>(1);

            // Act
            priority.Insert(0, key);

            // Assert
            priority.Next.Should().Be(key);
            priority.Count.Should().Be(1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnMaxKey_GivenMultipleKeys()
        {
            // Arrange
            const double min = .04;
            var candidates = new[] { 1.1, 300.1, 5.5, min, .2, 7.9, 900.2 };
            var priority = CreatePriorityQueue<double>(candidates);

            // Act
            var key = priority.DeleteMinimum();

            // Assert
            key.Should().Be(min);
            priority.Count.Should().Be(candidates.Length - 1);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldDeletePrimaryCandidate_GivenDeleteMaxIsCalledMultipleTimes()
        {
            // Arrange
            const double min = .04;
            var candidates = new[] { 1.1, 900.2, 5.5, 300.1, min, .2, 7.9 };
            var priority = CreatePriorityQueue(candidates.Length);
            var previousKey = double.MinValue;

            // Act
            while (!priority.IsEmpty)
            {
                var id = priority.DeleteMinimum();
                var key = candidates[id];

                // Assert
                key.Should()
                    .BeGreaterOrEqualTo(previousKey);

                if (priority.Count > 0)
                    key.Should().BeLessOrEqualTo(priority.Next);

                previousKey = key;
            }
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnMaxAndRemoveFromQueue()
        {
            // Arrange
            const double key = 1.00;
            var priority = CreatePriorityQueue(key);

            // Act
            var max = priority.DeleteMinimum();

            // Assert
            max.Should().Be(key);
            priority.Count.Should().Be(0);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void DeleteMax_ShouldReturnNull_GivenQueueIsEmpty()
        {
            // Arrange
            var priority = CreatePriorityQueue<double>(0);

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => priority.DeleteMinimum());

            // Assert
            ex.Should().NotBeNull();
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Change_ShouldResortNewItemToNext_GivenPreviousValueWasNotNextAndCurrentValueIsLowest()
        {
            // Arrange
            const int id = 2;
            var candidates = new[] { 1.1, 300.1, 5.5, .04, .2, 7.9, 900.2 };
            var priority = CreatePriorityQueue(candidates);

            // Preconditions check
            priority.NextIndex.Should().NotBe(id);

            // Act
            priority.Change(id, -1);

            // Assert
            priority.NextIndex.Should().Be(id);
        }

        [Fact]
        [Trait("Category", "Unit")]
        public void Change_ShouldResortNewItemFromNext_GivenPreviousValueWasNextAndCurrentValueIsNotLowest()
        {
            // Arrange
            var candidates = new[] { .04, 1.1, 300.1, 5.5, .2, 7.9, 900.2 };
            const int id = 0;
            var priority = CreatePriorityQueue(candidates);
            priority.NextIndex.Should().Be(id);

            // Act
            priority.Change(id, 999);

            // Assert
            priority.NextIndex.Should().NotBe(id);
        }
    }
}
