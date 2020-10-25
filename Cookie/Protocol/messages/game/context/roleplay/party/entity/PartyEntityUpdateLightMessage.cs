using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PartyEntityUpdateLightMessage : PartyUpdateLightMessage
    {
        public new const uint ProtocolId = 6781;
        public override uint MessageID { get { return ProtocolId; } }

        public byte IndexId = 0;

        public PartyEntityUpdateLightMessage(): base()
        {
        }

        public PartyEntityUpdateLightMessage(
            int partyId,
            long id_,
            int lifePoints,
            int maxLifePoints,
            short prospecting,
            byte regenRate,
            byte indexId
        ): base(
            partyId,
            id_,
            lifePoints,
            maxLifePoints,
            prospecting,
            regenRate
        )
        {
            IndexId = indexId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            base.Serialize(writer);
            writer.WriteByte(IndexId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            base.Deserialize(reader);
            IndexId = reader.ReadByte();
        }
    }
}