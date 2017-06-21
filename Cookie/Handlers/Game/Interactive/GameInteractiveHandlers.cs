using Cookie.Core;
using Cookie.Protocol.Network.Messages.Game.Interactive;
using Cookie.Utils.Enums;

namespace Cookie.Handlers.Game.Interactive
{
    public class GameInteractiveHandlers
    {
        [MessageHandler(InteractiveUseRequestMessage.ProtocolId)]
        private void InteractiveUseRequestMessageHandler(DofusClient client, InteractiveUseRequestMessage message)
        {
            //
        }

        [MessageHandler(InteractiveUsedMessage.ProtocolId)]
        private void InteractiveUsedMessageHandler(DofusClient client, InteractiveUsedMessage message)
        {
            //
        }

        [MessageHandler(InteractiveUseEndedMessage.ProtocolId)]
        private void InteractiveUseEndedMessageHandler(DofusClient client, InteractiveUseEndedMessage message)
        {
            client.Account.Character.Status = CharacterStatus.None;
        }

        [MessageHandler(StatedElementUpdatedMessage.ProtocolId)]
        private void StatedElementUpdatedMessageHandler(DofusClient client, StatedElementUpdatedMessage message)
        {
            client.Account.Character.MapData.UpdateStatedElement(message);
        }

        [MessageHandler(InteractiveElementUpdatedMessage.ProtocolId)]
        private void InteractiveElementUpdatedMessageHandler(DofusClient client, InteractiveElementUpdatedMessage message)
        {
            client.Account.Character.MapData.UpdateInteractiveElement(message);
        }

        [MessageHandler(InteractiveUseErrorMessage.ProtocolId)]
        private void InteractiveUseErrorMessageHandler(DofusClient client, InteractiveUseErrorMessage message)
        {
            client.Logger.Log($"Erreur sur {message.ElemId} skill {message.SkillInstanceUid}");
            client.Account.Character.Status = CharacterStatus.None;
        }
    }
}
