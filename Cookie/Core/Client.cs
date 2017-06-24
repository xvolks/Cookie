using System;
using System.Net;
using System.Net.Sockets;
using Cookie.API.Extensions;

namespace Cookie.Core
{
    public class Client : IDisposable
    {
        #region MyRegion

        private const int BufferLength = 8192;

        public byte[] Buffer = new byte[BufferLength];
        public Socket Socket;
        public Logger Logger = Logger.Default;

        private SocketAsyncEventArgs _receiveEvent;
        private event Action Disconnected;

        private TimerCore _timer;
        protected readonly object Sender;

        #endregion

        #region Constructor

        public Client(Socket socket)
        {
            Sender = new object();
            Socket = socket;
            Socket.NoDelay = true;

            _receiveEvent = new SocketAsyncEventArgs();
            _receiveEvent.SetBuffer(Buffer, 0, Buffer.Length);
            _receiveEvent.Completed += ReceiveEvent_Completed;

            _timer = new TimerCore(CheckDisonnect, 50, 500);

            if (!Socket.ReceiveAsync(_receiveEvent))
                ReceiveEvent_Completed(Socket, _receiveEvent);
        }

        public Client(string ip, short port)
        {
            Sender = new object();
            Logger.Log($"Connexion en cours <{ip}:{port}>");
            Connect(ip, port);
        }

        public void Connect(string ip, short port)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var socketAsyncEventArgs = new SocketAsyncEventArgs
            {
                RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port),
                UserToken = Socket
            };
            socketAsyncEventArgs.Completed += SocketAsyncEventArgs_Completed;
            Socket.ConnectAsync(socketAsyncEventArgs);
        }

        public void ChangeRemote(string ip, ushort port)
        {
            Socket.Shutdown(SocketShutdown.Both);
            Socket.Close();
            Socket = null;

            Connect(ip, Convert.ToInt16(port));
        }

        protected virtual void SocketAsyncEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            _receiveEvent = new SocketAsyncEventArgs();
            _receiveEvent.SetBuffer(Buffer, 0, Buffer.Length);
            _receiveEvent.Completed += ReceiveEvent_Completed;

            _timer = new TimerCore(CheckDisonnect, 50, 500);

            if (!Socket.ReceiveAsync(_receiveEvent))
                ReceiveEvent_Completed(Socket, _receiveEvent);
        }

        #endregion

        #region Event

        protected virtual void ReceiveEvent_Completed(object sender, SocketAsyncEventArgs e)
        {
            do
            {
                if (!IsConnected())
                    break;
            } while (!Socket.ReceiveAsync(_receiveEvent));
        }

        protected virtual void DisconnectedEvent()
        {
            Disconnected?.Invoke();
            _timer.Dispose();
            Dispose();
        }

        #endregion

        #region Funcs

        public void Send(byte[] datas)
        {
            if (!IsConnected())
                return;

            lock (Sender)
            {
                Socket.Send(datas);
            }
        }

        public void Dispose()
        {
            if (Socket != null)
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
                Socket.Dispose();
                Socket = null;
            }
            Buffer = null;
            _timer.Dispose();
            Disconnected?.Invoke();
        }

        private void CheckDisonnect()
        {
            if (!IsConnected())
                DisconnectedEvent();
        }

        public bool IsConnected()
        {
            return Socket != null && Socket.IsConnected();
        }

        #endregion
    }
}