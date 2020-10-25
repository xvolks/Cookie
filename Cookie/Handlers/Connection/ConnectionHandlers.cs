using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages;
using Cookie.Protocol.Network.Types;
using Cookie.Utils.Extensions;
using DofusBot.Utils.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Cookie.Handlers.Connection
{
    public class ConnectionHandlers
    {
        [MessageHandler(CredentialsAcknowledgementMessage.ProtocolId)]
        private void CredentialsAcknowledgementMessageHandler(DofusClient Client, CredentialsAcknowledgementMessage Message)
        {
            //
        } 

        [MessageHandler(HelloConnectMessage.ProtocolId)]
        private void HelloConnectMessageHandler(DofusClient Client, HelloConnectMessage Message)
        {
            Client.Logger.Log("Connecté au serveur d'authentification.");
            string password = "";
            using (SHA512 shaM = new SHA512Managed())
            {
                byte[] hash = shaM.ComputeHash(System.Text.Encoding.UTF8.GetBytes(Client.Account.Password));
                string hashedPw = BitConverter.ToString(hash).Replace("-", "").ToLower();
                MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
                password = BitConverter.ToString(md5provider.ComputeHash(System.Text.Encoding.UTF8.GetBytes(hashedPw + Message.Salt)) ).Replace("-","").ToLower();
                //Client.Logger.Log(password);
            }
            VersionExtended Version = new VersionExtended(2, 51, 5, 74014085, 0, (byte)BuildTypeEnum.RELEASE, 1, 1);
            ICollection<short> ic = new List<short>();
            IdentificationMessage IdentificationMessage = new IdentificationMessage(true, false, false, Version, "fr", Client.Account.Login, password, 0, 0, ic);
            Client.Logger.Log("Envois des informations d'identification...");
            Client.Send(IdentificationMessage);
            Client.Send(new ClientKeyMessage("y3JJiZ0geixj3GDmm2#01"));
        }

        [MessageHandler(IdentificationAccountForceMessage.ProtocolId)]
        private void IdentificationAccountForceMessageHandler(DofusClient Client, IdentificationAccountForceMessage Message)
        {
            //
        }

        [MessageHandler(IdentificationFailedBannedMessage.ProtocolId)]
        private void IdentificationFailedBannedMessageHandler(DofusClient Client, IdentificationFailedBannedMessage Message)
        {
            if (Message.BanEndDate != 0)
                Client.Logger.Log($"Votre compte est banni jusqu'au : {Message.BanEndDate.UnixTimestampToDateTime()}.", LogMessageType.Public);
            else
                Client.Logger.Log("Votre compte est banni pour : " + Message.Reason, LogMessageType.Public);
            Client.Dispose();
        }

        [MessageHandler(IdentificationFailedForBadVersionMessage.ProtocolId)]
        private void IdentificationFailedForBadVersionMessageHandler(DofusClient Client, IdentificationFailedForBadVersionMessage Message)
        {
            //
        }

        [MessageHandler(IdentificationFailedMessage.ProtocolId)]
        private void IdentificationFailedMessageHandler(DofusClient Client, IdentificationFailedMessage Message)
        {
            Client.Logger.Log("Identification échouée !", LogMessageType.Public);
            Client.Logger.Log(((IdentificationFailureReasonEnum)Message.Reason).ToString(), LogMessageType.Public);
            Client.Dispose();
        }

        [MessageHandler(IdentificationSuccessMessage.ProtocolId)]
        private void IdentificationSuccessMessageHandler(DofusClient Client, IdentificationSuccessMessage Message)
        {
            Client.Account.Nickname = Message.Nickname;
            Client.Account.Id = Message.AccountId;
            Client.Account.SecretQuestion = Message.SecretQuestion;
            Client.Account.AccountCreation = Message.AccountCreation;
            Client.Account.CommunityId = Message.CommunityId;
            Client.Account.SubscriptionElapsedDuration = Message.SubscriptionElapsedDuration;
            Client.Account.SubscriptionEndDate = Message.SubscriptionEndDate;
        }

        [MessageHandler(SelectedServerDataExtendedMessage.ProtocolId)]
        private void SelectedServerDataExtendedMessageHandler(DofusClient Client, SelectedServerDataExtendedMessage Message)
        {
            Client.Logger.Log("Sélection du serveur " + (ServerNameEnum)Message.ServerId);
            Client.Account.Ticket = Message.Ticket;
            Client.Logger.Log("Connexion en cours <" + Message.Address + ":" + Message.Ports.Take(1) + ">");
            Client.ChangeServer(Message.Address, (short)Message.Ports.Take(1).ToArray()[0]);
        }

        [MessageHandler(SelectedServerDataMessage.ProtocolId)]
        private void SelectedServerDataMessageMessageHandler(DofusClient Client, SelectedServerDataMessage Message)
        {
            Client.Logger.Log("Sélection du serveur " + (ServerNameEnum)Message.ServerId);
            Client.Account.Ticket = Message.Ticket;

            Client.Logger.Log("Connexion en cours <" + Message.Address + ":" + Message.Ports.FirstOrDefault() + ">");
            Client.ChangeServer(Message.Address, (short)Message.Ports.FirstOrDefault());
        }

        [MessageHandler(SelectedServerRefusedMessage.ProtocolId)]
        private void SelectedServerRefusedMessageHandler(DofusClient Client, SelectedServerRefusedMessage Message)
        {
            //
        }

        [MessageHandler(ServersListMessage.ProtocolId)]
        private void ServerListMessageHandler(DofusClient Client, ServersListMessage Message)
        {
            foreach (var Server in Message.Servers)
            {
                if (Server.CharactersCount > 0 && Server.IsSelectable)
                {
                    if ((ServerStatusEnum)Server.Status == ServerStatusEnum.ONLINE)
                        Client.Send(new ServerSelectionMessage(Server.Id_));
                    else
                        Client.Logger.Log((ServerNameEnum)Server.Id_ + ": " + (ServerStatusEnum)Server.Status);
                    break;
                }
            }
        }

        [MessageHandler(ServerStatusUpdateMessage.ProtocolId)]
        private void ServerStatusUpdateMessageHandler(DofusClient Client, ServerStatusUpdateMessage Message)
        {
            Client.Logger.Log(((ServerNameEnum)Message.Server.Id_).ToString() + ": " + (ServerStatusEnum)Message.Server.Status, LogMessageType.Default);
        }
    }
}
