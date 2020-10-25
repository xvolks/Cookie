using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StartupActionsObjetAttributionMessage : NetworkMessage
    {
        public const uint ProtocolId = 1303;
        public override uint MessageID { get { return ProtocolId; } }

        public int ActionId = 0;
        public long CharacterId = 0;

        public StartupActionsObjetAttributionMessage()
        {
        }

        public StartupActionsObjetAttributionMessage(
            int actionId,
            long characterId
        )
        {
            ActionId = actionId;
            CharacterId = characterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(ActionId);
            writer.WriteVarLong(CharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            ActionId = reader.ReadInt();
            CharacterId = reader.ReadVarLong();
        }
    }
}