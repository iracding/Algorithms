using System.Collections.Generic;
using System.Diagnostics;
using DataStructures.Lists;
using Newtonsoft.Json;

namespace Algorithms.Sorting
{
    //插入排序
    //插入排序（Insertion sort）是一种简单直观且稳定的排序算法。如果有一个已经有序的数据序列，要求在这个已经排好的数据序列中插入一个数，但要求插入后此数据序列仍然有序，
    //这个时候就要用到一种新的排序方法——插入排序法,插入排序的基本操作就是将一个数据插入到已经排好序的有序数据中，从而得到一个新的、个数加一的有序数据，
    //算法适用于少量数据的排序，时间复杂度为O(n^2)。是稳定的排序方法。插入算法把要排序的数组分成两部分：第一部分包含了这个数组的所有元素，但将最后一个元素除外（让数组多一个空间才有插入的位置），
    //而第二部分就只包含这一个元素（即待插入元素）。在第一部分排序完成后，再将这个最后元素插入到已排好序的第一部分中。
    //插入排序的基本思想是：每步将一个待排序的记录，按其关键码值的大小插入前面已经排序的文件中适当位置上，直到全部插入完为止。
    /// <summary>
    /// Implements this Insertion Sort algorithm over ArrayLists.
    /// </summary>
    public static class InsertionSorter
    {
        //
        // The quick insertion sort algorithm.
        // For any collection that implements the IList interface.
        public static void InsertionSort<T>(this IList<T> list, Comparer<T> comparer = null)
        {
            //
            // If the comparer is Null, then initialize it using a default typed comparer
            comparer = comparer ?? Comparer<T>.Default;

            // Do sorting if list is not empty.
            int i, j;
            for (i = 1; i < list.Count; i++)
            {
                T value = list[i];
                j = i - 1;

                while ((j >= 0) && (comparer.Compare(list[j], value) > 0))
                {
                    list[j + 1] = list[j];
                    j--;
                }

                list[j + 1] = value;
                Trace.WriteLine(JsonConvert.SerializeObject(list));
            }
        }


        //
        // The quick insertion sort algorithm.
        // For the internal ArrayList<T>. Check the DataStructures.ArrayList.cs.
        public static void InsertionSort<T>(this ArrayList<T> list, Comparer<T> comparer = null)
        {
            //
            // If the comparer is Null, then initialize it using a default typed comparer
            comparer = comparer ?? Comparer<T>.Default;

            for (int i = 1; i < list.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (comparer.Compare(list[j], list[j - 1]) < 0) //(j)th is less than (j-1)th
                    {
                        var temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }

    }

}

