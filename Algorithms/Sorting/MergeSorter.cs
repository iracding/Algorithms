using System.Collections.Generic;
using Algorithms.Common;

namespace Algorithms.Sorting
{
    //归并排序 ,速度仅次于快速排序，为稳定排序算法，一般用于对总体无序，但是各子项相对有序的数列
    //归并排序（MERGE-SORT）是建立在归并操作上的一种有效的排序算法,该算法是采用分治法（Divide and Conquer）的一个非常典型的应用。将已有序的子序列合并，得到完全有序的序列；
    //即先使每个子序列有序，再使子序列段间有序。若将两个有序表合并成一个有序表，称为二路归并
    //归并操作
    //归并操作(merge)，也叫归并算法，指的是将两个顺序序列合并成一个顺序序列的方法。
    //如 设有数列 {6，202，100，301，38，8，1}
    //初始状态：6,202,100,301,38,8,1
    //第一次归并后：{6,202},{100,301},{8,38},{1}，比较次数：3；
    //第二次归并后：{6,100,202,301}，{1,8,38}，比较次数：4；
    //第三次归并后：{1,6,8,38,100,202,301},比较次数：4；
    //总的比较次数为：3+4+4=11；
    //逆序数为14；
    public static class MergeSorter
    {
        //
        // Public merge-sort API
        public static List<T> MergeSort<T>(this List<T> collection, Comparer<T> comparer = null)
        {
            comparer = comparer ?? Comparer<T>.Default;

            return InternalMergeSort(collection, 0, collection.Count - 1, comparer);
        }


        //
        // Private static method
        // Implements the recursive merge-sort algorithm
        private static List<T> InternalMergeSort<T>(List<T> collection, int startIndex, int endIndex, Comparer<T> comparer)
        {
            if (collection.Count < 2)
            {
                return collection;
            }

            if (collection.Count == 2)
            {
                if (comparer.Compare(collection[endIndex], collection[startIndex]) < 0)
                {
                    collection.Swap(endIndex, startIndex);
                }

                return collection;
            }

            int midIndex = collection.Count / 2;

            var leftCollection = collection.GetRange(startIndex, midIndex);
            var rightCollection = collection.GetRange(midIndex, (endIndex - midIndex) + 1);

            leftCollection = InternalMergeSort<T>(leftCollection, 0, leftCollection.Count - 1, comparer);
            rightCollection = InternalMergeSort<T>(rightCollection, 0, rightCollection.Count - 1, comparer);

            return InternalMerge<T>(leftCollection, rightCollection, comparer);
        }


        //
        // Private static method
        // Implements the merge function inside the merge-sort
        private static List<T> InternalMerge<T>(List<T> leftCollection, List<T> rightCollection, Comparer<T> comparer)
        {
            int left = 0;
            int right = 0;
            int index;
            int length = leftCollection.Count + rightCollection.Count;

            List<T> result = new List<T>(length);

            for (index = 0; index < length; ++index)
            {
                if (right < rightCollection.Count && comparer.Compare(rightCollection[right], leftCollection[left]) <= 0) // rightElement <= leftElement
                {
                    //resultArray.Add(rightCollection[right]);
                    result.Insert(index, rightCollection[right]);
                    right++;
                }
                else
                {
                    //result.Add(leftCollection[left]);
                    result.Insert(index, leftCollection[left]);
                    left++;

                    if (left == leftCollection.Count)
                        break;
                }
            }

            //
            // Either one might have elements left
            int rIndex = index + 1;
            int lIndex = index + 1;

            while (right < rightCollection.Count)
            {
                result.Insert(rIndex, rightCollection[right]);
                rIndex++;
                right++;
            }

            while (left < leftCollection.Count)
            {
                result.Insert(lIndex, leftCollection[left]);
                lIndex++;
                left++;
            }

            return result;
        }
    }
}

