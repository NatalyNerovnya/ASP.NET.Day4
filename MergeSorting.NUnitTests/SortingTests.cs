using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MergeSorting;

namespace MergeSorting.NUnitTests
{
    [TestClass]
    public class SortingTests
    {
        [TestMethod]
        public void SortArray_AnyArray_SortedArrayAccordingToTheSum()
        {
            int[] array1 = new[] {3, 5, 7, 2, 7, 8};
            int[] array2 = new[] {4};
            int[] array3 = {0, -4, -6, 3};

            int[] result1 = new[] {2, 3, 5, 7, 7, 8};
            int[] result2 = new[] {4};
            int[] result3 = {-6, -4, 0, 3};

            Sorting.MergeSort(array1);
            Sorting.MergeSort(array2);
            Sorting.MergeSort(array3);

            CollectionAssert.AreEqual(array1, result1);
            CollectionAssert.AreEqual(array2, result2);
            CollectionAssert.AreEqual(array3, result3);

        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SortArray_Null_ArgumentNullException()
        {
            Sorting.MergeSort(null);
        }
    }
}



