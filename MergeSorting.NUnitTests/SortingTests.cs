using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MergeSorting;

namespace MergeSorting.NUnitTests
{
    [TestClass]
    public class SortingTests
    {
        #region Test Method
        [TestMethod]
        public void SortArray_AnyArray_SortedArrayAccordingToTheMax()
        {
            int[] array1 = new[] { 3, 5, 7, 2, 7, 8 };
            int[] result1 = new[] { 2, 3, 5, 7, 7, 8 };

            Sorting.MergeSort(array1);

            CollectionAssert.AreEqual(array1, result1);

        }

        [TestMethod]
        public void SortArray_AnyArray_SortedArrayAccordingToTheMin()
        {
            int[] array1 = { 0, -4, -6, 3 };
            int[] result1 = { 3, 0, -4, -6 };
            Comparison<int> compare = CompareByMin;

            Sorting.MergeSort(array1, compare);

            CollectionAssert.AreEqual(array1, result1);
        }
        #endregion

        #region Test exeption
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortArray_Null_ArgumentNullException()
        {
            Sorting.MergeSort(null);
        }
        #endregion

        #region Private methods
        private int CompareByMin(int a, int b)
        {
            if (a < b)
                return 1;
            else if (a > b)
                return -1;
            else
                return 0;
        }
        #endregion
    }
}



