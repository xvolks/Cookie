using Cookie.Core;
using Cookie.Gamedata;
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
            /* On reçoit ce packet quan on est connecté au serveur d'authentification du jeu.
             * Il faut ici crypter le nom de compte et le mot de passe du compte qu'on veut connecter avec la Key, et Salt
             * donnés par le packet, en RSA, ainsi que préciser la version du jeu, pour cela il faut changer les variables
             * dans le fichier GameConstant situé dans le dossier Utils du bot.
             */
            client.Logger.Log("Connecté au serveur d'authentification.");
            // On crypte le login et mot de passe
            var credentials = Rsa.Encrypt(message.Key, client.Account.Login, client.Account.Password, message.Salt);
            // On défini la version du jeu
            var version = new VersionExtended(GameConstant.Major, GameConstant.Minor, GameConstant.Release,
                GameConstant.Revision, GameConstant.Patch, GameConstant.BuildType, GameConstant.Install,
                GameConstant.Technology);
            // On précise qu'on veut se connecter sur ce compte et cette version et on envois le packet
            var identificationMessage =
                new IdentificationMessage(true, false, false, version, "fr", credentials, 0, 0, new ushort[0]);
            client.Logger.Log("Envois des informations d'identification...");
            client.Send(identificationMessage);
        }

        [MessageHandler(IdentificationFailedBannedMessage.ProtocolId)]
        private void IdentificationFailedBannedMessageHandler(DofusClient client,
            IdentificationFailedBannedMessage message)
        {
            /*
             * On reçois ce packet quand l'identification échoue parce qu'on est banni
             * On affiche donc la raison et le temps.
             * */
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
            /*
             * L'identification a réussi, il faut donc attribuer toutes les infos liés au compte à notre classe client.
             */
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
            client.Logger.Log($"Le serveur {D2OParsing.GetServerName(message.ServerId)} n'est pas accessible",
                LogMessageType.Public);
            switch ((ServerConnectionErrorEnum) message.Error)
            {
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_DUE_TO_STATUS:
                    client.Logger.Log($"Status du serveur: {(ServerStatusEnum) message.ServerStatus}",
                        LogMessageType.Public);
                    break;
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_NO_REASON:
                    break;
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_ACCOUNT_RESTRICTED:
                    break;
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_COMMUNITY_RESTRICTED:
                    break;
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_LOCATION_RESTRICTED:
                    break;
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_SUBSCRIBERS_ONLY:
                    break;
                case ServerConnectionErrorEnum.SERVER_CONNECTION_ERROR_REGULAR_PLAYERS_ONLY:
                    break;
            }
            client.Dispose();
        }

        [MessageHandler(ServerListMessage.ProtocolId)]
        private void ServerListMessageHandler(DofusClient client, ServerListMessage message)
        {
            if (message.AlreadyConnectedToServerId != 0)
            {
                client.Send(new ServerSelectionMessage(message.AlreadyConnectedToServerId));
                return;
            }

            var server = message.Servers.Find(s => (ServerStatusEnum) s.Status == ServerStatusEnum.ONLINE
                                                   && s.IsSelectable && s.CharactersCount > 0);

            client.Send(server == null ? new ServerSelectionMessage(11) : new ServerSelectionMessage(server.ObjectID));
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