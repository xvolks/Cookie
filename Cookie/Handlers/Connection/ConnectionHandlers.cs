using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Connection;
using Cookie.Protocol.Network.Types.Version;
using Cookie.Utils.Extensions;
using DofusBot.Utils.Cryptography;

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
            sbyte[] Credentials = RSA.Encrypt(Message.Key, Client.Account.Login, Client.Account.Password, Message.Salt);
            VersionExtended Version = new VersionExtended(2, 41, 1, 120980, 0, (sbyte)BuildTypeEnum.RELEASE, 1, 1);
            IdentificationMessage IdentificationMessage = new IdentificationMessage(true, false, false, Version, "fr", Credentials, 0, 0, new ushort[0]);
            Client.Logger.Log("Envois des informations d'identification...");
            Client.Send(IdentificationMessage);
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
            Client.Account.Ticket = AES.DecodeWithAES(Message.Ticket);
            Client.Logger.Log("Connexion en cours <" + Message.Address + ":" + Message.Port + ">");
            Client.ChangeRemote(Message.Address, Message.Port);
        }

        [MessageHandler(SelectedServerDataMessage.ProtocolId)]
        private void SelectedServerDataMessageMessageHandler(DofusClient Client, SelectedServerDataMessage Message)
        {
            Client.Logger.Log("Sélection du serveur " + (ServerNameEnum)Message.ServerId);
            Client.Account.Ticket = AES.DecodeWithAES(Message.Ticket);
            Client.Logger.Log("Connexion en cours <" + Message.Address + ":" + Message.Port + ">");
            Client.ChangeRemote(Message.Address, Message.Port);
        }

        [MessageHandler(SelectedServerRefusedMessage.ProtocolId)]
        private void SelectedServerRefusedMessageHandler(DofusClient Client, SelectedServerRefusedMessage Message)
        {
            //
        }

        [MessageHandler(ServerListMessage.ProtocolId)]
        private void ServerListMessageHandler(DofusClient Client, ServerListMessage Message)
        {
            foreach (var Server in Message.Servers)
            {
                if (Server.CharactersCount <= 0 || !Server.IsSelectable) continue;
                if ((ServerStatusEnum)Server.Status == ServerStatusEnum.ONLINE)
                    Client.Send(new ServerSelectionMessage(Server.ObjectID));
                else
                    Client.Logger.Log((ServerNameEnum)Server.ObjectID + ": " + (ServerStatusEnum)Server.Status);
                break;
            }
        }

        [MessageHandler(ServerStatusUpdateMessage.ProtocolId)]
        private void ServerStatusUpdateMessageHandler(DofusClient Client, ServerStatusUpdateMessage Message)
        {
            Client.Logger.Log(((ServerNameEnum)Message.Server.ObjectID).ToString() + ": " + (ServerStatusEnum)Message.Server.Status, LogMessageType.Default);
        }
    }
}
