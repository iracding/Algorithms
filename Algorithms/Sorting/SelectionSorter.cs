using System.Collections.Generic;
using Algorithms.Common;

namespace Algorithms.Sorting
{
    //选择排序
    //选择排序（Selection sort）是一种简单直观的排序算法。它的工作原理是：第一次从待排序的数据元素中选出最小（或最大）的一个元素，存放在序列的起始位置，然后再从剩余的未排序元素中寻找到最小（大）元素，
    //然后放到已排序的序列的末尾。以此类推，直到全部待排序的数据元素的个数为零。选择排序是不稳定的排序方法。
    public static class SelectionSorter
    {
        public static void SelectionSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.SelectionSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void SelectionSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            int i;
            for(i=0;i<collection.Count;i++)
            {
                int min=i;
                for (int j = i + 1; j < collection.Count; j++) 
                {
                    if (comparer.Compare(collection[j], collection[min]) < 0)
                    {
                        min = j;
                    }
                }
                collection.Swap(i,min);
            }
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void SelectionSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            int i;
            for (i = collection.Count-1; i >0; i--)
            {
                int max = i;
                for (int j = 0; j <=i; j++)
                {
                    if (comparer.Compare(collection[j], collection[max]) < 0)
                        max = j;
                }
                collection.Swap(i, max);
            }
        }
    }
}
