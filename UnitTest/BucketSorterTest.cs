using Algorithms.Sorting;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace UnitTest.AlgorithmsTests
{
    public static class BucketSorterTest
    {
        [Fact]
        public static void DoTest()
        {
            IList<int> list = new List<int>() { 23, 42, 4, 16, 8, 15, 3, 9, 55, 0, 34, 12, 2, 46, 25 };
            list.BucketSort();
            int[] sortedList = { 0, 2, 3, 4, 8, 9, 12, 15, 16, 23, 25, 34, 42, 46, 55 };
            Assert.True(list.SequenceEqual(sortedList));
        }
    }
}

