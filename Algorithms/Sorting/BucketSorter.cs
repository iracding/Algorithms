using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    //二、桶排序（BucketSort）
    //桶排序（Bucket sort）或所谓的箱排序，是一个排序算法，工作的原理是将数组分到有限数量的桶里。每个桶再个别排序（有可能再使用别的排序算法或是以递归方式继续使用桶排序进行排序），
    //最后依次把各个桶中的记录列出来记得到有序序列。桶排序是鸽巢排序的一种归纳结果。当要被排序的数组内的数值是均匀分配的时候，桶排序使用线性时间（Θ(n)）。但桶排序并不是比较排序，他不受到O(n log n)下限的影响。
    // 基本思想
    // 桶排序的思想近乎彻底的分治思想。
    // 桶排序假设待排序的一组数均匀独立的分布在一个范围中，并将这一范围划分成几个子范围（桶）。

    // 然后基于某种映射函数f ，将待排序列的关键字 k 映射到第i个桶中(即桶数组B 的下标i) ，那么该关键字k 就作为 B[i] 中的元素(每个桶B[i] 都是一组大小为N/M 的序列)。

    //接着将各个桶中的数据有序的合并起来 : 对每个桶B[i] 中的所有元素进行比较排序(可以使用快排)。然后依次枚举输出 B[0]….B[M] 中的全部内容即是一个有序序列。

    //补充： 映射函数一般是 f = array[i] / k; k^2 = n; n是所有元素个数

    //为了使桶排序更加高效，我们需要做到这两点：

    //在额外空间充足的情况下，尽量增大桶的数量
    //使用的映射函数能够将输入的 N 个数据均匀的分配到 K 个桶中
    //同时，对于桶中元素的排序，选择何种比较排序算法对于性能的影响至关重要。


    /// <summary>
    /// Only support IList<int> Sort
    /// </summary>
    public static class BucketSorter
    {
        public static void BucketSort(this IList<int> collection)
        {
            collection.BucketSortAscending();
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void BucketSortAscending(this IList<int> collection)
        {
            int maxValue = collection.Max();
            int minValue = collection.Min();

            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            foreach (int i in collection)
            {
                bucket[i - minValue].Add(i);
            }

            int k = 0;
            foreach (List<int> i in bucket)
            {
                if (i.Count > 0)
                {
                    foreach (int j in i)
                    {
                        collection[k] = j;
                        k++;
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void BucketSortDescending(this IList<int> collection)
        {
            int maxValue = collection[0];
            int minValue = collection[0];
            for (int i = 1; i < collection.Count; i++)
            {
                if (collection[i] > maxValue)
                    maxValue = collection[i];

                if (collection[i] < minValue)
                    minValue = collection[i];
            }
            List<int>[] bucket = new List<int>[maxValue - minValue + 1];

            for (int i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }

            foreach (int i in collection)
            {
                bucket[i - minValue].Add(i);
            }

            int k = collection.Count - 1;
            foreach (List<int> i in bucket)
            {
                if (i.Count > 0)
                {
                    foreach (int j in i)
                    {
                        collection[k] = j;
                        k--;
                    }
                }
            }
        }
    }
}
