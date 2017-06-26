using Cookie.API.Datacenter;
using Cookie.API.Gamedata.D2i;
using Cookie.API.Gamedata.D2o;
using Cookie.API.Network;
using Cookie.API.Protocol.Enums;
using Cookie.API.Protocol.Network.Messages.Game.Basic;
using Cookie.API.Utils;
using Cookie.API.Utils.Enums;
using Cookie.Core;

namespace Cookie.Handlers.Game.Basic
{
    public class GameBasicHandlers
    {
        [MessageHandler(BasicLatencyStatsRequestMessage.ProtocolId)]
        private void BasicLatencyStatsRequestMessageHandler(DofusClient client, BasicLatencyStatsRequestMessage message)
        {
            var basicLatencyStatsMessage = new BasicLatencyStatsMessage(
                (ushort) client.Account.LatencyFrame.GetLatencyAvg(),
                (ushort) client.Account.LatencyFrame.GetSamplesCount(),
                (ushort) client.Account.LatencyFrame.GetSamplesMax());
            client.Send(basicLatencyStatsMessage);
        }

        [MessageHandler(BasicAckMessage.ProtocolId)]
        private void BasicAckMessageHandler(DofusClient client, BasicAckMessage message)
        {
            //
        }

        [MessageHandler(BasicTimeMessage.ProtocolId)]
        private void BasicTimeMessageHandler(DofusClient client, BasicTimeMessage message)
        {
            //
        }

        [MessageHandler(SequenceNumberRequestMessage.ProtocolId)]
        private void SequenceNumberRequestMessageHandler(DofusClient client, SequenceNumberRequestMessage message)
        {
            client.Account.LatencyFrame.Sequence++;
            var sequenceNumberMessage = new SequenceNumberMessage((ushort) client.Account.LatencyFrame.Sequence);
            client.Send(sequenceNumberMessage);
        }

        [MessageHandler(BasicNoOperationMessage.ProtocolId)]
        private void BasicNoOperationMessageHandler(DofusClient client, BasicNoOperationMessage message)
        {
            //
        }

        [MessageHandler(CurrentServerStatusUpdateMessage.ProtocolId)]
        private void CurrentServerStatusUpdateMessageHandler(DofusClient client,
            CurrentServerStatusUpdateMessage message)
        {
            Logger.Default.Log("Server Status: " + (ServerStatusEnum) message.Status);
        }

        [MessageHandler(TextInformationMessage.ProtocolId)]
        private void TextInformationMessageHandler(DofusClient client, TextInformationMessage message)
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
                    client.Account.Character.Status = CharacterStatus.None;
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
    }
}