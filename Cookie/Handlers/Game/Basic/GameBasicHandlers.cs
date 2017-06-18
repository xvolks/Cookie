using Cookie.Core;
using Cookie.Datacenter;
using Cookie.Gamedata.D2o;
using Cookie.Gamedata.I18n;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages.Game.Basic;

namespace Cookie.Handlers.Game.Basic
{
    public class GameBasicHandlers
    {
        [MessageHandler(BasicLatencyStatsRequestMessage.ProtocolId)]
        private void BasicLatencyStatsRequestMessageHandler(DofusClient Client, BasicLatencyStatsRequestMessage Message)
        {
            //
        }

        [MessageHandler(BasicAckMessage.ProtocolId)]
        private void BasicAckMessageHandler(DofusClient Client, BasicAckMessage Message)
        {
            //
        }

        [MessageHandler(BasicTimeMessage.ProtocolId)]
        private void BasicTimeMessageHandler(DofusClient Client, BasicTimeMessage Message)
        {
            //
        }

        [MessageHandler(SequenceNumberRequestMessage.ProtocolId)]
        private void SequenceNumberRequestMessageHandler(DofusClient Client, SequenceNumberRequestMessage Message)
        {
            //
        }

        [MessageHandler(BasicNoOperationMessage.ProtocolId)]
        private void BasicNoOperationMessageHandler(DofusClient Client, BasicNoOperationMessage Message)
        {
            //
        }

        [MessageHandler(CurrentServerStatusUpdateMessage.ProtocolId)]
        private void CurrentServerStatusUpdateMessageHandler(DofusClient Client, CurrentServerStatusUpdateMessage Message)
        {
            Client.Logger.Log("Server Status: " + (ServerStatusEnum)Message.Status);
        }

        [MessageHandler(TextInformationMessage.ProtocolId)]
        private void TextInformationMessageHandler(DofusClient Client, TextInformationMessage Message)
        {
            var data = ObjectDataManager.Instance.Get<InfoMessage>(Message.MsgType * 10000 + Message.MsgId);
            var text = I18nDataManager.Instance.ReadText(data.TextId);
            var parameters = Message.Parameters.ToArray();
            for (var i = 0; i < parameters.Length; i++)
            {
                var parameter = parameters[i];
                text = text.Replace("%" + (i + 1), parameter);
            }

            switch ((TextInformationTypeEnum)Message.MsgType)
            {
                case TextInformationTypeEnum.TEXT_INFORMATION_ERROR:
                    Client.Logger.Log(text, LogMessageType.Default);
                    Client.Account.Character.Status = Utils.Enums.CharacterStatus.None;
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE:
                    Client.Logger.Log(text, LogMessageType.Info);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_PVP:
                case TextInformationTypeEnum.TEXT_INFORMATION_FIGHT_LOG:
                    Client.Logger.Log(text, LogMessageType.FightLog);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_POPUP:
                case TextInformationTypeEnum.TEXT_LIVING_OBJECT:
                case TextInformationTypeEnum.TEXT_ENTITY_TALK:
                    Client.Logger.Log(text, LogMessageType.Default);
                    break;
                case TextInformationTypeEnum.TEXT_INFORMATION_FIGHT:
                    Client.Logger.Log(text, LogMessageType.FightLog);
                    break;
                default:
                    Client.Logger.Log((TextInformationTypeEnum)Message.MsgType + " | ID = " + Message.MsgId, LogMessageType.Arena);
                    for (var i = 0; i < Message.Parameters.Count; i++)
                    {
                        var t = Message.Parameters[i];
                        Client.Logger.Log("Parameter[" + i + "] " + t, LogMessageType.Arena);
                    }
                    break;
            }
        }
    }
}