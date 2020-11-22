using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameFightHumanReadyStateMessage : NetworkMessage
    {
        public const uint ProtocolId = 740;
        public override uint MessageID { get { return ProtocolId; } }

        public long CharacterId = 0;
        public bool IsReady = false;

        public GameFightHumanReadyStateMessage()
        {
        }

        public GameFightHumanReadyStateMessage(
            long characterId,
            bool isReady
        )
        {
            CharacterId = characterId;
            IsReady = isReady;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarLong(CharacterId);
            writer.WriteBoolean(IsReady);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            CharacterId = reader.ReadVarLong();
            IsReady = reader.ReadBoolean();
        }
    }
}