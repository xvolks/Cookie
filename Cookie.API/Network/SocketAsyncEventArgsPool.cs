using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Cookie.API.Network
{
    public sealed class SocketAsyncEventArgsPool : IDisposable
    {
        private readonly Stack<SocketAsyncEventArgs> _pool;
        private bool _disposed;

        public SocketAsyncEventArgsPool(int capacity)
        {
            _pool = new Stack<SocketAsyncEventArgs>(capacity);
        }

        /// <summary>
        ///     Gets the number of SocketAsyncEventArgs instances in the pool
        /// </summary>
        public int Count => _pool.Count;

        #region IDisposable Members

        public void Dispose()
        {
            _pool.Clear();
            _disposed = true;
        }

        #endregion

        public void Push(SocketAsyncEventArgs item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            lock (_pool)
            {
                _pool.Push(item);
            }
        }

        public SocketAsyncEventArgs Pop()
        {
            if (_disposed)
                throw new ObjectDisposedException("SocketAsyncEventArgsPool");

            lock (_pool)
            {
                return _pool.Pop();
            }
        }
    }
}