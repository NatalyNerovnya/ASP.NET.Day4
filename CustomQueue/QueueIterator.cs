using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    /// <summary>
    /// Custom iterator
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    class QueueIterator<T> : IEnumerator<T>
    {
        #region Fields
        private T[] array;
        private int position;
        private readonly int tailPosition, headPosition;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="list">Array of elements</param>
        /// <param name="tail">Index of last element</param>
        /// <param name="head">Index of first element</param>
        public QueueIterator(T[] list, int tail, int head)
        {
            array = list;
            position = (head - 1) % list.Length;
            tailPosition = tail;
            headPosition = head;
        }
        #endregion

        #region Implementation of IEnumerator<T> methods
        /// <summary>
        /// Go to the next position
        /// </summary>
        /// <returns>False, if collection is finished</returns>
        public bool MoveNext()
        {
            if (position == tailPosition)
            {
                Reset();
                return false;
            }
            position = ++position % array.Length;
            return true;
        }

        /// <summary>
        /// Set index to the pre-begin
        /// </summary>
        public void Reset()
        {
            position = (headPosition - 1) % array.Length;
        }

        /// <summary>
        /// Return current element
        /// </summary>
        object IEnumerator.Current
        {
            get { return array[position]; }
        }

        public void Dispose()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Return current element
        /// </summary>
        public T Current
        {
            get { return array[position]; }
        }
        #endregion
    }
}
