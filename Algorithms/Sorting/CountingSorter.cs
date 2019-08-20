using System;
using System.Collections.Generic;
using System.Diagnostics;
using Algorithms.Common;
using Newtonsoft.Json;
namespace Algorithms.Sorting
{
    //计数排序
    //计数排序是一种非比较性质的排序算法，元素从未排序状态变为已排序状态的过程，是由额外空间的辅助和元素本身的值决定的。计数排序过程中不存在元素之间的比较和交换操作，根据元素本身的值，将每个元素出现的次数记录到辅助空间后，通过对辅助空间内数据的计算，即可确定每一个元素最终的位置。
    //根据待排序集合中最大元素和最小元素的差值范围，申请额外空间；
    //遍历待排序集合，将每一个元素出现的次数记录到元素值对应的额外空间内；
    //对额外空间内数据进行计算，得出每一个元素的正确位置；
    //将待排序集合每一个元素移动到计算得出的正确位置上。
    // 计数排序对输入的数据有附加的限制条件：
    //1、输入的线性表的元素属于有限偏序集S；
    //2、设输入的线性表的长度为n，|S|=k（表示集合S中元素的总数目为k），则k=O(n)。
    //在这两个条件下，计数排序的复杂性为O(n)。
    //计数排序的基本思想是对于给定的输入序列中的每一个元素x，确定该序列中值小于x的元素的个数（此处并非比较各元素的大小，而是通过对元素值的计数和计数值的累加来确定）。
    //  一旦有了这个信息，就可以将x直接存放到最终的输出序列的正确位置上。例如，如果输入序列中只有17个元素的值小于x的值，则x可以直接存放在输出序列的第18个位置上。
    // 当然，如果有多个元素具有相同的值时，我们不能将这些元素放在输出序列的同一个位置上，因此，上述方案还要作适当的修改
    public static class CountingSorter
    {
        public static void CountingSort(this IList<int> collection)
        {
            if (collection == null || collection.Count == 0)
                return;

            // Get the maximum number in array.
            int maxK = 0;
            int index = 0;
            while (true)
            {
                if (index >= collection.Count)
                    break;

                maxK = Math.Max(maxK, collection[index] + 1);
                index++;
            }

            // The array of keys, used to sort the original array.
            int[] keys = new int[maxK];
            keys.Populate(0); // populate it with zeros

            // Assign the keys
            for (int i = 0; i < collection.Count; ++i)
            {
                keys[collection[i]] += 1;
            }

            // Reset index.
            index = 0;

            // Sort the elements
            for (int j = 0; j < keys.Length; ++j)
            {
                var val = keys[j];

                if (val > 0)
                {
                    while (val-- > 0)
                    {
                        collection[index] = j;
                        index++;
                    }
                }
            }
            Trace.WriteLine(JsonConvert.SerializeObject(collection));
        }
    }
}
