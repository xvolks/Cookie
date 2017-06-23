using Cookie.Core;
using Cookie.Gamedata;
using Cookie.Gamedata.D2o;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Connection;
using Cookie.Protocol.Network.Types.Version;
using Cookie.Utils;
using Cookie.Utils.Cryptography;
using Cookie.Utils.Extensions;

namespace Cookie.Handlers.Connection
{
    public class ConnectionHandlers
    {
        [MessageHandler(CredentialsAcknowledgementMessage.ProtocolId)]
        private void CredentialsAcknowledgementMessageHandler(DofusClient client,
            CredentialsAcknowledgementMessage message)
        {
            //  
        }

        [MessageHandler(HelloConnectMessage.ProtocolId)]
        private void HelloConnectMessageHandler(DofusClient client, HelloConnectMessage message)
        {
            client.Logger.Log("Connecté au serveur d'authentification.");
            var credentials = Rsa.Encrypt(message.Key, client.Account.Login, client.Account.Password, message.Salt);
            //var version = new VersionExtended(2, 42, 0, 121441, 0, (sbyte) BuildTypeEnum.RELEASE, 1, 1);
            var version = new VersionExtended(GameConstant.Major, GameConstant.Minor, GameConstant.Release,
                GameConstant.Revision, GameConstant.Patch, GameConstant.BuildType, GameConstant.Install, 1);
            var identificationMessage =
                new IdentificationMessage(true, false, false, version, "fr", credentials, 0, 0, new ushort[0]);
            client.Logger.Log("Envois des informations d'identification...");
            client.Send(identificationMessage);
        }

        [MessageHandler(IdentificationFailedBannedMessage.ProtocolId)]
        private void IdentificationFailedBannedMessageHandler(DofusClient client,
            IdentificationFailedBannedMessage message)
        {
            if (message.BanEndDate != 0)
                client.Logger.Log($"Votre compte est banni jusqu'au : {message.BanEndDate.UnixTimestampToDateTime()}.",
                    LogMessageType.Public);
            else
                client.Logger.Log("Votre compte est banni pour : " + message.Reason, LogMessageType.Public);
            client.Dispose();
        }

        [MessageHandler(IdentificationFailedForBadVersionMessage.ProtocolId)]
        private void IdentificationFailedForBadVersionMessageHandler(DofusClient client,
            IdentificationFailedForBadVersionMessage message)
        {
            client.Logger.Log("La version n'est pas bonne. Version requise : " + message.RequiredVersion,
                LogMessageType.Public);
        }

        [MessageHandler(IdentificationFailedMessage.ProtocolId)]
        private void IdentificationFailedMessageHandler(DofusClient client, IdentificationFailedMessage message)
        {
            client.Logger.Log("Identification échouée !", LogMessageType.Public);
            client.Logger.Log(((IdentificationFailureReasonEnum) message.Reason).ToString(), LogMessageType.Public);
            client.Dispose();
        }

        [MessageHandler(IdentificationSuccessMessage.ProtocolId)]
        private void IdentificationSuccessMessageHandler(DofusClient client, IdentificationSuccessMessage message)
        {
            client.Account.Nickname = message.Nickname;
            client.Account.Id = message.AccountId;
            client.Account.SecretQuestion = message.SecretQuestion;
            client.Account.AccountCreation = message.AccountCreation;
            client.Account.CommunityId = message.CommunityId;
            client.Account.SubscriptionElapsedDuration = message.SubscriptionElapsedDuration;
            client.Account.SubscriptionEndDate = message.SubscriptionEndDate;
        }

        [MessageHandler(IdentificationSuccessWithLoginTokenMessage.ProtocolId)]
        private void IdentificationSuccessWithLoginTokenMessageHandler(DofusClient client,
            IdentificationMessage message)
        {
            //
        }

        [MessageHandler(MigratedServerListMessage.ProtocolId)]
        private void MigratedServerListMessageHandler(DofusClient client, MigratedServerListMessage message)
        {
            //
        }

        [MessageHandler(SelectedServerDataExtendedMessage.ProtocolId)]
        private void SelectedServerDataExtendedMessageHandler(DofusClient client,
            SelectedServerDataExtendedMessage message)
        {
            client.Logger.Log("Sélection du serveur " + D2OParsing.GetServerName(message.ServerId));
            client.Account.Ticket = AES.DecodeWithAES(message.Ticket);
            client.Logger.Log("Connexion en cours <" + message.Address + ":" + message.Port + ">");
            client.ChangeRemote(message.Address, message.Port);
        }

        [MessageHandler(SelectedServerDataMessage.ProtocolId)]
        private void SelectedServerDataMessageMessageHandler(DofusClient client, SelectedServerDataMessage message)
        {
            client.Logger.Log("Sélection du serveur " + D2OParsing.GetServerName(message.ServerId));
            client.Account.Ticket = AES.DecodeWithAES(message.Ticket);
            client.Logger.Log("Connexion en cours <" + message.Address + ":" + message.Port + ">");
            client.ChangeRemote(message.Address, message.Port);
        }

        [MessageHandler(SelectedServerRefusedMessage.ProtocolId)]
        private void SelectedServerRefusedMessageHandler(DofusClient client, SelectedServerRefusedMessage message)
        {
            //
        }

        [MessageHandler(ServerListMessage.ProtocolId)]
        private void ServerListMessageHandler(DofusClient client, ServerListMessage message)
        {
            if (message.AlreadyConnectedToServerId != 0)
            {
                client.Send(new ServerSelectionMessage(message.AlreadyConnectedToServerId));
                return;
            }
                
            var server = message.Servers.Find(s => (ServerStatusEnum)s.Status == ServerStatusEnum.ONLINE
                && s.IsSelectable && s.CharactersCount > 0);


            if (server == null)
            {
                // TODO: Check if server 11 is online and selectable              
                client.Send(new ServerSelectionMessage(11));
                client.Logger.Log("Selection du serveur automatique : Brumaire");
                return;
            }
            else
                client.Send(new ServerSelectionMessage(server.ObjectID));
        }

        [MessageHandler(ServerStatusUpdateMessage.ProtocolId)]
        private void ServerStatusUpdateMessageHandler(DofusClient client, ServerStatusUpdateMessage message)
        {
            client.Logger.Log(
                D2OParsing.GetServerName(message.Server.ObjectID) + ": " + (ServerStatusEnum) message.Server.Status,
                LogMessageType.Default);
        }
    }
}