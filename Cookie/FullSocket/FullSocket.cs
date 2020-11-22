﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Cookie.API.Core;
using Cookie.API.Datacenter;
using Cookie.API.Game.Map;
using Cookie.API.Gamedata;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Gamedata.D2p;
using Cookie.API.Messages;
using Cookie.API.Network;
using Cookie.API.Protocol;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages;
using Cookie.API.Protocol.Network.Types;
using Cookie.API.Utils;
using Cookie.API.Utils.Cryptography;
using Cookie.API.Utils.Enums;
using Cookie.API.Utils.Extensions;
using Cookie.API.Utils.IO;
using Cookie.Core;
using Cookie.Game.Map;

namespace Cookie.FullSocket
{
    public class FullSocket
    {
        public static int ServerConnectionTimeout = 4000;

        private readonly FullSocketConfiguration _mConfiguration;

        private readonly Dictionary<string, Tuple<IAccount, SelectedServerDataMessage>> _mTickets =
            new Dictionary<string, Tuple<IAccount, SelectedServerDataMessage>>();

        private readonly List<ConnectionFullSocket> _servers = new List<ConnectionFullSocket>();

        public FullSocket(FullSocketConfiguration configuration, MessageReceiver messageReceiver)
        {
            _mConfiguration = configuration;
            MessageBuilder = messageReceiver;
        }

        public ClientManager<ConnectionFullSocket> AuthConnection { get; set; }

        public MessageReceiver MessageBuilder { get; set; }

        public IAccount Connect(string username, string password, MainForm main)
        {
            var server = new ConnectionFullSocket(new ServerConnection(MessageBuilder), MessageBuilder);

            server.Disconnected += OnAuthClientDisconnected;
            server.MessageReceived += OnAuthClientMessageReceived;

            var dispatcher = new NetworkMessageDispatcher {Server = server};

            server.Account = new Account(username, password, server, dispatcher, main)
            {
                Network = {ConnectionType = ClientConnectionType.Authentification}
            };

            server.Account.Network.RegisterPacket<HelloConnectMessage>(HandleHelloConnectMessage, MessagePriority.VeryHigh);

            server.Account.Network.RegisterPacket<ServersListMessage>(HandleServersListMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<SelectedServerDataMessage>(HandleSelectedServerDataMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<RawDataMessage>(HandleRawDataMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<SelectedServerDataExtendedMessage>(
                HandleSelectedServerDataExtendedMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<IdentificationFailedBannedMessage>(
                HandleIdentificationFailedBannedMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<IdentificationFailedMessage>(HandleIdentificationFailedMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<IdentificationFailedForBadVersionMessage>(
                HandleIdentificationFailedForBadVersionMessage, MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<SelectedServerRefusedMessage>(HandleSelectedServerRefusedMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<LoginQueueStatusMessage>(HandleLoginQueueStatusMessage,
                MessagePriority.VeryHigh);
            server.Account.Network.RegisterPacket<QueueStatusMessage>(HandleQueueStatusMessage,
                MessagePriority.VeryHigh);
            // Connection FullSocket BindingToServer
            server.Account.Network.Start();
            server.BindToServer(_mConfiguration.RealAuthHost, _mConfiguration.RealAuthPort);

            _servers.Add(server);
            return server.Account;
        }

        private static void HandleRawDataMessage(IAccount account, RawDataMessage message)
        {
            var tt = new List<sbyte>();
            for (var i = 0; i <= 255; i++)
            {
                var random = new Random();
                var test = random.Next(-127, 127);
                tt.Add((sbyte) test);
            }
            var rawData = new CheckIntegrityMessage(tt);
            account.Network.SendToServer(rawData);
        }

        private void OnAuthClientDisconnected(Client client)
        {
            var fs = client as ConnectionFullSocket;
            Logger.Default.Log("Déconnecté.");
            fs.Account.Network.AddMessage(() =>
            {
                if (fs.Account.Network.ExpectedDisconnection)
                {
                    fs.Account.Network.ExpectedDisconnection = false;

                    // Need to free event for recursive call
                    fs.Disconnected -= OnAuthClientDisconnected;
                    fs.MessageReceived -= OnAuthClientMessageReceived;

                    fs.Account.Network.Stop();

                    var ticket = fs.Account.Ticket;
                    var tuple = _mTickets[ticket];
                    _mTickets.Remove(ticket);

                    // Reconnect to selected server
                    fs.Account.Network.Start();

                    // Handle Message on World Client
                    fs.Disconnected += OnWorldClientDisconnected;
                    fs.MessageReceived += OnWorldClientMessageReceived;
                    try
                    {
                        fs.Server.Reconnect(tuple.Item2.Address, tuple.Item2.Ports.FirstOrDefault());
                    }
                    catch (Exception ex)
                    {
                        fs.Account.Network.Stop();
                        Console.WriteLine(ex);
                    }
                }
                else
                {
                    fs.Account.Network.Dispose();
                }
            });
        }

        private static void OnWorldClientDisconnected(Client client)
        {
            var fs = client as ConnectionFullSocket;

            fs?.Account.Network?.AddMessage(fs.Account.Network.Dispose);
        }

        private void OnAuthClientMessageReceived(Client client, NetworkMessage message)
        {
            if (!(client is ConnectionFullSocket))
                throw new ArgumentException("client is not of type ConnectionFullSocket");
            //Logger.Default.Log(string.Format("MessageID[{0}] received", message.MessageID));
            var fs = (ConnectionFullSocket) client;
            if (message is IdentificationSuccessMessage ism)
                HandleIdentificationSuccessMessage(fs, ism);
            if (message is SelectedServerDataMessage ssdm)
            {
                var msg = ssdm;
                //Logger.Default.Log(msg.ServerId.ToString());
                Logger.Default.Log("Sélection du serveur " + D2OParsing.GetServerName(msg.ServerId));
                var ticket = string.Join(",", msg.Ticket);
                fs.Account.Ticket = ticket;
                _mTickets.Add(ticket,
                    Tuple.Create(fs.Account,
                        new SelectedServerDataMessage(msg.ServerId, msg.Address, msg.Ports, msg.CanCreateNewCharacter,
                            msg.Ticket)));
            }
            if (message is SelectedServerRefusedMessage ssrm)
            {
                var msg = ssrm;

                Logger.Default.Log("Impossible de se connecter au serveur "  + D2OParsing.GetServerName(msg.ServerId) + 
                                   " status " + msg.ServerStatus + " erreur " + msg.Error);

                fs.Disconnect();
            }

            if (fs.Account.Network == null)
                throw new NullReferenceException("fs.Bot");
            fs.Account.Network.Dispatcher.Enqueue(message, fs.Account);
        }

        private void OnWorldClientMessageReceived(Client client, NetworkMessage message)
        {
            if (!(client is ConnectionFullSocket))
                throw new ArgumentException("client is not of type ConnectionFullSocket");

            var fs = (ConnectionFullSocket) client;

            if (message is HelloGameMessage)
            {
                //var timer = ((ConnectionFullSocket) fs.Account.Network.Connection).TimeOutTimer;
                //timer?.Dispose();

                fs.SendToServer(new AuthenticationTicketMessage("fr", fs.Account.Ticket));
            }

            if (message is AuthenticationTicketAcceptedMessage)
            {
                // special handling to connect and retrieve the bot instance
                fs.Account.Network.ConnectionType = ClientConnectionType.GameConnection;
                fs.SendToServer(new CharactersListRequestMessage());
            }
            else
            {
                if (fs.Account.Network == null)
                    throw new NullReferenceException("fs.Bot");

                if (fs.Account.Network.Dispatcher.Stopped)
                    throw new Exception("Enqueue a message but the dispatcher is stopped !");

                fs.Account.Network.Dispatcher.Enqueue(message, fs.Account);
            }
        }

        private void HandleIdentificationSuccessMessage(ConnectionFullSocket client,
            IdentificationSuccessMessage message)
        {
            client.Account.Nickname = message.Login;
            Logger.Default.Log("Connecté");
            client.Account.Network.ExpectedDisconnection = true;
        }

        private void HandleHelloConnectMessage(IAccount account, HelloConnectMessage message)
        {
            account.Network.ConnectionType = ClientConnectionType.Authentification;
            Logger.Default.Log("Connecté au serveur d'authentification.");
            var version = new VersionExtended
            {
                BuildType = GameConstant.BuildType,
                Install = GameConstant.Install,
                Major = GameConstant.Major,
                Minor = GameConstant.Minor,
                Patch = GameConstant.Patch,
                Release = GameConstant.Release,
                Revision = GameConstant.Revision,
                Technology = GameConstant.Technology
            };
            string password = "";
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] hash = shaM.ComputeHash(System.Text.Encoding.UTF8.GetBytes(account.Password));
                string hashedPw = BitConverter.ToString(hash).Replace("-", "").ToLower();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                password = BitConverter.ToString(md5provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hashedPw + message.Salt))).Replace("-", "").ToLower();
                //Client.Logger.Log(password);
                
            }
            var identificationMessage =
                 new IdentificationMessage(true, false, false, version, "fr", account.Login, password, "y3JJiZ0geixj3GDmm2#01", 0, 0, new List<short>());
            Logger.Default.Log("Envois des informations d'identification...");
            account.Network.SendToServer(identificationMessage);
            account.Network.SendToServer(new ClientKeyMessage("y3JJiZ0geixj3GDmm2#01"));
        }

        private void HandleServersListMessage(IAccount account, ServersListMessage message)
        {
            if (message.AlreadyConnectedToServerId != 0)
            {
                account.Network.SendToServer(new ServerSelectionMessage(message.AlreadyConnectedToServerId));
                return;
            }

            var server = message.Servers.Find(s => (ServerStatusEnum) s.Status == ServerStatusEnum.ONLINE
                                                   /*&& s.IsSelectable*/ && s.CharactersCount > 0);

            account.Network.SendToServer(server == null
                ? new ServerSelectionMessage(11)
                : new ServerSelectionMessage(server.Id));
            Logger.Default.Log("Connecté au serveur de jeu !");
        }

        private void HandleSelectedServerDataMessage(IAccount account, SelectedServerDataMessage message)
        {
            //
        }

        private void HandleSelectedServerDataExtendedMessage(IAccount account,
            SelectedServerDataExtendedMessage message)
        {
            HandleSelectedServerDataMessage(account, message);
        }

        private void HandleIdentificationFailedBannedMessage(IAccount account,
            IdentificationFailedBannedMessage message)
        {
            if (message.BanEndDate != 0)
                Logger.Default.Log($"Votre compte est banni jusqu'au : {message.BanEndDate.UnixTimestampToDateTime()}.",
                    LogMessageType.Public);
            else
                Logger.Default.Log("Votre compte est banni pour : " + message.Reason, LogMessageType.Public);
        }

        private void HandleIdentificationFailedMessage(IAccount account, IdentificationFailedMessage message)
        {
            Logger.Default.Log($"Identification Fail -> {(IdentificationFailureReasonEnum) message.Reason}");
        }

        private void HandleIdentificationFailedForBadVersionMessage(IAccount account,
            IdentificationFailedForBadVersionMessage message)
        {
            Logger.Default.Log($"Wrong Dofus version. -> {message.RequiredVersion}");
        }

        private void HandleLoginQueueStatusMessage(IAccount account, LoginQueueStatusMessage message)
        {
            if (message.Position != 0 && message.Total != 0)
                Logger.Default.Log("Vous êtes en position " + message.Position + " sur " + message.Total +
                                   " dans la file d'attente.");
        }

        private void HandleQueueStatusMessage(IAccount account, QueueStatusMessage message)
        {
            if (message.Position != 0 && message.Total != 0)
                Logger.Default.Log("Vous êtes en position " + message.Position + " sur " + message.Total +
                                   " dans la file d'attente.");
        }

        private void HandleSelectedServerRefusedMessage(IAccount account, SelectedServerRefusedMessage message)
        {
            switch ((ServerStatusEnum) message.ServerStatus)
            {
                case ServerStatusEnum.SAVING:
                    Logger.Default.Log($"Le serveur séléctionné est en cours de sauvegarde.");
                    break;
                case ServerStatusEnum.FULL:
                    Logger.Default.Log($"Le serveur séléctionné est plein.");
                    break;
            }
        }
    }
}