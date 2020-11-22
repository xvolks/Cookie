using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

namespace Cookie.API.Utils.Extensions
{
    internal class SingleLinkNode<T>
    {
        public T Item;
        public SingleLinkNode<T> Next;
    }

    public class LockFreeQueue<T> : IEnumerable<T>
    {
        private int _count;
        private SingleLinkNode<T> _head;
        private SingleLinkNode<T> _tail;

        /// <summary>
        ///     Default constructor.
        /// </summary>
        public LockFreeQueue()
        {
            _head = new SingleLinkNode<T>();
            _tail = _head;
        }

        public LockFreeQueue(IEnumerable<T> items)
            : this()
        {
            foreach (var item in items)
                Enqueue(item);
        }

        /// <summary>
        ///     Gets the number of elements contained in the queue.
        /// </summary>
        public int Count => Thread.VolatileRead(ref _count);

        #region IEnumerable<T> Members

        /// <summary>
        ///     Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>an enumerator for the queue</returns>
        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = _head;

            do
            {
                if (currentNode.Item == null)
                    yield break;
                yield return currentNode.Item;
            } while ((currentNode = currentNode.Next) != null);
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        ///     Returns an enumerator that iterates through the queue.
        /// </summary>
        /// <returns>an enumerator for the queue</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        /// <summary>
        ///     Adds an object to the end of the queue.
        /// </summary>
        /// <param name="item">the object to add to the queue</param>
        public void Enqueue(T item)
        {
            SingleLinkNode<T> oldTail = null;

            var newNode = new SingleLinkNode<T> {Item = item};

            var newNodeWasAdded = false;

            while (!newNodeWasAdded)
            {
                oldTail = _tail;
                var oldTailNext = oldTail.Next;

                if (_tail == oldTail)
                    if (oldTailNext == null)
                        newNodeWasAdded =
                            Interlocked.CompareExchange(ref _tail.Next, newNode, null) == null;
                    else
                        Interlocked.CompareExchange(ref _tail, oldTailNext, oldTail);
            }

            Interlocked.CompareExchange(ref _tail, newNode, oldTail);
            Interlocked.Increment(ref _count);
        }

        public T TryDequeue()
        {
            T item;
            TryDequeue(out item);
            return item;
        }

        /// <summary>
        ///     Removes and returns the object at the beginning of the queue.
        /// </summary>
        /// <param name="item">
        ///     when the method returns, contains the object removed from the beginning of the queue,
        ///     if the queue is not empty; otherwise it is the default value for the element type
        /// </param>
        /// <returns>
        ///     true if an object from removed from the beginning of the queue;
        ///     false if the queue is empty
        /// </returns>
        public bool TryDequeue(out T item)
        {
            item = default(T);
            SingleLinkNode<T> oldHead = null;

            var haveAdvancedHead = false;
            while (!haveAdvancedHead)
            {
                oldHead = _head;
                var oldTail = _tail;
                var oldHeadNext = oldHead.Next;

                if (oldHead == _head)
                    if (oldHead == oldTail)
                    {
                        if (oldHeadNext == null)
                            return false;

                        Interlocked.CompareExchange(ref _tail, oldHeadNext, oldTail);
                    }

                    else
                    {
                        item = oldHeadNext.Item;
                        haveAdvancedHead =
                            Interlocked.CompareExchange(ref _head, oldHeadNext, oldHead) == oldHead;
                    }
            }

            Interlocked.Decrement(ref _count);
            return true;
        }

        /// <summary>
        ///     Removes and returns the object at the beginning of the queue.
        /// </summary>
        /// <returns>the object that is removed from the beginning of the queue</returns>
        public T Dequeue()
        {
            T result;

            if (!TryDequeue(out result))
                throw new InvalidOperationException("the queue is empty");

            return result;
        }

        /// <summary>
        ///     Clears the queue.
        /// </summary>
        /// <remarks>This method is not thread-safe.</remarks>
        public void Clear()
        {
            var currentNode = _head;

            while (currentNode != null)
            {
                var tempNode = currentNode;
                currentNode = currentNode.Next;

                tempNode.Item = default(T);
                tempNode.Next = null;
            }

            _head = new SingleLinkNode<T>();
            _tail = _head;
            _count = 0;
        }
    }
}