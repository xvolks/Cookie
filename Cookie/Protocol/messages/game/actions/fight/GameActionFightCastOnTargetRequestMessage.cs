using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class GameActionFightCastOnTargetRequestMessage : NetworkMessage
    {
        public const uint ProtocolId = 6330;
        public override uint MessageID { get { return ProtocolId; } }

        public short SpellId = 0;
        public double TargetId = 0;

        public GameActionFightCastOnTargetRequestMessage()
        {
        }

        public GameActionFightCastOnTargetRequestMessage(
            short spellId,
            double targetId
        )
        {
            SpellId = spellId;
            TargetId = targetId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SpellId);
            writer.WriteDouble(TargetId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SpellId = reader.ReadVarShort();
            TargetId = reader.ReadDouble();
        }
    }
}