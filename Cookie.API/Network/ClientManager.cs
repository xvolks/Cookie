using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cookie.API.Network
{
    public class ClientManager<T>
        where T : class, IClient
    {
        public delegate T ClientCreationHandler(Socket socket);

        public const int MaxConcurrentConnections = 1000;
        public const int BufferSize = 8192;

        private readonly SocketAsyncEventArgs _acceptArgs = new SocketAsyncEventArgs()
            ; // async arg used on client connection

        private readonly ClientCreationHandler _clientCreationDelegate;

        private readonly List<T> _clients = new List<T>();

        private readonly IPEndPoint _endPoint;

        private readonly Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
            ProtocolType.Tcp);

        private BufferManager _bufferManager
            ; // allocate memory dedicated to a client to avoid memory alloc on each send/recv

        private SemaphoreSlim _semaphore; // limit the number of threads accessing to a ressource

        public ClientManager(IPEndPoint endPoint, ClientCreationHandler clientCreationDelegate)
        {
            _endPoint = endPoint;
            _clientCreationDelegate = clientCreationDelegate;

            Initialize();
        }

        /// <summary>
        ///     List of connected Clients
        /// </summary>
        public ReadOnlyCollection<T> Clients => _clients.AsReadOnly();

        public int Count => _clients.Count;

        public bool Running { get; private set; }

        private void Initialize()
        {
            // init buffer manager
            _bufferManager = new BufferManager(MaxConcurrentConnections * BufferSize, BufferSize);
            _bufferManager.InitializeBuffer();

            // init semaphore
            _semaphore = new SemaphoreSlim(MaxConcurrentConnections, MaxConcurrentConnections);
            _acceptArgs.Completed += (sender, e) => ProcessAccept(e);
        }

        public void Start()
        {
            if (Running)
                return;

            Running = true;

            _socket.Bind(_endPoint);
            _socket.Listen(MaxConcurrentConnections);

            StartAccept();
        }

        public void Stop()
        {
            if (!Running)
                return;

            Running = false;

            lock (_clients)
            {
                foreach (var client in _clients)
                    client.Disconnect();
            }

            _semaphore = new SemaphoreSlim(MaxConcurrentConnections, MaxConcurrentConnections);

            lock (_clients)
            {
                _clients.Clear();
            }
            _socket.Close();
        }

        private void StartAccept()
        {
            _acceptArgs.AcceptSocket = null;

            // thread block if the max connections limit is reached
            _semaphore.Wait();

            if (!Running)
                return;

            // raise or not the event depending on AcceptAsync return
            if (!_socket.AcceptAsync(_acceptArgs))
                ProcessAccept(_acceptArgs);
        }

        private void ProcessAccept(SocketAsyncEventArgs e)
        {
            if (!Running)
                return;

            T client = null;
            try
            {
                // use a async arg from the pool avoid to re-allocate memory on each connection
                var args = new SocketAsyncEventArgs();
                args.Completed += OnReceiveCompleted;

                _bufferManager.SetBuffer(args);

                // create the client instance
                client = _clientCreationDelegate(e.AcceptSocket);
                args.UserToken = client;

                lock (_clients)
                {
                    _clients.Add(client);
                }

                OnClientConnected(client);

                // if the event is not raised we first check new connections before parsing message that can blocks the connection queue
                if (!e.AcceptSocket.ReceiveAsync(args))
                {
                    StartAccept();
                    ProcessReceive(args);
                }
                else
                {
                    StartAccept();
                }
            }
            catch (Exception)
            {
                client?.Disconnect();

                StartAccept();
            }
        }

        private void OnReceiveCompleted(object sender, SocketAsyncEventArgs e)
        {
            try
            {
                switch (e.LastOperation)
                {
                    case SocketAsyncOperation.Receive:
                        ProcessReceive(e);
                        break;
                    case SocketAsyncOperation.Disconnect:
                        CloseClientSocket(e);
                        break;
                }
            }
            catch (Exception)
            {
                // theoretically it shouldn't go up to there.
                //logger.Error("Last chance exception on receiving ! : " + exception);
            }
        }

        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (!Running)
                return;

            if (e.BytesTransferred <= 0 || e.SocketError != SocketError.Success)
            {
                CloseClientSocket(e);
                return;
            }

            var client = e.UserToken as Client;

            if (client == null)
            {
                CloseClientSocket(e);
                return;
            }

            client.Receive(e.Buffer, e.Offset, e.BytesTransferred);

            if (client.Socket == null)
            {
                CloseClientSocket(e);
                return;
            }

            // just continue to receive
            var willRaiseEvent = client.Socket.ReceiveAsync(e);

            if (!willRaiseEvent)
                ProcessReceive(e);
        }

        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            var client = e.UserToken as T;

            if (client == null)
            {
                e.Dispose();
                return;
            }

            try
            {
                client.Disconnect();
            }
            finally
            {
                var removed = false;
                lock (_clients)
                {
                    removed = _clients.Remove(client);
                }

                if (removed)
                {
                    OnClientDisconnected(client);
                    _semaphore.Release();
                }

                e.Dispose();
            }
        }

        #region Events

        public event Action<T> ClientConnected;

        private void OnClientConnected(T client)
        {
            var handler = ClientConnected;
            handler?.Invoke(client);
        }

        public event Action<T> ClientDisconnected;

        private void OnClientDisconnected(T client)
        {
            var handler = ClientDisconnected;
            handler?.Invoke(client);
        }

        #endregion
    }
}