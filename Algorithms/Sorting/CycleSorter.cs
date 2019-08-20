using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithms.Sorting
{
    //从n个不同元素中不重复地取出m（1≤m≤n）个元素在一个圆周上，叫做这n个不同元素的圆排列。如果一个m-圆排列旋转可以得到另一个m-圆排列，则认为这两个圆排列相同。
    public static class CycleSorter
    {

        public static void CycleSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.CycleSortAscending(comparer);
        }
        public static void CycleSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            for (int cycleStart = 0; cycleStart < collection.Count; cycleStart++)
            {
                T item = collection[cycleStart];
                int position = cycleStart;

                do
                {
                    int to = 0;
                    for (int i = 0; i < collection.Count; i++)
                    {
                        if (i != cycleStart && comparer.Compare(collection[i], item) < 0)
                        {
                            to++;
                        }
                    }
                    if (position != to)
                    {
                        while (position != to && comparer.Compare(item, collection[to]) == 0)
                        {
                            to++;
                        }

                        T temp = collection[to];
                        collection[to] = item;
                        item = temp;
                        position = to;
                    }
                } while (position != cycleStart);
            }
            Trace.WriteLine(JsonConvert.SerializeObject(collection));
        }
        public static void CycleSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            for (int cycleStart = 0; cycleStart < collection.Count; cycleStart++)
            {
                T item = collection[cycleStart];
                int position = cycleStart;

                do
                {
                    int to = 0;
                    for (int i = 0; i < collection.Count; i++)
                    {
                        if (i != cycleStart && comparer.Compare(collection[i], item) > 0)
                        {
                            to++;
                        }
                    }
                    if (position != to)
                    {
                        while (position != to && comparer.Compare(item, collection[to]) == 0)
                        {
                            to++;
                        }

                        T temp = collection[to];
                        collection[to] = item;
                        item = temp;
                        position = to;
                    }
                } while (position != cycleStart);
            }
            Trace.WriteLine(JsonConvert.SerializeObject(collection));
        }

    
    }
}
