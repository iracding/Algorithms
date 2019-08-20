using System.Collections.Generic;
using Algorithms.Common;

namespace Algorithms.Sorting
{
    //冒泡排序:冒泡排序的基本思想是：每次比较两个相邻的元素，如果它们的顺序错误就把它们交换过来
    //冒泡排序是一种交换排序。

    //什么是交换排序呢？

    //交换排序：两两比较待排序的关键字，并交换不满足次序要求的那对数，直到整个表都满足次序要求为止。

    //算法思想
    //它重复地走访过要排序的数列，一次比较两个元素，如果他们的顺序错误就把他们交换过来。走访数列的工作是重复地进行直到没有再需要交换，也就是说该数列已经排序完成。

    //这个算法的名字由来是因为越小的元素会经由交换慢慢“浮”到数列的顶端，故名。

    //假设有一个大小为 N 的无序序列。冒泡排序就是要每趟排序过程中通过两两比较，找到第 i 个小（大）的元素，将其往上排。
    public static class BubbleSorter
    {
        public static void BubbleSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.BubbleSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void BubbleSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            for (int i = 0; i < collection.Count; i++)
            {
                for (int index = 0; index < collection.Count - 1; index++)
                {
                    if (comparer.Compare(collection[index], collection[index + 1]) > 0)
                    {
                        collection.Swap(index, index + 1);
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void BubbleSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            for (int i = 0; i < collection.Count - 1; i++)
            {
                for (int index = 1; index < collection.Count - i; index++)
                {
                    if (comparer.Compare(collection[index], collection[index - 1]) > 0)
                    {
                        collection.Swap(index - 1, index);
                    }
                }
            }
        }
    }
}
