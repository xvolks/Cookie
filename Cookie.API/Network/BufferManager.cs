using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace Cookie.API.Network
{
    public sealed class BufferManager : IDisposable
    {
        private readonly int _bufferSize;
        private readonly int _numBytes; // the total number of bytes controlled by the buffer pool
        private byte[] _buffer; // the underlying byte array maintained by the Buffer Manager
        private int _currentIndex;
        private Stack<int> _freeIndexPool;

        public BufferManager(int totalBytes, int bufferSize)
        {
            _numBytes = totalBytes;
            _currentIndex = 0;
            _bufferSize = bufferSize;
            _freeIndexPool = new Stack<int>();
        }

        #region IDisposable Members

        public void Dispose()
        {
            _buffer = null;
            _freeIndexPool = null;
        }

        #endregion

        // Allocates buffer space used by the buffer pool
        public void InitializeBuffer()
        {
            // create one big large buffer and divide that 
            // out to each SocketAsyncEventArg object
            _buffer = new byte[_numBytes];
        }

        // Assigns a buffer from the buffer pool to the 
        // specified SocketAsyncEventArgs object
        //
        // <returns>true if the buffer was successfully set, else false</returns>
        public bool SetBuffer(SocketAsyncEventArgs args)
        {
            if (_freeIndexPool.Count > 0)
            {
                args.SetBuffer(_buffer, _freeIndexPool.Pop(), _bufferSize);
            }
            else
            {
                if (_numBytes - _bufferSize < _currentIndex)
                    return false;
                args.SetBuffer(_buffer, _currentIndex, _bufferSize);
                _currentIndex += _bufferSize;
            }
            return true;
        }

        // Removes the buffer from a SocketAsyncEventArg object.  
        // This frees the buffer back to the buffer pool
        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            _freeIndexPool.Push(args.Offset);
            args.SetBuffer(null, 0, 0);
        }
    }
}