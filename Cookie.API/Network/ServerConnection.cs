using System;
using System.ComponentModel;
using System.Net.Sockets;
using Cookie.API.Protocol;
using Cookie.API.Utils.IO;

namespace Cookie.API.Network
{
    public class ServerConnection : IClient, INotifyPropertyChanged
    {
        private readonly byte[] _buffer = new byte[8192];
        private readonly object _recvLocker = new object();
        private MessagePart _currentMessage;
        private BigEndianReader buffer = new BigEndianReader();

        public ServerConnection(IMessageBuilder messageBuilder)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            MessageBuilder = messageBuilder;
        }

        public Socket Socket { get; private set; }

        public bool IsConnected => Socket != null && Socket.Connected;

        public string Ip => $"{Host}:{Port}";

        public int Port { get; private set; }

        public string Host { get; private set; }


        /// <summary>
        ///     Last activity as a socket client (since last packet received sent )
        /// </summary>
        public DateTime LastActivity { get; private set; }

        public IMessageBuilder MessageBuilder { get; }

        /// <summary>
        ///     True whenever the server has sent at least one packet
        /// </summary>
        public bool IsResponding { get; private set; }

        /// <summary>
        ///     Disconnect the Client
        /// </summary>
        public void Disconnect()
        {
            if (IsConnected)
                Close();

            OnClientDisconnected();
        }

        public void Send(NetworkMessage message)
        {
            lock (this)
            {
                if (!IsConnected)
                    return;

                var args = new SocketAsyncEventArgs();
                args.Completed += OnSendCompleted;
                args.UserToken = message;

                byte[] data;
                using (var writer = new BigEndianWriter())
                {
                    message.Pack(writer);
                    data = writer.Data;
                }

                args.SetBuffer(data, 0, data.Length);

                if (!Socket.SendAsync(args))
                {
                    OnMessageSended(message);
                    args.Dispose();
                }

                LastActivity = DateTime.Now;
            }
        }

        public virtual void Receive(byte[] data, int offset, int count)
        {
            lock (_recvLocker)
            {
                buffer.Add(data, offset, count);

                while (buffer.BytesAvailable > 0)
                {
                    if (_currentMessage == null)
                        _currentMessage = new MessagePart();

                    // if message is complete
                    if (!_currentMessage.Build(buffer)) continue;
                    var messageDataReader = new BigEndianReader(_currentMessage.Data);
                    if (_currentMessage.MessageId != null)
                    {
                        var message =
                            MessageBuilder.BuildMessage((ushort) _currentMessage.MessageId.Value, messageDataReader);

                        LastActivity = DateTime.Now;
                        OnMessageReceived(message);
                    }

                    _currentMessage = null;
                }
                buffer = new BigEndianReader();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //private IPEndPoint endPoint;
        public event Action<ServerConnection, NetworkMessage> MessageReceived;

        public event Action<ServerConnection, NetworkMessage> MessageSent;
        public event Action<ServerConnection> Connected;
        public event Action<ServerConnection> Disconnected;

        private void OnMessageReceived(NetworkMessage message)
        {
            var handler = MessageReceived;
            handler?.Invoke(this, message);
        }

        private void OnMessageSended(NetworkMessage message)
        {
            var handler = MessageSent;
            handler?.Invoke(this, message);
        }

        private void OnClientConnected()
        {
            var handler = Connected;
            handler?.Invoke(this);
        }

        private void OnClientDisconnected()
        {
            var handler = Disconnected;
            handler?.Invoke(this);
        }

        public void Connect(string host, int port)
        {
            if (Socket == null)
                throw new Exception("Socket already closed");
            if (Socket.Connected)
                throw new Exception("Socket already connected");

            Host = host;
            Port = port;
            Socket.Connect(host, port);
            OnClientConnected();

            ReceiveLoop();
        }

        public void Reconnect()
        {
            if (IsConnected)
                Disconnect();

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Connect(Host, Port);
        }

        public void Reconnect(string host, int port)
        {
            if (IsConnected)
                Socket.Close();

            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Connect(host, port);
        }

        private void OnSendCompleted(object sender, SocketAsyncEventArgs socketAsyncEventArgs)
        {
            OnMessageSended((NetworkMessage) socketAsyncEventArgs.UserToken);
            socketAsyncEventArgs.Dispose();
        }

        private void ReceiveLoop()
        {
            lock (this)
            {
                if (!IsConnected)
                    return;

                var args = new SocketAsyncEventArgs();
                args.Completed += OnReceiveCompleted;
                args.SetBuffer(_buffer, 0, 8192);

                if (!Socket.ReceiveAsync(args))
                    ProcessReceiveCompleted(args);
            }
        }

        private void OnReceiveCompleted(object sender, SocketAsyncEventArgs args)
        {
            switch (args.LastOperation)
            {
                case SocketAsyncOperation.Receive:
                    ProcessReceiveCompleted(args);
                    break;
                case SocketAsyncOperation.Disconnect:
                    Disconnect();
                    break;
            }
        }

        private void ProcessReceiveCompleted(SocketAsyncEventArgs args)
        {
            lock (this)
            {
                if (!IsConnected)
                    return;

                IsResponding = true;

                if (args.BytesTransferred <= 0 ||
                    args.SocketError != SocketError.Success)
                {
                    Disconnect();
                }
                else
                {
                    Receive(args.Buffer, args.Offset, args.BytesTransferred);

                    ReceiveLoop();
                }
            }
        }

        protected void Close()
        {
            lock (this)
            {
                if (Socket == null || !Socket.Connected) return;
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();

                Socket = null;
            }
        }

        public override string ToString()
        {
            return string.Concat("<", Ip, ">");
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}