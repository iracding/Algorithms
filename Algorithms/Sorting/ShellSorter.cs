using System.Collections.Generic;
using System.Diagnostics;
using Algorithms.Common;
using Newtonsoft.Json;

namespace Algorithms.Sorting
{
    //希尔排序
    //希尔排序是把记录按下标的一定增量分组，对每组使用直接插入排序算法排序；随着增量逐渐减少，每组包含的关键词越来越多，当增量减至1时，整个文件恰被分成一组，算法便终止。 [1] 
    //希尔排序是基于插入排序的以下两点性质而提出改进方法的：
    //插入排序在对几乎已经排好序的数据操作时，效率高，即可以达到线性排序的效率。
    //但插入排序一般来说是低效的，因为插入排序每次只能将数据移动一位。
    public static class ShellSorter
    {
        public static void ShellSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.ShellSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void ShellSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            bool flag = true;
            int d = collection.Count;
            while (flag || (d > 1))
            {
                flag = false;
                d = (d + 1) / 2;
                for (int i = 0; i < (collection.Count - d); i++)
                {
                    if (comparer.Compare(collection[i + d], collection[i]) < 0)
                    {
                        collection.Swap(i + d, i);
                        flag = true;
                        Trace.WriteLine(JsonConvert.SerializeObject(collection));
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void ShellSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            bool flag = true;
            int d = collection.Count;
            while (flag || (d > 1))
            {
                flag = false;
                d = (d + 1) / 2;
                for (int i = 0; i < (collection.Count - d); i++)
                {
                    if (comparer.Compare(collection[i + d], collection[i])>0)
                    {
                        collection.Swap(i+d,i);
                        flag = true;
                    }
                }
            }
        }
    }
}
