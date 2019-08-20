using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Sorting
{
    //鸽巢排序（Pigeonhole sort），也被称作基数分类，是一种时间复杂度为O(n)（大O符号）且在不可避免遍历每一个元素并且排序的情况下效率最好的一种排序算法。但它只有在差值（或者可被映射在差值）很小的范围内的数值排序的情况下实用。
    //当涉及到多个不相等的元素，且将这些元素放在同一个"鸽巢"的时候，算法的效率会有所降低。为了简便和保持鸽巢排序在适应不同的情况，比如两个在同一个存储桶中结束的元素必然相等
    /// <summary>
    /// Only support IList<int> Sort
    /// Also called CountSort (not CountingSort)
    /// </summary>
    public static class PigeonHoleSorter
    {
        public static void PigeonHoleSort(this IList<int> collection)
        {
            collection.PigeonHoleSortAscending();
        }

        public static void PigeonHoleSortAscending(this IList<int> collection)
        {
            int min = collection.Min();
            int max = collection.Max();
            int size = max - min + 1;
            int[] holes = new int[size];
            foreach (int x in collection)
            {
                holes[x - min]++;
            }
            
            int i = 0;
            for (int count = 0; count < size; count++)
            {
                while (holes[count]-- > 0)
                {
                    collection[i] = count + min;
                    i++;
                }
            }    
        }

        public static void PigeonHoleSortDescending(this IList<int> collection)
        {
            int min = collection.Min();
            int max = collection.Max();
            int size = max - min + 1;
            int[] holes = new int[size];
            foreach (int x in collection)
            {
                holes[x - min]++;
            }

            int i = 0;
            for (int count = size-1; count >= 0; count--)
            {
                while (holes[count]-- >0)
                {
                    collection[i] = count + min;
                    i++;
                }
            }
        }
    }
}
