using Cookie.Core;
using Cookie.Extensions;
using System;
using System.Net;
using System.Net.Sockets;

namespace Cookie
{
    public class Client : IDisposable
    {
        #region MyRegion
        const int bufferLength = 8192;

        public byte[] buffer = new byte[bufferLength];
        public Socket Socket;
        public Logger Logger = Logger.Default;

        protected SocketAsyncEventArgs ReceiveEvent;
        protected event Action Disconnected;

        private TimerCore _timer;
        protected object _sender;
        #endregion

        #region Constructor
        public Client(Socket socket)
        {
            _sender = new object();
            Socket = socket;
            Socket.NoDelay = true;

            ReceiveEvent = new SocketAsyncEventArgs();
            ReceiveEvent.SetBuffer(buffer, 0, buffer.Length);
            ReceiveEvent.Completed += ReceiveEvent_Completed;

            _timer = new TimerCore(new Action(CheckDisonnect), 50, 1000);

            if (!Socket.ReceiveAsync(ReceiveEvent))
            {
                ReceiveEvent_Completed(Socket, ReceiveEvent);
            }
        }

        public Client(string ip, short port)
        {
            _sender = new object();
            Logger.Log($"Connexion en cours <{ip}:{port}>");
            Connect(ip, port);
        }

        public void Connect(string ip, short port)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            SocketAsyncEventArgs SocketAsyncEventArgs = new SocketAsyncEventArgs()
            {
                RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port),
                UserToken = Socket
            };
            SocketAsyncEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(SocketAsyncEventArgs_Completed);
            Socket.ConnectAsync(SocketAsyncEventArgs);
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
            ReceiveEvent = new SocketAsyncEventArgs();
            ReceiveEvent.SetBuffer(buffer, 0, buffer.Length);
            ReceiveEvent.Completed += ReceiveEvent_Completed;

            _timer = new TimerCore(new Action(CheckDisonnect), 50, 1000);

            if (!Socket.ReceiveAsync(ReceiveEvent))
            {
                ReceiveEvent_Completed(Socket, ReceiveEvent);
            }
        }

        #endregion

        #region Event
        protected virtual void ReceiveEvent_Completed(object sender, SocketAsyncEventArgs e)
        {
            do
            {
                if (!IsConnected())
                    break;
            } while (!Socket.ReceiveAsync(ReceiveEvent));
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

            lock (_sender)
            {
                Socket.Send(datas);
            }
        }

        public virtual void Dispose()
        {
            if (Socket != null)
            {
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close();
                Socket.Dispose();
                Socket = null;

            }
            buffer = null;
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
            if (Socket == null)
                return false;
            else
                return Socket.IsConnected();
        }
        #endregion
    }
}
