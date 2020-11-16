using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class StartupActionsAllAttributionMessage : NetworkMessage
    {
        public const uint ProtocolId = 6537;
        public override uint MessageID { get { return ProtocolId; } }

        public long CharacterId = 0;

        public StartupActionsAllAttributionMessage()
        {
        }

        public StartupActionsAllAttributionMessage(
            long characterId
        )
        {
            CharacterId = characterId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(CharacterId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CharacterId = reader.ReadVarLong();
        }
    }
}