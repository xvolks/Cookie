using Cookie.API.Core;
using Cookie.API.Core.Frames;
using Cookie.API.Datacenter;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Messages;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Basic;
using Cookie.API.Protocol.Network.Messages.Server.Basic;
using Cookie.API.Protocol.Network.Messages.Web.Ankabox;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;

namespace Cookie.Core.Frames
{
    public class BasicFrame : IBasicFrame
    {
        public BasicFrame(IAccount account)
        {
            account.Network.RegisterPacket<BasicLatencyStatsRequestMessage>(HandleBasicLatencyStatsRequestMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<SequenceNumberRequestMessage>(HandleSequenceNumberRequestMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<CurrentServerStatusUpdateMessage>(HandleCurrentServerStatusUpdateMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<TextInformationMessage>(HandleTextInformationMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<SystemMessageDisplayMessage>(HandleSystemMessageDisplayMessage,
                MessagePriority.VeryHigh);
            account.Network.RegisterPacket<MailStatusMessage>(HandleMailStatusMessage, MessagePriority.VeryHigh);
            account.Network.RegisterPacket<NewMailMessage>(HandleNewMailMessage, MessagePriority.VeryHigh);
        }

        private void HandleBasicLatencyStatsRequestMessage(IAccount account, BasicLatencyStatsRequestMessage message)
        {
            var basicLatencyStatsMessage = new BasicLatencyStatsMessage(
                (ushort) account.LatencyFrame.GetLatencyAvg(),
                (ushort) account.LatencyFrame.GetSamplesCount(),
                (ushort) account.LatencyFrame.GetSamplesMax());
            account.Network.SendToServer(basicLatencyStatsMessage);
        }

        private void HandleSequenceNumberRequestMessage(IAccount account, SequenceNumberRequestMessage message)
        {
            account.LatencyFrame.Sequence++;
            account.Network.SendToServer(new SequenceNumberMessage((ushort) account.LatencyFrame.Sequence));
        }

        private void HandleCurrentServerStatusUpdateMessage(IAccount account, CurrentServerStatusUpdateMessage message)
        {
            Logger.Default.Log("Server Status: " + (ServerStatusEnum) message.Status);
        }

        private void HandleTextInformationMessage(IAccount account, TextInformationMessage message)
        {
            var data = ObjectDataManager.Instance.Get<InfoMessage>(message.MsgType * 10000 + message.MsgId);
            var text = FastD2IReader.Instance.GetText(data.TextId);
            var parameters = message.Parameters.ToArray();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                text = text.Replace("%" + (i + 1), parameter);
            }

            switch ((TextInformationTypeEnum) message.MsgType)
            {
                case TextInformationTypeEnum.TEXT_INFORMATION_ERROR:
                    Logger.Default.Log(text, LogMessageType.Default);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE:
                    Logger.Default.Log(text, LogMessageType.Info);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_PVP:
                case TextInformationTypeEnum.TEXT_INFORMATION_FIGHT_LOG:
                    Logger.Default.Log(text, LogMessageType.FightLog);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_POPUP:
                case TextInformationTypeEnum.TEXT_LIVING_OBJECT:
                case TextInformationTypeEnum.TEXT_ENTITY_TALK:
                    Logger.Default.Log(text, LogMessageType.Default);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_FIGHT:
                    Logger.Default.Log(text, LogMessageType.FightLog);
                    break;
                default:
                    Logger.Default.Log((TextInformationTypeEnum) message.MsgType + " | ID = " + message.MsgId,
                        LogMessageType.Arena);
                    for (var i = 0; i < message.Parameters.Count; i++)
                    {
                        var t = message.Parameters[i];
                        Logger.Default.Log("Parameter[" + i + "] " + t, LogMessageType.Arena);
                    }
                    break;
            }
        }

        private void HandleSystemMessageDisplayMessage(IAccount account, SystemMessageDisplayMessage message)
        {
            if (message.MsgId != 13) return;
            Logger.Default.Log(
                "Le serveur est actuellement en maintenance. Vous pouvez consulter la rubrique Etats des serveurs du forum officiel, ou sur le site du Support pour plus d'informations. Merci de votre compréhension.",
                LogMessageType.Public);
            account.Network.Stop();
        }

        private void HandleMailStatusMessage(IAccount account, MailStatusMessage message)
        {
            if (message.Total > 0)
                Logger.Default.Log(
                    $"Ankabox: Vous avez {message.Unread} message(s) non-lus sur {message.Total} dans votre ankabox.",
                    LogMessageType.Default);
        }

        private void HandleNewMailMessage(IAccount account, NewMailMessage message)
        {
            Logger.Default.Log($"Ankabox: Vous avez reçu un nouveau message de la part de : {message.SendersAccountId}",
                LogMessageType.Default);
            if (message.Total > 0)
                Logger.Default.Log(
                    $"Ankabox: Vous avez {message.Unread} message(s) non-lus sur {message.Total} dans votre ankabox.",
                    LogMessageType.Default);
        }
    }
}