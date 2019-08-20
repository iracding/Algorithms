using System;
using System.Collections.Generic;

namespace Algorithms.Sorting
{
    //基数排序是按照低位先排序，然后收集；再按照高位排序，然后再次收集；依次类推，直到最高位。有时候有些属性是有优先级顺序，先按照低优先级排序，再按照高优先级排序。最后的次序就是高优先级的在前，高优先级相同的低优先级高的在前。

    //算法描述：
    //取得数组中的最大数，并取得位数；
    //Arrays为原始数组，从低位开始取到每个位组成radix数组；
    //对redix进行计数排序（利用计数排序适用于小范围数的特点）

    /// <summary>
    /// LSD (Least Significat Digit) Radix Sort.
    ///
    /// Sorts ASCII-encoded strings.
    /// Implemented as a static class of extension methods.
    /// </summary>
    public static class LSDRadixSorter
    {
        /// <summary>
        /// Extension method for sorting strings.
        /// </summary>
        public static string LSDRadixSort(this string source)
        {
            if (string.IsNullOrEmpty(source) || source.Length <= 1)
                return source;

            // LSD Radix Sort the character arrapy representation of the string
            var charArray = source.ToCharArray();
            charArray.LSDRadixSort();

            return new String(charArray);
        }


        /// <summary>
        /// Extension method for sorting character arrays, in place.
        /// </summary>
        public static void LSDRadixSort(this char[] source)
        {
            if (source == null || source.Length <= 1)
                return;

            // extend ASCII alphabet size
            int asciiSize = 256;

            int length = source.Length;
            char[] auxiliary = new char[length];

            // compute frequency counts
            int[] count = new int[asciiSize + 1];

            for (int i = 0; i < length; i++)
                count[source[i] + 1]++;

            // compute cumulates
            for (int r = 0; r < asciiSize; r++)
                count[r + 1] += count[r];

            // move data
            for (int i = 0; i < length; i++)
                auxiliary[count[source[i]]++] = source[i];

            // copy back
            for (int i = 0; i < length; i++)
                source[i] = auxiliary[i];
        }


        /// <summary>
        /// Extension method for sorting collections of strings of the same width, in place.
        /// </summary>
        public static void LSDRadixSort(this IList<String> collection, int stringFixedWidth)
        {
            // Validate input
            if (collection == null || collection.Count <= 1)
                return;
            for (int i = 0; i < collection.Count; ++i)
                if (collection[i] == null || collection[i].Length != stringFixedWidth)
                    throw new InvalidOperationException("Not all strings have the same width");

            // extend ASCII alphabet size
            int asciiSize = 256;

            int stringsCount = collection.Count;
            string[] auxiliary = new string[stringsCount];

            for (int d = stringFixedWidth - 1; d >= 0; d--)
            {
                // compute frequency counts
                int[] count = new int[asciiSize + 1];

                for (int i = 0; i < stringsCount; i++)
                    count[collection[i][d] + 1]++;

                // compute cumulates
                for (int r = 0; r < asciiSize; r++)
                    count[r + 1] += count[r];

                // move data
                for (int i = 0; i < stringsCount; i++)
                    auxiliary[count[collection[i][d]]++] = collection[i];

                // copy back
                for (int i = 0; i < stringsCount; i++)
                    collection[i] = auxiliary[i];
            }
        }
    }
}
