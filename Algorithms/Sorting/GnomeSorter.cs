using System.Collections.Generic;
using Algorithms.Common;

namespace Algorithms.Sorting
{
    //侏儒排序（Gnome sort或Stupid sort）是一种排序算法，最初由伊朗计算机工程师Hamid Sarbazi-Azad博士（谢里夫理工大学计算机工程教授）于2000年提出并被称为“愚蠢排序”（不是 与bogosort混淆），
    //然后由Dick Grune描述并命名为“gnome sort”。 它是一种类似于插入排序的排序算法，除了将元素移动到适当的位置是通过一系列交换完成的，如冒泡排序。 它在概念上很简单，不需要嵌套循环。 
    //平均或预期的运行时间是O（n2），但如果列表最初几乎排序，则倾向于O（n）
    //Dick Grune用以下故事描述了排序方法：
    //Gnome Sort基于标准Dutch Garden Gnome（Du。：tuinkabouter）使用的技术。
    //以下是花园侏儒如何对一系列花盆进行分类。
    //基本上，他看着旁边的花盆和前一个花盆; 如果他们按照正确的顺序，他会向前迈出一个底池，否则他会将它们交换掉，并向后踩一个底池[1]  。
    //边界条件：如果没有先前的底池，他会前进; 如果他旁边没有锅，他就完成了。
    //- “Gnome Sort - 最简单的排序算法”。Dickgrune.com
    /// <summary>
    /// Also called Stupid Sort
    /// </summary>
    public static class GnomeSorter
    {
        public static void GnomeSort<T>(this IList<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;
            collection.GnomeSortAscending(comparer);
        }

        /// <summary>
        /// Public API: Sorts ascending
        /// </summary>
        public static void GnomeSortAscending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            int pos = 1;
            while (pos < collection.Count)
            {
                if (comparer.Compare(collection[pos], collection[pos - 1]) >= 0)
                {
                    pos++;
                }
                else
                {
                    collection.Swap(pos, pos - 1);
                    if (pos > 1)
                    {
                        pos--;
                    }
                }
            }
        }

        /// <summary>
        /// Public API: Sorts descending
        /// </summary>
        public static void GnomeSortDescending<T>(this IList<T> collection, Comparer<T> comparer)
        {
            int pos = 1;
            while (pos < collection.Count)
            {
                if (comparer.Compare(collection[pos], collection[pos - 1]) <= 0)
                {
                    pos++;
                }
                else
                {
                    collection.Swap(pos, pos - 1);
                    if (pos > 1)
                    {
                        pos--;
                    }
                }
            }
        }
    }
}
