using Cookie.Core;
using Cookie.Extensions;
using Cookie.IO;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Cookie
{
    public static class MyGlobals
    {
        public static UInt32 GLOBAL_INSTANCE_ID = 35;
    }
    public class DataHeader
    {
        public byte[] MessageData { get; set; }
        public uint MessageId { get; set; }
        public DataHeader(uint messageId, byte[] messageData)
        {
            this.MessageId = messageId;
            this.MessageData = messageData;
        }
        
    }
    public class Client : IDisposable
    {
        #region Variables
        public Logger Logger = Logger.Default;
        const int bufferLength = 81920;
        private const int MessageHeaderSize = 2;
        private Socket clientSocket;
        private IPEndPoint hostEndPoint;
        private AutoResetEvent autoConnectEvent;
        private AutoResetEvent autoSendEvent;
        private SocketAsyncEventArgs sendEventArgs;
        private SocketAsyncEventArgs receiveEventArgs;
        private BlockingCollection<byte[]> sendingQueue;
        public BlockingCollection<DataHeader> receivedMessageQueue;
        private Thread sendMessageWorker;
        private Thread processReceivedMessageWorker;
        private bool Debug = false;
        #endregion

        #region Constructor
        public Client(string ip, short port)
        {
            IPEndPoint hostEndPoint = new IPEndPoint(IPAddress.Parse(ip), (int)port);
            this.hostEndPoint = hostEndPoint;
            this.autoConnectEvent = new AutoResetEvent(false);
            this.autoSendEvent = new AutoResetEvent(false);
            this.sendingQueue = new BlockingCollection<byte[]>();
            this.receivedMessageQueue = new BlockingCollection<DataHeader>();
            this.clientSocket = new Socket(this.hostEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            this.sendMessageWorker = new Thread(new ThreadStart(SendQueueMessage));
            this.processReceivedMessageWorker = new Thread(new ThreadStart(ProcessReceivedMessage));

            this.sendEventArgs = new SocketAsyncEventArgs();
            this.sendEventArgs.UserToken = this.clientSocket;
            this.sendEventArgs.RemoteEndPoint = this.hostEndPoint;
            this.sendEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnSend);

            this.receiveEventArgs = new SocketAsyncEventArgs();
            this.receiveEventArgs.UserToken = new AsyncUserToken(clientSocket);
            this.receiveEventArgs.RemoteEndPoint = this.hostEndPoint;
            this.receiveEventArgs.SetBuffer(new Byte[bufferLength], 0, bufferLength);
            this.receiveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnReceive);
            Connect();
        }
        #endregion
        #region Methods
        #region Private
        private void OnConnect(object sender, SocketAsyncEventArgs e)
        {
            Logger.Log(String.Format("Connected!{0}:{1}", this.hostEndPoint.Address, this.hostEndPoint.Port), LogMessageType.Info);
            autoConnectEvent.Set();
        }
        private void OnSend(object sender, SocketAsyncEventArgs e)
        {
            autoSendEvent.Set();
        }
        private void OnReceive(object sender, SocketAsyncEventArgs e)
        {
            ProcessReceive(e);
        }
        private void ProcessReceive(SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                AsyncUserToken token = e.UserToken as AsyncUserToken;
                if(Debug)
                    Logger.Log(String.Format("DataStartOffset[{0}], DataStartOffset[{1}], BytesTransferred[{2}]", token.NextReceiveOffset, token.DataStartOffset, e.BytesTransferred));

                //Process the received data
                ProcessReceivedData(token.DataStartOffset, token.NextReceiveOffset - token.DataStartOffset + e.BytesTransferred, 0, token, e);

                //Update the starting position of the next data to be received
                token.NextReceiveOffset += e.BytesTransferred;

                //If the end of the buffer is reached, reset NextReceiveOffset to the beginning of the buffer and migrate unprocessed data that may need to be migrated
                if (token.NextReceiveOffset >= e.Buffer.Length)
                {
                    if(Debug)
                        Logger.Log("End of the buffer reached");
                    //Reset NextReceiveOffset to the beginning of the buffer
                    token.NextReceiveOffset = 0;

                    //If there are unprocessed data, move these data to the beginning of the data buffer
                    if (token.DataStartOffset < e.Buffer.Length)
                    {
                        var notYetProcessDataSize = e.Buffer.Length - token.DataStartOffset;
                        Buffer.BlockCopy(e.Buffer, token.DataStartOffset, e.Buffer, 0, notYetProcessDataSize);

                        //After the data is migrated to the beginning of the buffer, NextReceiveOffset needs to be updated again
                        token.NextReceiveOffset = notYetProcessDataSize;
                    }

                    token.DataStartOffset = 0;
                }

                //Update the starting position of the receiving data buffer and the maximum receivable data length
                e.SetBuffer(token.NextReceiveOffset, e.Buffer.Length - token.NextReceiveOffset);

                //Receive subsequent data
                if (!token.Socket.ReceiveAsync(e))
                {
                    ProcessReceive(e);
                }
            }
            else
            {
                ProcessError(e);
            }
        }
        private void ProcessReceivedData(int dataStartOffset, int totalReceivedDataSize, int alreadyProcessedDataSize, AsyncUserToken token, SocketAsyncEventArgs e, uint messageId = 0)
        {
            //Console.WriteLine("ProcessReceivedData({0}, {1}, {2}, {3}, {4})", dataStartOffset, totalReceivedDataSize, alreadyProcessedDataSize, token.MessageSize, e.Buffer.Length);
            if (alreadyProcessedDataSize >= totalReceivedDataSize && messageId == 0)
            {
                return;
            }

            if (token.MessageSize == null)
            {
                //If the previously received data plus the currently received data is greater than the size of the message header, you can
                if (totalReceivedDataSize > MessageHeaderSize)
                {
                    CustomDataReader reader = new CustomDataReader(e.Buffer.Skip(dataStartOffset).ToArray());
                    int header = reader.ReadShort();
                    int headerType = header & 0x3;
                    int MessageId = header >> 2;
                    //Making sure that we can extract the actual data after knowing the typeLen
                    if (totalReceivedDataSize >= MessageHeaderSize + headerType)
                    {
                        int packetSize = 0;
                        for (int i = headerType - 1; i >= 0; i--)
                        {
                            packetSize |= reader.ReadByte() << (i * 8);
                        }
                        if (Debug)
                            Logger.Log(String.Format("Header[{0}], MessageId[{1}], HeaderType[{2}], PacketSize[{3}]", header.ToString("X4"), MessageId, headerType, packetSize));

                        reader.Dispose(); 
                        token.MessageSize = packetSize;
                        //Updating where does the packetContentStartsAt
                        token.DataStartOffset += MessageHeaderSize + headerType;
                        ProcessReceivedData(token.DataStartOffset, totalReceivedDataSize, alreadyProcessedDataSize + MessageHeaderSize + headerType, token, e, (uint)MessageId);
                    }
                }
            }
            else
            {
                var messageSize = token.MessageSize.Value;
                //Determine whether the current cumulative number of bytes received minus the number of processed bytes is greater than the length of the message, if it is greater, the message can be parsed
                if (totalReceivedDataSize - alreadyProcessedDataSize >= messageSize)
                {
                    var messageData = new byte[messageSize];
                    Buffer.BlockCopy(e.Buffer, dataStartOffset, messageData, 0, messageSize);
                    ProcessMessage(messageId,messageData);

                    //After the message is processed, the token needs to be cleaned up in order to receive the next message
                    token.DataStartOffset = dataStartOffset + messageSize;
                    token.MessageSize = null;

                    //Recursive processing
                    ProcessReceivedData(token.DataStartOffset, totalReceivedDataSize, alreadyProcessedDataSize + messageSize, token, e);
                }
                //Explain that the remaining bytes are not enough to be converted into messages, you need to continue to receive subsequent bytes
                else
                {
                    //ÕâÀï²»ÐèÒª×öÊ²Ã´ÊÂÇé
                }
            }
        }
        private void ProcessMessage(uint messageId, byte[] messageData)
        {
            if(Debug)
                Console.WriteLine("MessageId<{0}> added to queue", messageId);
            receivedMessageQueue.Add(new DataHeader(messageId,messageData));
        }
        private void ProcessReceivedMessage() 
        {
            try
            {
                //Async work that process messages added to the que
                while (true)
                {
                    if (receivedMessageQueue.TryTake(out DataHeader message, TimeSpan.FromSeconds(0.1)))
                        MessageArrived(message);
                }
            }
            catch(ThreadAbortException)
            {
                System.Diagnostics.Debug.WriteLine("Receiving Thread Aborted");
            }
        }
        protected virtual void MessageArrived(DataHeader message) { }
        private void SendQueueMessage()
        {
            try
            {
                while (true)
                {
                    if (clientSocket.IsConnected())
                        if (sendingQueue.TryTake(out byte[] message, TimeSpan.FromSeconds(1)))
                        {
                            sendEventArgs.SetBuffer(message, 0, message.Length);
                            clientSocket.SendAsync(sendEventArgs);
                            autoSendEvent.WaitOne();
                        }
                }
            }
            catch(ThreadAbortException)
            {
                System.Diagnostics.Debug.WriteLine("Sending Thread Aborted");
            }
        }
        #endregion
        #region Public
        protected virtual void Connect()
        {
            SocketAsyncEventArgs connectArgs = new SocketAsyncEventArgs();
            connectArgs.UserToken = this.clientSocket;
            connectArgs.RemoteEndPoint = this.hostEndPoint;
            connectArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnConnect);

            clientSocket.ConnectAsync(connectArgs);
            autoConnectEvent.WaitOne();

            SocketError errorCode = connectArgs.SocketError;
            if (errorCode != SocketError.Success)
            {
                throw new SocketException((Int32)errorCode);
            }
            if(sendMessageWorker.ThreadState == ThreadState.Unstarted)
             sendMessageWorker.Start();
            if (processReceivedMessageWorker.ThreadState == ThreadState.Unstarted)
                processReceivedMessageWorker.Start();

            if (!clientSocket.ReceiveAsync(receiveEventArgs))
            {
                ProcessReceive(receiveEventArgs);
            }
        }
        public void ChangeServer(string address, short port)
        {
            Disconnect();
            IPEndPoint hostEndPoint = new IPEndPoint(IPAddress.Parse(address), (int)port);
            this.hostEndPoint = hostEndPoint;
            this.autoConnectEvent = new AutoResetEvent(false);
            this.autoSendEvent = new AutoResetEvent(false);
            //this.sendingQueue = new BlockingCollection<byte[]>();
            //this.receivedMessageQueue = new BlockingCollection<DataHeader>();
            this.clientSocket = new Socket(this.hostEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            //this.sendMessageWorker = new Thread(new ThreadStart(SendQueueMessage));
            //this.processReceivedMessageWorker = new Thread(new ThreadStart(ProcessReceivedMessage));

            this.sendEventArgs = new SocketAsyncEventArgs();
            this.sendEventArgs.UserToken = this.clientSocket;
            this.sendEventArgs.RemoteEndPoint = this.hostEndPoint;
            this.sendEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnSend);

            this.receiveEventArgs = new SocketAsyncEventArgs();
            this.receiveEventArgs.UserToken = new AsyncUserToken(clientSocket);
            this.receiveEventArgs.RemoteEndPoint = this.hostEndPoint;
            this.receiveEventArgs.SetBuffer(new Byte[bufferLength], 0, bufferLength);
            this.receiveEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(OnReceive);
            Connect();
        }
        protected virtual void Disconnect()
        {
            if(clientSocket.Connected)
                clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            //sendMessageWorker.Abort();
            //sendMessageWorker = null;
            //processReceivedMessageWorker.Abort();
            //processReceivedMessageWorker = null;
            hostEndPoint = null;
            autoConnectEvent.Dispose();
            autoConnectEvent = null;
            autoSendEvent.Dispose();
            autoSendEvent = null;
            //if (receivedMessageQueue.TryTake(out DataHeader dh, TimeSpan.FromSeconds(1)))
            //    MessageArrived(dh);
            //receivedMessageQueue.Dispose();
            //receivedMessageQueue = null;
            //clientSocket.Dispose();
            clientSocket = null;
            sendEventArgs.Dispose();
            sendEventArgs = null;
            receiveEventArgs.Dispose();
            receiveEventArgs = null;
        }
        public void Send(byte[] message)
        {
            sendingQueue.Add(message);
        }
        #endregion
        #endregion
        #region ExceptionHandler
        private void ProcessError(SocketAsyncEventArgs e)
        {
            Socket s = e.UserToken as Socket;
            if (s != null && s.Connected)
            {
                // close the socket associated with the client
                try
                {
                    s.Shutdown(SocketShutdown.Both);
                }
                catch (Exception)
                {
                    return;
                }
                finally
                {
                    if (s.Connected)
                    {
                        s.Close();
                    }
                }
            }
            else
                Dispose();

            // Throw the SocketException
            //throw new SocketException((Int32)e.SocketError);
        }
        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            autoConnectEvent.Close();
            if (this.clientSocket.Connected)
            {
                this.clientSocket.Close();
            }
        }

        #endregion
    }
}
