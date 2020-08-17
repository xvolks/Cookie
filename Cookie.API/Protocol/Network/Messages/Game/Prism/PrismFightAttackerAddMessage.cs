using Cookie.API.Protocol.Network.Types.Game.Character;
using Cookie.API.Utils.IO;

namespace Cookie.API.Protocol.Network.Messages.Game.Prism
{
    public class PrismFightAttackerAddMessage : NetworkMessage
    {
        public const ushort ProtocolId = 5893;

        public PrismFightAttackerAddMessage(ushort subAreaId, ushort fightId,
            CharacterMinimalPlusLookInformations attacker)
        {
            SubAreaId = subAreaId;
            FightId = fightId;
            Attacker = attacker;
        }

        public PrismFightAttackerAddMessage()
        {
        }

        public override ushort MessageID => ProtocolId;
        public ushort SubAreaId { get; set; }
        public ushort FightId { get; set; }
        public CharacterMinimalPlusLookInformations Attacker { get; set; }

        public override void Serialize(IDataWriter writer)
        {
            writer.WriteVarUhShort(SubAreaId);
            writer.WriteVarUhShort(FightId);
            writer.WriteUShort(Attacker.TypeID);
            Attacker.Serialize(writer);
        }

        public override void Deserialize(IDataReader reader)
        {
            SubAreaId = reader.ReadVarUhShort();
            FightId = reader.ReadVarUhShort();
            Attacker = ProtocolTypeManager.GetInstance<CharacterMinimalPlusLookInformations>(reader.ReadUShort());
            Attacker.Deserialize(reader);
        }
    }
}