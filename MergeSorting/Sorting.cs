using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSorting
{
    /// <summary>
    /// Merge sorting of integer array
    /// </summary>
    public class Sorting
    {
        #region Public Methods
        /// <summary>
        /// Sort array (increase)
        /// </summary>
        /// <param name="array"></param>
        public static void MergeSort(int[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            MergeSort(array, 0, array.Length - 1, null);
        }

        /// <summary>
        /// Sort array according to customer comparer
        /// </summary>
        /// <param name="array"></param>
        /// <param name="compare">Comparision</param>
        public static void MergeSort(int[] array, Comparison<int> compare)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (compare == null)
                MergeSort(array, 0, array.Length - 1, null);
            else
                MergeSort(array, 0, array.Length - 1, compare);
        }

        /// <summary>
        /// Sort array according to customer comparer
        /// </summary>
        /// <param name="array"></param>
        /// <param name="compare">IComparer</param>
        public static void MergeSort(int[] array, IComparer<int> compare)
        {
            if(array == null)
                throw new ArgumentNullException();
            if (compare == null)
                MergeSort(array, 0, array.Length - 1, null);
            else
                MergeSort(array, 0, array.Length - 1, compare.Compare);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Sort array with Merge Sort
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="first">Index of first element</param>
        /// <param name="last">Index of last element</param>
        /// <param name="compare">Comparison</param>
        private static void MergeSort(int[] array, int first, int last, Comparison<int> compare)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (first == last)
                return;
            if (first > last || first < 0 || last < 0)
                throw new ArgumentException();
            if (compare == null)
            {
                compare = Comparer<int>.Default.Compare;
            }

            int middle = (last + first - 1) / 2;
            MergeSort(array, first, middle, compare);
            MergeSort(array, middle + 1, last, compare);
            Merge(array, first, middle, last, compare);

        }

        /// <summary>
        /// Sort array from first elemnt to last
        /// </summary>
        /// <param name="array">Array</param>
        /// <param name="first">Index of first element</param>
        /// <param name="middle">Index of middle element</param>
        /// <param name="last">Index of last element</param>
        /// <param name="compare">Comparison</param>
        private static void Merge(int[] array, int first, int middle, int last, Comparison<int> compare)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (first > last || first < 0 || last < 0 || first > middle || middle < 0)
                throw new ArgumentException();
            if (compare == null)
            {
                compare = Comparer<int>.Default.Compare;
            }

            int[] mergedArray = new int[last - first + 1];
            for (int i = first, j = middle + 1, k = 0; k < mergedArray.Length; k++)
            {
                if (i > middle || j > last)
                    mergedArray[k] = i > middle ? array[j++] : array[i++];
                else
                    mergedArray[k] = compare(array[i], array[j]) < 0 ? array[i++] : array[j++];
            }

            Array.Copy(mergedArray, 0, array, first, mergedArray.Length);
        }

        #endregion
    }
}
