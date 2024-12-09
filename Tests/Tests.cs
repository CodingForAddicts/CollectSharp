using Woodstix.Proficiencies;

namespace Tests;

public class Warmup
{
public class InventoryTests
    {
        [Theory]
        [InlineData(new[] { "Apple", "Banana", "Apple" }, 2, 1)]
        [InlineData(new[] { "Orange", "Orange", "Orange" }, 3, 0)]
        [InlineData(new string[0], 0, 0)]
        [InlineData(new[] { "Apple", "Banana", "Carrot" }, 1, 1)]
        public void MakeInventory_ReturnsCorrectCounts(
            string[] items,
            int expectedAppleCount,
            int expectedBananaCount)
        {
            // Arrange
            var itemList = new List<string>(items);

            // Act
            var result = Woodstix.Fundamentals.Warmup.MakeInventory(itemList);

            // Assert
            if (result.ContainsKey("Apple"))
            {
                Assert.Equal(expectedAppleCount, result["Apple"]);
            }
            else
            {
                Assert.False(result.ContainsKey("Apple"));
            }

            if (result.ContainsKey("Banana"))
            {
                Assert.Equal(expectedBananaCount, result["Banana"]);
            }
            else
            {
                Assert.False(result.ContainsKey("Banana"));
            }
        }

        [Fact]
        public void MakeInventory_EmptyList_ReturnsEmptyDictionary()
        {
            // Arrange
            var itemList = new List<string>();

            // Act
            var result = Woodstix.Fundamentals.Warmup.MakeInventory(itemList);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void MakeInventory_SingleItemList_ReturnsCorrectCount()
        {
            // Arrange
            var itemList = new List<string> { "Apple" };

            // Act
            var result = Woodstix.Fundamentals.Warmup.MakeInventory(itemList);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result["Apple"]);
        }

        [Fact]
        public void MakeInventory_DuplicateItems_ReturnsCorrectCounts()
        {
            // Arrange
            var itemList = new List<string> { "Apple", "Apple", "Banana", "Apple" };

            // Act
            var result = Woodstix.Fundamentals.Warmup.MakeInventory(itemList);

            // Assert
            Assert.Equal(3, result["Apple"]);
            Assert.Equal(1, result["Banana"]);
        }
        
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
        [InlineData(new[] { 10, 20, 30 }, new[] { 30, 20, 10 })]
        [InlineData(new[] { 1 }, new[] { 1 })]
        [InlineData(new int[0], new int[0])] // Empty list
        public void ReversePlaylist_ReversesListCorrectly(int[] original, int[] expected)
        {
            // Arrange
            var list = new List<int>(original);

            // Act
            Woodstix.Fundamentals.Warmup.ReversePlaylist(list);

            // Assert
            Assert.Equal(expected, list);
        }
    }
}

public class management
{
    public class NextGreaterPriceTests
    {
        [Theory]
        [InlineData(new[] { 4, 6, 3, 2, 8, 1 }, new[] { 6, 8, 8, 8, -1, -1 })]
        [InlineData(new[] { 3, 2, 1 }, new[] { -1, -1, -1 })]
        [InlineData(new[] { 1, 3, 2, 4 }, new[] { 3, 4, 4, -1 })]
        [InlineData(new int[0], new int[0])] // Empty array
        [InlineData(new[] { 7 }, new[] { 0 })] // Single element
        public void NextGreaterPrice_ReturnsCorrectResult(int[] numbers, int[] expected)
        {
            // Act
            var result = Woodstix.Fundamentals.Management.NextGreaterPrice(numbers);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void NextGreaterPrice_AllElementsSame_ReturnsAllZeros()
        {
            // Arrange
            var numbers = new[] { 5, 5, 5, 5 };

            // Act
            var result = Woodstix.Fundamentals.Management.NextGreaterPrice(numbers);

            // Assert
            Assert.All(result, value => Assert.Equal(0, value));
        }

        [Fact]
        public void NextGreaterPrice_DecreasingOrder_ReturnsAllZeros()
        {
            // Arrange
            var numbers = new[] { 9, 7, 5, 3, 1 };

            // Act
            var result = Woodstix.Fundamentals.Management.NextGreaterPrice(numbers);

            // Assert
            Assert.All(result, value => Assert.Equal(0, value));
        }

        [Fact]
        public void NextGreaterPrice_IncreasingOrder_ReturnsNextGreaterElement()
        {
            // Arrange
            var numbers = new[] { 1, 2, 3, 4, 5 };

            // Act
            var result = Woodstix.Fundamentals.Management.NextGreaterPrice(numbers);

            // Assert
            Assert.Equal(new[] { 2, 3, 4, 5, 0 }, result);
        }
    }
}

public class SwapMethodTests
{
    [Fact]
    public void Swap_SwapsTwoElementsCorrectly()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4 };

        // Act
        Woodstix.Proficiencies.RollingStone.Swap(list, 1, 3);

        // Assert
        Assert.Equal(new List<int> { 1, 4, 3, 2 }, list);
    }

    [Fact]
    public void Swap_WithSameIndices_LeavesListUnchanged()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3, 4 };

        // Act
        Woodstix.Proficiencies.RollingStone.Swap(list, 2, 2);

        // Assert
        Assert.Equal(new List<int> { 1, 2, 3, 4 }, list);
    }

    [Fact]
    public void Swap_FirstAndLastIndices_SwapsCorrectly()
    {
        // Arrange
        var list = new List<int> { 5, 6, 7, 8 };

        // Act
        Woodstix.Proficiencies.RollingStone.Swap(list, 0, 3);

        // Assert
        Assert.Equal(new List<int> { 8, 6, 7, 5 }, list);
    }

    [Fact]
    public void Swap_EmptyList_ThrowsException()
    {
        // Arrange
        var list = new List<int>();

        // Act & Assert
        Assert.Throws<System.ArgumentOutOfRangeException>(() => Woodstix.Proficiencies.RollingStone.Swap(list, 0, 1));
    }

    [Fact]
    public void Swap_InvalidIndices_ThrowsException()
    {
        // Arrange
        var list = new List<int> { 1, 2, 3 };

        // Act & Assert
        Assert.Throws<System.ArgumentOutOfRangeException>(() => Woodstix.Proficiencies.RollingStone.Swap(list, -1, 2));
        Assert.Throws<System.ArgumentOutOfRangeException>(() => Woodstix.Proficiencies.RollingStone.Swap(list, 1, 5));
    }
}

public class RollingStoneTests
    {
        [Fact]
        public void Partition_CorrectlyPartitionsArray_KnownCase1()
        {
            // Arrange
            var list = new List<int> { 5, 3, 1, 2, 4 };

            // Act
            int pivotIndex = Woodstix.Proficiencies.RollingStone.Partition(list, 0, 4);

            // Assert
            Assert.Equal(3, pivotIndex);
            Assert.Equal(new List<int> { 3, 1, 2, 4, 5 }, list);
        }

        [Fact]
        public void Partition_CorrectlyPartitionsArray_KnownCase2()
        {
            // Arrange
            var list = new List<int> { 5, 3, 1, 2, 4 };

            // Act
            int pivotIndex = Woodstix.Proficiencies.RollingStone.Partition(list, 0, 2);

            // Assert
            Assert.Equal(0, pivotIndex);
            Assert.Equal(new List<int> { 1, 3, 5, 2, 4 }, list);
        }

        [Fact]
        public void Partition_CorrectlyPartitionsArray_KnownCase3()
        {
            // Arrange
            var list = new List<int> { 5, 3, 1, 2, 4 };

            // Act
            int pivotIndex = Woodstix.Proficiencies.RollingStone.Partition(list, 3, 4);

            // Assert
            Assert.Equal(4, pivotIndex);
            Assert.Equal(new List<int> { 5, 3, 1, 2, 4 }, list);
        }

        [Fact]
        public void Partition_CorrectlyHandlesSingleElementList()
        {
            // Arrange
            var list = new List<int> { 1 };

            // Act
            int pivotIndex = Woodstix.Proficiencies.RollingStone.Partition(list, 0, 0);

            // Assert
            Assert.Equal(0, pivotIndex);
            Assert.Equal(new List<int> { 1 }, list);
        }

        [Fact]
        public void Partition_ThrowsException_WhenLeftIsGreaterThanRight()
        {
            // Arrange
            var list = new List<int> { 5, 3, 1, 2, 4 };

            // Act & Assert
            Assert.Throws<System.ArgumentException>(() => Woodstix.Proficiencies.RollingStone.Partition(list, 4, 3));
        }

        [Fact]
        public void Partition_ThrowsException_ForEmptyList()
        {
            // Arrange
            var list = new List<int>();

            // Act & Assert
            Assert.Throws<System.ArgumentOutOfRangeException>(() => Woodstix.Proficiencies.RollingStone.Partition(list, 0, 0));
        }
        
        public class QuickSortTests
        {
            [Fact]
            public void IterativeQuickSort_SortsUnsortedListCorrectly()
            {
                // Arrange
                var list = new List<int> { 8, 3, 1, 7, 0, 10, 2 };

                // Act
                Woodstix.Proficiencies.RollingStone.IterativeQuickSort(list);

                // Assert
                Assert.Equal(new List<int> { 0, 1, 2, 3, 7, 8, 10 }, list);
            }

            [Fact]
            public void IterativeQuickSort_HandlesAlreadySortedList()
            {
                // Arrange
                var list = new List<int> { 1, 2, 3, 4, 5 };

                // Act
                Woodstix.Proficiencies.RollingStone.IterativeQuickSort(list);

                // Assert
                Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, list);
            }

            [Fact]
            public void IterativeQuickSort_HandlesReverseSortedList()
            {
                // Arrange
                var list = new List<int> { 5, 4, 3, 2, 1 };

                // Act
                Woodstix.Proficiencies.RollingStone.IterativeQuickSort(list);

                // Assert
                Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, list);
            }

            [Fact]
            public void IterativeQuickSort_HandlesListWithDuplicates()
            {
                // Arrange
                var list = new List<int> { 4, 2, 4, 3, 4, 1, 2 };

                // Act
                Woodstix.Proficiencies.RollingStone.IterativeQuickSort(list);

                // Assert
                Assert.Equal(new List<int> { 1, 2, 2, 3, 4, 4, 4 }, list);
            }

            [Fact]
            public void IterativeQuickSort_HandlesSingleElementList()
            {
                // Arrange
                var list = new List<int> { 42 };

                // Act
                Woodstix.Proficiencies.RollingStone.IterativeQuickSort(list);

                // Assert
                Assert.Equal(new List<int> { 42 }, list);
            }

            [Fact]
            public void IterativeQuickSort_HandlesEmptyList()
            {
                // Arrange
                var list = new List<int>();

                // Act
                Woodstix.Proficiencies.RollingStone.IterativeQuickSort(list);

                // Assert
                Assert.Equal(new List<int>(), list);
            }
        }
    }

public class WagonsTests
    {
        [Fact]
        public void WagonsCollision_HandlesCaseWithNoCollisions()
        {
            // Arrange
            var wagons = new List<int> { 5, 10, -5 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Equal(new Stack<int>(new[] { 5, 10 }), result);
        }

        [Fact]
        public void WagonsCollision_HandlesEqualCollidingWagons()
        {
            // Arrange
            var wagons = new List<int> { 8, -8 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void WagonsCollision_HandlesPartialCollisionWithRemainder()
        {
            // Arrange
            var wagons = new List<int> { 10, 2, -5 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Equal(new Stack<int>(new[] { 10 }), result);
        }

        [Fact]
        public void WagonsCollision_HandlesMixedPositiveAndNegativeWagons()
        {
            // Arrange
            var wagons = new List<int> { -2, -1, 1, 2 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Equal(new Stack<int>(new[] { -2, -1, 1, 2 }), result);
        }

        [Fact]
        public void WagonsCollision_HandlesEmptyInputList()
        {
            // Arrange
            var wagons = new List<int>();

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void WagonsCollision_HandlesAllPositiveWagons()
        {
            // Arrange
            var wagons = new List<int> { 1, 2, 3, 4, 5 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Equal(new Stack<int>(new[] { 1, 2, 3, 4, 5 }), result);
        }

        [Fact]
        public void WagonsCollision_HandlesAllNegativeWagons()
        {
            // Arrange
            var wagons = new List<int> { -1, -2, -3, -4, -5 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Equal(new Stack<int>(new[] { -1, -2, -3, -4, -5 }), result);
        }

        [Fact]
        public void WagonsCollision_HandlesComplexCollisionScenario()
        {
            // Arrange
            var wagons = new List<int> { 3, 5, -6, -4, 2, -2 };

            // Act
            var result = Woodstix.Proficiencies.Wagons.WagonsCollision(wagons);

            // Assert
            Assert.Equal(new Stack<int>(new[] { -6, -4 }), result);
        }
    }

public class CalculusTests
    {
        [Fact]
        public void ConvertToRPN_ValidSimpleExpression_ReturnsCorrectQueue()
        {
            // Arrange
            string infix = "1 + 2";

            // Act
            Queue<string> result = Woodstix.Proficiencies.Calculus.ConvertToRPN(infix);

            // Assert
            Assert.Equal(new Queue<string>(new[] { "1", "2", "+" }), result);
        }

        [Fact]
        public void ConvertToRPN_ValidExpressionWithMultipleOperators_ReturnsCorrectQueue()
        {
            // Arrange
            string infix = "1 + 2 - 3";

            // Act
            Queue<string> result =  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix);

            // Assert
            Assert.Equal(new Queue<string>(new[] { "1", "2", "+", "3", "-" }), result);
        }

        [Fact]
        public void ConvertToRPN_ValidExpressionWithParentheses_ReturnsCorrectQueue()
        {
            // Arrange
            string infix = "42 - ( 1 + 2 )";

            // Act
            Queue<string> result =  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix);

            // Assert
            Assert.Equal(new Queue<string>(new[] { "42", "1", "2", "+", "-" }), result);
        }

        [Fact]
        public void ConvertToRPN_EmptyExpression_ReturnsEmptyQueue()
        {
            // Arrange
            string infix = "";

            // Act
            Queue<string> result =  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix);

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ConvertToRPN_InvalidExpressionWithLetters_ThrowsArgumentException()
        {
            // Arrange
            string infix = "a + 2";

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix));
        }

        [Fact]
        public void ConvertToRPN_InvalidExpressionWithUnbalancedLeftParenthesis_ThrowsArgumentException()
        {
            // Arrange
            string infix = "(2 + 3";

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix));
        }

        [Fact]
        public void ConvertToRPN_InvalidExpressionWithUnbalancedRightParenthesis_ThrowsArgumentException()
        {
            // Arrange
            string infix = "2 + ( 3";

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix));
        }

        [Fact]
        public void ConvertToRPN_InvalidExpressionWithExtraParentheses_ThrowsArgumentException()
        {
            // Arrange
            string infix = "1 + 2 )";

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix));
        }

        [Fact]
        public void ConvertToRPN_ComplexValidExpression_ReturnsCorrectQueue()
        {
            // Arrange
            string infix = "3 + 4 - ( 5 + 6 )";

            // Act
            Queue<string> result =  Woodstix.Proficiencies.Calculus.ConvertToRPN(infix);

            // Assert
            Assert.Equal(new Queue<string>(new[] { "3", "4", "+", "5", "6", "+", "-" }), result);
        }
        
         [Fact]
        public void EvaluateRPN_SingleOperand_ReturnsOperand()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "5" });

            // Act
            var result = Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void EvaluateRPN_Addition_ReturnsCorrectResult()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "2", "3", "+" });

            // Act
            var result = Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void EvaluateRPN_Subtraction_ReturnsCorrectResult()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "5", "3", "-" });

            // Act
            var result = Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression);

            // Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void EvaluateRPN_MultipleOperations_ReturnsCorrectResult()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "3", "4", "+", "2", "-" });

            // Act
            var result = Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression);

            // Assert
            Assert.Equal(5, result); // (3 + 4) - 2 = 5
        }

        [Fact]
        public void EvaluateRPN_InsufficientOperands_ThrowsArgumentException()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "5", "+" });

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression));
            Assert.Equal("Invalid RPN expression", exception.Message);
        }

        [Fact]
        public void EvaluateRPN_InvalidToken_ThrowsArgumentException()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "5", "abc", "+" });

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression));
            Assert.Equal("Invalid token: abc", exception.Message);
        }

        [Fact]
        public void EvaluateRPN_EmptyQueue_ThrowsArgumentException()
        {
            // Arrange
            var rpnExpression = new Queue<string>();

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression));
            Assert.Equal("Invalid RPN expression", exception.Message);
        }

        [Fact]
        public void EvaluateRPN_ExtraOperands_ThrowsArgumentException()
        {
            // Arrange
            var rpnExpression = new Queue<string>(new string[] { "5", "3", "+", "8" });

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => Woodstix.Proficiencies.Calculus.EvaluateRPN(rpnExpression));
            Assert.Equal("Invalid RPN expression", exception.Message);
        }
    }


public class CacheTests
{
    [Fact]
    public void CreateCache_ShouldReturnCacheAndKeysWithSpecifiedCapacity()
    {
        // Arrange
        int capacity = 5;

        // Act
        var (cache, keys) = Woodstix.Proficiencies.Toolkit.CreateCache(capacity);

        // Assert
        Assert.NotNull(cache); // Ensure cache is not null
        Assert.NotNull(keys); // Ensure keys list is not null
       // Assert.Equal(capacity, cache.Count); // Ensure cache is created with specified capacity
        Assert.Equal(capacity, keys.Capacity); // Ensure keys list is created with specified capacity
    }

    [Fact]
    public void CreateCache_ShouldAllowAddingItemsToCache()
    {
        // Arrange
        int capacity = 5;
        var (cache, keys) = Woodstix.Proficiencies.Toolkit.CreateCache(capacity);

        // Act
        cache[1] = "One";
        cache[2] = "Two";
        keys.Add(1);
        keys.Add(2);

        // Assert
        Assert.Equal("One", cache[1]);
        Assert.Equal("Two", cache[2]);
        Assert.Contains(1, keys);
        Assert.Contains(2, keys);
    }

    [Fact]
    public void CreateCache_ShouldAllowCapacityResizeForKeysList()
    {
        // Arrange
        int capacity = 5;
        var (cache, keys) = Woodstix.Proficiencies.Toolkit.CreateCache(capacity);

        // Act
        for (int i = 0; i < 10; i++)
        {
            cache[i] = $"Value{i}";
            keys.Add(i);
        }

        // Assert
        Assert.Equal(10, cache.Count); // Ensure cache count increased as items were added
        Assert.Equal(10, keys.Count);  // Ensure keys list contains all added keys
    }

    [Fact]
    public void CreateCache_ShouldInitializeCacheWithZeroItems()
    {
        // Arrange
        int capacity = 3;

        // Act
        var (cache, keys) = Woodstix.Proficiencies.Toolkit.CreateCache(capacity);

        // Assert
        Assert.Empty(cache); // Ensure cache is empty
        Assert.Empty(keys); // Ensure keys list is empty
    }
    
    [Fact]
    public void CreateCache_ShouldInitializeCacheWithEmptyKeysList()
    {
        // Arrange
        int capacity = 10;

        // Act
        var (cache, keys) = Woodstix.Proficiencies.Toolkit.CreateCache(capacity);

        // Assert
        Assert.Empty(keys); // Ensure the keys list is initially empty
    }
    
    [Fact]
    public void Put_ShouldAddNewToolToCache()
    {
        // Arrange
        var cacheTuple = Toolkit.CreateCache(3);

        // Act
        Toolkit.Put(1, "firstTool", cacheTuple);

        // Assert
        Assert.Contains("firstTool", cacheTuple.cache.Values);
        Assert.Equal(1, cacheTuple.keys.Count);
        Assert.Equal(1, cacheTuple.keys[0]);
    }

    [Fact]
    public void Put_ShouldAddMultipleToolsToCache()
    {
        // Arrange
        var cacheTuple = Toolkit.CreateCache(3);

        // Act
        Toolkit.Put(1, "firstTool", cacheTuple);
        Toolkit.Put(2, "secondTool", cacheTuple);
        Toolkit.Put(3, "thirdTool", cacheTuple);

        // Assert
        Assert.Equal(3, cacheTuple.keys.Count);
        Assert.Equal(1, cacheTuple.keys[2]); // Least Recently Used should be at the end
    }

    [Fact]
    public void Put_ShouldRemoveLeastRecentlyUsedToolWhenCacheIsFull()
    {
        // Arrange
        var cacheTuple = Toolkit.CreateCache(3);

        // Act
        Toolkit.Put(1, "firstTool", cacheTuple);
        Toolkit.Put(2, "secondTool", cacheTuple);
        Toolkit.Put(3, "thirdTool", cacheTuple);
        Toolkit.Put(4, "fourthTool", cacheTuple);

        // Assert
        Assert.Equal(3, cacheTuple.keys.Count);
        Assert.Equal(4, cacheTuple.keys[0]); // Most recently added tool is at the beginning
        Assert.Equal(3, cacheTuple.keys[1]);
        Assert.Equal(2, cacheTuple.keys[2]); // Least Recently Used is at the end
    }

    [Fact]
    public void Put_ShouldUpdateValueForExistingKeyAndMoveItToFront()
    {
        // Arrange
        var cacheTuple = Toolkit.CreateCache(3);

        // Act
        Toolkit.Put(1, "firstTool", cacheTuple);
        Toolkit.Put(2, "secondTool", cacheTuple);
        Toolkit.Put(1, "updatedTool", cacheTuple); // Update the value of key 1

        // Assert
        Assert.Equal("updatedTool", cacheTuple.cache[1]); // The value for key 1 should be updated
        Assert.Equal(2, cacheTuple.keys.Count);
        Assert.Equal(1, cacheTuple.keys[0]); // Key 1 should be at the front (most recently used)
        Assert.Equal(2, cacheTuple.keys[1]); // Key 2 should be at the back
    }

    [Fact]
    public void Put_ShouldNotExceedCacheCapacity()
    {
        // Arrange
        var cacheTuple = Toolkit.CreateCache(3);

        // Act
        Toolkit.Put(1, "firstTool", cacheTuple);
        Toolkit.Put(2, "secondTool", cacheTuple);
        Toolkit.Put(3, "thirdTool", cacheTuple);
        Toolkit.Put(4, "fourthTool", cacheTuple); // Exceeds capacity

        // Assert
        Assert.Equal(3, cacheTuple.cache.Count); // Cache should only contain 3 items
        Assert.Equal(3, cacheTuple.keys.Count);
        Assert.Equal(4, cacheTuple.keys[0]);
    }
    
    [Fact]
    public void Get_ReturnsCorrectTool_WhenKeyExists()
    {
        // Arrange
        var cacheTuple = Woodstix.Proficiencies.Toolkit.CreateCache(3);
        Woodstix.Proficiencies.Toolkit.Put(1, "firstTool", cacheTuple);
        Woodstix.Proficiencies.Toolkit.Put(2, "secondTool", cacheTuple);
        Woodstix.Proficiencies.Toolkit.Put(3, "thirdTool", cacheTuple);

        // Act
        var result = Woodstix.Proficiencies.Toolkit.Get(1, cacheTuple);

        // Assert
        Assert.Equal("firstTool", result);
    }

    [Fact]
    public void Get_ThrowsArgumentOutOfRangeException_WhenKeyDoesNotExist()
    {
        // Arrange
        var cacheTuple = Woodstix.Proficiencies.Toolkit.CreateCache(3);
        Woodstix.Proficiencies.Toolkit.Put(1, "firstTool", cacheTuple);
        Woodstix.Proficiencies.Toolkit.Put(2, "secondTool", cacheTuple);

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Woodstix.Proficiencies.Toolkit.Get(3, cacheTuple));
        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }

    [Fact]
    public void Get_BumpsKeyToFront_WhenKeyExists()
    {
        // Arrange
        var cacheTuple = Woodstix.Proficiencies.Toolkit.CreateCache(3);
        Woodstix.Proficiencies.Toolkit.Put(1, "firstTool", cacheTuple);
        Woodstix.Proficiencies.Toolkit.Put(2, "secondTool", cacheTuple);
        Woodstix.Proficiencies.Toolkit.Put(3, "thirdTool", cacheTuple);

        // Act
        Woodstix.Proficiencies.Toolkit.Get(1, cacheTuple); // Access key 1
        var keysAfterGet = cacheTuple.keys;

        // Assert: Key 1 should be at the front
        Assert.Equal(1, keysAfterGet[0]);
        Assert.Equal(3, keysAfterGet[1]);
        Assert.Equal(2, keysAfterGet[2]);
    }

    [Fact]
    public void Get_ThrowsArgumentOutOfRangeException_WhenCacheIsEmpty()
    {
        // Arrange
        var cacheTuple = Woodstix.Proficiencies.Toolkit.CreateCache(3);

        // Act & Assert
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => Woodstix.Proficiencies.Toolkit.Get(1, cacheTuple));
        Assert.IsType<ArgumentOutOfRangeException>(exception);
    }
}

public class HandleJobsTests
{
    [Fact]
    public void HandleJobs_ShouldProcessJobsWithGivenValues()
    {
        // Arrange
        Stack<(int value, string name)> jobs1 = new Stack<(int, string)>();
        jobs1.Push((1, "A"));
        jobs1.Push((2, "B"));
        jobs1.Push((3, "C"));
        jobs1.Push((2, "D"));

        // Act
        var (queue1, queue2) = TaskBalancing.HandleJobs(jobs1);

        // Assert
        var queue1Results = new List<string>(queue1);
        var queue2Results = new List<string>(queue2);

        // Expecting: 
        // queue1 = { Empty, D, D, B, B }
        // queue2 = { Empty, C, C, C, A }
        Assert.Equal(new List<string> { "Empty", "D", "D", "B", "B" }, queue1Results);
        Assert.Equal(new List<string> { "Empty", "C", "C", "C", "A" }, queue2Results);
    }

    [Fact]
    public void HandleJobs_ShouldProcessJobsWithAnotherSetOfValues()
    {
        // Arrange
        Stack<(int value, string name)> jobs2 = new Stack<(int, string)>();
        jobs2.Push((1, "A"));
        jobs2.Push((2, "B"));
        jobs2.Push((2, "C"));
        jobs2.Push((2, "D"));

        // Act
        var (queue3, queue4) = TaskBalancing.HandleJobs(jobs2);

        // Assert
        var queue3Results = new List<string>(queue3);
        var queue4Results = new List<string>(queue4);

        // Expecting:
        // queue3 = { Empty, D, D, B, B }
        // queue4 = { Empty, C, C, A, Done }
        Assert.Equal(new List<string> { "Empty", "D", "D", "B", "B" }, queue3Results);
        Assert.Equal(new List<string> { "Empty", "C", "C", "A", "Done" }, queue4Results);
    }
    
    [Fact]
        public void HandleJobs_ThreeWorkers_CorrectTaskDistribution()
        {
            // Arrange
            var jobs = new Stack<(int value, string name)>();
            jobs.Push((1, "A"));
            jobs.Push((2, "B"));
            jobs.Push((3, "C"));
            jobs.Push((2, "D"));

            // Act
            List<Queue<string>> queues = TaskBalancing.HandleJobs(jobs, 3);

            // Assert
            Assert.Equal(3, queues.Count);

            // First worker queue
            Assert.Equal(new[] { "Empty", "D", "D", "A" }, queues[0].ToArray());

            // Second worker queue
            Assert.Equal(new[] { "Empty", "C", "C", "C" }, queues[1].ToArray());

            // Third worker queue
            Assert.Equal(new[] { "Empty", "B", "B", "Done" }, queues[2].ToArray());
        }

        [Fact]
        public void HandleJobs_FourWorkers_CorrectTaskDistribution()
        {
            // Arrange
            var jobs = new Stack<(int value, string name)>();
            jobs.Push((1, "A"));
            jobs.Push((2, "B"));
            jobs.Push((2, "C"));
            jobs.Push((2, "D"));
            jobs.Push((2, "E"));

            // Act
            List<Queue<string>> queues = TaskBalancing.HandleJobs(jobs, 4);

            // Assert
            Assert.Equal(4, queues.Count);

            // First worker queue
            Assert.Equal(new[] { "Empty", "E", "E", "A" }, queues[0].ToArray());

            // Second worker queue
            Assert.Equal(new[] { "Empty", "D", "D", "Done" }, queues[1].ToArray());

            // Third worker queue
            Assert.Equal(new[] { "Empty", "C", "C", "Done" }, queues[2].ToArray());

            // Fourth worker queue
            Assert.Equal(new[] { "Empty", "B", "B", "Done" }, queues[3].ToArray());
        }

        [Fact]
        public void HandleJobs_FewerJobsThanWorkers_CorrectHandling()
        {
            // Arrange
            var jobs = new Stack<(int value, string name)>();
            jobs.Push((1, "A"));
            jobs.Push((2, "B"));

            // Act
            List<Queue<string>> queues = TaskBalancing.HandleJobs(jobs, 4);

            // Assert
            Assert.Equal(4, queues.Count);

            // Verify that extra workers are marked as done
            Assert.Equal(new[] { "Empty", "A", "Done", "Done" }, queues[0].ToArray());
            Assert.Equal(new[] { "Empty", "B", "B", "Done" }, queues[1].ToArray());
            Assert.Equal(new[] { "Empty", "Done", "Done", "Done" }, queues[2].ToArray());
            Assert.Equal(new[] { "Empty", "Done", "Done", "Done" }, queues[3].ToArray());
        }

        [Fact]
        public void HandleJobs_EmptyJobStack_AllWorkersDone()
        {
            // Arrange
            var jobs = new Stack<(int value, string name)>();

            // Act
            List<Queue<string>> queues = TaskBalancing.HandleJobs(jobs, 3);

            // Assert
            Assert.Equal(3, queues.Count);

            // All workers should have only "Empty" and "Done"
            foreach (var queue in queues)
            {
                Assert.Equal(new[] { "Empty", "Done" }, queue.ToArray());
            }
        }
}
    
public class VIPTicketTests
    {
        [Fact]
        public void Test_ReversedPriorityQueue_ReturnsCorrectOperationCounts()
        {
            // Arrange
            Queue<int> wait1 = new Queue<int>(new[] { 3, 2, 1 });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait1, 3);
            
            // Assert
            Assert.Equal(new List<int> { 3, 4, 5 }, result);
        }

        [Fact]
        public void Test_AlreadyOrderedPriorityQueue_ReturnsCorrectOperationCounts()
        {
            // Arrange
            Queue<int> wait2 = new Queue<int>(new[] { 1, 2, 3 });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait2, 3);
            
            // Assert
            Assert.Equal(new List<int> { 1, 2, 3 }, result);
        }

        [Fact]
        public void Test_QueueWithNonVIPTickets_ReturnsCorrectOperationCounts()
        {
            // Arrange
            Queue<int> wait3 = new Queue<int>(new[] { 0, 3, 0, 2, 0, 0, 0, 1, 0, 0 });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait3, 3);
            
            // Assert
            Assert.Equal(new List<int> { 8, 9, 10 }, result);
        }

        [Fact]
        public void Test_EmptyQueueWithNoVIPTickets_ReturnsEmptyList()
        {
            // Arrange
            Queue<int> wait4 = new Queue<int>(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait4, 0);
            
            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void Test_SingleVIPTicketInQueue_ReturnsCorrectOperationCount()
        {
            // Arrange
            Queue<int> wait = new Queue<int>(new[] { 0, 1, 0, 0 });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait, 1);
            
            // Assert
            Assert.Equal(new List<int> { 2 }, result);
        }

        [Fact]
        public void Test_MixedOrderVIPTicketsWithNonVIPTickets_ReturnsCorrectOperationCounts()
        {
            // Arrange
            Queue<int> wait = new Queue<int>(new[] { 0, 2, 0, 1, 0, 3, 0 });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait, 3);
            
            // Assert
            Assert.Equal(new List<int> { 4, 6, 7 }, result);
        }

        [Fact]
        public void Test_LargeNumberOfNonVIPTickets_ReturnsCorrectOperationCounts()
        {
            // Arrange
            Queue<int> wait = new Queue<int>(new[] { 
                0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 
                0, 2, 0, 0, 0, 1, 0, 0, 0, 0 
            });
            
            // Act
            List<int> result = VIP.TicketsVIP(wait, 3);
            
            // Assert
            Assert.Equal(new List<int> { 16, 7, 18 }, result);
        }

        [Fact]
        public void Test_ArgumentValidation_NullQueue_ThrowsArgumentNullException()
        {
            // Arrange
            Queue<int> nullQueue = null;
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => VIP.TicketsVIP(nullQueue, 3));
        }
    }
    
