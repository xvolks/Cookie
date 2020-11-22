using System;
using System.Net.Sockets;
using Cookie.API.Protocol;
using Cookie.API.Utils.IO;

namespace Cookie.API.Network
{
    public abstract class Client : IClient
    {
        private readonly BigEndianReader _buffer = new BigEndianReader();
        private readonly object _lockObject = new object();

        private MessagePart _currentMessage;

        protected Client(Socket socket)
        {
            Socket = socket;
        }

        public Socket Socket { get; private set; }

        public bool Connected => Socket != null && Socket.Connected;

        /// <summary>
        ///     Last activity as a socket client (last received packet or sent packet)
        /// </summary>
        public DateTime LastActivity { get; private set; }

        public abstract IMessageBuilder MessageBuilder { get; }

        public virtual void Send(NetworkMessage message)
        {
            if (Socket == null || !Connected)
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
                OnMessageSent(message);
                args.Dispose();
            }

            LastActivity = DateTime.Now;
        }

        public virtual void Receive(byte[] data, int offset, int count)
        {
            try
            {
                lock (_lockObject)
                {
                    _buffer.Add(data, offset, count);

                    BuildMessage();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Disconnect()
        {
            if (Socket != null && Socket.Connected)
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();

                Socket = null;
            }

            OnClientDisconnected();
        }

        public event Action<Client, NetworkMessage> MessageReceived;
        public event Action<Client, NetworkMessage> MessageSent;
        public event Action<Client> Disconnected;

        protected virtual void OnMessageReceived(NetworkMessage message)
        {
            var handler = MessageReceived;
            handler?.Invoke(this, message);
        }

        protected virtual void OnMessageSent(NetworkMessage message)
        {
            var handler = MessageSent;
            handler?.Invoke(this, message);
        }

        protected virtual void OnClientDisconnected()
        {
            var handler = Disconnected;
            handler?.Invoke(this);
        }

        private void OnSendCompleted(object sender, SocketAsyncEventArgs e)
        {
            OnMessageSent((NetworkMessage) e.UserToken);
            e.Dispose();
        }

        private void BuildMessage()
        {
            if (_buffer.BytesAvailable <= 0)
                return;

            if (_currentMessage == null)
                _currentMessage = new MessagePart();

            // if message is complete
            if (!_currentMessage.Build(_buffer)) return;
            var messageDataReader = new BigEndianReader(_currentMessage.Data);
            if (_currentMessage.MessageId != null)
            {
                var message = MessageBuilder.BuildMessage((ushort) _currentMessage.MessageId.Value, messageDataReader);

                LastActivity = DateTime.Now;
                OnMessageReceived(message);
            }

            _currentMessage = null;
            BuildMessage(); // there is maybe a second message in the buffer
        }
    }
}