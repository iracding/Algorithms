using System.Collections.Generic;
using Algorithms.Common;

namespace Algorithms.Sorting
{
    //奇偶排序
    //奇偶排序法的思路是在数组中重复两趟扫描。第一趟扫描选择所有的数据项对，a[j] 和a[j + 1]，j是奇数(j= 1, 3, 5……)。如果它们的关键字的值次序颠倒，就交换它们。第二趟扫描对所有的偶数数据项进行同样的操作(j= 2, 4,6……)。
    //重复进行这样两趟的排序直到数组全部有序。
    //奇偶排序实际上在多处理器环境中很有用，处理器可以分别同时处理每一个奇数对，然后又同时处理偶数对。因为奇数对是彼此独立的，每一刻都可以用不同的处理器比较和交换。这样可以非常快速地排序。
    /// <summary>
    /// Based on bubble sort
    /// </summary>
    public static class OddEvenSorter
    {
        public static void OddEvenSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.OddEvenSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void OddEvenSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < collection.Count - 1; i += 2)
                {
                    if (comparer.Compare(collection[i], collection[i + 1]) > 0)
                    {
                        collection.Swap(i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < collection.Count - 1; i += 2)
                {
                    if (comparer.Compare(collection[i], collection[i + 1]) > 0)
                    {
                        collection.Swap(i, i + 1);
                        sorted = false;
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void OddEvenSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (var i = 1; i < collection.Count - 1; i += 2)
                {
                    if (comparer.Compare(collection[i], collection[i + 1]) < 0)
                    {
                        collection.Swap(i, i + 1);
                        sorted = false;
                    }
                }

                for (var i = 0; i < collection.Count - 1; i += 2)
                {
                    if (comparer.Compare(collection[i], collection[i + 1]) < 0)
                    {
                        collection.Swap(i, i + 1);
                        sorted = false;
                    }
                }
            }
        }
    }
}
