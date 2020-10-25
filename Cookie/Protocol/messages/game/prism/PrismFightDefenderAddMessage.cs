using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightDefenderAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5895;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public short FightId = 0;
        public CharacterMinimalPlusLookInformations Defender;

        public PrismFightDefenderAddMessage()
        {
        }

        public PrismFightDefenderAddMessage(
            short subAreaId,
            short fightId,
            CharacterMinimalPlusLookInformations defender
        )
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            Defender = defender;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarShort(FightId);
            writer.WriteShort(Defender.TypeId);
            Defender.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            FightId = reader.ReadVarShort();
            var defenderTypeId = reader.ReadShort();
            Defender = new CharacterMinimalPlusLookInformations();
            Defender.Deserialize(reader);
        }
    }
}