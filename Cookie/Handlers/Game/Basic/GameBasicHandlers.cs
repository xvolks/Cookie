using Cookie.Core;
using Cookie.Protocol.Enums;
using Cookie.Protocol.Network.Messages;

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
            if ((TextInformationTypeEnum)Message.MsgType == TextInformationTypeEnum.TEXT_INFORMATION_ERROR)
            {
                if (Message.MsgId == 89)
                {
                    Client.Logger.Log("Bienvenue sur DOFUS, dans le Monde des Douze ! Il est interdit de transmettre votre identifiant ou votre mot de passe.", LogMessageType.Default);
                    Client.Account.Character.Status = Utils.Enums.CharacterStatus.None;
                }

            }
            else if ((TextInformationTypeEnum)Message.MsgType == TextInformationTypeEnum.TEXT_INFORMATION_MESSAGE)
            {
                if (Message.MsgId == 193)
                    Client.Logger.Log("Précédente connexion sur ce compte: " + Message.Parameters[2] + "/" + Message.Parameters[1] + "/" + Message.Parameters[0] + " à " + Message.Parameters[3] + ":" + Message.Parameters[4], LogMessageType.Info);
                else if (Message.MsgId == 197)
                    Client.Logger.Log("Vous avez " + Message.Parameters[0] + " ami(s) en ligne.", LogMessageType.Info);
                else if (Message.MsgId == 25)
                    Client.Logger.Log("Votre familier vous fait la fête !", LogMessageType.Info);
                else if (Message.MsgId == 143)
                    Client.Logger.Log(Message.Parameters[0] + " (" + Message.Parameters[1] + ") est en ligne.", LogMessageType.Info);
                else
                {
                    Client.Logger.Log(((TextInformationTypeEnum)Message.MsgType).ToString() + " | ID = " + Message.MsgId, LogMessageType.Arena);
                    for (int i = 0; i < Message.Parameters.Count; i++)
                    {
                        string t = Message.Parameters[i];
                        Client.Logger.Log("Parameter[" + i + "] " + t, LogMessageType.Arena);
                    }
                }
            }
            else
            {
                Client.Logger.Log(((TextInformationTypeEnum)Message.MsgType).ToString() + " | ID = " + Message.MsgId, LogMessageType.Arena);
                for (int i = 0; i < Message.Parameters.Count; i++)
                {
                    string t = Message.Parameters[i];
                    Client.Logger.Log("Parameter[" + i + "] " + t, LogMessageType.Arena);
                }
            }
        }
    }
}
