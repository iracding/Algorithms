using System.Collections.Generic;
using System.Diagnostics;
using Algorithms.Common;
using Newtonsoft.Json;

namespace Algorithms.Sorting
{
    //快速排序
    //快速排序是一种分治的排序算法，他将一个数组分成两个数组，将两部分独立的排序。
    //快速排序和归并排序是互补的：归并排序是将数组分成两个子数组分别排序，并将有序的子数组归并以将整个数组排序，而快速排序将数组排序的方式是当两个子数组都有序时整个数组也就有序了。
    public static class QuickSorter
    {
        //
        // The public APIs for the quick sort algorithm.
        public static void QuickSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            int startIndex = 0;
            int endIndex = collection.Count - 1;

            //
            // If the comparer is Null, then initialize it using a default typed comparer
            comparer = comparer ?? Comparer<T>.Default;

            collection.InternalQuickSort(startIndex, endIndex, comparer);
        }


        //
        // Private static method
        // The recursive quick sort algorithm
        private static void InternalQuickSort<T>(this IList<T> collection, int leftmostIndex, int rightmostIndex, Comparer<T> comparer)
        {
            //
            // Recursive call check
            if (leftmostIndex < rightmostIndex)
            {
                int wallIndex = collection.InternalPartition(leftmostIndex, rightmostIndex, comparer);
                collection.InternalQuickSort(leftmostIndex, wallIndex - 1, comparer);
                collection.InternalQuickSort(wallIndex + 1, rightmostIndex, comparer);
            }
        }


        //
        // Private static method
        // The partition function, used in the quick sort algorithm
        private static int InternalPartition<T>(this IList<T> collection, int leftmostIndex, int rightmostIndex, Comparer<T> comparer)
        {
            int wallIndex, pivotIndex;

            // Choose the pivot
            pivotIndex = rightmostIndex;
            T pivotValue = collection[pivotIndex];

            // Compare remaining array elements against pivotValue
            wallIndex = leftmostIndex;

            // Loop until pivot: exclusive!
            for (int i = leftmostIndex; i <= (rightmostIndex - 1); i++)
            {
                // check if collection[i] <= pivotValue
                if (comparer.Compare(collection[i], pivotValue) <= 0)
                {
                    collection.Swap(i, wallIndex);
                    wallIndex++;
                }


                Trace.WriteLine(JsonConvert.SerializeObject(collection));
            }

            collection.Swap(wallIndex, pivotIndex);

            return wallIndex;
        }

    }

}

