using System.Collections.Generic;
using System.Diagnostics;
using Algorithms.Common;
using Newtonsoft.Json;

namespace Algorithms.Sorting
{
    //梳排序（Comb sort）是一种由Wlodzimierz Dobosiewicz于1980年所发明的不稳定排序算法，并由Stephen Lacey和Richard Box于1991年四月号的Byte杂志中推广。梳排序是改良自泡沫排序和快速排序，其要旨在于消除乌龟，
    //亦即在数组尾部的小数值，这些数值是造成泡沫排序缓慢的主因。相对地，兔子，亦即在数组前端的大数值，不影响泡沫排序的性能。
    //在泡沫排序中，只比较数组中相邻的二项，即比较的二项的间距（Gap）是1，梳排序提出此间距其实可大于1，改自插入排序的希尔排序同样提出相同观点。梳排序中，开始时的间距设置为数组长度，
    //并在循环中以固定比率递减，通常递减率设置为1.3。在一次循环中，梳排序如同泡沫排序一样把数组从首到尾扫描一次，比较及交换两项，不同的是两项的间距不固定于1。如果间距递减至1，梳排序假定输入数组大致排序好，
    //并以泡沫排序作最后检查及修正。 [1]
    public static class CombSorter
    {
        public static void CombSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.CombSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void CombSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            double gap = collection.Count;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < collection.Count)
                {
                    int igap = i + (int)gap;
                    if (comparer.Compare(collection[i], collection[igap])>0)
                    {
                        collection.Swap(i,igap);
                        swaps = true;
                    }
                    i++;
                }
            }
            Trace.WriteLine(JsonConvert.SerializeObject(collection));
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void CombSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            double gap = collection.Count;
            bool swaps = true;
            while (gap > 1 || swaps)
            {
                gap /= 1.247330950103979;
                if (gap < 1) { gap = 1; }
                int i = 0;
                swaps = false;
                while (i + gap < collection.Count)
                {
                    int igap = i + (int)gap;
                    if (comparer.Compare(collection[i], collection[igap]) < 0)
                    {
                        collection.Swap(i, igap);
                        swaps = true;
                    }
                    i++;
                }
            }
        }
    }
}
