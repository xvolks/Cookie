using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class AreaFightModificatorUpdateMessage : NetworkMessage
    {
        public const uint ProtocolId = 6493;
        public override uint MessageID { get { return ProtocolId; } }

        public int SpellPairId = 0;

        public AreaFightModificatorUpdateMessage()
        {
        }

        public AreaFightModificatorUpdateMessage(
            int spellPairId
        )
        {
            SpellPairId = spellPairId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteInt(SpellPairId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellPairId = reader.ReadInt();
        }
    }
}