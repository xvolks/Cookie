using Cookie.IO;
using Cookie.Protocol.Network.Types;
using System;

namespace Cookie.Protocol.Network.Messages
{
    public class PrismFightAttackerAddMessage : NetworkMessage
    {
        public const uint ProtocolId = 5893;
        public override uint MessageID { get { return ProtocolId; } }

        public short SubAreaId = 0;
        public short FightId = 0;
        public CharacterMinimalPlusLookInformations Attacker;

        public PrismFightAttackerAddMessage()
        {
        }

        public PrismFightAttackerAddMessage(
            short subAreaId,
            short fightId,
            CharacterMinimalPlusLookInformations attacker
        )
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            Attacker = attacker;
        }

        public override void Serialize(ICustomDataOutput writer)
        {
            writer.WriteVarShort(SubAreaId);
            writer.WriteVarShort(FightId);
            writer.WriteShort(Attacker.TypeId);
            Attacker.Serialize(writer);
        }

        public override void Deserialize(ICustomDataInput reader)
        {
            SubAreaId = reader.ReadVarShort();
            FightId = reader.ReadVarShort();
            var attackerTypeId = reader.ReadShort();
            Attacker = new CharacterMinimalPlusLookInformations();
            Attacker.Deserialize(reader);
        }
    }
}