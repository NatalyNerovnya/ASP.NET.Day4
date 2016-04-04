using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using CustomQueue;

namespace CustomQueue.NUnitTests
{
    public class CustomQueueTests
    {
        #region EnqueueTests
        #region Properties
        public IEnumerable<TestCaseData> ObjectEnqueuElemData
        {
            get
            {
                yield return new TestCaseData
                    (new object[] { new List<object>(), "Good day!"}, 13,
                        new CustomQueue<object>(new List<object>(), "Good day!", 13) )
                    .Returns(true);
            }
        }
        public IEnumerable<TestCaseData> StructEnqueuElemData
        {
            get
            {
                yield return new TestCaseData
                    (new int[] { 1,2,3}, 13,
                        new CustomQueue<int>(1,2,3,13)).Returns(true);
            }
        }
        #endregion

        #region Methods
        [Test, TestCaseSource(nameof(ObjectEnqueuElemData))]
        public bool EnqueueElemTest(object[] arr, object elem, CustomQueue<object> expectedQueue )
        {
            CustomQueue<object> queue = new CustomQueue<object>(arr);
            queue.Enqueue(elem);
            return Same(queue, expectedQueue);
        }

        [Test, TestCaseSource(nameof(StructEnqueuElemData))]
        public bool EnqueueElemTest(int[] arr, int elem, CustomQueue<int> expectedQueue)
        {
            CustomQueue<int> queue = new CustomQueue<int>(arr);
            queue.Enqueue(elem);
            return Same(queue, expectedQueue);
        }
        #endregion
        #endregion

        #region Dequeue tests
        public IEnumerable<TestCaseData> ObjectDequeuElemData
        {
            get
            {
                yield return new TestCaseData
                    (new object[] { new List<object>(), "Good day!", 13},
                        new CustomQueue<object>("Good day!", 13) )
                    .Returns(true);
            }
        }

        public IEnumerable<TestCaseData> StructDequeuElemData
        {
            get
            {
                yield return new TestCaseData
                    (new int[] { 1, 2, 3, 13 },
                        new CustomQueue<int>(2, 3, 13))
                    .Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(ObjectDequeuElemData))]
        public bool DequeueElemTest(object[] arr, CustomQueue<object> expectedQueue)
        {
            CustomQueue<object> queue = new CustomQueue<object>(arr);
            queue.Dequeue();
            return Same(queue, expectedQueue);
        }



        [Test, TestCaseSource(nameof(StructDequeuElemData))]
        public bool DequeueElemTest(int[] arr, CustomQueue<int> expectedQueue)
        {
            CustomQueue<int> queue = new CustomQueue<int>(arr);
            queue.Dequeue();
            return Same(queue, expectedQueue);
        }
        #endregion

        #region Contain tests

        public IEnumerable<TestCaseData> ContainElementData
        {
            get
            {
                yield return new TestCaseData(new CustomQueue<object>(1,"Tests"), "Tests" ).Returns(true);
            }
        }

        [Test, TestCaseSource(nameof(ContainElementData))]
        public bool ContainElement(CustomQueue<object> queue, object elem)
        {
            return queue.Contain(elem);
        }

        #endregion

        #region Private methods
        private static bool Same<T>(CustomQueue<T> queue1, CustomQueue<T> queue2) 
        {
            foreach (var variable in queue1)
            {
                if (queue1.Peek().GetType() != queue2.Peek().GetType() && !queue1.Dequeue().Equals(queue2.Dequeue()))
                {
                    return false;
                }
            }
            return true;
        }
#endregion
    }




}
