using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    /// <summary>
    /// Custom queu
    /// </summary>
    /// <typeparam name="T">Any type</typeparam>
    public class CustomQueue<T> : IEnumerable<T>
    {
        #region Fields
        private T[] queue;
        private int capacity, head, tail;
        private static readonly int defaultCapacity = 8;
        #endregion

        #region Constructors
        /// <summary>
        /// Special constructor
        /// </summary>
        public CustomQueue() : this(defaultCapacity) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="n">The length of queue</param>
        public CustomQueue(int n)
        {
            if (n > 0)
            {
                queue = new T[n];
                capacity = n;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
            head = 0;
            tail = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arr">array of values</param>
        public CustomQueue(params T[] arr)
            : this((IEnumerable<T>)arr)
        { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="arr">Array of elements</param>
        public CustomQueue(IEnumerable<T> arr)
    : this(arr.ToArray().Length)
        {
            if (arr == null)
                return;
            Array.Copy(arr.ToArray(), queue, capacity);
            tail = capacity - 1;
        }

        #endregion

        #region Public Methods
        /// <summary>
        /// Add element to the tail of queue
        /// </summary>
        /// <param name="element">element</param>
        public void Enqueue(T element)
        {
            if ((tail + 1) % capacity == head % capacity)
            {
                Extend();
                queue[capacity] = element;
                tail = capacity;
                head = 0;
                capacity *= 2;
            }
            else
            {
                queue[++tail % capacity] = element;
                tail = tail % capacity;
            }

        }

        /// <summary>
        /// Return the element from the head of the queue and delete it 
        /// </summary>
        /// <returns>The first  element</returns>
        public T Dequeue()
        {
            if (IsEmpty())
                throw new ArgumentException();

            T returnValue = Peek();
            DeleteHead();
            return returnValue;
        }

        /// <summary>
        /// Return first element
        /// </summary>
        /// <returns>First element</returns>
        public T Peek()
        {
            if (IsEmpty())
                throw new ArgumentException();
            return queue[head];
        }

        /// <summary>
        /// Delete all elements from the queue
        /// </summary>
        public void Clear()
        {
            for (int i = head, j = 0; j < capacity; j++)
            {
                //queue[i] = null;
                i = ++i % capacity;
            }
            head = tail = 0;
        }

        /// <summary>
        /// Does the queue contain the element?
        /// </summary>
        /// <param name="str">element</param>
        /// <returns>True, if the queue contains the element</returns>
        public bool Contain(T str)
        {
            foreach (var variable in queue)
            {
                if (variable.Equals(str))
                    return true;
            }
            return false;
        }

        #endregion

        #region Interface implementation

        public IEnumerator<T> GetEnumerator()
        {
            return new QueueIterator<T>(queue, tail, head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
        
        #region Private Methods
        /// <summary>
        /// Extend capacity in 2 times
        /// </summary>
        private void Extend()
        {
            T[] wideQueue = new T[capacity * 2];

            for (int i = head, j = 0; j < capacity; j++)
            {
                wideQueue[j] = queue[i];
                i = ++i % capacity;
            }
            queue = wideQueue;
        }

        /// <summary>
        /// Delete head
        /// </summary>
        private void DeleteHead()
        {
            //queue[head] = null;
            head = ++head % capacity;
        }

        /// <summary>
        /// Check weather the queue is empty
        /// </summary>
        /// <returns>True, if the queue ie empty</returns>
        private bool IsEmpty()
        {
            return tail % capacity == head % capacity;
        }

        #endregion
    }
}
