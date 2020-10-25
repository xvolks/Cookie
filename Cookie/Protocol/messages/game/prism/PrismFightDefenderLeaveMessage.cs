using Cookie.IO;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightDefenderLeaveMessage : NetworkMessage
    {
        public const uint ProtocolId = 5892;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public short FightId = 0;
        public long FighterToRemoveId = 0;

        public PrismFightDefenderLeaveMessage()
        {
        }

        public PrismFightDefenderLeaveMessage(
            short subAreaId,
            short fightId,
            long fighterToRemoveId
        )
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            FighterToRemoveId = fighterToRemoveId;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarShort(FightId);
            writer.WriteVarLong(FighterToRemoveId);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            FightId = reader.ReadVarShort();
            FighterToRemoveId = reader.ReadVarLong();
        }
    }
}