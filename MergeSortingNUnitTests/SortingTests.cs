using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MergeSorting;

namespace MergeSortingNUnitTests
{
    public class SortingTests
    {
        #region Properties
        public IEnumerable<TestCaseData> DefaultTestData
        {
            get
            {
                yield return new TestCaseData(new[] { 9, 4, 0, 2, 3, 1 }, new[] { 0, 1, 2, 3, 4, 9 }).Returns(true);
                yield return new TestCaseData(new[] {11}, new[] {11}).Returns(true);
            }
        }

        public IEnumerable<TestCaseData> ExexptionTestData
        {
            get
            {
                Comparison<int> comparer = Comparer<int>.Default.Compare;
                yield return new TestCaseData(null, comparer).Throws(typeof(ArgumentNullException));
            }
        }
        #endregion

        #region Public Methods
        [Test, TestCaseSource(nameof(ExexptionTestData))]
        public void SortDefaultTest(int[] arr, Comparison<int> comparer )
        {
            Sorting.MergeSort(arr, comparer);
        }

        [Test, TestCaseSource(nameof(DefaultTestData))]
        public bool SortDefaultTest(int[] actual, int[] expected)
        {
            Sorting.MergeSort(actual);
            return CompareArrays(actual, expected);
        }

        #endregion

        #region Private Methods
        private bool CompareArrays(int[] arr1, int[] arr2)
        {

            if (arr1.Length != arr2.Length)
                return false;
            bool equal = true;

            for (int i = 0; i < arr1.GetLength(0); i++)
            {
                if (arr1[i].CompareTo(arr2[i]) != 0)
                {
                    equal = false;
                    break;
                }
            }
            return equal;
        }
        #endregion
    }

}
