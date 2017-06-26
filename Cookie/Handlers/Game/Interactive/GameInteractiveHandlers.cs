using Cookie.API.Network;
using Cookie.API.Protocol.Network.Messages.Game.Interactive;
using Cookie.Core;
using Cookie.API.Utils.Enums;
using Cookie.API.Utils;

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
            client.Account.Character.Map.UpdateStatedElement(message);
        }

        [MessageHandler(InteractiveElementUpdatedMessage.ProtocolId)]
        private void InteractiveElementUpdatedMessageHandler(DofusClient client,
            InteractiveElementUpdatedMessage message)
        {
            client.Account.Character.Map.UpdateInteractive(message);

            if (client.Account.Character.GatherManager.Launched)
            {
                client.Account.Character.GatherManager.Gather();
                client.Account.Character.Status = CharacterStatus.Gathering;
            }
                
        }

        [MessageHandler(InteractiveUseErrorMessage.ProtocolId)]
        private void InteractiveUseErrorMessageHandler(DofusClient client, InteractiveUseErrorMessage message)
        {
            Logger.Default.Log($"Erreur sur {message.ElemId} skill {message.SkillInstanceUid}");
            //client.Account.Character.GatherManager.BannedElementId.Add((int) message.ElemId);
            client.Account.Character.Status = CharacterStatus.None;
        }

        [MessageHandler(InteractiveMapUpdateMessage.ProtocolId)]
        private void InteractiveMapUpdateMessageHandler(DofusClient client, InteractiveMapUpdateMessage message)
        {
            client.Account.Character.Map.UpdateInteractive(message);
        }

        [MessageHandler(StatedMapUpdateMessage.ProtocolId)]
        private void StatedMapUpdateMessageHandler(DofusClient client, StatedMapUpdateMessage message)
        {
            client.Account.Character.Map.UpdateStatedElement(message);
        }
    }
}